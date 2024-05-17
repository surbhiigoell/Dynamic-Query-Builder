#pragma checksum "D:\QueryBuilder (3)\QueryBuilder\Views\querytemplate\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "995cbc0de8dbe369e41de1ff972afb003a5ba8db"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_querytemplate_Index), @"mvc.1.0.view", @"/Views/querytemplate/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"995cbc0de8dbe369e41de1ff972afb003a5ba8db", @"/Views/querytemplate/Index.cshtml")]
    public class Views_querytemplate_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\QueryBuilder (3)\QueryBuilder\Views\querytemplate\Index.cshtml"
  
    Layout = "~/Pages/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<link rel=""stylesheet"" type=""text/css"" href=""https://cdn.datatables.net/1.10.20/css/jquery.dataTables.min.css"" />
<script type=""text/javascript"" src=""https://cdn.datatables.net/1.10.20/js/jquery.dataTables.min.js""></script>
<link rel=""stylesheet"" type=""text/css"" href=""https://cdn.datatables.net/buttons/1.7.1/css/buttons.dataTables.min.css"" />
<script type=""text/javascript"" src=""https://cdn.datatables.net/buttons/1.7.1/js/dataTables.buttons.min.js""></script>
<script type=""text/javascript"" src=""https://cdnjs.cloudflare.com/ajax/libs/jszip/3.1.3/jszip.min.js""></script>
<script type=""text/javascript"" src=""https://cdn.datatables.net/buttons/1.7.1/js/buttons.html5.min.js""></script>

<style>
    body {
        background-color: #E5E5E5;
        top: 0;
        left: 0;
        width: 100%;
        height: 100%;
        background-size: cover;
        background-image: url(""https://images.unsplash.com/photo-1543286386-713bdd548da4?w=600&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZW");
            WriteLiteral(@"FyY2h8MTB8fHJlcG9ydHxlbnwwfHwwfHx8MA%3D%3D"");
    }

    /*container {
        position: relative;
        top: 0;
        left: 0;
        width: 100%;
        height: 100%;

        background-size: cover;
        z-index: -1;
    }*/

    .container {
        /*position: absolute;
        z-index: -21;*/
        background-color: #FFFFFF;
        padding: 20px;
        border-radius: 10px;
        box-shadow: 0px 0px 10px 0px rgba(0, 0, 0, 0.1);
        margin-top: 50px;
    }


    h1 {
        color: #4A154B;
        margin-top: 0;
    }

    table {
        margin-top: 20px;
    }

    th, td {
    }

    .flex {
        display: flex; /* Use flexbox layout */
        align-items: baseline; /* Align items vertically */
    }

    .flex-distance {
        justify-content: space-between;
    }

    .dist {
        margin-right: 10px;
    }

    label {
        color: #4A154B;
    }

    select {
        border: 1px solid #ccc;
        border-radius: ");
            WriteLiteral(@"5px;
    }

    button.btn-primary {
        background-color: #4A154B;
        border: none;
    }

        button.btn-primary:hover {
            background-color: #6F3489;
        }

    .btn-primary.dt-buttons {
        margin: 10px;
        color: white;
        border-radius: 5px;
    }

        .btn-primary.dt-buttons:hover {
            background-color: #6F3489 !important; /* Set hover color to match other buttons */
        }

    label {
        font-size: 140%;
    }

    h2 {
        text-align: center;
        padding: 20px 0;
    }

    table caption {
        padding: .5em 0;
    }

    table.dataTable th,
    table.dataTable td {
    }

    .input-box {
        display: flex;
        align-items: center; /* Align items vertically */
        border: 1px solid #ccc; /* Add border */
        border-radius: 5px; /* Add border radius */
        padding: 15px; /* Add padding */
        margin-left: 10px; /* Adjust margin as needed */
    }

    .p {
");
            WriteLiteral(@"        text-align: center;
        padding-top: 140px;
        font-size: 14px;
    }

    #resultTable {
        width: auto;
        border-collapse: collapse;
        border: 1px solid #ccc;
        font-family: ""Helvetica Neue"", Helvetica, Arial, sans-serif;
    }

        #resultTable th,
        #resultTable td {
            border: 1px solid #ccc;
            white-space: nowrap;
        }

        #resultTable th {
            background-color: #4A154B;
            color: white;
        }

        #resultTable tbody tr:nth-child(even) {
            background-color: #f2f2f2;
        }

        #resultTable tbody tr:hover {
            background-color: #ddd;
        }

    #resultdiv {
        overflow-x: auto; /* Add horizontal scrollbar when content overflows */
        /*max-width: 100%;*/ /* Ensure the div doesn't overflow its container */
        padding-bottom: 20px; /* Add some padding to prevent overlapping with the scrollbar */
    }

    .action-buttons ");
            WriteLiteral(@"{
        display: flex;
        padding: 5px;
        gap: 10px; /* Adjust the gap as needed */
    }
