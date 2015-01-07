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
        getDeleteForm: function (data, callback) {
            return $.get(pms.users.dataManager.urls.getDeleteForm, data, callback);
        },
    });

})($, ko, pms);