Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial
Imports MISys.API

<Table("MIUSER")>
Partial Public Class MIUSER
    <Key>
    <StringLength(8)>
    Public Property userId As String

    <Required>
    <StringLength(60)>
    Public Property userName As String

    <Required>
    <StringLength(256)>
    Public Property userPwd As String

    <Column(TypeName:="text")>
    <Required>
    Public Property config As String

    <Required>
    <StringLength(260)>
    Public Property domainName As String

    Public Property acctType As Integer

    Public Property acctStatus As Integer

    <StringLength(8)>
    Public Property groupId As String

    <Required>
    <StringLength(8)>
    Public Property uiProfileId As String

    <StringLength(3)>
    Public Property lang As String

    <Required>
    <StringLength(12)>
    Public Property licenseId As String

    Public Property logFlg As Boolean

    <StringLength(128)>
    Public Property SFQSerialNum As String

    <StringLength(128)>
    Public Property machineId As String

    <Column(TypeName:="timestamp")>
    <MaxLength(8)>
    <Timestamp>
    Public Property rowVer As Byte()

    Public Shared Widening Operator CType(v As MIAPI) As MIUSER
        Throw New NotImplementedException()
    End Operator
End Class
