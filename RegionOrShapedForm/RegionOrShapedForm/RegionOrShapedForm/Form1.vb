Public Class Form1
    Private MouseX, MouseY As Integer
    Private MouseIsDown As Boolean
    Private WithEvents Button1 As New Button
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Using g As New Drawing.Drawing2D.GraphicsPath
            g.AddString("HTH" & vbCrLf & "Cor",
            Drawing.FontFamily.GenericSansSerif,
            Drawing.FontStyle.Bold, 200,
            New Point(0, 0),
            Drawing.StringFormat.GenericDefault)
            Me.BackColor = Color.Red
            Me.Region = New Drawing.Region(g)
        End Using
        Me.AutoScaleBaseSize = New Drawing.Size(0, 0)
        Me.ClientSize = New Drawing.Size(500, 450)
        Button1.BackColor = Drawing.SystemColors.ActiveCaptionText
        Button1.ForeColor = Drawing.Color.Black
        Button1.Location = New Drawing.Point(420, 10)
        Button1.Size = New Drawing.Size(20, 20)
        Me.Controls.Add(Button1)
        Button1.Text = "X"
        Me.Location = New Drawing.Point(50, 50)
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
    Private Sub Form1_MouseIsDown(sender As Object,
        e As Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
        MouseIsDown = True
        MouseX = Cursor.Position.X - Me.Location.X
        MouseY = Cursor.Position.Y - Me.Location.Y
    End Sub
    Private Sub Form1_MouseMove(sender As Object, e As Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove
        Static LastCursor As Point
        Dim NowCursor As Point = New Point(Cursor.Position.X, Cursor.Position.Y)
        If Point.op_Inequality(NowCursor, LastCursor) Then
            If MouseIsDown Then
                Me.Location = New Drawing.Point(Cursor.Position.X _
                - MouseX, Cursor.Position.Y - MouseY)
            End If
            LastCursor = Cursor.Position
        End If
    End Sub
    Private Sub Form1_MouseUp(sender As Object, e As Windows.Forms.MouseEventArgs) Handles MyBase.MouseUp
        MouseIsDown = False
    End Sub
End Class
