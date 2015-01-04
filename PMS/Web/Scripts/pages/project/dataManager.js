(function ($, pms) {
    pms.projects = pms.projects || {};
    pms.projects.dataManager = function () { };

    $.extend(pms.projects.dataManager.prototype, {
        getProjects: function (callback) {
            return $.getJSON(pms.projects.dataManager.urls.getProjects, callback);
        },
    });

})($, pms);