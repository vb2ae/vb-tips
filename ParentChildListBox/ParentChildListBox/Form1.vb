Public Class Form1
    'VB10SP1 for older versions Add Byval
    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim dt1 As New DataTable("Names")
        dt1.Columns.Add("Name")
        dt1.Columns.Add("State")
        dt1.LoadDataRow(New Object() {"Ken Tucker", "Florida"}, True)
        dt1.LoadDataRow(New Object() {"Cor Ligthert", "Netherlands"}, True)
        dt1.LoadDataRow(New Object() {"John Antonny Oliver", "England"}, True)
        dt1.LoadDataRow(New Object() {"Armin Zingler", "Germany"}, True)
        dt1.LoadDataRow(New Object() {"Paul Clement", "Illinois"}, True)
        dt1.LoadDataRow(New Object() {"Liliane Teng", "SjangHai"}, True)
        dt1.LoadDataRow(New Object() {"Mike Feng", "SjangHai"}, True)
        dt1.LoadDataRow(New Object() {"Hannes Heslacher", "Germany"}, True)
        'Here we use the possibilies of the dataview in versions 2.0 and newer to create a little bit lazy State table
        ListBox1.DataSource = New DataView(dt1, "", "State", DataViewRowState.CurrentRows).ToTable(True, {"State"})
        ListBox1.DisplayMember = "State"
        ListBox1.ValueMember = "State"
        ListBox1.SelectedIndex = 0
        dt1.DefaultView.RowFilter = "State = '" & CStr(ListBox1.SelectedValue) & "'"
        ListBox2.DisplayMember = "Name"
        ListBox2.DataSource = dt1.DefaultView
        AddHandler ListBox1.SelectedIndexChanged, AddressOf ListBox1_SelectedIndexChanged
    End Sub
    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As System.EventArgs)
        DirectCast(ListBox2.DataSource, DataView).RowFilter = "State = '" & CStr(ListBox1.SelectedValue) & "'"
    End Sub
End Class
