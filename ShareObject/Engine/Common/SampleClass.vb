Imports LinqDB.ConnectDB
Public Class SampleClass



    Public Function GetSampleDataFromDIP3DB() As DataTable
        'Dim dt As New DataTable
        'dt = DIP3SqlDB.ExecuteTable("select * from ms_module")
        'Return dt




        Dim trans As New TransactionDB(SelectDB.DIPRFID)
        Dim dt As New DataTable
        dt = DIPRFIDSqlDB.ExecuteTable("select * from ms_module", trans.Trans)
        trans.CommitTransaction()
        Return dt
    End Function

    Public Shared Function EncryptData(txt As String) As String
        Return SqlDB.EnCripPwd(txt)
    End Function


    Public Function GetSampleDataFromDIP2DB() As DataTable
        'Dim dt As New DataTable
        'dt = DIP2SqlDB.ExecuteTable("select * from TB_MENU")
        'Return dt



        Dim trans As New TransactionDB(SelectDB.DIPRFID)
        Dim dt As New DataTable
        dt = DIPRFIDSqlDB.ExecuteTable("select * from TB_MENU", trans.Trans)

        trans.CommitTransaction()
        Return dt
    End Function

    Public Function GetSampleDataFromPatentDB() As DataTable
        'Dim dt As New DataTable
        'dt = PatentSqlDB.ExecuteTable("select * from OFFICER")
        'Return dt



        Dim trans As New TransactionDB(SelectDB.PATENDB)
        Dim dt As New DataTable
        dt = PatentSqlDB.ExecuteTable("select * from OFFICER", trans.Trans)
        trans.CommitTransaction()
        Return dt
    End Function

    Public Function InsertTBAlarmLog() As Boolean
        Dim lnq As New LinqDB.TABLE.TbAlarmLogLinqDB
        lnq.ALARM_DATETIME = DateTime.Now
        lnq.REQUISITION_ID = 4

        Dim trans As New LinqDB.ConnectDB.TransactionDB(SelectDB.DIPRFID)
        Dim ret As Boolean = lnq.InsertData("TestInsertAlarm", trans.Trans)

        If ret = False Then
            Dim _err As String = ""
            _err = lnq.ErrorMessage
            trans.RollbackTransaction()
        Else
            trans.CommitTransaction()
        End If
        Return ret
    End Function
End Class
