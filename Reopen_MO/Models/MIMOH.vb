Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("MIMOH")>
Partial Public Class MIMOH
    <Key>
    <StringLength(15)>
    <Display(Name:="MO Number")>
    Public Property mohId As String

    Public Property lstMaintDt As Date?

    <Display(Name:="Description")>
    <StringLength(60)>
    Public Property descr As String


    <StringLength(2000)>
    Public Property notes As String


    <StringLength(8)>
    Public Property creator As String


    <StringLength(8)>
    Public Property releaser As String

    <Display(Name:="Job ID")>
    <StringLength(12)>
    Public Property jobId As String

    <Display(Name:="Location")>
    <StringLength(6)>
    Public Property locId As String

    <Display(Name:="Build Item Number")>
    <StringLength(24)>
    Public Property buildItem As String

    Public Property buildNonItem As Boolean


    <StringLength(60)>
    Public Property buildNonItemDesc As String

    <Display(Name:="BOM - Item #")>
    <StringLength(24)>
    Public Property bomItem As String

    <Display(Name:="BOM Revision #")>
    <StringLength(6)>
    Public Property bomRev As String

    Public Property moStat As Short

    Public Property prStat As Short

    <Display(Name:="Ordered Qty")>
    <Column(TypeName:="numeric")>
    Public Property ordQty As Decimal

    <Display(Name:="Ordered Date")>
    <StringLength(8)>
    Public Property ordDate As String

    <Display(Name:="Start Date")>
    <StringLength(8)>
    Public Property startDate As String

    <Display(Name:="End Date")>
    <StringLength(8)>
    Public Property endDate As String

    <StringLength(8)>
    Public Property releaseDate As String

    <Column(TypeName:="numeric")>
    Public Property relOrdQty As Decimal

    <Column(TypeName:="numeric")>
    Public Property releaseCost As Decimal

    <Column(TypeName:="numeric")>
    Public Property relLabCost As Decimal

    <Column(TypeName:="numeric")>
    Public Property relOvrhdCost As Decimal

    Public Property priority As Short

    <Column(TypeName:="numeric")>
    Public Property markup As Decimal

    <Column(TypeName:="numeric")>
    Public Property wipQty As Decimal

    <Column(TypeName:="numeric")>
    Public Property resQty As Decimal

    <Display(Name:="Completed Qty")>
    <Column(TypeName:="numeric")>
    Public Property endQty As Decimal

    <StringLength(8)>
    Public Property closeDate As String

    <StringLength(30)>
    Public Property hdrTxt1 As String

    <StringLength(30)>
    Public Property hdrTxt2 As String

    <StringLength(30)>
    Public Property hdrTxt3 As String

    <StringLength(30)>
    Public Property hdrTxt4 As String

    <StringLength(260)>
    Public Property docPath As String

    <StringLength(256)>
    Public Property oeOrdNo As String

    Public Property oeOrdDtLn As Integer

    <Column(TypeName:="numeric")>
    Public Property icTransQty As Decimal

    Public Property onHold As Boolean

    <Column(TypeName:="text")>
    Public Property fldXml As String

    <StringLength(256)>
    Public Property icLoc As String

    <StringLength(256)>
    Public Property customer As String

    <StringLength(8)>
    Public Property soShipDate As String

    Public Property chkValidEndDt As Boolean

    <StringLength(256)>
    Public Property buildSales As String

    <Column(TypeName:="numeric")>
    Public Property cumCost As Decimal

    <DatabaseGenerated(DatabaseGeneratedOption.Computed)>
    Public Property ordDt As Date?

    <DatabaseGenerated(DatabaseGeneratedOption.Computed)>
    Public Property startDt As Date?

    <DatabaseGenerated(DatabaseGeneratedOption.Computed)>
    Public Property endDt As Date?

    <DatabaseGenerated(DatabaseGeneratedOption.Computed)>
    Public Property releaseDt As Date?

    <DatabaseGenerated(DatabaseGeneratedOption.Computed)>
    <Display(Name:="Close Date")>
    <DataType(DataType.Date)>
    <DisplayFormat(DataFormatString:="{0:yyyy/MM/dd}", ApplyFormatInEditMode:=True)>
    Public Property closeDt As Date?

    <DatabaseGenerated(DatabaseGeneratedOption.Computed)>
    Public Property soShipDt As Date?

    <Column(TypeName:="timestamp")>
    <MaxLength(8)>
    <Timestamp>
    Public Property rowVer As Byte()
End Class
