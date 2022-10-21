@ModelType IEnumerable(Of InventoryCycleCountforScannersVB.MIPIBH)
@Code
    ViewData("Title") = "Count Batches"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h1>@ViewData("vStartDate")</h1>
<h2>Current Open Inventory Batches</h2>
    <table class="table">
        <tr>
            <th>
                Batch Creator
            </th>
            <th>
                Batch Id
            </th>
            <th>
                Batch Type
            </th>
            <th>
                Batch Description
            </th>
            <th>
                Batch Created on...
            </th>
            <th>
                Batch Last Update...
            </th>
            <th>
                Batch Status
            </th>
            <th>
                View Batch Details
            </th>
        </tr>

        @For Each item In Model
            @<tr>
    <td>
        @Html.DisplayFor(Function(modelItem) item.userId)
    </td>
    <td>

        @Html.DisplayFor(Function(modelItem) item.batchId)

    </td>
    <td>
        @Html.DisplayFor(Function(modelItem) item.bType)
    </td>
    <td>
        @Html.DisplayFor(Function(modelItem) item.descr)
    </td>
    <td>
        @Html.DisplayFor(Function(modelItem) item.createdDt)
    </td>
    <td>
        @Html.DisplayFor(Function(modelItem) item.lstEditDt)
    </td>
    <td>
        @Html.DisplayFor(Function(modelItem) item.status)
    </td>
    <td>
        @Html.ActionLink("Details", "BatchDetails", New With {.batchId = item.batchId})
    </td>
</tr>
        Next

    </table>
