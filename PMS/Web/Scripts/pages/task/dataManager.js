(function ($, pms) {
    pms.tasks = pms.tasks || {};
    pms.tasks.dataManager = function () { };

    $.extend(pms.tasks.dataManager.prototype, {
        createTask: function (data, callback) {
            return $.ajax({
                url: pms.tasks.dataManager.urls.createTask,
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

        getTasks: function (data, callback) {
            return $.getJSON(pms.tasks.dataManager.urls.getTasks, data, callback);
        },
        getTaskJson: function (data, callback) {
            return $.get(pms.tasks.dataManager.urls.getTaskJson, data, callback);
        },
        //getTaskMembers: function (data, callback) {
        //    return $.get(pms.tasks.dataManager.urls.getTaskMembers, data, callback);
        //},
        deleteTask: function (data, callback) {
            $.get(pms.tasks.dataManager.urls.deleteTask, data, callback);
        },
        editTask: function (data, callback) {
            return $.ajax({
                url: pms.tasks.dataManager.urls.editTask,
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
        //saveTaskMembers: function (data, callback) {
        //    $.get(pms.tasks.dataManager.urls.saveTaskMembers, data, callback);
        //}
    });

})($, pms);