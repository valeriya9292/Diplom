(function ($, pms) {

    var local = pms.timelogs;

    pms.timelogs.timelogViewModel = function (timelog) {

        var self = this;
        this.isTimelogEditOpen = ko.observable(false);
        this.Id = ko.observable(timelog.Id);
        this.Title = ko.observable(timelog.Title);
        this.Week = ko.observable(timelog.Week);
        this.Year = ko.observable(timelog.Year);
        this.HoursInMonday = ko.observable(timelog.HoursInMonday);
        this.HoursInTuesday = ko.observable(timelog.HoursInTuesday);
        this.HoursInWednesday = ko.observable(timelog.HoursInWednesday);
        this.HoursInThursday = ko.observable(timelog.HoursInThursday);
        this.HoursInFriday = ko.observable(timelog.HoursInFriday);
        this.HoursInSaturday = ko.observable(timelog.HoursInSaturday);
        this.HoursInSunday = ko.observable(timelog.HoursInSunday);
        
    };
})($, pms);