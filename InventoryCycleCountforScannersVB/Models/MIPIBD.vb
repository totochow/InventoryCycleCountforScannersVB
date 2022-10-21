Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("MIPIBD")>
Partial Public Class MIPIBD
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

    Public Property lineNbr As Integer

    <StringLength(24)>
    Public Property itemId As String

    <StringLength(6)>
    Public Property locId As String

    Public Property type As Short

    <StringLength(24)>
    Public Property binId As String

    <StringLength(8)>
    Public Property dateISO As String

    <Column(TypeName:="numeric")>
    Public Property qty As Decimal

    <Column(TypeName:="numeric")>
    Public Property wip As Decimal

    <Column(TypeName:="numeric")>
    Public Property recQty As Decimal

    <Column(TypeName:="numeric")>
    Public Property recWip As Decimal

    <Required>
    <StringLength(30)>
    Public Property ticket As String

    <Required>
    <StringLength(60)>
    Public Property comment As String

    Public Property status As Short

    <StringLength(8)>
    Public Property errId As String

    <Column("date")>
    <DatabaseGenerated(DatabaseGeneratedOption.Computed)>
    Public Property _date As Date?

    <Column(TypeName:="timestamp")>
    <MaxLength(8)>
    <Timestamp>
    Public Property rowVer As Byte()
End Class
