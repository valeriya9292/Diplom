(function ($, pms) {

    var local = pms.projects;

    pms.projects.projectsViewModel = function(options) {
        this._dataManager = options.dataManager || new local.dataManager();
        this.options = options;

        this.projects = ko.observable(options.projects);

    };
})($, pms);