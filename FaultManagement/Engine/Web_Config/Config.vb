Imports System.Data
Imports LinqDB.ConnectDB
Imports LinqDB.TABLE
Imports System.IO


Namespace Web_Config
    Public Class Config

        Public Function SetDDLData(ByVal dt As DataTable, ByVal drp As Web.UI.WebControls.DropDownList, ByVal DisplayField As String, ByVal ValueField As String, ByVal DefaultDisplay As String, ByVal DefaultValue As String) As Boolean

            If dt Is Nothing Then

                dt.Columns.Add(ValueField)
                dt.Columns.Add(DisplayField)

            End If
            Dim dr As DataRow = dt.NewRow()

            dr([ValueField]) = DefaultValue
            dr([DisplayField]) = DefaultDisplay
            dt.Rows.InsertAt(dr, 0)

            drp.DataTextField = DisplayField
            drp.DataValueField = ValueField
            drp.DataSource = dt
            drp.DataBind()


        End Function
    End Class
End Namespace
