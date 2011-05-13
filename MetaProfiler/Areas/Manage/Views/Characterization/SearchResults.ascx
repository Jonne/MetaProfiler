<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<MetaProfiler.Areas.Manage.Models.Entities.Profile>>" %>
<h3>Matchende profielen</h3>
<% if (!Model.Any())
   { %>
   Geen resultaten gevonden
<%}
   else
   { %>
<table>
    <thead>
        <tr>
            <td>
                Name
            </td>
        </tr>
    </thead>
    <tbody>
        <% foreach (var profile in Model)
           {%>
        <tr>
            <td>
                <%=Html.ActionLink(profile.Name, "Edit", "Profile", new { id = profile.Id }, new { target = "_blank" })%>
            </td>
        </tr>
        <%} %>
    </tbody>
</table>
<%} %>