(function ($, pms) {

    var local = pms.projects;

    pms.users.userViewModel = function(options) {
       // this._dataManager = options.dataManager || new local.dataManager();
        this.options = options;

        this.birthday = ko.observable();

    };
})($, pms);