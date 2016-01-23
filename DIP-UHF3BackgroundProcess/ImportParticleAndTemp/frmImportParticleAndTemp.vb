Imports LinqDB.ConnectDB
Imports LinqDB.TABLE
Imports System.Data
Imports System.IO
Imports System.Globalization
Imports Engine.LogFile
Imports Engine.Common
Imports Engine
Public Class frmImportParticleAndTemp

    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.WindowState = FormWindowState.Minimized
        Timer1.Start()
    End Sub

#Region "HuminityTemp"
    Function SaveHumidity() As String
        Dim retStatus As String = ""
        Try
            Dim TempPath As String = Application.StartupPath & "\temperature"
            If Directory.Exists(TempPath) = False Then
                retStatus = "ไม่พบไฟล์"
                Return retStatus
            End If
            Dim di As New IO.DirectoryInfo(TempPath)
            Dim diar1 As IO.FileInfo() = di.GetFiles()
            Dim dra As IO.FileInfo

            For Each dra In diar1
                Dim device As String = "1"
                If dra.Name.ToLower = "6.xls" Then
                    device = "6"
                End If

                Dim dt As New DataTable
                dt = ReadTextHumidityTemp(dra.FullName)
                If dt.Rows.Count > 0 Then

                    For i As Integer = 0 To dt.Rows.Count - 1
                        Dim tempdr As DataRow = dt.Rows(i)

                        Dim lnq As New TsHumidityTempDataLinqDB
                        lnq.ChkDataByMS_HUMIDITY_TEMP_ID(device, Nothing)

                        lnq.MS_HUMIDITY_TEMP_ID = device
                        lnq.RECORD_DATETIME = tempdr("RECORD_DATETIME")
                        lnq.HUMIDITY_VALUE = tempdr("HUMIDITY_VALUE")
                        lnq.TEMP_VALUE = tempdr("TEMP_VALUE")
                        lnq.TEMP_UNIT = tempdr("TEMP_UNIT")

                        Dim ret As Boolean = False
                        Dim trans As New LinqDB.ConnectDB.TransactionDB(LinqDB.ConnectDB.SelectDB.DIPRFID)
                        If lnq.ID > 0 Then
                            ret = lnq.UpdateByPK("ImportParticleAndTemp.SaveHumidity", trans.Trans)
                        Else
                            ret = lnq.InsertData("ImportParticleAndTemp.SaveHumidity", trans.Trans)
                        End If

                        If ret = True Then
                            ret = InsertHumidityTempHistory(lnq, trans)
                            If ret = True Then
                                trans.CommitTransaction()
                            Else
                                trans.RollbackTransaction()
                            End If
                        Else
                            trans.RollbackTransaction()
                            Return "ไม่สามารถบันทึกข้อมูลได้"
                        End If
                        lnq = Nothing

                        Threading.Thread.Sleep(1000)

                    Next

                    'Dim index As Integer = 0
                    'Dim Generator As System.Random = New System.Random()
                    'Dim strtime As String = DateTime.Now.ToString("HH:mm", New CultureInfo("th-TH"))
                    'If strtime < "12.00" Then
                    '    index = Generator.Next(0, (dt.Rows.Count / 2) - 1)
                    'Else
                    '    index = Generator.Next(((dt.Rows.Count / 2) - 1), dt.Rows.Count - 1)
                    'End If
                    
                End If
            Next


        Catch ex As Exception
            Return ex.ToString
        End Try
        Return retStatus
    End Function

    Function InsertHumidityTempHistory(DataLnq As TsHumidityTempDataLinqDB, trans As LinqDB.ConnectDB.TransactionDB) As Boolean
        Dim ret As Boolean = False
        Try
            Dim lnq As New TsHumidityTempHistoryLinqDB
            lnq.MS_HUMIDITY_TEMP_ID = DataLnq.MS_HUMIDITY_TEMP_ID
            lnq.RECORD_DATETIME = DataLnq.RECORD_DATETIME
            lnq.HUMIDITY_VALUE = DataLnq.HUMIDITY_VALUE
            lnq.TEMP_VALUE = DataLnq.TEMP_VALUE
            lnq.TEMP_UNIT = DataLnq.TEMP_UNIT

            ret = lnq.InsertData("ImportParticleAndTemp.InsertHumidityTempHistory", trans.Trans)
            If ret = False Then
                LogFile.LogENG.SaveErrLog("ImportParticleAndTemp.InsertHumidityTempHistory", lnq.ErrorMessage)
            End If
            lnq = Nothing
        Catch ex As Exception
            ret = False
            LogFile.LogENG.SaveErrLog("ImportParticleAndTemp.InsertHumidityTempHistory", "Exception " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Return ret
    End Function

    Function ReadTextHumidityTemp(TextFile As String) As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("MsHumidityTempID")
        dt.Columns.Add("RECORD_DATETIME")
        dt.Columns.Add("HUMIDITY_VALUE")
        dt.Columns.Add("TEMP_VALUE")
        dt.Columns.Add("TEMP_UNIT")

        Dim dr As DataRow
        Dim Stream As New StreamReader(TextFile, System.Text.UnicodeEncoding.Default)
        Dim i As Long = 0
        While Stream.Peek <> -1
            Dim str As String = Stream.ReadLine
            If str.Trim <> "" Then
                Try
                    If i = 0 Then   'First row is a Header Row
                        i += 1
                        Continue While
                    End If

                    Dim strFld As String() = Split(str, Chr(9))   'TAB
                    dr = dt.NewRow
                    dr("MsHumidityTempID") = 0
                    dr("RECORD_DATETIME") = cStrToDateTime3(strFld(1).Trim, strFld(2).Trim)
                    dr("HUMIDITY_VALUE") = Convert.ToDouble(strFld(3).Trim)
                    dr("TEMP_VALUE") = Convert.ToDouble(strFld(5).Trim)
                    dr("TEMP_UNIT") = strFld(6).Trim.Replace("DEGREE ", "")
                    dt.Rows.Add(dr)
                Catch ex As Exception

                End Try
            End If
            i += 1
        End While
        Stream.Close()
        Stream = Nothing

        Return dt
    End Function
#End Region

    Function cStrToDateTime3(ByVal StrDate As String, ByVal StrTime As String) As DateTime
        'Convert วันที่จาก yyyy/MM/dd HH:mm:ss เป็น DateTime
        Dim ret As New Date(1, 1, 1)
        If StrDate.Trim <> "" Then
            Dim vDate() As String = Split(StrDate, "/")
            If StrTime.Trim <> "" Then
                Dim vTime() As String = Split(StrTime, ":")
                ret = New Date(vDate(0), vDate(1), vDate(2), vTime(0), vTime(1), vTime(2))
            Else
                ret = New Date(vDate(0), vDate(1), vDate(2))
            End If
        End If
        Return ret
    End Function

#Region "Particle"

    Function SavePaticle() As String
        Dim retStatus As String = ""
        Try
            For i As Integer = 1 To 3
                Dim path As String = Application.StartupPath & "\particle"
                If Directory.Exists(path) = False Then
                    retStatus = "ไม่พบไฟล์"
                    Return retStatus
                End If
                Dim di As New IO.DirectoryInfo(path)
                Dim diar1 As IO.FileInfo() = di.GetFiles()
                Dim dra As IO.FileInfo

                Dim Generator As System.Random = New System.Random()
                Dim index As Integer = Generator.Next(0, diar1.Count - 1)
                dra = diar1(index)

                Dim eng As New Engine.ParticleENG
                eng.ReadTextFileData("SYSTEM", dra.FullName)
                If eng.HaveData = True Then
                    Dim fInfo As New FileInfo(dra.FullName)
                    Dim numBytes As Long = fInfo.Length

                    Dim fStream As New FileStream(dra.FullName, FileMode.Open, FileAccess.Read)
                    Dim br As New BinaryReader(fStream)
                    Dim byteData As Byte() = br.ReadBytes(CInt(numBytes))

                    Dim filename As String = dra.FullName
                    eng.MS_PARTICLE_COUNTER_DEVICE_ID = i
                    eng.IMPORT_TIME = DateTime.Now
                    eng.LOG_FILE_NAME = filename
                    eng.LOG_FILE_BYTE = byteData

                    Dim trans As New LinqDB.ConnectDB.TransactionDB(LinqDB.ConnectDB.SelectDB.DIPRFID)
                    Dim ret = Engine.ParticleENG.SaveParticleCounterData("SYSTEM", eng, trans)
                    If ret = True Then
                        trans.CommitTransaction()
                    Else
                        trans.RollbackTransaction()
                        Return "ไม่สามารถบันทึกข้อมูลได้"
                    End If
                End If
            Next

        Catch ex As Exception
            Return ex.ToString
        End Try
        Return retStatus
    End Function

#End Region


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        Dim retH As String = SaveHumidity()
        If retH <> "" Then
            MessageBox.Show(retH)
            Exit Sub
        End If

        Dim retP As String = SavePaticle()
        If retP <> "" Then
            MessageBox.Show(retP)
            Exit Sub
        End If
        Timer1.Enabled = True
    End Sub
End Class
