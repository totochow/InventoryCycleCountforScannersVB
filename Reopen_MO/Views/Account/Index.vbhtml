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