(function ($, pms) {

    var local = pms.users;

    pms.users.usersViewModel = function (users) {
        this.birthdayDom = "#Birthday";
        var self = this;
        this._dataManager = new local.dataManager();
        this.errorMsg = ko.observable("");
        this.flag = ko.observable(Math.random()).extend({ notify: "always" });

        this.isCreateOpen = ko.observable(false);
        this.isEditOpen = ko.observable(false);
        this.isDeleteOpen = ko.observable(false);

        this.editContent = ko.observable({});
        this.deleteContent = ko.observable({ FirstName: "", LastName: "", Role: "" });

        this.users = ko.observableArray(users);
        this.roles = [{ roleId: 0, roleName: "Admin" }, { roleId: 1, roleName: "Project Manager" }, { roleId: 2, roleName: "User" }];

        this.user = ko.observable(this.users()[0]);

        this.openCreate = function () {
            this.isCreateOpen(true);
            this._initForm();
        };

        this.openEdit = function (data) {
            self._dataManager.getUserJson(data, function (json) {
                self.editContent(json);
                self.isEditOpen(true);
                self._initForm();
            });           
        };

        this.openDelete = function (data) {
            self._dataManager.getUserJson(data, function (json) {
                self.deleteContent(json);
                self.isDeleteOpen(true);
            });           
        };

        this.deleteUser = function(id) {
            self._dataManager.deleteUser(id, function (response) {
                var item = $.grep(self.users(), function(val) { return val.Id == response.id; })[0];
                self.users.remove(item);
                self.isDeleteOpen(false);

            });
        };
        this.submitCreate = function(form) {
            var formData = new FormData($(form)[0]);
            self._dataManager.createUser(formData, function (response) {
                if (response.error)
                    self.errorMsg(response.error);
                else {
                    self.users.push(response);
                    self.isCreateOpen(false);
                }
            });
        };
        this.submitEdit = function(form) {
            var formData = new FormData($(form)[0]);
            self._dataManager.editUser(formData, function (response) {
                if (response.error)
                    self.errorMsg(response.error);
                else {
                    var item = $.grep(self.users(), function (val) { return val.Id == response.Id; })[0];
                    self.flag(Math.random());
                    self.users.replace(item, response);
                    self.user(self.users()[0]);
                    self.isEditOpen(false);
                }
            });
        };
        this._initForm = function() {
            initUserValidate();
            initFileValidation();
            initDOBPicker(this.birthdayDom);
        }
    };
})($, pms);