(function ($, pms) {

    var local = pms.projects;

    pms.projects.projectsViewModel = function (options) {
        var self = this;
        this.startDateDom = "#StartDate";
        this._dataManager = options.dataManager || new local.dataManager();
        this.options = options;
        this.errorMsg = ko.observable("");

        this.isCreateOpen = ko.observable(false);
        this.isEditOpen = ko.observable(false);
        this.isDeleteOpen = ko.observable(false);
        this.isPMOpen = ko.observable(false);

        this.projectMembers = ko.observable();//new pms.projects.projectMembersViewModel({});

        this.editContent = ko.observable({});
        this.deleteContent = ko.observable({ Name: "", StartDate: "", Status: "" });
        this.statuses = [{ statusId: 0, statusName: "Open" }, { statusId: 1, statusName: "In Progress" }, { statusId: 2, statusName: "Complete" }];

        this.projects = ko.observableArray(options.projects);

        this.openCreate = function () {
            this.isCreateOpen(true);
            this._initForm();
        };
        this.openDelete = function (data) {
            self._dataManager.getProjectJson(data, function (json) {
                self.deleteContent(json);
                self.isDeleteOpen(true);
            });
        };
        this.openEdit = function (data) {
            self._dataManager.getProjectJson(data, function (json) {
                self.editContent(json);
                self.isEditOpen(true);
                self._initForm();
            });

        };
        this.openPM = function (data) {
            self._dataManager.getProjectMembers(data, function (json) {
                self.projectMembers(new pms.projects.projectMembersViewModel(json));
                self.isPMOpen(true);
                self.projectMembers().init();
            });
        };

        this.deleteProject = function (id) {
            self._dataManager.deleteProject(id, function (response) {
                var item = $.grep(self.projects(), function (val) { return val.Id == response.id; })[0];
                self.projects.remove(item);
                self.isDeleteOpen(false);

            });
        };

        this.submitCreate = function (form) {
            var formData = new FormData($(form)[0]);
            self._dataManager.createProject(formData, function (response) {
                if (response.error)
                    self.errorMsg(response.error);
                else {
                    self.projects.push(response);
                    self.isCreateOpen(false);
                }
            });
        };
        this.submitEdit = function (form) {
            var formData = new FormData($(form)[0]);
            self._dataManager.editProject(formData, function (response) {
                if (response.error)
                    self.errorMsg(response.error);
                else {
                    var item = $.grep(self.projects(), function (val) { return val.Id == response.Id; })[0];
                    self.projects.replace(item, response);
                    //self.project(self.project()[0]);
                    self.isEditOpen(false);
                }
            });
        };
        this.submitPM = function (form) {
            var projectId = $("#Id", form).val();
            var users = $("select", form).val();
            self._dataManager.saveProjectMembers({projectId: projectId, users: users.join()}, function (response) {
                if (response.error)
                    self.errorMsg(response.error);
                else {
                    self.isPMOpen(false);
                }
            });
        };

        this._initForm = function () {
            initProjectValidate();
            initStartDate(this.startDateDom);
        }

    };
})($, pms);