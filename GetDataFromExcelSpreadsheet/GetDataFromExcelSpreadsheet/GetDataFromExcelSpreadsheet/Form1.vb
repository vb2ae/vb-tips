Imports System.Data.OleDb

Public Class Form1
    'VB10SP1 style for older versions add Byval
    Private Sub Form1_Load(sender As System.Object,
                           e As System.EventArgs) Handles MyBase.Load
        Dim dt As New DataTable
        Using conn As New OleDbConnection _
        ("Data Source=test.xlsx;Provider=Microsoft.ACE.OLEDB.12.0;" &
         "Extended Properties=Excel 12.0;")
            Using da As New OleDbDataAdapter("Select * from [Sheet1$]", conn)
                da.Fill(dt)
            End Using
        End Using
        DataGridView1.DataSource = dt
    End Sub
End Class
