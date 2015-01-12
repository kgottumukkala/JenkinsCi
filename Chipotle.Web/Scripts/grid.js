var gridLayout = function (entityName, modelName, containerId, tableId, columns, dataFields, addToolBar, addFooter, actionUrls, selectRowEvent, keyName) {
    var gridHtml = $("<div id='grid'></div>");
    
    if(addToolBar){
    
        var gridToolBar = $("<div class='grid-toolbar'></div>");
        //$.append(gridToolBar);
        gridToolBar.append("<a href='"+actionUrls["Create"]+">Create "+entityName+"</a>");
        gridToolBar.append("<a href='"+actionUrls["Edit"]+">Edit "+entityName+"</a>");
        gridToolBar.append("<a href='"+actionUrls["Delete"]+">Delete "+entityName+"</a>");
        gridHtml.append(gridToolBar);
    }
    if (columns.length > 0 && dataFields.length > 0) {
        var tblHtml = $("<table id='"+tableId+"'></table>");
        var tblHeader = $("<thead class='grid-header'></thead>");
        for (var i = 1; i <= columns.length; i++) {
            
                tblHeader.append("<th>" + columns[i] + "</th>");
            

        }
        
        var tblBody = $("<tbody data-bind=\"foreach: " + modelName + "\"></tbody>");
        var tRow;
        if (selectRowEvent != undefined) {
            tRow = $("<tr data-dind=\"attr: {id: " + keyName + "}, click: " + selectRowEvent + " \"></tr>");
        }
        else {
            tRow = $("<tr></tr>");
        }
            

        for (var j = 1; j <= dataFields.length; j++) {
            
            tRow.append("<td data-dind=\"text: "+dataFields[j]+"\"></td>");
        }
        tblBody.append(tRow);
        tblHtml.append(tblHeader);
        tblHtml.append(tblBody);
    }
    gridHtml.append(tblHtml);
    var container = $("#"+containerId);
    container.append(gridHtml);
    //$(function () {

        ko.applyBindings(RoleListVM);
        RoleListVM.getRoles();

    //});
    //$.parseHTML(container);

}
