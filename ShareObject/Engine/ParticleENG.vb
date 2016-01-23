Imports System
Imports System.IO
Imports LinqDB.TABLE
Imports LinqDB.ConnectDB

Public Class ParticleENG

    Dim _HaveData As Boolean = False
    Dim _MS_PARTICLE_COUNTER_DEVICE_ID As Long = 0
    Dim _IMPORT_TIME As DateTime = New DateTime(1, 1, 1)
    Dim _LOG_FILE_NAME As String = ""
    Dim _LOG_FILE_BYTE() As Byte
    Dim _COUNTER_MODE As String = ""
    Dim _CHANNEL_0_3 As Long = 0
    Dim _CHANNEL_0_5 As Long = 0
    Dim _CHANNEL_1_0 As Long = 0
    Dim _CHANNEL_2_5 As Long = 0
    Dim _CHANNEL_5_0 As Long = 0
    Dim _CHANNEL_10_0 As Long = 0
    Dim _AIR_TEMPERATURE As Double = 0
    Dim _RELATIVE_HUMIDITY As Double = 0
    Dim _DEWPOINT_TEMPERATURE As Double = 0
    Dim _WET_BULB_TEMPERATURE As Double = 0

    Public Property HaveData() As Boolean
        Get
            Return _HaveData
        End Get
        Set(value As Boolean)
            _HaveData = value
        End Set
    End Property

    Public Property MS_PARTICLE_COUNTER_DEVICE_ID() As Long
        Get
            Return _MS_PARTICLE_COUNTER_DEVICE_ID
        End Get
        Set(ByVal value As Long)
            _MS_PARTICLE_COUNTER_DEVICE_ID = value
        End Set
    End Property

    Public Property IMPORT_TIME() As DateTime
        Get
            Return _IMPORT_TIME
        End Get
        Set(ByVal value As DateTime)
            _IMPORT_TIME = value
        End Set
    End Property

    Public Property LOG_FILE_NAME() As String
        Get
            Return _LOG_FILE_NAME
        End Get
        Set(ByVal value As String)
            _LOG_FILE_NAME = value
        End Set
    End Property

    Public Property LOG_FILE_BYTE() As Byte()
        Get
            Return _LOG_FILE_BYTE
        End Get
        Set(ByVal value As Byte())
            _LOG_FILE_BYTE = value
        End Set
    End Property

    Public Property COUNTER_MODE() As String
        Get
            Return _COUNTER_MODE
        End Get
        Set(ByVal value As String)
            _COUNTER_MODE = value
        End Set
    End Property

    Public Property CHANNEL_0_3() As Long
        Get
            Return _CHANNEL_0_3
        End Get
        Set(ByVal value As Long)
            _CHANNEL_0_3 = value
        End Set
    End Property

    Public Property CHANNEL_0_5() As Long
        Get
            Return _CHANNEL_0_5
        End Get
        Set(ByVal value As Long)
            _CHANNEL_0_5 = value
        End Set
    End Property

    Public Property CHANNEL_1_0() As Long
        Get
            Return _CHANNEL_1_0
        End Get
        Set(ByVal value As Long)
            _CHANNEL_1_0 = value
        End Set
    End Property

    Public Property CHANNEL_2_5() As Long
        Get
            Return _CHANNEL_2_5
        End Get
        Set(ByVal value As Long)
            _CHANNEL_2_5 = value
        End Set
    End Property

    Public Property CHANNEL_5_0() As Long
        Get
            Return _CHANNEL_5_0
        End Get
        Set(ByVal value As Long)
            _CHANNEL_5_0 = value
        End Set
    End Property

    Public Property CHANNEL_10_0() As Long
        Get
            Return _CHANNEL_10_0
        End Get
        Set(ByVal value As Long)
            _CHANNEL_10_0 = value
        End Set
    End Property

    Public Property AIR_TEMPERATURE() As Double
        Get
            Return _AIR_TEMPERATURE
        End Get
        Set(ByVal value As Double)
            _AIR_TEMPERATURE = value
        End Set
    End Property

    Public Property RELATIVE_HUMIDITY() As Double
        Get
            Return _RELATIVE_HUMIDITY
        End Get
        Set(ByVal value As Double)
            _RELATIVE_HUMIDITY = value
        End Set
    End Property

    Public Property DEWPOINT_TEMPERATURE() As Double
        Get
            Return _DEWPOINT_TEMPERATURE
        End Get
        Set(ByVal value As Double)
            _DEWPOINT_TEMPERATURE = value
        End Set
    End Property

    Public Property WET_BULB_TEMPERATURE() As Double
        Get
            Return _WET_BULB_TEMPERATURE
        End Get
        Set(ByVal value As Double)
            _WET_BULB_TEMPERATURE = value
        End Set
    End Property

    Public Function ReadTextFileData(LoginUsername As String, PathTextFile As String) As ParticleENG
        Try
            If File.Exists(PathTextFile) = True Then
                Dim fInfo As New FileInfo(PathTextFile)

                Dim FileContent() As String = Split(File.ReadAllText(PathTextFile), Chr(13))
                Dim LineNo As Integer = 1

                _HaveData = True
                '_MS_PARTICLE_COUNTER_DEVICE_ID = MsParticleCounterDeviceID
                _IMPORT_TIME = DateTime.Now
                _LOG_FILE_NAME = fInfo.Name
                _LOG_FILE_BYTE = File.ReadAllBytes(PathTextFile)

                For Each str As String In FileContent
                    If LineNo = 1 Then
                        _COUNTER_MODE = str.Trim
                    ElseIf LineNo = 2 Then
                        Dim lne2() As String = Split(str, ":")
                        If lne2.Length = 2 Then
                            _CHANNEL_0_3 = lne2(1).Trim
                        End If
                    ElseIf LineNo = 3 Then
                        Dim lne3() As String = Split(str, ":")
                        If lne3.Length = 2 Then
                            _CHANNEL_0_5 = lne3(1).Trim
                        End If

                    ElseIf LineNo = 4 Then
                        Dim lne4() As String = Split(str, ":")
                        If lne4.Length = 2 Then
                            _CHANNEL_1_0 = lne4(1).Trim
                        End If

                    ElseIf LineNo = 5 Then
                        Dim lne5() As String = Split(str, ":")
                        If lne5.Length = 2 Then
                            _CHANNEL_2_5 = lne5(1).Trim
                        End If

                    ElseIf LineNo = 6 Then
                        Dim lne6() As String = Split(str, ":")
                        If lne6.Length = 2 Then
                            _CHANNEL_5_0 = lne6(1).Trim
                        End If

                    ElseIf LineNo = 7 Then
                        Dim lne7() As String = Split(str, ":")
                        If lne7.Length = 2 Then
                            _CHANNEL_10_0 = lne7(1).Trim
                        End If

                    ElseIf LineNo = 8 Then
                        'Dim lne8() As String = Split(str.Trim, " ")
                        Dim ATDigit As Integer = InStr(str.Trim, "AT:")
                        Dim RHDigit As Integer = InStr(str.Trim, "RH:")

                        _AIR_TEMPERATURE = str.Substring(ATDigit + 3, RHDigit - (ATDigit + 3)).Trim
                        _RELATIVE_HUMIDITY = str.Substring(RHDigit + 3).Trim
                    ElseIf LineNo = 9 Then
                        Dim DPDigit As Integer = InStr(str.Trim, "DP:")
                        Dim WBDigit As Integer = InStr(str.Trim, "WB:")

                        _DEWPOINT_TEMPERATURE = str.Substring(DPDigit + 3, WBDigit - (DPDigit + 3)).Trim
                        _WET_BULB_TEMPERATURE = str.Substring(WBDigit + 3).Trim
                    End If
                    LineNo += 1
                Next

                'Dim trans As New TransactionDB(SelectDB.DIPRFID)
                'If lnq.InsertData(LoginUsername, trans.Trans) = True Then
                '    If SaveParticleCounterData(LoginUsername, lnq, trans) = True Then
                '        trans.CommitTransaction()
                '    Else
                '        trans.RollbackTransaction()
                '    End If
                'Else
                '    trans.RollbackTransaction()
                '    LogFile.LogENG.SaveErrLog("ParticleENG.ReadImportTextFile", "PathTextFile=" & PathTextFile & vbNewLine & lnq.ErrorMessage)
                'End If
            End If
        Catch ex As Exception
            LogFile.LogENG.SaveErrLog("ParticleENG.ReadImportTextFile", "Exception : " & "PathTextFile=" & PathTextFile & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Return Me
    End Function

    Public Shared Function SaveParticleCounterData(LoginUsername As String, data As ParticleENG, trans As TransactionDB) As Boolean
        Dim ret As Boolean = False
        Try
            Dim hlnq As New TsParticleCounterHistoryLinqDB
            hlnq.MS_PARTICLE_COUNTER_DEVICE_ID = data.MS_PARTICLE_COUNTER_DEVICE_ID
            hlnq.IMPORT_TIME = data.IMPORT_TIME
            hlnq.LOG_FILE_NAME = data.LOG_FILE_NAME
            hlnq.LOG_FILE_BYTE = data.LOG_FILE_BYTE
            hlnq.COUNTER_MODE = data.COUNTER_MODE
            hlnq.CHANNEL_0_3 = data.CHANNEL_0_3
            hlnq.CHANNEL_0_5 = data.CHANNEL_0_5
            hlnq.CHANNEL_1_0 = data.CHANNEL_1_0
            hlnq.CHANNEL_2_5 = data.CHANNEL_2_5
            hlnq.CHANNEL_5_0 = data.CHANNEL_5_0
            hlnq.CHANNEL_10_0 = data.CHANNEL_10_0
            hlnq.AIR_TEMPERATURE = data.AIR_TEMPERATURE
            hlnq.RELATIVE_HUMIDITY = data.RELATIVE_HUMIDITY
            hlnq.DEWPOINT_TEMPERATURE = data.DEWPOINT_TEMPERATURE
            hlnq.WET_BULB_TEMPERATURE = data.WET_BULB_TEMPERATURE


            ret = hlnq.InsertData(LoginUsername, trans.Trans)
            If ret = True Then
                Dim lnq As New TsParticleCounterDataLinqDB
                lnq.ChkDataByCOUNTER_MODE_MS_PARTICLE_COUNTER_DEVICE_ID(data.COUNTER_MODE, data.MS_PARTICLE_COUNTER_DEVICE_ID, trans.Trans)
                lnq.MS_PARTICLE_COUNTER_DEVICE_ID = data.MS_PARTICLE_COUNTER_DEVICE_ID
                lnq.IMPORT_TIME = data.IMPORT_TIME
                lnq.LOG_FILE_NAME = data.LOG_FILE_NAME
                lnq.LOG_FILE_BYTE = data.LOG_FILE_BYTE
                lnq.COUNTER_MODE = data.COUNTER_MODE
                lnq.CHANNEL_0_3 = data.CHANNEL_0_3
                lnq.CHANNEL_0_5 = data.CHANNEL_0_5
                lnq.CHANNEL_1_0 = data.CHANNEL_1_0
                lnq.CHANNEL_2_5 = data.CHANNEL_2_5
                lnq.CHANNEL_5_0 = data.CHANNEL_5_0
                lnq.CHANNEL_10_0 = data.CHANNEL_10_0
                lnq.AIR_TEMPERATURE = data.AIR_TEMPERATURE
                lnq.RELATIVE_HUMIDITY = data.RELATIVE_HUMIDITY
                lnq.DEWPOINT_TEMPERATURE = data.DEWPOINT_TEMPERATURE
                lnq.WET_BULB_TEMPERATURE = data.WET_BULB_TEMPERATURE

                If Lnq.ID > 0 Then
                    ret = lnq.UpdateByPK(LoginUsername, trans.Trans)
                Else
                    ret = Lnq.InsertData(LoginUsername, trans.Trans)
                End If
                If ret = False Then
                    LogFile.LogENG.SaveErrLog("ParticleENG.SaveParticleCounterData", "PathTextFile=" & data.LOG_FILE_NAME & vbNewLine & lnq.ErrorMessage)
                End If
                lnq = Nothing
            Else
                LogFile.LogENG.SaveErrLog("ParticleENG.SaveParticleCounterData", "PathTextFile=" & data.LOG_FILE_NAME & vbNewLine & hlnq.ErrorMessage)
            End If
            hlnq = Nothing
        Catch ex As Exception
            ret = False
            LogFile.LogENG.SaveErrLog("ParticleENG.SaveParticleCounterData", "Exception : " & "PathTextFile=" & data.LOG_FILE_NAME & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Return ret
    End Function
End Class
