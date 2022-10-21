<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>@ViewBag.Title - CNS Application</title>
    @Styles.Render("~/Content/css")
    @Scripts.Render("~/bundles/modernizr")
</head>
<body>
    <div class="navbar navbar-inverse navbar-fixed-top">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                @Html.ActionLink("Inventory Cycle Count", "Index", "Home", New With {.area = ""}, New With {.class = "navbar-brand"})
            </div>
            <div class="navbar-collapse collapse">
                @If (ViewBag.LoggedInName IsNot Nothing) Then
                    @<ul Class="nav navbar-nav">
                        @*<li>@Html.ActionLink("Home", "Index", "Home")</li>*@
                        <li>@Html.ActionLink("View Batches", "AddCount", "Home")</li>
                        @*<li>@Html.ActionLink("Contact", "Contact", "Home")</li>*@
                    </ul>

                    @Using Html.BeginForm("LogOff", "Account", FormMethod.Post, New With {.class = "navbar-collapse collapse", .align = "Right", .style = "padding-top:10px", .role = "form"})
                        @Html.AntiForgeryToken()

                    @<form class="navbar-collapse collapse" align="Right" style="padding-top:10px">
                        <button class="btn btn-outline-success my-2 my-sm-0" type="submit" >LOGOUT</button>
                    </form>
                    End Using
                End If
            </div>
        </div>

        </div>
        <div class="container body-content">
            @RenderBody()
            <hr />
            <footer>
                <p>&copy; @DateTime.Now.Year - Central Nervous Systems</p>
            </footer>
        </div>

        @Scripts.Render("~/bundles/jquery")
        @Scripts.Render("~/bundles/bootstrap")
        @RenderSection("scripts", required:=False)

        </body>
        </html>
