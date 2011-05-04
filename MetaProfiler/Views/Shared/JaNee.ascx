<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<MetaProfiler.Areas.Manage.Models.Entities.ProfileProperty>" %>
<%= Model.Description %>
<%= Html.CheckBox(Model.Description) %>

