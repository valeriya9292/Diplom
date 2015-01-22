(function ($, pms) {
    pms.projects = pms.projects || {};
    pms.projects.dataManager = function () { };

    $.extend(pms.projects.dataManager.prototype, {
        createProject: function (data, callback) {
            return $.ajax({
                url: pms.projects.dataManager.urls.createProject,
                type: 'POST',
                data: data,
                async: false,
                success: callback,
                error: callback,
                cache: false,
                contentType: false,
                processData: false
            });
        },
       
        getProjects: function (callback) {
            return $.getJSON(pms.projects.dataManager.urls.getProjects, callback);
        },
        getProjectJson: function (data, callback) {
            return $.get(pms.projects.dataManager.urls.getProjectJson, data, callback);
        },
        getProjectMembers: function (data, callback) {
            return $.get(pms.projects.dataManager.urls.getProjectMembers, data, callback);
        },
        deleteProject: function (data, callback) {
            $.get(pms.projects.dataManager.urls.deleteProject, data, callback);
        },
        editProject: function (data, callback) {
            return $.ajax({
                url: pms.projects.dataManager.urls.editProject,
                type: 'POST',
                data: data,
                async: false,
                success: callback,
                error: callback,
                cache: false,
                contentType: false,
                processData: false
            });
        },
        saveProjectMembers: function (data, callback) {
            $.get(pms.projects.dataManager.urls.saveProjectMembers, data, callback);
        }
    });

})($, pms);