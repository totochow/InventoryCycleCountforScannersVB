@Code
    ViewData("Title") = "About"
End Code

<h2><u>@ViewData("Title")</u></h2>
<h4>@ViewData("Message")</h4>

<p>
    This Application is for selected/allowed users to re-open closed MO.<br/>
    Currently, only the following user group(s) have access:<br/><br />


    @System.Configuration.ConfigurationManager.AppSettings("Allowed_Group")
</p>

