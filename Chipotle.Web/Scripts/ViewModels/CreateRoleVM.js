var urlPath = window.location.pathname;
$(function () {
    ko.applyBindings(CreateRoleVM);
});

var CreateRoleVM = {
    
    RoleId: 0,
    Title: ko.observable(),
    Description: ko.observable(),
    IsEnabled: ko.observable(),
    SaveRole: function () {
        $.ajax({
            url: '/Role/Create',
            type: 'post',
            dataType: 'json',
            data: ko.toJSON(this),
            contentType: 'application/json',
            success: function (result) {
                window.location.href = '../../Role/';
            },
            error: function (err) {
                if (err.responseText == "Creation Failed")
                { window.location.href = '../../Role'; }
                else {
                    
                }
            },
            complete: function () {
                
                window.location.href = '../../admin/Role/';
            }
        });
    }
};
