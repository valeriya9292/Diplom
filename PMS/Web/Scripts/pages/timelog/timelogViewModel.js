(function ($, pms) {

    var local = pms.timelogs;

    pms.timelogs.timelogViewModel = function (timelog) {

        var self = this;
        this.Id = ko.isObservable(timelog.Id);
        this.Title = ko.isObservable(timelog.Title);
        this.Week = ko.isObservable(timelog.Week);
        this.Year = ko.isObservable(timelog.Year);
        this.HoursInMonday = ko.isObservable(timelog.HoursInMonday);
        this.HoursInTuesday = ko.isObservable(timelog.HoursInTuesday);
        this.HoursInWednesday = ko.isObservable(timelog.HoursInWednesday);
        this.HoursInThursday = ko.isObservable(timelog.HoursInThursday);
        this.HoursInFriday = ko.isObservable(timelog.HoursInFriday);
        this.HoursInSaturday = ko.isObservable(timelog.HoursInSaturday);
        this.HoursInSunday = ko.isObservable(timelog.HoursInSunday);

    };
})($, pms);