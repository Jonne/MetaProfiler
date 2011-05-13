<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Manage/Shared/Manage.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MetaProfiler.Areas.Manage.Models.Entities.Article>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Artikelen
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Artikelen</h2>

    <table>
        <tr>
            <th>Name</th>
            <th></th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.Encode(item.Name) %>
            </td>
            <td>
                <%= Html.ActionLink("Bewerken", "Edit", new { id=item.Id}) %> |
                <%= Html.ActionLink("Verwijderen", "Delete", new { id=item.Id})%>
            </td>            
        </tr>
    
    <% } %>

    </table>

    <p>
        <%= Html.ActionLink("Toevoegen", "Create") %>
    </p>

</asp:Content>
