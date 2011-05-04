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
    });

</script>

<fieldset>
    <legend>Lijst</legend>
    <%= Html.DropDownListFor(x => x.Type, Enum.GetNames(typeof(MetaProfiler.Code.PropertyTypes.ListType)).Select(y => new SelectListItem { Value = y, Text = y }))%>
    <table id="options">
        <thead>
            <tr>
                <th>Naam</th>
                <th>Waarde</th>
            </tr>        
        </thead>
        <tbody>
            <tr>
                <td><%= Html.TextBox("Options[0].Name") %></td>
                <td><%= Html.TextBox("Options[0].Value") %></td>
            </tr>
        </tbody>
    </table>
    <a id="addOption" href="#">Toevoegen</a>
</fieldset>




