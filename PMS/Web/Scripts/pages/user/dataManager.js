(function ($, ko, pms) {
    pms.users = pms.users || {};
    pms.users.dataManager = function () { };

    $.extend(pms.users.dataManager.prototype, {
        createUser: function (data, callback) {
            return $.ajax({
                url: pms.users.dataManager.urls.createUser,
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
        getUserJson: function (data, callback) {
            return $.get(pms.users.dataManager.urls.getUserJson, data, callback);
        },
        getUsersJson: function (callback) {
            return $.get(pms.users.dataManager.urls.getUsersJson, callback);
        },
        deleteUser: function (data, callback) {
            $.get(pms.users.dataManager.urls.deleteUser, data, callback);
        },
        editUser: function (data, callback) {
            return $.ajax({
                url: pms.users.dataManager.urls.editUser,
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
    });

})($, ko, pms);