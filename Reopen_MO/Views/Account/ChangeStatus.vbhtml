﻿@ModelType Reopen_MO.MIMOH

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()

    @<div class="form-horizontal">
         <h4>MO @ViewData("mohId") have been re-opened successfully. </h4>
        <hr />
    </div>
End Using

<div>
    @Html.ActionLink("Back to List", "MO")
</div>
