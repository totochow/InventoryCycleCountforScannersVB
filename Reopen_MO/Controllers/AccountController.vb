Imports System.Web.Mvc
Imports MISys.API
Imports System.Net

Namespace Controllers
    Public Class GlobalVariables
        Public Shared Role As String
    End Class

    Public Class AccountController
        Inherits Controller

        Function Index() As ActionResult
            Return View()
        End Function

        Public Async Function Login(UserName As String, Password As String) As Threading.Tasks.Task(Of ActionResult)
            Dim user As String = UserName
            Dim pass As String = Password
            CheckPassword(user, pass)
            Dim Allowed_Group = ConfigurationManager.AppSettings("Allowed_Group").Split(";")
            If Not Allowed_Group.Contains(GlobalVariables.Role) Then
                Return RedirectToAction("ErrorLogin")
            End If
            ViewBag.Start_Date = "2010-01-01"
            ViewBag.End_Date = "2099-12-31"
            Return RedirectToAction("MO", New With {.Start_Date = ViewBag.Start_Date, .End_Date = ViewBag.End_Date})
        End Function
        Public Function ErrorLogin()
            Return View()
        End Function
        Public Function MO(ByVal Search_mohId As String, ByVal Search_descr As String,
                           ByVal jobIdtxt As String, ByVal locIdtxt As String, ByVal Search_buildItem As String,
                           ByVal Start_Date As Date, ByVal End_Date As Date) As ActionResult
            Dim job_List As New List(Of String)
            Dim loc_List As New List(Of String)
            Dim db As CompanyDbContext = New CompanyDbContext
            Dim jobs = From m In db.MIMOHs
                       Order By m.jobId
                       Select m.jobId
            Dim locs = From m In db.MIMOHs
                       Order By m.locId
                       Select m.locId
            job_List.AddRange(jobs.Distinct)
            job_List.RemoveAll(Function(x) x = "")
            loc_List.AddRange(locs.Distinct)
            ViewBag.jobIdtxt = New SelectList(job_List)
            ViewBag.locIdtxt = New SelectList(loc_List)
            Dim Allowed_Group = ConfigurationManager.AppSettings("Allowed_Group").Split(";")
            If Not Allowed_Group.Contains(GlobalVariables.Role) Then
                Return RedirectToAction("Index")
            End If
            Dim List_sort As New List(Of MIMOH)
            List_sort = GenerateMOList(Search_mohId, Search_descr, jobIdtxt, locIdtxt, Search_buildItem,
                                       Start_Date, End_Date).OrderByDescending(Function(s) s.closeDate).ToList()
            Return View(List_sort)
        End Function

        Private Sub CheckPassword(user As String, pass As String)
            GlobalVariables.Role = "No User"
            Dim api As New MIAPI(Nothing, ConfigurationManager.AppSettings("CNS_CompanyName"), user.ToUpper(), pass, False)
            Dim loggedOn As Boolean = api.Logon()
            If loggedOn Then
                GlobalVariables.Role = ReturnRole(user)
            End If
            api.Logoff()
        End Sub
        Private Function ReturnRole(user As String) As String
            Dim db As CompanyDbContext = New CompanyDbContext
            Dim usr As MIUSER = New MIUSER
            usr = db.MIUSERs.Where(Function(a) a.userId.ToUpper() = user.ToUpper() And a.acctStatus = 0).FirstOrDefault()
            Dim group As String = usr.groupId
            Return group
        End Function

        Private Function GenerateMOList(ByVal Search_mohId As String, ByVal Search_descr As String,
                                        ByVal jobIdtxt As String, ByVal locIdtxt As String, ByVal Search_buildItem As String,
                                        ByVal Start_Date As Date, ByVal End_Date As Date) As List(Of MIMOH)
            Dim db2 As CompanyDbContext = New CompanyDbContext
            Dim mos As New List(Of MIMOH)
            mos = db2.MIMOHs.Where(Function(a) a.moStat = 2).ToList()
            If Not String.IsNullOrEmpty(Search_mohId) Then
                mos = mos.Where(Function(a) a.mohId.Contains(Search_mohId)).ToList()
            End If
            If Not String.IsNullOrEmpty(Search_descr) Then
                mos = mos.Where(Function(a) a.descr.Contains(Search_descr)).ToList()
            End If
            If Not (jobIdtxt = Nothing Or jobIdtxt = "ALL") Then
                mos = mos.Where(Function(a) a.jobId = jobIdtxt).ToList()
            End If
            If Not String.IsNullOrEmpty(locIdtxt) Or locIdtxt = "ALL" Then
                mos = mos.Where(Function(a) a.locId = locIdtxt).ToList()
            End If
            If Not String.IsNullOrEmpty(Search_buildItem) Then
                mos = mos.Where(Function(a) a.buildItem = Search_buildItem).ToList()
            End If
            mos = mos.Where(Function(a) a.closeDt >= Start_Date And a.closeDt <= End_Date).ToList()
            Return mos
        End Function

        Public Function Confirm_Change(mohId As String) As ActionResult
            Dim Allowed_Group = ConfigurationManager.AppSettings("Allowed_Group").Split(";")
            If Not Allowed_Group.Contains(GlobalVariables.Role) Then
                Return RedirectToAction("Index")
            End If
            If IsNothing(mohId) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim db2 As CompanyDbContext = New CompanyDbContext
            Dim mo As MIMOH = db2.MIMOHs.Find(mohId)
            If IsNothing(mo) Then
                Return HttpNotFound()
            End If
            Return View(mo)
        End Function

        Public Function ChangeStatus(mohId As String) As ActionResult
            Dim Allowed_Group = ConfigurationManager.AppSettings("Allowed_Group").Split(";")
            If Not Allowed_Group.Contains(GlobalVariables.Role) Then
                Return RedirectToAction("Index")
            End If
            If IsNothing(mohId) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim db As New CompanyDbContext()
            db.Dispose()
            db = New CompanyDbContext()
            Dim MIMOHs As New List(Of MIMOH)
            Dim MIMOH = db.MIMOHs.Where(Function(a) a.mohId = mohId And a.moStat = 2).ToList()
            For Each oMIMOH In MIMOH
                oMIMOH.moStat = 1
            Next
            db.SaveChanges()
            ViewBag.mohId = mohId
            Return View()
        End Function
    End Class
End Namespace