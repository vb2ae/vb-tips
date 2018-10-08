Public Class Form1
    Dim Dt As DataTable
    Private Dt1 As DataTable
    Private Sub Form1_Load(ByVal sender As System.Object,
       ByVal e As System.EventArgs) Handles MyBase.Load
        Dt = CreateTables()
        'Create a dataView from the table below (be aware you can also use 2 tables)
        Dt1 = Dt.DefaultView.ToTable("TableForBox1", True, {"Nation"})
        ComboBox1.DataSource = Dt1
        ComboBox1.DisplayMember = "Nation"
        ComboBox1.ValueMember = "Nation" 'to prevent a possible bug in Framework 4.5
        AddHandler ComboBox1.SelectedIndexChanged, AddressOf ComboBox1_SelectedIndexChanged
        ComboBox1_SelectedIndexChanged(Me, Nothing)
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim dt2 As DataTable = Dt.DefaultView.ToTable("TableForBox2", True, {"Nation", "State"})
        dt2.DefaultView.RowFilter = "Nation = '" & ComboBox1.SelectedValue.ToString & "'"
        ComboBox2.DataSource = dt2.DefaultView
        ComboBox2.DisplayMember = "State"
    End Sub
    'To have a table to use is one created below
    Private Function CreateTables() As DataTable
        Dim dt As New DataTable("Persons")
        dt.Columns.Add("Name", GetType(System.String))
        dt.Columns.Add("Nation", GetType(System.String))
        dt.Columns.Add("State", GetType(System.String))
        dt.LoadDataRow(New Object() {"Ken", "USA", "Florida"}, True)
        dt.LoadDataRow(New Object() {"Rudy", "USA", "New York"}, True)
        dt.LoadDataRow(New Object() {"Luc", "Canada", "Quebeck"}, True)
        dt.LoadDataRow(New Object() {"Mark", "China", "Shanghai"}, True)
        dt.LoadDataRow(New Object() {"Mike", "China", "Shanghai"}, True)
        dt.LoadDataRow(New Object() {"Cor", "EU", "Netherlands"}, True)
        dt.LoadDataRow(New Object() {"John", "EU", "Great Britain"}, True)
        dt.LoadDataRow(New Object() {"Paul", "USA", "Illinois"}, True)
        Return dt
    End Function
End Class
