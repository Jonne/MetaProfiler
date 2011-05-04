<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<MetaProfiler.Code.PropertyTypes.ListSettings>" %>

<script type="text/javascript">
    $(document).ready(function() {
        $('#addOption').click(function() {
            var index = $('#options tbody tr').length;

            var nameOfGeneratedOption = $('#options input:first-child').attr('name');
            var namePartWithoutIndexer = nameOfGeneratedOption.substring(0, nameOfGeneratedOption.lastIndexOf('['));
            var newOptionName = namePartWithoutIndexer + '[' + index + ']';

            $('#options tbody').append('<tr>' +
                    '<td><input type=\'text\' name=\'' + newOptionName + '.Name' + '\'/></td>' +
                    '<td><input type=\'text\' name=\'' + newOptionName + '.Value' + '\'/></td>' +
                '</tr>');
        });

        $('.removeOption').live('click', function() {
            $(this).closest('tr').remove();
        });
    });

</script>

<fieldset>
    <legend>Lijst</legend>
    <%= Html.DropDownListFor(x => x.Type, Enum.GetNames(typeof(MetaProfiler.Code.PropertyTypes.ListType)).Select(y => new SelectListItem { Value = y, Text = y }))%>
    <table id="options">
        <thead>
            <tr>
                <th>
                    Naam
                </th>
                <th>
                    Waarde
                </th>
                <th></th>
            </tr>
        </thead>
        <tbody>
            <% if (Model == null || !Model.Options.Any())
               { %>
            <tr>
                <td>
                    <%= Html.TextBox("Options[0].Name")%>
                </td>
                <td>
                    <%= Html.TextBox("Options[0].Value")%>
                </td>
                <td><a href="#" class="removeOption">Verwijderen</a></td>
            </tr>
            <%}
               else
               { %>
            <% for (int index = 0; index < Model.Options.Count; index++)
               { %>
            <tr>
                <td>
                    <%= Html.TextBox("Options[" + index + "].Name", Model.Options[index].Name)%>
                </td>
                <td>
                    <%= Html.TextBox("Options[" + index + "].Value", Model.Options[index].Value)%>
                </td>
                <td><a href="#" class="removeOption">Verwijderen</a></td>
            </tr>
            <%}
               }%>
        </tbody>
    </table>
    <a id="addOption" href="#">Toevoegen</a>
</fieldset>
