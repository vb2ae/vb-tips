Imports System.ComponentModel

Public Class Form1
    Private Contributors As New BindingList(Of Contributor)
    Private Cma As CurrencyManager = DirectCast(BindingContext(Contributors), CurrencyManager)
    Private Sub Form1_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load
        Button1.Text = "Forward"
        Button2.Text = "Back"
        Contributors.Add(New Contributor With {.Name = "Ken"})
        Contributors.Add(New Contributor With {.Name = "Cor"})
        Contributors.Add(New Contributor With {.Name = "Armin"})
        Contributors.Add(New Contributor With {.Name = "John"})
        Contributors.Add(New Contributor With {.Name = "Frank"})
        Contributors.Add(New Contributor With {.Name = "Paul"})
        Contributors.Add(New Contributor With {.Name = "Kevin"})
        Label1.DataBindings.Add("Text", Contributors, "Name")
        AddHandler Cma.CurrentChanged, AddressOf CurrentChanged
    End Sub
    Private Sub CurrentChanged(ByVal sender As Object, ByVal e As EventArgs)
        Label2.Text = DirectCast(sender, CurrencyManager).Position.ToString
    End Sub
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If Cma.Position < Contributors.Count + 2 Then
            Cma.Position += 1
        End If
    End Sub
    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        If Cma.Position > 0 Then
            Cma.Position -= 1
        End If
    End Sub
End Class
Public Class Contributor
    Public Property Name As String
End Class
