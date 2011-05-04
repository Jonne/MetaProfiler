<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<MetaProfiler.Areas.Manage.Models.Entities.ProfileProperty>" %>
<div class="editor-label">
    <%= Model.Description %>
</div>
<div class="editor-field">        
    <%= Html.CheckBox(Model.Description) %>
</div>
