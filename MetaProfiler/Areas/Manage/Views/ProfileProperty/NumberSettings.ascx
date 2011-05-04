<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<MetaProfiler.Code.PropertyTypes.NumberSettings>" %>
<span>
    <%= Html.LabelFor(x => x.Type) %>
    <%= Html.DropDownListFor(x => x.Type, Enum.GetNames(typeof(MetaProfiler.Code.PropertyTypes.NumberType)).Select(y => new SelectListItem { Value = y, Text = y }))%>
</span>

<span>
    <%= Html.LabelFor(x => x.Length) %>
    <%= Html.TextBoxFor(x => x.Length) %>
</span>

