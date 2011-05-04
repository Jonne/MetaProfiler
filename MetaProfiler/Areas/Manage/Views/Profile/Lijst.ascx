<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<MetaProfiler.Areas.Manage.Models.PropertyValue>" %>
<div class="editor-label">
<%= Model.Property.Description%>
</div>
<div class="editor-field">      
<%
    var listItems = ((MetaProfiler.Code.PropertyTypes.ListSettings)Model.Property.Details).Options
        .Select(x => new SelectListItem 
        { 
            Text = x.Name, 
            Value = x.Value, 
            Selected = Model.Value == x.Value 
        });
    
     %>

  
<% if (((MetaProfiler.Code.PropertyTypes.ListSettings)Model.Property.Details).Type == MetaProfiler.Code.PropertyTypes.ListType.Dropdownlist)
   {%>
   
<%= Html.DropDownList(Model.Property.Description, listItems)%>
<%}
   else
   { %>
    <%= Html.ListBox(Model.Property.Description, listItems)%>
   
<%} %>
</div> 
