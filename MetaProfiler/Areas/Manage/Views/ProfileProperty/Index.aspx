<%@ Page Language="C#" MasterPageFile="~/Areas/Manage/Shared/Manage.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MetaProfiler.Areas.Manage.Models.Entities.ProfileProperty>>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div>
    <h2>Profiel gegevens</h2>
    <table id="Properties">
        <thead>
            <tr>
                <th>Naam</th>
                <th>Type</th>
            </tr>
        </thead>
        <tbody>
    <% foreach(MetaProfiler.Areas.Manage.Models.Entities.ProfileProperty profileProperty in Model){  %>
        <tr>
            <td><%= profileProperty.Description %></td>
            <td><%= profileProperty.PropertyType %></td>
            <td><%= Html.ActionLink("Verwijderen", "Delete", new { Description = profileProperty.Description })%> </td>
        </tr>        
    <%} %>
        </tbody>
    </table>
    <%= Html.ActionLink("Toevoegen", "Add") %>
</div>
</asp:Content>
