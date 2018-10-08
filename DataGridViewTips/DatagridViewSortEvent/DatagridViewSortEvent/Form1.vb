Imports System.Data.SQLite

Public Class Form1
    Private Sub Form1_Load(ByVal sender As System.Object,
                           ByVal e As System.EventArgs) Handles MyBase.Load
        Using da As New SQLiteDataAdapter("Select * From Product",
                                       "Data Source = NorthWind_small.sqlite")
            Dim dt As New DataTable
            da.Fill(dt)
            DataGridView1.DataSource = dt.DefaultView
            AddHandler dt.DefaultView.ListChanged, AddressOf ListChanged
        End Using
    End Sub

    Private Sub ListChanged(ByVal sender As Object,
                            ByVal e As System.ComponentModel.ListChangedEventArgs)
        Dim dv = DirectCast(DataGridView1.DataSource, DataView)
        MessageBox.Show(String.Format("Sort on column {0}", dv.Sort))
    End Sub
End Class
