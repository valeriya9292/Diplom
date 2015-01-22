(function ($, pms) {

    var local = pms.users;

    pms.users.userViewModel = function (user) {
        var self = this;
        this.data = user || {};

        this.Id = ko.observable(this.data.Id);
        this.FirstName = ko.observable(this.data.FirstName);
        this.LastName = ko.observable(this.data.LastName);
        this.Login = ko.observable(this.data.Login);
        this.Password = ko.observable(this.data.Password);
        this.ConfirmPassword = ko.observable(this.data.ConfirmPassword);
        this.Email = ko.observable(this.data.Email);
        this.Skype = ko.observable(this.data.Skype);
        this.Phone = ko.observable(this.data.Phone);
        this.Avatar = ko.observable(this.data.Avatar);
        this.Birthday = ko.observable(this.data.Birthday);
        this.Role = ko.observable(this.data.Role);

        this.setContent = function (content) {
            this.Id(content.Id);
            this.FirstName(content.FirstName);
            this.LastName(content.LastName);
            this.Login(content.Login);
            this.Password(content.Password);
            this.ConfirmPassword(content.ConfirmPassword);
            this.Email(content.Email);
            this.Skype(content.Skype);
            this.Phone(content.Phone);
            this.Avatar(content.Avatar);
            this.Birthday(content.Birthday);
            this.Role(content.Role);
        }

    };
})($, pms);