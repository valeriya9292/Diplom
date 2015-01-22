(function ($, pms) {
    pms.timelogs = pms.timelogs || {};
    pms.timelogs.dataManager = function () { };

    $.extend(pms.timelogs.dataManager.prototype, {
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

        getTimelogs: function (data, callback) {
            return $.get(pms.timelogs.dataManager.urls.getTimelogs, data, callback);
        },
       
    });

})($, pms);