(function ($, pms) {
    pms.timelogs = pms.timelogs || {};
    pms.timelogs.dataManager = function () { };

    $.extend(pms.timelogs.dataManager.prototype, {
        createTimelog: function (data, callback) {
            return $.ajax({
                url: pms.timelogs.dataManager.urls.createTimelog,
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
        deleteTimelog: function (data, callback) {
            $.get(pms.timelogs.dataManager.urls.deleteTimelog, data, callback);
        }
       
    });

})($, pms);