</style>

<div class=""container-fluid"">
    <h1 class=""mt-5"">Existing Templates</h1>
    <button type=""button"" id=""backButton"" class=""btn btn-primary"">Back</button>
    <table id=""templateTable"" class=""table table-bordered table-hover"">
        <thead>
            <tr>
                <th>Template Name</th>
                <th>Query</th>
                <th>Action</th>
            </tr>
        </thead>
        <tbody>
");
            WriteLiteral(@"        </tbody>
    </table>
</div>

<div id=""resultdiv"" class=""container-fluid"" style=""display: none"">
    <div class=""row"">
        <div class=""col-xs-12"">
            <div class=""my-2"">
                <h1 class=""mt-5"">Result</h1>
            </div>
            <table id=""resultTable"" class=""table table-bordered table-hover dt-responsive"">
                <thead id=""tableHeader"">
                </thead>
                <tbody id=""tableBody"">
                </tbody>
            </table>
        </div>
    </div>
</div>

<script>

    document.getElementById(""backButton"").addEventListener(""click"", function () {
        window.history.back(); // Go back to the original page
    });

    // Function to fetch existing templates and populate the table
    function fetchExistingTemplates() {
        // Replace the API endpoint with the actual endpoint for fetching existing templates
        let templateId = 1; // Or any other dynamic value
        fetch(`api/querytemplate/getallte");
            WriteLiteral(@"mplate/${templateId}`)
            .then(response => response.json())
            .then(data => {
                var templateTableBody = document.querySelector(""#templateTable tbody"");
                templateTableBody.innerHTML = """"; // Clear previous table body content
                data.forEach(template => {
                    var row = document.createElement(""tr"");
                    var tableNameCell = document.createElement(""td"");
                    tableNameCell.innerText = template.values.Name;
                    row.appendChild(tableNameCell);
                    var columnsCell = document.createElement(""td"");
                    columnsCell.innerText = template.values.Query;
                    row.appendChild(columnsCell);

                    var actionCell = document.createElement(""td"");
                    var actionButtonsDiv = document.createElement(""div"");
                    actionButtonsDiv.className = ""action-buttons"";
                    var goButton = document.cre");
            WriteLiteral(@"ateElement(""button"");
                    var deleteButton = document.createElement(""button"");
                    goButton.type = ""button"";
                    goButton.className = ""btn btn-primary"";
                    goButton.innerText = ""Go"";
                    deleteButton.type = ""button"";
                    deleteButton.className = ""btn btn-danger"";
                    deleteButton.innerText = ""Delete"";
                    goButton.addEventListener(""click"", function () {
                        fetch('api/querytemplate/getheader', {
                            method: 'POST',
                            headers: {
                                'Content-Type': 'application/json'
                            },
                            body: JSON.stringify(template.values.Query)
                        })
                            .then(response => response.json())
                            .then(data => {
                                if ($.fn.DataTable.isDataTable('table')");
            WriteLiteral(@") {
                                    $('table').DataTable().destroy();
                                }
                                document.getElementById(""resultdiv"").style.display = ""block"";
                                var tableHeader = document.getElementById(""tableHeader"");
                                var tableBody = document.getElementById(""tableBody"");
                                tableHeader.innerHTML = """";
                                tableBody.innerHTML = """"; // Clear previous table body content

                                // Split the string into an array of headers
                                var headers = data.columns.split(', ');

                                // Create a table header row
                                var headerRow = document.createElement(""tr"");

                                // Iterate over the headers array
                                headers.forEach(header => {
                                    // Create a table hea");
            WriteLiteral(@"der cell for each header
                                    var headerCell = document.createElement(""th"");
                                    headerCell.innerText = header; // Set the text content of the header cell
                                    headerRow.appendChild(headerCell); // Append the header cell to the header row
                                });

                                // Append the header row to the table header
                                tableHeader.appendChild(headerRow);

                                fetch(`api/querytemplate/gettemplate/${template.values.QueryTemplateId}`)
                                    .then(response => response.json())
                                    .then(data => {

                                        for (var i = 0; i < data.length; i++) {
                                            var rowData = data[i];
                                            var row = document.createElement(""tr""); // Create a new table row for ea");
            WriteLiteral(@"ch row of data
                                            for (var j = 0; j < rowData.length; j++) {
                                                var val = rowData[j];
                                                var cell = document.createElement(""td""); // Create a new table cell for each value
                                                cell.innerText = val; // Set the text content of the cell to the current value
                                                row.appendChild(cell); // Append the cell to the current row
                                            }
                                            tableBody.appendChild(row); // Append the row to the table body
                                        }
                                        // Destroy any existing DataTable instances
                                        if ($.fn.DataTable.isDataTable('#resultTable')) {
                                            $('#resultTable').DataTable().destroy();
                  ");
            WriteLiteral(@"                      }

                                        // Initialize DataTables for the result table only
                                        $('#resultTable').DataTable({
                                            dom: 'lBfrtip',
                                            buttons: [
                                                {
                                                    extend: 'excelHtml5',
                                                    text: 'Export to Excel',
                                                    className: 'btn btn-primary dt-buttons',
                                                    exportOptions: {
                                                        columns: ':visible'
                                                    }
                                                },
                                                {
                                                    extend: 'csvHtml5',
                                         ");
            WriteLiteral(@"           text: 'Export to CSV',
                                                    className: 'btn btn-primary dt-buttons',
                                                    exportOptions: {
                                                        columns: ':visible'
                                                    }
                                                }
                                            ],
                                            // Enable pagination
                                            paging: true,
                                            // Enable the search feature
                                            searching: true
                                        });
                                    });
                            });

                    });
                    deleteButton.addEventListener(""click"", function () {
                        // Confirm deletion
                        var confirmDelete = confirm(""Are you sure you");
            WriteLiteral(@" want to delete this template?"");
                        if (confirmDelete) {
                            // Perform deletion
                            fetch(`api/querytemplate/deletetemplate/?id=${template.values.QueryTemplateId}`, {
                                method: 'DELETE'
                            })
                                .then(response => {
                                    if (response.ok) {
                                        // Remove the row from the table if deletion is successful
                                        row.remove();
                                    } else {
                                        // Handle error cases if needed
                                        console.error('Error deleting template:', response.statusText);
                                    }
                                })
                                .catch(error => {
                                    console.error('Error deleting template:', error);");
            WriteLiteral(@"
                                });
                        }
                    });

                    actionButtonsDiv.appendChild(goButton);
                    actionButtonsDiv.appendChild(deleteButton);
                    row.appendChild(actionButtonsDiv);
                    templateTableBody.appendChild(row);
                });
            });
    }
    // Call the function to fetch existing templates when the page loads
    fetchExistingTemplates();

</script>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
