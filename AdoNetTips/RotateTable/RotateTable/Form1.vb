Public Class Form1
    Private Sub Form1_Load(ByVal sender As Object,
            ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ds As New DataSet
        Dim dt1 As DataTable = CreateTables()
        ds.Tables.Add(dt1)
        Dim dt2 As New DataTable("Reflection")
        ds.Tables.Add(dt2)
        For i As Integer = 0 To ds.Tables("Original").Rows.Count - 1
            dt2.Columns.Add(i.ToString)
        Next
        For i As Integer = 0 To ds.Tables("Original").Rows.Count - 1
            Dim dr As DataRow = ds.Tables("Reflection").NewRow
            For y As Integer = 0 To ds.Tables("Original").Columns.Count - 1
                dr(y) = ds.Tables("Original").Rows(y).Item(i)
            Next
            ds.Tables("Reflection").Rows.Add(dr)
        Next
        DataGridView1.DataSource = ds.Tables("Reflection")
    End Sub

    'To have a table to use is one created below
    Private Function CreateTables() As DataTable
        Dim dt As New DataTable("Original")
        dt.Columns.Add("Name")
        dt.Columns.Add("State")
        dt.Columns.Add("Country")
        dt.LoadDataRow(New Object() {"Cor", "Holland", "EU"}, True)
        dt.LoadDataRow(New Object() {"Ken", "Florida", "US"}, True)
        dt.LoadDataRow(New Object() {"Michael", "New Jersey", "US"}, True)
        Return dt
    End Function
End Class
