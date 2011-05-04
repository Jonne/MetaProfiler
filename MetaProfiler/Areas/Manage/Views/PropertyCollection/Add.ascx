<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<MetaProfiler.Areas.Manage.Models.Entities.PropertyCollection>" %>
<span>
    <%= Html.LabelFor(x => x.Name) %>
    <%= Html.TextBoxFor(x => x.Name) %>
</span>
