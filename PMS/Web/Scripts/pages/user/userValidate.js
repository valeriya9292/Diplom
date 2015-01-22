var initUserValidate = function () {
    $("#createForm").validate({

        rules: {
            FirstName: {
                required: true
            },

            LastName: {
                required: true
            },
            Login: {
                required: true
            },
            Password: {
                required: true,
                minlength: 6,
                maxlength: 16
            },
            ConfirmPassword: {
                required: true,
                minlength: 6,
                maxlength: 16,
                equalTo: "#Password"
            },
            Email: {
                email: true
            },
            Birthday: {
            },
            Phone: {
            },
            Skype: {
            },
            Role: {
                required: true
            },
            Avatar: {

            },
        },

        messages: {
            FirstName: {
                required: "First name is required",
            },

            LastName: {
                required: "Last name is required"
            },
            Login: {
                required: "Login is required",
            },
            Password: {
                required: "Password is required",
                minlength: "Min length is 6",
                maxlength: "Max length is 16",
            },
            ConfirmPassword: {
                required: "Password is required",
                minlength: "Min length is 6",
                maxlength: "Max length is 16",
                equalTo: "Passwords must match"
            },
            Email: {
                email: "Incorrect email"
            },
            Birthday: {
            },
            Phone: {
            },
            Skype: {
            },
            Role: {
                required: "Role is required",
            },
            Avatar: {
            }

        }

    });
}

var initDOBPicker = function (elem) {
    $(elem).datepicker({
        changeMonth: true,
        changeYear: true,
        yearRange: "1910:2015"
    });
}