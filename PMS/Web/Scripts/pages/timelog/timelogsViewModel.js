(function ($, pms) {

    var local = pms.timelogs;

    pms.timelogs.timelogsViewModel = function (options) {
        var self = this;

        this.weekpicker = ko.observable();
        this.startDate = ko.observable();
        this.endDate = ko.observable();

        this.openEdit = function (data) {
            self._dataManager.getTaskJson(data, function (json) {
                self.editContent(json);
                self.isEditOpen(true);
                self._initForm();
            });

        };


    };
})($, pms);