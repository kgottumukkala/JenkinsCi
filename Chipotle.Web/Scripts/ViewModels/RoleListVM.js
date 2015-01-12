var urlPath = window.location.pathname;


var selectedRoleId;
$(function () {
    
    ko.applyBindings(RoleListVM);
    RoleListVM.gridParams.selectedPageSize.subscribe(changePageSize);
    RoleListVM.getRoles();
        
});

//View Model
var RoleListVM = {

    BaseUrl: './GetRoles',
    Roles: ko.observableArray([]),
    

    
    pageNumChanged: function (event) {
        
        this.getRoles();
    },
    gridParams: {
        pageSizeOptions: ko.observableArray(["10", "15", "20"]),
        selectedPageSize: ko.observable("10"),
        currentPageSize: ko.observable("10"),
        totalPages: ko.observable(0),
        pageNum: ko.observable(1),
        totalRows: ko.observable(0)
    },
    
    getRoles: function () {
        
        var self = this;
        $.ajax({
            type: "GET",
            url: self.getUrl(),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                self.gridParams.totalRows(data.totalRows);
                
                self.gridParams.totalPages(Math.ceil(data.totalRows / self.gridParams.currentPageSize()));
                self.Roles(data.result); //Put the response in ObservableArray
            },
            error: function (err) {
                alert(err.status + " : " + err.statusText);
            }
            
        });
    },

    getUrl: function () {
        //this.selectedPageSize = ko.observable($('#pageSize option.selected').text());
        //console.log(this.gridParams.selectedPageSize());
        var size = this.gridParams.currentPageSize(); //$('#pageSize option.selected').text();
        var pageNum = this.gridParams.pageNum();

        console.log("pagesize: "+size);
        var url = this.BaseUrl + '/?pageSize=' + this.gridParams.currentPageSize() + '&pageNum=' + pageNum;
        console.log("Url: " + url);
        return url;
    },
    
        
    
    

};

self.flipPage = function (newPageNum) {
    var self = RoleListVM;
    if (self.gridParams.pageNum() != newPageNum) {
        self.gridParams.pageNum(newPageNum);
        self.getRoles();
    }
};

self.changePageSize = function () {
    var self = RoleListVM;
    if (self.gridParams.currentPageSize() != self.gridParams.selectedPageSize()) {
        self.gridParams.currentPageSize(self.gridParams.selectedPageSize());
        self.getRoles();
    }
};


self.editRole = function () {
    if (selectedRoleId == undefined || selectedRoleId == null) {
        alert("Select any row to edit");

    }
    else {
        window.location.href = '../Role/Edit/' + selectedRoleId;
    }
};
self.deleteRole = function (role) {
    if (selectedRoleId == undefined || selectedRoleId == null) {
        alert("Select any row to delete");

    }
    else {
        window.location.href = '../Role/Delete/' + selectedRoleId;
    }
};
self.selectRow = function (role) {


    var tr = $('#roleGrid').find('tr');
    tr.removeClass('grid-selected-row');
    if ((selectedRoleId == undefined || selectedRoleId != null) && selectedRoleId != role.RoleId) {
        var tds = $('#' + role.RoleId).addClass('grid-selected-row').find('td');
        //alert($(this).prop("tagName"));
        selectedRoleId = role.RoleId;
        //alert(selectedRoleId);
    }
    else {
        selectedRoleId = undefined;
    }

};

//Model
function Roles(data) {
      
    this.RoleId = ko.observable(data.RoleId);
    this.Title = ko.observable(data.Title);
    this.Description = ko.observable(data.Description);
    this.IsEnabled = ko.observable(data.IsEnabled);
}