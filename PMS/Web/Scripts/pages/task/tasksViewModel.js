(function ($, pms) {

    var local = pms.tasks;

    pms.tasks.tasksViewModel = function (options) {
        var self = this;
        this.startDateDom = "#StartDate";
        this._dataManager = options.dataManager || new local.dataManager();
        this.options = options;
        this.errorMsg = ko.observable("");

        this.isCreateOpen = ko.observable(false);
        this.isEditOpen = ko.observable(false);
        this.isDeleteOpen = ko.observable(false);

        this.projectId = ko.observable(options.projectId);

        //this.taskMembers = ko.observable();//new pms.tasks.taskMembersViewModel({});

        this.editContent = ko.observable({});
        this.deleteContent = ko.observable({ Name: "", StartDate: "", Status: "" });
        this.statuses = [{ statusId: 0, statusName: "Open" }, { statusId: 1, statusName: "In Progress" }, { statusId: 2, statusName: "Complete" }];

        this.tasks = ko.observableArray(options.tasks);

        this.openCreate = function () {
            this.isCreateOpen(true);
            this._initForm();
        };
        this.openDelete = function (data) {
            self._dataManager.getTaskJson(data, function (json) {
                self.deleteContent(json);
                self.isDeleteOpen(true);
            });
        };
        this.openEdit = function (data) {
            self._dataManager.getTaskJson(data, function (json) {
                self.editContent(json);
                self.isEditOpen(true);
                self._initForm();
            });

        };
        //this.openPM = function (data) {
        //    self._dataManager.getTaskMembers(data, function (json) {
        //        self.taskMembers(new pms.tasks.taskMembersViewModel(json));
        //        self.isPMOpen(true);
        //        self.taskMembers().init();
        //    });
        //};

        this.deleteTask = function (id) {
            self._dataManager.deleteTask(id, function (response) {
                var item = $.grep(self.tasks(), function (val) { return val.Id == response.id; })[0];
                self.tasks.remove(item);
                self.isDeleteOpen(false);
            });
        };

        this.submitCreate = function (form) {
            var formData = new FormData($(form)[0]);
            self._dataManager.createTask(formData, function (response) {
                if (response.error)
                    self.errorMsg(response.error);
                else {
                    self.tasks.push(response);
                    self.isCreateOpen(false);
                }
            });
        };
        this.submitEdit = function (form) {
            var formData = new FormData($(form)[0]);
            self._dataManager.editTask(formData, function (response) {
                if (response.error)
                    self.errorMsg(response.error);
                else {
                    var item = $.grep(self.tasks(), function (val) { return val.Id == response.Id; })[0];
                    self.tasks.replace(item, response);
                    //self.task(self.task()[0]);
                    self.isEditOpen(false);
                }
            });
        };
        //this.submitPM = function (form) {
        //    var taskId = $("#Id", form).val();
        //    var users = $("select", form).val();
        //    self._dataManager.saveTaskMembers({taskId: taskId, users: users.join()}, function (response) {
        //        if (response.error)
        //            self.errorMsg(response.error);
        //        else {
        //            self.isPMOpen(false);
        //        }
        //    });
        //};

        this._initForm = function () {
            initTaskValidate();
            initStartDate(this.startDateDom);
        }

    };
})($, pms);