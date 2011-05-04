<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<MetaProfiler.Areas.Manage.Models.AddProperty>" %>

    <script type="text/javascript">
        $(document).ready(function() {
            $('.propertyTypeSelector').change(function() {
                $('#propertyDetails').load('/Manage/PropertyCollection/RenderDetails?name=' + $(this).val() + '&index=<%= Model.IndexInList %>');
            });
        });
    </script>

    <% using (Html.BeginForm()) {%>
        <%= Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Algemeen</legend>
            <%= Html.HiddenFor(model => model.IndexInList) %>            
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Property.Description) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Property.Description) %>
                <%= Html.ValidationMessageFor(model => model.Property.Description) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Property.PropertyType) %>
            </div>
            <div class="editor-field">
                <%= Html.DropDownListFor(model => model.Property.PropertyType, Model.AvailablePropertyTypes, new { @class = "propertyTypeSelector" })%>
                <%= Html.ValidationMessageFor(model => model.Property.PropertyType) %>
            </div>
        </fieldset>
        
        <legend>Details</legend>
        <fieldset>
            <div id="propertyDetails"/>
        </fieldset>

    <% } %>


