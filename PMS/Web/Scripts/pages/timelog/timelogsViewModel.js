(function ($, pms) {

    var local = pms.timelogs;

    pms.timelogs.timelogsViewModel = function (options) {
        var self = this;
        this._dataManager = options.dataManager || new local.dataManager();

        this.isWeekPickerVisible = ko.observable(false);

        this.errorMsg = ko.observable();

        this.weekpicker = ko.observable();
        this.startDate = ko.observable();

        this.startDate.subscribe(function (newVal) {
            self._dataManager.getTimelogs({ startDate: newVal }, function (timelogs) {
                self.timelogs.removeAll();
                $.each(timelogs.timelogs, function (i, v) { 
                    self.timelogs.push(new pms.timelogs.timelogViewModel(v));
                });
            });
        });
        this.endDate = ko.observable();

        //this.timelogs = ko.observableArray(options.timelogs);
        this.deleteContent = ko.observable({ title: "" });

        this.timelogs = ko.observableArray();
        //$.each(options.timelogs, function (i, v) {
        //    self.timelogs.push(new pms.timelogs.timelogViewModel(v));
        //});

        //this.newTimelog = ko.observable(new pms.timelogs.timelogViewModel({}));

        this.isCreateOpen = ko.observable(false);
        this.isDeleteOpen = ko.observable(false);

        this.days = ['Mon', 'Tues', 'Wed', 'Thu', 'Fri', 'Sat', 'Sun'];

        this.openCreate = function () {
            this.isCreateOpen(true);
            //this._initForm();
        };

        this.openDelete = function (data) {
            self.deleteContent(data);
            self.isDeleteOpen(true);
        };

        this.submitCreate = function (form) {
            var formData = new FormData($(form)[0]);
            formData.append("startDate", self.startDate());

            self._dataManager.createTimelog(formData, function (response) {
                if (response.error)
                    self.errorMsg(response.error);
                else {
                    self.errorMsg("");
                    self.timelogs.push(new pms.timelogs.timelogViewModel(response));
                    //self.timelogs.push(response);
                    self.isCreateOpen(false);
                }
            });
        };
        this.submitEdit = function (form) {
            var formData = new FormData($(form)[0]);
            formData.append("startDate", self.startDate());
            self._dataManager.createTimelog(formData, function (response) {
                if (response.error)
                    self.errorMsg(response.error);
                else {
                    var item = $.grep(self.timelogs(), function (val) { return val.Id() == response.Id; })[0];
                    //self.timelogs.replace(item, response);
                    self.timelogs.replace(item, new pms.timelogs.timelogViewModel(response));
                    //self.isEditOpen(false);
                }
            });
        };
        this.deleteTimelog = function (id) {
            self._dataManager.deleteTimelog(id, function (response) {
                var item = $.grep(self.timelogs(), function (val) { return val.Id() == response.id; })[0];
                self.timelogs.remove(item);
                self.isDeleteOpen(false);
            });
        };
        this.clean = function () {
            self.errorMsg("");
        };

    };
})($, pms);