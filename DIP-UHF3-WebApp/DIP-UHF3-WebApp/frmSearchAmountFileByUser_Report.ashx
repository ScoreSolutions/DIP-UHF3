<%@ WebHandler Language="VB" Class="frmSearchAmountFileByUser_Report" %>


Imports System
Imports System.Web
Imports System.IO
Imports System.Data
Imports System.Drawing
Imports OfficeOpenXml
Imports System.Globalization

Public Class frmSearchAmountFileByUser_Report : Implements IHttpHandler
    
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        Dim url As String = context.Request.RawUrl
        Dim strTemp As String() = url.Split("&")
        Dim department_id, username, patent_type_id, isshow As String
        For i As Integer = 0 To strTemp.Length - 1
            Dim strTemp2 As String() = strTemp(i).Split("=")
            Select Case i
                Case 0
                    department_id = strTemp2(1) & ""
                Case 1
                    username = strTemp2(1) & ""
                Case 2
                    patent_type_id = strTemp2(1) & ""
                Case 3
                    isshow = strTemp2(1) & ""
            End Select
        Next
        
        Dim countCriteria As Integer = 1
        Using ep As New ExcelPackage
            Dim ws As ExcelWorksheet = ep.Workbook.Worksheets.Add("FileUser")
            ws.Cells("A" & countCriteria & "").Value = "ลำดับ"
            ws.Cells("B" & countCriteria & "").Value = "ชื่อผู้ครอบครอง"
            ws.Cells("C" & countCriteria & "").Value = "หน่วยงาน"
            ws.Cells("D" & countCriteria & "").Value = "ประเภทแฟ้ม"
            ws.Cells("E" & countCriteria & "").Value = "จำนวนแฟ้ม"
                                                
            ' //Format the header 
            Using RowHeader As ExcelRange = ws.Cells("A" & countCriteria & ":E" & countCriteria & "")
                RowHeader.Style.Font.Bold = True
                RowHeader.Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                RowHeader.Style.Fill.BackgroundColor.SetColor(Color.YellowGreen)
                RowHeader.Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Center
                RowHeader.Style.Font.Color.SetColor(Color.White)
            End Using
            '## End Header ##

            Dim webs As New WebService
            Dim dt As New DataTable
            dt = webs.GetSearchAmountFileByDepartmentToDatatable(department_id, username, patent_type_id, isshow)
            For i As Integer = 0 To dt.Rows.Count - 1
                countCriteria += 1
                ws.Cells("A" & countCriteria & "").Value = dt.Rows(i)("no").ToString
                ws.Cells("B" & countCriteria & "").Value = dt.Rows(i)("officer_name").ToString
                ws.Cells("C" & countCriteria & "").Value = dt.Rows(i)("department_name").ToString
                ws.Cells("D" & countCriteria & "").Value = dt.Rows(i)("patent_type_name").ToString
                ws.Cells("E" & countCriteria & "").Value = dt.Rows(i)("amountfile").ToString
            Next
            Using RowContent As ExcelRange = ws.Cells("A" & countCriteria & ":E" & countCriteria)
                'RowContent.Style.Border.Top.Style = Style.ExcelBorderStyle.Thin
                'RowContent.Style.Border.Bottom.Style = Style.ExcelBorderStyle.Thin
                'RowContent.Style.Border.Left.Style = Style.ExcelBorderStyle.Thin
                'RowContent.Style.Border.Right.Style = Style.ExcelBorderStyle.Thin
                'RowContent.AutoFitColumns()
            End Using

            ws.Cells("A0:E" & countCriteria).AutoFitColumns()

            '//Write it back to the client
            context.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
            context.Response.AddHeader("content-disposition", "attachment;  filename=" & "EportFileQtyByBorrowerName_" & DateTime.Now.ToString("yyyyMMddhhmmss") & ".xlsx")
            context.Response.BinaryWrite(ep.GetAsByteArray())
            context.Response.End()
            context.Response.Flush()
        End Using
            
    End Sub
 
    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class