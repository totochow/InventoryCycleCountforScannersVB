Imports System.Web.Mvc
Imports MISys.API
Imports System.Net
Imports System.Security.Cryptography

Namespace Controllers
    Public Class GlobalVariables
        Public Shared Role As String
        Public Shared Company As String = ConfigurationManager.AppSettings("CNS_CompanyName")
        Public Shared URLString As String = ConfigurationManager.AppSettings("CNS_ServerURL")
        Public Shared Start_Date As String = DateAdd(DateInterval.Month, -2, Today()).ToString("yyyy-MM-dd")
        Public Shared End_Date As String = DateAdd(DateInterval.Day, 5, Today()).ToString("yyyy-MM-dd")
        Public Shared LoggedInId As String
    End Class

    Public Class AccountController
        Inherits Controller

        Function Index() As ActionResult
            ViewBag.LoggedInName = GlobalVariables.LoggedInId
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
            ViewBag.Start_Date = GlobalVariables.Start_Date
            ViewBag.End_Date = GlobalVariables.End_Date
            GlobalVariables.LoggedInId = user
            ViewBag.LoggedInName = GlobalVariables.LoggedInId
            Return RedirectToAction("CountBatch", "Home")
        End Function
        Public Function ErrorLogin()
            Return View()
        End Function
        Public Function LogOff()
            GlobalVariables.LoggedInId = Nothing
            Return RedirectToAction("Index")
        End Function

        Private Sub CheckPassword(user As String, pass As String)
            GlobalVariables.Role = "No User"
            Dim api_url As New MIAPI(GlobalVariables.URLString, GlobalVariables.Company, user.ToUpper(), pass, False)
            Dim api_nothing As New MIAPI(Nothing, GlobalVariables.Company, user.ToUpper(), pass, False)
            Dim loggedOn_url As Boolean = api_url.Logon()
            Dim loggedOn_nothing As Boolean = api_nothing.Logon()
            If loggedOn_url Or loggedOn_nothing Then
                GlobalVariables.Role = ReturnRole(user)
            End If
            api_url.Logoff()
            api_nothing.Logoff()
            If Not (loggedOn_url Or loggedOn_nothing) Then
                Dim usrPwd As String
                usrPwd = GetMISysPassword(user.ToUpper())
                Dim MISysPwd As String
                Dim convertedToBytes As Byte() = Encoding.UTF8.GetBytes(pass)
                Dim hashType As HashAlgorithm = New SHA1Managed()
                Dim hashBytes As Byte() = hashType.ComputeHash(convertedToBytes)
                MISysPwd = Convert.ToBase64String(hashBytes)
                Dim usrPwdSplit As String
                If usrPwd.Contains("=:") Then
                    usrPwdSplit = usrPwd.Split(New String() {"=:"}, StringSplitOptions.RemoveEmptyEntries)(1)
                Else usrPwdSplit = Nothing
                End If

                If (usrPwd = MISysPwd Or usrPwdSplit = MISysPwd) Then
                    GlobalVariables.Role = ReturnRole(user)
                End If
            End If
        End Sub
        Public Function GetMISysPassword(user As String) As String
            Dim db As CompanyDbContext = New CompanyDbContext
            Dim usr As MIUSER = New MIUSER
            If user Is Nothing Then
                Return ""
            Else
                usr = db.MIUSERs.Where(Function(a) a.userId.ToUpper() = user.ToUpper() And a.acctStatus = 0).FirstOrDefault()
                If usr IsNot Nothing Then
                    Dim userPwd As String = usr.userPwd
                    Return userPwd
                End If
                Return ""
            End If
        End Function
        Private Function ReturnRole(user As String) As String
            Dim db As CompanyDbContext = New CompanyDbContext
            Dim usr As MIUSER = New MIUSER
            usr = db.MIUSERs.Where(Function(a) a.userId.ToUpper() = user.ToUpper() And a.acctStatus = 0).FirstOrDefault()
            Dim group As String = usr.groupId
            Return group
        End Function

    End Class
End Namespace