Public Class frmTestForm

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Engine.FileLocationENG.TracingDocumentData()
        'Engine.ExcelFileENG.ReadTextExcelFromMHT381SD(1, "D:\My Documents\ScoreSolutions\ProjectDocument\DIP-UHF3\SourceDoc\เครื่องวันความชื้นและอุณหภูมิ\HTC01002.XLS")
        'Engine.DigitalSignageENG.GetFileGrowthRatio(2010)

        'Engine.DigitalSignageENG.GetFileBorrowAndReserveQty(New Date(2011, 3, 17))
        Engine.DigitalSignageENG.GetFileQtyByFloor()
    End Sub
End Class