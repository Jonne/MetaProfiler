<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Manage/Shared/Manage.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MetaProfiler.Areas.Manage.Models.Entities.PropertyCollection>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">

        $(document).ready(function() {
            $("#addPropertyCollectionModalPopup").dialog({
                autoOpen: false,
                title: 'Voeg gegevensverzameling toe',
                modal: true,
                height: 600,
                open: function(event, ui) {
                    $(this).load('<%= Url.Action("Add") %>');
                },
                buttons: {
                    "Close": function() {
                        $(this).dialog("close");
                    }
                }
            });
        
            $('#addPropertyCollection').click(function() {
                $('#addPropertyCollectionModalPopup').dialog('open');
            });
        });
    
    </script>
    
    <h2>Index</h2>
    
    <table>
        <thead>
            <tr>
                <th>Name</th>
            </tr>
        </thead>
        <tbody>
            <% foreach(MetaProfiler.Areas.Manage.Models.Entities.PropertyCollection collection in Model){ %>
            
            <tr>
                <td><%= collection %></td>
            </tr>
            
            <%} %>
        </tbody>
    </table>
    
    <a href="#" id="addPropertyCollection">Voeg gegevens verzameling toe</a>
    
    <div id="addPropertyCollectionModalPopup"></div>

</asp:Content>
