var urlPath = window.location.pathname;
$(function () {
    ko.applyBindings(UserListVM);
    UserListVM.getUsers();
});

//View Model
var UserListVM = {
    Users: ko.observableArray([]),
    getUsers: function () {
        var self = this;
        $.ajax({
            type: "GET",
            url: './GetUsers',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                self.Users(data); //Put the response in ObservableArray
            },
            error: function (err) {
                alert(err.status + " : " + err.statusText);
            }
        });
    },
};

self.editUser = function (user) {
    window.location.href = '/User/Edit/' + user.UserId;
};
self.deleteUser = function (user) {
    window.location.href = '/User/Delete/' + user.UserId;
};

//Model
function Users(data) {
    this.UserId = ko.observable(data.UserId);
    this.RoleId = ko.observable(data.RoleId);
    this.FirstName = ko.observable(data.FirstName);
    this.LastName = ko.observable(data.LastName);
    this.EmailId = ko.observable(data.EmailId);
    this.Password = ko.observable(data.Password);
    this.IsActive = ko.observable(data.IsActive);
    this.IsLoggedIn = ko.observable(data.IsLoggedIn);
}