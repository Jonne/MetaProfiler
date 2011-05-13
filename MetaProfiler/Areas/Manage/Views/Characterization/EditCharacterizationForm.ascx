<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<MetaProfiler.Areas.Manage.Models.EditCharacterization>" %>

<script src="../../../../Scripts/json2.js" type="text/javascript"></script>

<script type="text/javascript">

    $(document).ready(function() {
        $('.removeClause').live('click', function() {
            $(this).closest('tr').remove();
        });

        $('.addClause').click(function() {

            $.ajax({
                url: this.href,
                cache: false,
                success: function(html) { $('#clauses tbody').append(html); }
            });
            return false;
        });

        $('.runQuery').click(function() {
            $('#queryResults').html('<img src=\'/Content/Images/ajax-loader.gif\'/>');

            var query = [];

            $('#clauses tbody tr').each(function(index) {
                var andOr = $(this).find('.AndOr').val();
                var property = $(this).find('.PropertyName').val();
                var operator = $(this).find('.Operator').val();
                var value = $(this).find('.Value').val();

                query.push({ AndOr: andOr, PropertyName: property, Operator: operator, Value: value });
            });

            $.ajax({
                contentType: "application/json; charset=utf-8",
                type: "POST",
                url: this.href,
                data: JSON.stringify({ query: query }),
                success: function(result) {
                    $('#queryResults').html(result);
                },
                error: function(result) {
                    $('#queryResults').html(result);
                }
            });

            return false;
        });
    });
</script>

<% using (Html.BeginForm())
   {
       if (Model.Characterization != null)
       { 
%>
<%= Html.HiddenFor(model => model.Characterization.Id) %>
<%} %>
<fieldset>
    <legend>Algemeen</legend>
    <div class="editor-label">
        <%= Html.LabelFor(model => model.Characterization.Name)%>
    </div>
    <div class="editor-field">
        <%= Html.TextBoxFor(model => model.Characterization.Name) %>
    </div>
</fieldset>
<table id="clauses">
    <thead>
        <tr>
            <td>
                En/of
            </td>
            <td>
                Eigenschap
            </td>
            <td>
                Operator
            </td>
            <td>
                Waarde
            </td>
            <td>
            </td>
        </tr>
    </thead>
    <tbody>
        <% if (Model.Characterization == null || Model.Characterization.Clauses == null)
           {
               Html.RenderPartial("Clause", new MetaProfiler.Areas.Manage.Models.Entities.Clause(), new ViewDataDictionary { { "PropertyNames", Model.PropertyNames } }
);
           }
           else
           { %>
        <% foreach (MetaProfiler.Areas.Manage.Models.Entities.Clause clause in Model.Characterization.Clauses)
           {  %>
        <% Html.RenderPartial("Clause", clause, new ViewDataDictionary { { "PropertyNames", Model.PropertyNames } }
); %>
        <%}
           }%>
    </tbody>
</table>
<%= Html.ActionLink("Conditie toevoegen", "NewClause", null, new { @class = "addClause" })%>
|
<%= Html.ActionLink("Bekijk resultaten", "RunQuery", null, new { @class = "runQuery" })%>
<br />
<input type="submit" value="Opslaan" />
<%} %>
<hr />
<div id="queryResults" />
