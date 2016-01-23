Imports Newtonsoft.Json
Imports Engine
Imports System.Data
Partial Class frmHandheldWebService
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim ret As String = ""
        Select Case Request("MethodName")
            Case "GetTagListByAppNo"
                Dim dt As DataTable = Engine.FileLocationENG.GetTagListByAppNo(Request("AppNo"))
                If dt.Rows.Count > 0 Then
                    'ret = JsonConvert.SerializeObject(dt, Formatting.Indented)
                    For Each dr As DataRow In dt.Rows
                        If ret = "" Then
                            ret = dr("tag_no")
                        Else
                            ret += "#" & dr("tag_no")
                        End If
                    Next
                End If
        End Select

        Response.Write(ret)
    End Sub
End Class
