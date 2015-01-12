var urlPath = window.location.pathname;

var getRoleId = function () { // parse for RoleId from url
    var array = window.location.href.split('/');
    var roleId = array[array.length - 1];
    return roleId;
};


var EditRole = {};

// View model declaration
EditRole.initViewModel = function (role) {
    var roleViewModel = {
        RoleId: ko.observable(role.RoleId),
        Title: ko.observable(role.Title),
        Description: ko.observable(role.Description),
        IsEnabled: ko.observable(role.IsEnabled)
    };
    return roleViewModel;
}

// Bind the customer
EditRole.bindData = function (role) {
    // Create the view model
    var viewModel = EditRole.initViewModel(role);

    ko.applyBindings(viewModel);
}

EditRole.getRole = function () {

    $.ajax({
        url: "/Role/Details/" + getRoleId(),
        type: 'Get',
        contentType: 'application/json',
        success: function (result) {
            EditRole.bindData(result);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            var errorMessage = '';
            $('#message').html(jqXHR.responseText);
        }
    });
}

EditRole.saveRole = function () {
    $.ajax({
        url: "/Role/Edit/",
        type: 'post',
        data: ko.toJSON(this),
        contentType: 'application/json',
        success: function (result) {

            window.location.href = '../../Role/';
        },
        error: function (err) {
            alert(err.responseText);
            window.location.href = '../../Role/';
        },
        complete: function () {
            window.location.href = '../../Role/';
        }
    });
}


$(document).ready(function () {
    EditRole.getRole();

});