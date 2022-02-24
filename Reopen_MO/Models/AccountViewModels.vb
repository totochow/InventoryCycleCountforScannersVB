Imports System.ComponentModel.DataAnnotations
Public Class LoginViewModel
    <Required>
    <Display(Name:="Username")>
    Public Property UserName As String

    <Required>
    <DataType(DataType.Password)>
    <Display(Name:="Password")>
    Public Property Password As String

    <Display(Name:="Remember me?")>
    Public Property RememberMe As Boolean
    Public Property Message As String
End Class

