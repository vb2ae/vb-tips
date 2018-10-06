Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If Not Char.IsDigit(CChar(e.KeyChar)) AndAlso Not {ControlChars.Back}.Contains(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    'For paste protection
    Private Sub TextBox1_Leave(sender As Object, e As EventArgs) Handles TextBox1.Leave
        For i = 0 To TextBox1.Text.Length - 1
            Dim x As Char = CChar(TextBox1.Text(i))
            If Not Char.IsDigit(CChar(TextBox1.Text(i))) Then
                MessageBox.Show("TextBox contains not allowed characters")
                TextBox1.Focus()
            End If
        Next
    End Sub
End Class
