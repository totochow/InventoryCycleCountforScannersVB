Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("MIPIBH")>
Partial Public Class MIPIBH
    Public Sub New()
        MIPIBDDs = New HashSet(Of MIPIBDD)()
    End Sub

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

    <Required>
    <StringLength(60)>
    Public Property descr As String

    Public Property createdDt As Date?

    Public Property lstEditDt As Date?

    Public Property status As Short

    Public Property lstCheckDt As Date?

    Public Property lstPostDt As Date?

    Public Property selected As Boolean

    Public Property showRecorded As Boolean

    <Column(TypeName:="timestamp")>
    <MaxLength(8)>
    <Timestamp>
    Public Property rowVer As Byte()

    Public Overridable Property MIPIBDDs As ICollection(Of MIPIBDD)
End Class
