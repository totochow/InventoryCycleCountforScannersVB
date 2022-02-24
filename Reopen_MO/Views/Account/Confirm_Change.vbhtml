@ModelType Reopen_MO.MIMOH
@Code
    ViewData("Title") = "Change Status"
End Code

<h2>Change Status</h2>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()

    @<div class="form-horizontal">
    <h4>MO Details</h4>
    <h5>Please confirm if you would like to re-open the following MO:</h5>
    <hr />
    <table style="width:40%">
        <tr>
            <th>
                <b>@Html.LabelFor(Function(model) model.mohId)</b>
            </th>
            <td>
                @Html.DisplayFor(Function(model) model.mohId)
            </td>
        </tr>
        <tr>
            <th>
                <b>@Html.LabelFor(Function(model) model.descr)</b>
            </th>
            <td>
                @Html.DisplayFor(Function(model) model.descr)
            </td>
        </tr>
        <tr>
            <th>
                <b>@Html.LabelFor(Function(model) model.jobId)</b>
            </th>
            <td>
                @Html.DisplayFor(Function(model) model.jobId)
            </td>
        </tr>
        <tr>
            <th>
                <b>@Html.LabelFor(Function(model) model.locId)</b>
            </th>
            <td>
                @Html.DisplayFor(Function(model) model.locId)
            </td>
        </tr>
        <tr>
            <th>
                <b>@Html.LabelFor(Function(model) model.buildItem)</b>
            </th>
            <td>
                @Html.DisplayFor(Function(model) model.buildItem)
            </td>
        </tr>
        <tr>
            <th>
                <b>@Html.LabelFor(Function(model) model.bomItem)</b>
            </th>
            <td>
                @Html.DisplayFor(Function(model) model.bomItem)
            </td>
        </tr>
        <tr>
            <th>
                <b>@Html.LabelFor(Function(model) model.bomRev)</b>
            </th>
            <td>
                @Html.DisplayFor(Function(model) model.bomRev)
            </td>
        </tr>
        <tr>
            <th>
                <b>@Html.LabelFor(Function(model) model.endQty)</b>
            </th>
            <td>
                @Html.DisplayFor(Function(model) model.endQty)
            </td>
        </tr>
        <tr>
            <th>
                <b>@Html.LabelFor(Function(model) model.closeDt)</b>
            </th>
            <td>
                @Html.DisplayFor(Function(model) model.closeDt)
            </td>
        </tr>
    </table>
    <div class="form-group">
        <div class="col-md-offset-2 col-md-10">
            <a href='@Url.Action("ChangeStatus", "Account", New With {.mohId = Model.mohId})' class="btn btn-default">Confirm &raquo;</a>
        </div>
    </div>
</div>
End Using

    <div>
        @Html.ActionLink("Cancel - Back to List", "MO", New With {.Start_Date = "2010-01-01", .End_Date = "2099-12-31"})
    </div>
