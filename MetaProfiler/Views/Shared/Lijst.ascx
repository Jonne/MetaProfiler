<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<MetaProfiler.Areas.Manage.Models.Entities.ProfileProperty>" %>
<%= Model.Description %>
<% if (((MetaProfiler.Code.PropertyTypes.ListSettings)Model.Details).Type == MetaProfiler.Code.PropertyTypes.ListType.Dropdownlist)
   {%>
<%= Html.DropDownList(Model.Description, ((MetaProfiler.Code.PropertyTypes.ListSettings)Model.Details).Options.Select(x => new SelectListItem{ Text = x.Name, Value = x.Value})) %>
<%}
   else
   { %>
<%= Html.ListBox(Model.Description, ((MetaProfiler.Code.PropertyTypes.ListSettings)Model.Details).Options.Select(x => new SelectListItem{ Text = x.Name, Value = x.Value})) %>
<%} %>
