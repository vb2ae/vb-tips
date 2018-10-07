Imports System.Data.SQLite

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Using Con As New SQLiteConnection("Data Source=Northwind_small.sqlite")
                Con.Open()
                Using com As New SQLiteCommand("Select FirstName || ' ' || Lastname from Employee where id = @person", Con)
                    com.Parameters.AddWithValue("@person", 1)
                    Dim textObj = com.ExecuteScalar
                    If Not textObj Is Nothing AndAlso Not textObj Is DBNull.Value Then
                        TextBox1.Text = CStr(textObj)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class
