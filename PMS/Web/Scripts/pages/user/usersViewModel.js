﻿(function ($, pms) {

    var local = pms.users;

    pms.users.usersViewModel = function (options) {
        var self = this;
        this._dataManager = new local.dataManager();
        this.options = options;

        this.isCreateOpen = ko.observable(false);
        this.isEditOpen = ko.observable(false);
        this.isDeleteOpen = ko.observable(false);

        this.createContent = ko.observable("");
        this.editContent = ko.observable("");
        this.deleteContent = ko.observable("");

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
            this._dataManager.getDeleteForm(data, function (content) {
                self.deleteContent(content);
            });
            this.isDeleteOpen(true);
        };

    };
})($, pms);