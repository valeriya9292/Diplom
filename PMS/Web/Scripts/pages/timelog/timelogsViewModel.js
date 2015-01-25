(function ($, pms) {

    var local = pms.timelogs;

    pms.timelogs.timelogsViewModel = function (options) {
        var self = this;
        this._dataManager = options.dataManager || new local.dataManager();

        this.isWeekPickerVisible = ko.observable(false);
        this.errorMsg = ko.observable();

        this.weekpicker = ko.observable();
        this.startDate = ko.observable();
        this.endDate = ko.observable();

        this.timelogs = ko.observableArray(options.timelogs);
        //$.each(options.timelogs, function (i, v) {
        //    self.timelogs.push(new pms.timelogs.timelogViewModel(v));
        //});

        //this.newTimelog = ko.observable(new pms.timelogs.timelogViewModel({}));

        this.isCreateOpen = ko.observable(false);

        this.days = ['Mon', 'Tues', 'Wed', 'Thu', 'Fri', 'Sat', 'Sun'];

        this.openCreate = function() {
            this.isCreateOpen(true);
            //this._initForm();
        };

        this.openEdit = function (data) {
            self._dataManager.getTaskJson(data, function (json) {
                self.editContent(json);
                self.isEditOpen(true);
                self._initForm();
            });
        };

        this.submitCreate = function (form) {
            var formData = new FormData($(form)[0]);
            formData.append("startDate", self.startDate());

            self._dataManager.createTimelog(formData, function (response) {
                if (response.error)
                    self.errorMsg(response.error);
                else {
                    self.errorMsg("");
                    self.timelogs.push(response);
                    self.isCreateOpen(false);
                }
            });
        };
        this.clean = function() {
            self.errorMsg("");
        };

    };
})($, pms);