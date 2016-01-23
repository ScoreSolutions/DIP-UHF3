Imports LinqDB.TABLE
Imports LinqDB.ConnectDB
Public Class FaultMngENG

#Region "Fault Management Content 1"


    Private Shared Function GetQueryServerInfo(FaultServerIP) As String
        Dim sql As String = "Select r.ServerIP, r.ServerName,r.online_status, r.today_alailable, "
        sql += " convert(bigint,isnull(cpu.CPUPercent,0)) CPUPercent, convert(bigint,isnull(ram.RAMPercent,0)) RAMPercent, isnull(d.DiskPercent,0) DiskPercent,"
        sql += " r.LocationServer, r.OS"
        sql += " ,isnull(configcpu.AlarmMinorValue,0) as AlarmMinorValueCPU"
        sql += " ,isnull(configcpu.AlarmMajorValue,0) as AlarmMajorValueCPU"
        sql += " ,isnull(configcpu.AlarmCriticalValue,0) as AlarmCriticalValueCPU"
        sql += " ,isnull(configdisk.AlarmMinorValue,0) as AlarmMinorValueDisk"
        sql += " ,isnull(configdisk.AlarmMajorValue,0) as AlarmMajorValueDisk"
        sql += " ,isnull(configdisk.AlarmCriticalValue,0) as AlarmCriticalValueDisk"
        sql += " ,isnull(configram.AlarmMinorValue,0) as AlarmMinorValueRAM"
        sql += " ,isnull(configram.AlarmMajorValue,0) as AlarmMajorValueRAM"
        sql += " ,isnull(configram.AlarmCriticalValue,0) as AlarmCriticalValueRAM	"
        sql += " ,60 as AlarmMinorValueAvb"
        sql += " ,80 as AlarmMajorValueAvb"
        sql += " ,100 as AlarmCriticalValueAvb	"
        sql += " from  TB_REGISTER R"
        sql += " left join TB_CPU_INFO cpu on r.ServerIP=cpu.ServerIP"
        sql += " left join TB_RAM_INFO ram on r.ServerIP=ram.ServerIP"
        ' sql += " left join (select ServerIP, convert(bigint,(sum(TotalSizeGB-FreeSpaceGB)*100)/sum(TotalSizeGB)) DiskPercent"
        sql += " left join (select ServerIP, convert(bigint,(sum(TotalSizeGB-FreeSpaceGB)*100)/ case when sum(TotalSizeGB) >  0 then sum(TotalSizeGB)  else 1 end) DiskPercent"
        sql += "             from TB_DRIVE_INFO"
        sql += " 			group by ServerIP"
        sql += " 			) d on d.ServerIP=r.ServerIP"
        sql += " left join  ("
        sql += "    Select ccpu.ServerIP"
        sql += "    , ccpu.AlarmMinorValue"
        sql += "    ,ccpu.AlarmMajorValue"
        sql += "    ,ccpu.AlarmCriticalValue "
        sql += "    ,'CPU' device"
        sql += "    from CF_CONFIG_CPU ccpu"
        sql += " ) as configcpu on configcpu.ServerIP = R.ServerIP"
        sql += " left join ("
        sql += "    Select cdhd.ServerIP"
        sql += "    ,table1.AlarmMinorValue"
        sql += "    ,table1.AlarmMajorValue"
        sql += "    ,table1.AlarmCriticalValue"
        sql += "    ,'Disk' device"
        sql += " from CF_CONFIG_DRIVE cdhd"
        sql += " inner join("
        sql += "        Select cddt.cf_config_drive_id"
        ' sql += "        ,sum(cddt.AlarmMinorValue)/ count(cddt.cf_config_drive_id) AlarmMinorValue"
        ' sql += "        ,sum(cddt.AlarmMajorValue) / count(cddt.cf_config_drive_id) AlarmMajorValue"
        ' sql += "        ,sum(cddt.AlarmCriticalValue ) / count(cddt.cf_config_drive_id) AlarmCriticalValue"
        sql += "        ,sum(cddt.AlarmMinorValue)/  case when count(cddt.cf_config_drive_id) >  0 then count(cddt.cf_config_drive_id)  else 1 end AlarmMinorValue"
        sql += "        ,sum(cddt.AlarmMajorValue) / case when count(cddt.cf_config_drive_id) >  0 then count(cddt.cf_config_drive_id)  else 1 end AlarmMajorValue"
        sql += "        ,sum(cddt.AlarmCriticalValue ) / case when  count(cddt.cf_config_drive_id) >  0 then  count(cddt.cf_config_drive_id)  else 1 end AlarmCriticalValue"
        sql += "        from CF_CONFIG_DRIVE_DETAIL cddt"
        sql += "        group by cddt.cf_config_drive_id"
        sql += "            ) as table1 on cdhd.id =table1.cf_config_drive_id"
        sql += " ) as configdisk on configdisk.ServerIP = R.ServerIP"
        sql += " left join ("
        sql += "    Select cram.ServerIP"
        sql += "    ,cram.AlarmMinorValue"
        sql += "    ,cram.AlarmMajorValue"
        sql += "    ,cram.AlarmCriticalValue "
        sql += "    ,'RAM' device"
        sql += " from CF_CONFIG_RAM cram"
        sql += " ) as configram on configram.ServerIP = R.ServerIP"
        sql += " where R.ServerIP in (" & FaultServerIP & ")"
        Return sql
    End Function
    Public Shared Function GetSignageServerInfo() As DataTable
        Dim ret As New DataTable
        Try
            Dim FaultServerIP As String = GlobalFunction.GetSysConfing("ServerIPList")
            If FaultServerIP.Trim <> "" Then
                Dim sql As String = GetQueryServerInfo(FaultServerIP)
                ret = FaultMngSqlDB.ExecuteTable(sql)
            End If
        Catch ex As Exception
            ret = New DataTable
            LogFile.LogENG.SaveErrLog("FaultMngEng.GetSignageServerInfo", ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Return ret
    End Function

    Public Shared Function GetSignageSpeedwayInfo() As DataTable
        Dim ret As New DataTable
        Try
            Dim FaultServerIP As String = GlobalFunction.GetSysConfing("SpeedwayIPList")
            If FaultServerIP.Trim <> "" Then
                Dim sql As String = GetQueryServerInfo(FaultServerIP)
                ret = FaultMngSqlDB.ExecuteTable(sql)
                If ret.Rows.Count > 0 Then
                    ret.Columns.Add("floor_name")


                    Dim spDt As DataTable = GetSpeedwayFloorList()
                    For i As Integer = 0 To ret.Rows.Count - 1
                        spDt.DefaultView.RowFilter = "ip_address='" & ret.Rows(i)("ServerIP") & "'"
                        If spDt.DefaultView.Count > 0 Then
                            ret.Rows(i)("floor_name") = spDt.DefaultView(0)("floor_name")
                        End If
                        spDt.DefaultView.RowFilter = ""
                    Next
                    spDt.Dispose()
                End If
            End If
        Catch ex As Exception
            ret = New DataTable
            LogFile.LogENG.SaveErrLog("FaultMngEng.GetSignageSpeedwayInfo", ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Return ret
    End Function

    Public Shared Function GetSignageTVInfo() As DataTable
        Dim ret As New DataTable
        Try
            Dim FaultServerIP As String = GlobalFunction.GetSysConfing("LedTvIPList")
            If FaultServerIP.Trim <> "" Then
                Dim sql As String = GetQueryServerInfo(FaultServerIP)
                ret = FaultMngSqlDB.ExecuteTable(sql)

                If ret.Rows.Count > 0 Then
                    ret.Columns.Add("floor_name")

                    Dim tvDt As DataTable = GetLedTvFloorList()
                    For i As Integer = 0 To ret.Rows.Count - 1
                        tvDt.DefaultView.RowFilter = "ip_address='" & ret.Rows(i)("ServerIP") & "'"
                        If tvDt.DefaultView.Count > 0 Then
                            ret.Rows(i)("floor_name") = tvDt.DefaultView(0)("floor_name")
                        End If
                        tvDt.DefaultView.RowFilter = ""
                    Next
                    tvDt.Dispose()
                End If
            End If
        Catch ex As Exception
            ret = New DataTable
            LogFile.LogENG.SaveErrLog("FaultMngEng.GetSignageTVInfo", ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Return ret
    End Function

    Private Shared Function GetLedTvFloorList() As DataTable
        Dim ret As New DataTable
        Try
            Dim sql As String = "select tv.ip_address, fl.floor_name"
            sql += " from MS_LED_TV tv"
            sql += " inner join ms_floor fl on fl.id=tv.ms_floor_id"
            ret = DIPRFIDSqlDB.ExecuteTable(sql)
        Catch ex As Exception
            ret = New DataTable
        End Try
        Return ret
    End Function

    Private Shared Function GetSpeedwayFloorList() As DataTable
        Dim ret As New DataTable
        Try
            Dim sql As String = "select sp.ip_address, fl.floor_name"
            sql += " from ms_speedway sp"
            sql += " inner join ms_room r on r.id=sp.ms_room_id"
            sql += " inner join ms_floor fl on fl.id=r.ms_floor_id"
            ret = DIPRFIDSqlDB.ExecuteTable(sql)
        Catch ex As Exception
            ret = New DataTable
        End Try
        Return ret
    End Function
#End Region

#Region "Fault Management Content 2 Top 5 Utilization"
    Public Shared Function TopDeviceAvailability(Optional TopLevel As Int16 = 5) As DataTable
        Dim ret As New DataTable
        Try
            Dim sql As String = "select top " & TopLevel & " r.ServerName, r.ServerIP, r.OS, r.LocationServer, r.today_alailable"
            sql += " from TB_REGISTER r"
            sql += " order by r.today_alailable desc"
            ret = FaultMngSqlDB.ExecuteTable(sql)
        Catch ex As Exception
            ret = New DataTable
            LogFile.LogENG.SaveErrLog("FaultMngEng.Top5DeviceAvailability", ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Return ret
    End Function

    Public Shared Function TopCPUUtilication(Optional TopLevel As Integer = 5) As DataTable
        Dim ret As New DataTable
        Try
            Dim sql As String = "select top " & TopLevel & " r.ServerName, r.ServerIP, r.OS, r.LocationServer, convert(bigint,cpu.CPUPercent) CPUPercent"
            sql += " from TB_REGISTER r"
            sql += " inner join TB_CPU_INFO cpu on cpu.ServerIP=r.ServerIP"
            sql += " order by cpu.CPUPercent desc "
            ret = FaultMngSqlDB.ExecuteTable(sql)
        Catch ex As Exception
            ret = New DataTable
            LogFile.LogENG.SaveErrLog("FaultMngEng.TopCPUUtilication", ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Return ret
    End Function

    Public Shared Function TopRAMUtilication(Optional TopLevel As Integer = 5) As DataTable
        Dim ret As New DataTable
        Try
            Dim sql As String = "select top " & TopLevel & " r.ServerName, r.ServerIP, r.OS, r.LocationServer, convert(bigint, ram.RAMPercent) RAMPercent "
            sql += " from TB_REGISTER r"
            sql += " inner join TB_RAM_INFO ram on ram.ServerIP=r.ServerIP"
            sql += " order by ram.RAMPercent desc "
            ret = FaultMngSqlDB.ExecuteTable(sql)
        Catch ex As Exception
            ret = New DataTable
            LogFile.LogENG.SaveErrLog("FaultMngEng.TopRAMUtilication", ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Return ret
    End Function

    Public Shared Function TopDiskUtilication(Optional TopLevel As Integer = 5) As DataTable
        Dim ret As New DataTable
        Try
            Dim sql As String = "select top " & TopLevel & " r.ServerName, r.ServerIP, r.OS, r.LocationServer, "
            sql += " convert(bigint,(sum(TotalSizeGB-FreeSpaceGB)*100)/case when sum(TotalSizeGB) <> 0 then sum(TotalSizeGB) else 1 end  ) DiskPercent"
            sql += " from TB_REGISTER r"
            sql += " inner join TB_DRIVE_INFO d on d.ServerIP=r.ServerIP"
            sql += " group by r.ServerName,r.ServerIP,r.OS,r.LocationServer"
            sql += " order by DiskPercent desc "
            ret = FaultMngSqlDB.ExecuteTable(sql)
        Catch ex As Exception
            ret = New DataTable
            LogFile.LogENG.SaveErrLog("FaultMngEng.TopDiskUtilication", ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Return ret
    End Function
#End Region



    Public Shared Sub UpdateRegisterDeviceDataToFaultMng()
        Try
            'ข้อมูลการ Register ใน Fault Management
            Dim sql As String = "select id, ServerIP, ServerName, MacAddress, isnull(UpdatedDate,CreatedDate) last_update_date "
            sql += " from TB_REGISTER "
            Dim fDt As DataTable = FaultMngSqlDB.ExecuteTable(sql)


            'ข้อมูล Speedway
            Dim spLnq As New MsSpeedwayLinqDB
            Dim spDT As DataTable = spLnq.GetDataList("active_status='Y'", "", Nothing)
            If spDT.Rows.Count > 0 Then
                For Each spDr As DataRow In spDT.Rows
                    spLnq = New MsSpeedwayLinqDB
                    spLnq.GetDataByPK(spDr("id"), Nothing)
                    If spLnq.ID > 0 Then
                        Dim LastUpdateDate As DateTime = New DateTime(1, 1, 1)
                        If spLnq.UPDATED_DATE.Value.Year <> 1 Then
                            LastUpdateDate = spLnq.UPDATED_DATE
                        Else
                            LastUpdateDate = spLnq.CREATED_DATE
                        End If

                        Dim flSql As String = "select fl.floor_name "
                        flSql += " from ms_floor fl"
                        flSql += " inner join ms_room r on fl.id=r.ms_floor_id"
                        flSql += " where r.id='" & spLnq.MS_ROOM_ID & "'"

                        Dim FloorName As String = spLnq.INSTALL_POSITION
                        Dim flDt As DataTable = GlobalFunction.GetDatatable(flSql)
                        If flDt.Rows.Count > 0 Then
                            If Convert.IsDBNull(flDt.Rows(0)("floor_name")) = False Then
                                FloorName = flDt.Rows(0)("floor_name")
                            End If
                        End If
                        SaveRegisterData(fDt, spLnq.IP_ADDRESS, spLnq.MAC_ADDRESS.Replace(":", ""), spLnq.SERIAL_NO, FloorName, "Speedway", "CentOS", spLnq.ACTIVE_STATUS, LastUpdateDate)
                    End If
                Next
            End If
            spDT.Dispose()
            spLnq = Nothing


            'ข้อมูล LED TV
            Dim ledLnq As New MsLedTvLinqDB
            Dim ledDT As DataTable = ledLnq.GetDataList("active_status='Y'", "", Nothing)
            If ledDT.Rows.Count > 0 Then
                For Each ledDR As DataRow In ledDT.Rows
                    ledLnq = New MsLedTvLinqDB
                    ledLnq.GetDataByPK(ledDR("id"), Nothing)
                    If ledLnq.ID > 0 Then
                        Dim LastUpdateDate As DateTime = New DateTime(1, 1, 1)
                        If ledLnq.UPDATED_DATE.Value.Year <> 1 Then
                            LastUpdateDate = ledLnq.UPDATED_DATE
                        Else
                            LastUpdateDate = ledLnq.CREATED_DATE
                        End If

                        Dim fLnq As New MsFloorLinqDB
                        fLnq.GetDataByPK(ledLnq.MS_FLOOR_ID, Nothing)
                        SaveRegisterData(fDt, ledLnq.IP_ADDRESS, ledLnq.MAC_ADDRESS, ledLnq.TV_NAME, fLnq.FLOOR_NAME, "LED TV", "Android", ledLnq.ACTIVE_STATUS, LastUpdateDate)
                        fLnq = Nothing
                    End If
                Next
            End If
            ledDT.Dispose()
            ledLnq = Nothing

            ''ข้อมูล RFID Midrange Reader
            'Dim mLnq As New MsMidRangeReaderLinqDB
            'Dim mDt As DataTable = mLnq.GetDataList("active_status='Y'", "", Nothing)
            'If mDt.Rows.Count > 0 Then
            '    For Each mDr As DataRow In mDt.Rows
            '        mLnq = New MsMidRangeReaderLinqDB
            '        mLnq.GetDataByPK(mDr("id"), Nothing)
            '        If mLnq.ID > 0 Then
            '            Dim LastUpdateDate As DateTime = New DateTime(1, 1, 1)
            '            If mLnq.UPDATED_DATE.Value.Year <> 1 Then
            '                LastUpdateDate = mLnq.UPDATED_DATE
            '            Else
            '                LastUpdateDate = mLnq.CREATED_DATE
            '            End If
            '            SaveRegisterData(fDt, mLnq.IP_ADDRESS, mLnq.MAC_ADDRESS, mLnq.SERIAL_NO, mLnq.INSTALL_POSITION, "MID RANGE READER", "LINUX", mLnq.ACTIVE_STATUS, LastUpdateDate)
            '        End If
            '    Next
            'End If
            'mDt.Dispose()
            'mLnq = Nothing
        Catch ex As Exception
            LogFile.LogENG.SaveErrLog("FaultMngEng.UpdateRegisterDeviceDataToFaultMng", ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub


    Private Shared Sub SaveRegisterData(fDt As DataTable, IpAddress As String, MacAddress As String, DeviceName As String, InstallPosition As String, DeviceType As String, OS As String, ActiveStatus As String, LastUpdateDate As DateTime)
        Dim frID As Long = 0
        Dim frLastUpdateDate As New DateTime(1, 1, 1)

        fDt.DefaultView.RowFilter = "ServerIP = '" & IpAddress & "'"
        If fDt.DefaultView.Count = 0 Then
            fDt.DefaultView.RowFilter = ""
            fDt.DefaultView.RowFilter = "ServerName='" & DeviceName & "'"

            If fDt.DefaultView.Count = 0 Then
                fDt.DefaultView.RowFilter = ""
                fDt.DefaultView.RowFilter = "MacAddress='" & MacAddress & "'"
            End If
        End If

        If fDt.DefaultView.Count > 0 Then
            frID = fDt.DefaultView(0)("id")
            frLastUpdateDate = Convert.ToDateTime(fDt.DefaultView(0)("last_update_date"))

            If LastUpdateDate > frLastUpdateDate Then
                Dim iSql As String = "update tb_register "
                iSql += " set UpdatedDate=getdate(), UpdatedBy='FaultMngEng.UpdateRegisterDeviceDataToFaultMng' "
                iSql += " ,ServerIP='" & IpAddress & "'"
                iSql += " ,MacAddress='" & MacAddress & "'"
                iSql += " ,ServerName='" & DeviceName & "'"
                iSql += " ,OS='" & OS & "'"
                iSql += " ,LocationServer='" & InstallPosition & "'"
                iSql += " ,Active_Status='" & ActiveStatus & "'"
                iSql += " where id = '" & frID & "'"

                Dim trans As New TransactionDB(SelectDB.FaultMng)
                If FaultMngSqlDB.ExecuteNonQuery(iSql, trans.Trans) = True Then
                    trans.CommitTransaction()
                Else
                    trans.RollbackTransaction()
                    LogFile.LogENG.SaveErrLog("FaultMngEng.UpdateRegisterDeviceDataToFaultMng", FaultMngSqlDB.ErrorMessage)
                End If
            End If
        Else
            Dim iSql As String = " insert into tb_register(id, CreatedDate,CreatedBy,ServerIP, MacAddress, ServerName, OS, e_mail,fname,lname,"
            iSql += " system_type, LocationServer,Active_Status,group_id)"
            iSql += " values((select isnull(max(id),0)+1 from TB_REGISTER), getdate(),'FaultMngEng.UpdateRegisterDeviceDataToFaultMng',"
            iSql += " '" & IpAddress & "','" & MacAddress & "','" & DeviceName & "','" & OS & "','#','#','#',"
            iSql += " '" & DeviceType & "','" & InstallPosition & "','" & ActiveStatus & "',0)"

            Dim trans As New TransactionDB(SelectDB.FaultMng)
            If FaultMngSqlDB.ExecuteNonQuery(iSql, trans.Trans) = True Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
                LogFile.LogENG.SaveErrLog("FaultMngEng.UpdateRegisterDeviceDataToFaultMng", FaultMngSqlDB.ErrorMessage)
            End If
        End If
        fDt.DefaultView.RowFilter = ""
    End Sub
End Class
