@ModelType IEnumerable(Of Reopen_MO.MIMOH)
@Code
    ViewData("Title") = "Login"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h1>@ViewData("vStartDate")</h1>
<h2>Current Closed MO</h2>
<p> <h3>Filters:</h3>
    @Using Html.BeginForm("MO", "Account", FormMethod.Get)
        @<p>
             <table style="width:50%">
                 <tr>
                     <th>MO Number:</th>
                     <td>@Html.TextBox("Search_mohId")</td>
                 </tr>
                 <tr>
                     <th>Description:</th>
                     <td>@Html.TextBox("Search_descr")</td>
                </tr>
                 <tr>
                     <th>JobId:</th><td>@Html.DropDownList("jobIdtxt", "ALL")</td>
                 </tr>
                 <tr>
                     <th>Location :</th><td> @Html.DropDownList("locIdtxt", "ALL")</td>
                </tr>
                 <tr>
                     <th>Build Item :  </th><td>@Html.TextBox("Search_buildItem")</td>
                </tr>
                <tr>
                     <th>Closed Date :  </th><td>From: <br />@Html.TextBox("Start_Date", ViewBag.vStartDate, New With {.type = "date"})</td><td> To:<br />@Html.TextBox("End_Date", ViewBag.vEndDate, New With {.type = "date"})</td>
                </tr>
                 <tr>
                     <th></th><td></td><td></td><td><input type="submit" value="Filter" /></td>
                 </tr>
                 </table>

                     
</p>
    End Using
    </p>
    <table class="table">
        <tr>
            <th>
                @Html.DisplayNameFor(Function(model) model.mohId)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.descr)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.jobId)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.locId)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.buildItem)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.bomItem)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.bomRev)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.endQty)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.closeDt)
            </th>
            <th></th>
        </tr>

        @For Each item In Model
            @<tr>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.mohId)
                </td>
                <td>
                    @If Not (item.buildNonItem) Then
                        @Html.DisplayFor(Function(modelItem) item.descr)
                    Else
                        @Html.DisplayFor(Function(modelItem) item.buildNonItemDesc)
                    End If
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.jobId)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.locId)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.buildItem)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.bomItem)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.bomRev)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.endQty)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.closeDt)
                </td>
                <td>
                    @Html.ActionLink("Re-Open", "Confirm_Change", New With {.mohId = item.mohId})
                </td>
            </tr>
        Next

    </table>
