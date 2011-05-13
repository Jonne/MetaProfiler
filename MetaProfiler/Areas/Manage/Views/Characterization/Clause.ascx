<%@ Import Namespace="MetaProfiler.Code" %>
<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<MetaProfiler.Areas.Manage.Models.Entities.Clause>" %>
<tr>
<% using (Html.BeginCollectionItem("Characterization.Clauses"))
   { %>
    <td>
        <%= Html.DropDownListFor(model => model.AndOr,
            Enum.GetNames(typeof(MetaProfiler.Areas.Manage.Models.Entities.AndOr))
                           .Select(x => new SelectListItem { Text = x, Value = x }), 
                                   new { @class = "AndOr" })%>
    </td>
    <td>
        <%= Html.DropDownListFor(model => model.PropertyName, ((IEnumerable<string>)ViewData["PropertyNames"])
                                       .Select(x => new SelectListItem { Text = x, Value = x }),
                                                           new { @class = "PropertyName" })%>
    </td>
    <td>
        <%= Html.DropDownListFor(model => model.Operator, Enum.GetNames(typeof(MetaProfiler.Areas.Manage.Models.Entities.Operator))
                           .Select(x => new SelectListItem { Text = x, Value = x }),
                                               new { @class = "Operator" })%>
    </td>
    <td>
        <%= Html.TextBoxFor(model => model.Value, new { @class = "Value" })%>
    </td>
    <td>
    </td>
<%} %>    
</tr>
