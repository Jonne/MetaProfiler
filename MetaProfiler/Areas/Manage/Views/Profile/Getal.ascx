<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<MetaProfiler.Areas.Manage.Models.PropertyValue>" %>
<div class="editor-label">
<%= Model.Property.Description%>
</div>
<div class="editor-field">
<%= Html.TextBox(Model.Property.Description, Model.Value) %>
</div>
