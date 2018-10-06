Imports System.Security.Cryptography
Imports System.Text
Imports Microsoft.Win32

Public Class Form1
    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim rk As RegistryKey = Registry.Users
        Dim keyName = "HKEY_CURRENT_USER\ExpireExample"
        Dim registeredDate As Object = Registry.GetValue(keyName, "Abacadabra", "Empty")

        If registeredDate Is Nothing OrElse registeredDate.ToString = "Empty" Then
            registeredDate = Now.ToShortDateString
            Registry.SetValue(keyName, "Abacadabra", Encrypt(registeredDate.ToString))
        Else
            registeredDate = DeCrypt(registeredDate.ToString)
        End If
        Dim expirationDate = CDate(registeredDate).AddDays(15) 'to adjust it use this key
        If expirationDate < Now Then MessageBox.Show("Expired")
    End Sub
    Private Function Encrypt(Source As String) As String
        Dim desCrypto As New TripleDESCryptoServiceProvider
        Dim hashMD5 As New MD5CryptoServiceProvider()
        Dim byteHash As Byte()
        Dim byteBuff As Byte()
        byteHash = hashMD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes("Donkey"))
        desCrypto.Key = byteHash
        desCrypto.Mode = CipherMode.ECB
        byteBuff = ASCIIEncoding.ASCII.GetBytes(Source)
        Return Convert.ToBase64String(desCrypto.CreateEncryptor().
   TransformFinalBlock(byteBuff, 0, byteBuff.Length))
    End Function
    Private Function DeCrypt(Source As String) As String
        Dim desCrypto As New TripleDESCryptoServiceProvider
        Dim hashMD5 As New MD5CryptoServiceProvider()
        Dim byteHash As Byte()
        Dim byteBuff As Byte()
        byteHash = hashMD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes("Donkey"))
        desCrypto.Key = byteHash
        desCrypto.Mode = CipherMode.ECB
        byteBuff = Convert.FromBase64String(Source)
        Return ASCIIEncoding.ASCII.GetString(desCrypto.CreateDecryptor().TransformFinalBlock(byteBuff, 0, byteBuff.Length))
    End Function
End Class
