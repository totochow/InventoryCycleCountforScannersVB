@*@Code
        ViewData("Title") = "Home Page"
    End Code

    <div class="jumbotron">
        <h1>Re-Open MOs</h1>
        <p class="lead">
            Use this Application to re-open closed MO within MISys.<br />
            Click the  following button to start the app.
        </p>
        <p><a href='@Url.Action("Index", "Account")' class="btn btn-primary btn-lg">Log In&raquo;</a></p>
    </div>

    <div class="row">
            <div class="col-md-4">
                <h2>Getting started</h2>
                <p>
                    ASP.NET MVC gives you a powerful, patterns-based way to build dynamic websites that
                    enables a clean separation of concerns and gives you full control over markup
                    for enjoyable, agile development.
                </p>
                <p><a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301865">Learn more &raquo;</a></p>
            </div>
            <div class="col-md-4">
                <h2>Get more libraries</h2>
                <p>NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.</p>
                <p><a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301866">Learn more &raquo;</a></p>
            </div>
            <div class="col-md-4">
                <h2>Web Hosting</h2>
                <p>You can easily find a web hosting company that offers the right mix of features and price for your applications.</p>
                <p><a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301867">Learn more &raquo;</a></p>
            </div>
        </div>*@


@ModelType LoginViewModel
@Code
    ViewData("Title") = "Login"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Login</h2>

<div class="row">
    <div class="col-md-8">
        <section id="loginForm">
            @Using Html.BeginForm("Login", "Account", New With {.ReturnUrl = ViewBag.ReturnUrl}, FormMethod.Post, New With {.class = "form-horizontal", .role = "form"})
                @Html.AntiForgeryToken()
                @<text>
                    <h4>Please Sign in with a MISys Account</h4>
                    <hr />
                    @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
                    <div class="form-group">
                        @Html.LabelFor(Function(m) m.UserName, New With {.class = "col-md-2 control-label"})
                        <div class="col-md-4">
                            @Html.TextBoxFor(Function(m) m.UserName, New With {.class = "form-control"})
                            @Html.ValidationMessageFor(Function(m) m.UserName, "", New With {.class = "text-danger"})
                        </div>
                    </div>
                    <div class="form-group">
                        @Html.LabelFor(Function(m) m.Password, New With {.class = "col-md-2 control-label"})
                        <div class="col-md-4">
                            @Html.PasswordFor(Function(m) m.Password, New With {.class = "form-control"})
                            @Html.ValidationMessageFor(Function(m) m.Password, "", New With {.class = "text-danger"})
                            @Html.ValidationMessageFor(Function(m) m.Message, "", New With {.class = "text-danger"})
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <input type="submit" value="Log in" class="btn btn-default" />
                        </div>
                    </div>
                </text>
            End Using
        </section>
    </div>
</div>