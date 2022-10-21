Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("MIPIBDD")>
Partial Public Class MIPIBDD
    <Key>
    <Column(Order:=0)>
    <StringLength(8)>
    Public Property userId As String

    <Key>
    <Column(Order:=1)>
    <StringLength(6)>
    Public Property batchId As String

    <Key>
    <Column(Order:=2)>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property bType As Short

    <Key>
    <Column(Order:=3)>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property entry As Integer

    <Key>
    <Column(Order:=4)>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property detail As Integer

    <StringLength(24)>
    Public Property itemId As String

    <StringLength(6)>
    Public Property locId As String

    <StringLength(24)>
    Public Property binId As String

    <Required>
    <StringLength(40)>
    Public Property lotId As String

    <Column(TypeName:="numeric")>
    Public Property qty As Decimal

    <Column(TypeName:="numeric")>
    Public Property wip As Decimal

    <Column(TypeName:="timestamp")>
    <MaxLength(8)>
    <Timestamp>
    Public Property rowVer As Byte()

    Public Overridable Property MIPIBH As MIPIBH
End Class
