<%@ Import Namespace="MetaProfiler.Code" %>
<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<MetaProfiler.Areas.Manage.Models.EditProfile>" %>
<% using (Html.BeginForm())
   {%>
   
<fieldset>
    <legend>Algemeen</legend>
    <div class="editor-label">
        <%= Html.Label("Name") %>
    </div>
    <div class="editor-field">
        <% if (Model.Profile != null)
           { %>
            <%= Html.HiddenFor(model => model.Profile.Id) %>
            <%= Html.TextBox("Name", Model.Profile.Name)%>
        <%}
           else
           {%>
           <%= Html.TextBox("Name") %>
        <%} %>
    </div>
</fieldset>
<fieldset>
    <legend>Eigenschappen</legend>
    <%  foreach (var property in Model.Properties)
        { %>
    <% 
        if (Model.Profile != null && Model.Profile.Properties.ContainsKey(property.Description))
        {
            string value = Model.Profile.Properties[property.Description];
            Html.RenderEditorFor(property, value);
        }
        else
        {
            Html.RenderEditorFor(property);
        }
    %>
    <%}%>
</fieldset>
<input type="submit" value="Opslaan" />
<% }%>