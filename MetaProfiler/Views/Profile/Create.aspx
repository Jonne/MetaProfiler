<%@ Import Namespace="MetaProfiler.Code" %>
<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MetaProfiler.Areas.Manage.Models.Entities.ProfileProperty>>" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Create</title>
</head>
<body>
    <div>
        <h2>Profiel toevoegen</h2>
        
        <% using (Html.BeginForm())
           {

               foreach (var property in Model)
               { %>
        
           <span>
                <% Html.RenderEditorFor(property); %>           
           </span>
        
        <%}%>
        
        <input type="submit" value="Opslaan" />
        
        <% }%>
    </div>
</body>
</html>
