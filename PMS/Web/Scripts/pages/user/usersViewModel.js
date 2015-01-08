(function ($, pms) {

    var local = pms.users;

    pms.users.usersViewModel = function (users) {
        var self = this;
        this._dataManager = new local.dataManager();

        this.isCreateOpen = ko.observable(false);
        this.isEditOpen = ko.observable(false);
        this.isDeleteOpen = ko.observable(false);

        this.createContent = ko.observable("");
        this.editContent = ko.observable("");
        this.deleteContent = ko.observable({ FirstName: "", LastName: "", Role: "" });

        this.users = ko.observableArray(users);

        this.openCreate = function () {
            this._dataManager.getCreateForm(function (content) {
                self.createContent(content);
            });
            this.isCreateOpen(true);
        };

        this.openEdit = function (data) {
            this._dataManager.getEditForm(data, function (content) {
                self.editContent(content);
            });
            this.isEditOpen(true);
        };

        this.openDelete = function (data) {
            this._dataManager.getUserJson(data, function (json) {
                self.deleteContent(json);
            });
            this.isDeleteOpen(true);
        };

        this.deleteUser = function(id) {
            this._dataManager.deleteUser(id, function (response) {
                var item = $.grep(self.users(), function(val) { return val.id == response.id; })[0];
                self.users.remove(item);
                self.isDeleteOpen(false);

            });
        }
    };
})($, pms);