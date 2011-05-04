<%@ Page Language="C#" MasterPageFile="~/Areas/Manage/Shared/Manage.Master" Inherits="System.Web.Mvc.ViewPage<MetaProfiler.Areas.Manage.Models.AddPropertyCollection>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">

        $(document).ready(function() {
            $("#addPropertyModalPopup").dialog({
                autoOpen: false,
                title: 'Voeg gegeven toe',
                modal: true,
                height: 600,
                open: function(event, ui) {
                    var index = $('#Properties > tbody tr').length;
                    $(this).load('<%= Url.Action("AddProperty")%>?Index=' + index);
                },
                buttons: {
                    "Sluiten": function() {
                        $(this).dialog("close");
                    },
                    "Toevoegen": function() {
                        var description = $('#Property_Description').val();
                        var type = $('#Property_PropertyType').val();
                        var index = $('#IndexInList').val();

                        var propertyValue = '<input type=\'hidden\' name=\'PropertyCollection.Properties[' + index + '].Description\' value=\'' + description + '\'/>';
                        propertyValue += '<input type=\'hidden\' name=\'PropertyCollection.Properties[' + index + '].PropertyType\' value=\'' + type + '\'/>';

                        $('#Properties > tbody:last').append('<tr><td>' + description + '</td><td>' + type + '</td><td style=\'display:none\'>' + propertyValue + '</td></tr>');
                        $('#Properties > tbody:last tr:last td:last').append($('#propertyDetails').children().clone());

                        $(this).dialog("close");
                    }
                }
            });

            $('#addProperty').click(function() {
                $('#addPropertyModalPopup').dialog('open');
            });
        });
    
    </script>
    <div>
        <h2>Voeg gegevens verzameling toe</h2>
    <% using(Html.BeginForm()){ %>
        <fieldset>
            <span>
                <%= Html.EditorFor(x => x.PropertyCollection.Name) %>
            </span>
            
            <table id="Properties">
                <thead>
                    <tr>
                        <td>Beschrijving</td>
                        <td>Soort</td>
                    </tr>
                </thead>
                <tbody>
                   
                </tbody>
            </table>
            
            
            <a href="#" id="addProperty">Voeg gegeven toe</a>

            <div id="propertySettingsEditor"></div>
            
            <input type="submit" value="Voeg toe"/>
        </fieldset>
    <%} %>
    </div>
    
    <div id="addPropertyModalPopup"></div>
</asp:Content>
