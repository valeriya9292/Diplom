(function ($, ko, pms) {
    pms.users = pms.users || {};
    pms.users.dataManager = function () {};

    $.extend(pms.users.dataManager.prototype, {
        getCreateForm: function (callback) {
            return $.get(pms.users.dataManager.urls.getCreateForm, callback);
        },
        getEditForm: function (data, callback) {
            return $.get(pms.users.dataManager.urls.getEditForm, data, callback);
        },
        getUserJson: function (data, callback) {
            return $.get(pms.users.dataManager.urls.getUserJson, data, callback);
        },
        getUsersJson: function (callback) {
            return $.get(pms.users.dataManager.urls.getUsersJson, callback);
        },
        deleteUser: function (data, callback) {
            $.get(pms.users.dataManager.urls.deleteUser, data, callback);
        }
    });

})($, ko, pms);