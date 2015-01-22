(function ($, pms) {

    var local = pms.projects;

    pms.projects.projectMembersViewModel = function (options) {
        this.users = ko.observableArray(options.Users);
        this.selectedPM = ko.observableArray(options.ProjectMembers);
        this.dom = ".chosen-select";
        this.projectId = ko.observable(options.ProjectId);
        this.init = function () {
            $(this.dom).chosen({});
        }
    };
})($, pms);