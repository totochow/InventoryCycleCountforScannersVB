Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Function Index() As ActionResult
        Return View()
    End Function

    Function About() As ActionResult
        ViewData("Message") = "Purpose of this Application:"

        Return View()
    End Function

    Function Contact() As ActionResult
        ViewData("Message") = "Central Nervous Systems"

        Return View()
    End Function
End Class
