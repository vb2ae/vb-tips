Public Class Form1
    Sub Form1_Load(ByVal sender As System.Object,
     ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dt As New DataTable
        dt.Columns.Add("Name")
        dt.Columns.Add("Place")
        dt.LoadDataRow(New Object() {"Cor", "Holland"}, True)
        dt.LoadDataRow(New Object() {"Ken", "Florida"}, True)
        dt.LoadDataRow(New Object() {"Paul", "Illinois"}, True)
        dt.LoadDataRow(New Object() {"Herfried", "Austria"}, True)
        dt.LoadDataRow(New Object() {"Armin", "Germany"}, True)
        dt.LoadDataRow(New Object() {"John", "UK"}, True)
        dt.LoadDataRow(New Object() {"Mike", "SjangHai"}, True)
        DataGridView1.DataSource = dt.DefaultView
        Dim cma As CurrencyManager = DirectCast _
        (BindingContext(dt.DefaultView), CurrencyManager)
        AddHandler cma.CurrentChanged, AddressOf rowchanging
        rowchanging(Me, Nothing)
    End Sub
    Public Sub rowchanging(ByVal sender As Object,
        ByVal e As EventArgs)
        Dim dv1 = DirectCast(DataGridView1.DataSource, DataView)
        Dim dv2 As New DataView(dv1.Table)
        Dim cma = DirectCast(BindingContext(dv1), CurrencyManager)
        dv2.RowFilter = "Name = '" & dv1(cma.Position)("Name").ToString & "'"
        DataGridView2.DataSource = dv2
    End Sub
End Class
