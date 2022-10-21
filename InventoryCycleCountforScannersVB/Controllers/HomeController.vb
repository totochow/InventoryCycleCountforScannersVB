Imports InventoryCycleCountforScannersVB.Controllers

Public Class HomeController
    Inherits System.Web.Mvc.Controller
    Dim db As New CompanyDbContext
    Function Index() As ActionResult
        ViewBag.LoggedInName = GlobalVariables.LoggedInId
        Return RedirectToAction("Index", "Account")
    End Function

    Function About() As ActionResult
        ViewData("Message") = "Purpose of this Application:"

        Return View()
    End Function

    Function Contact() As ActionResult
        ViewData("Message") = "Central Nervous Systems"

        Return View()
    End Function

    Private Function CountBatch() As ActionResult

        Dim oPIBatchH As List(Of MIPIBH) = db.MIPIBHs.Where(Function(f) f.status = 0).ToList()
        ViewBag.LoggedInName = GlobalVariables.LoggedInId
        If GlobalVariables.LoggedInId IsNot Nothing Then
            Return View(oPIBatchH)
        Else
            Return RedirectToAction("Index", "Account")
        End If
    End Function

    Private Function BatchDetails(batchId As String)
        Dim oPIBatchD As List(Of MIPIBD) = db.MIPIBDs.Where(Function(f) f.batchId = batchId).ToList()
        ViewBag.LoggedInName = GlobalVariables.LoggedInId
        If GlobalVariables.LoggedInId IsNot Nothing Then
            Return View(oPIBatchD)
        Else
            Return RedirectToAction("Index", "Account")
        End If
    End Function

End Class