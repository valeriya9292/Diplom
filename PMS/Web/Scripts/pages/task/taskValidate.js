var initTaskValidate = function () {
    $("#createForm").validate({
        rules: {
            Name: {
                required: true
            },
            StartDate: {
                required: true
            },
            Duration: {
            },
            Progress: {
            },
            Description: {
            }
        },

        messages: {
            Name: {
                required: "Name is required",
            },
            StartDate: {
                required: "Start Date is required"
            }
        }
    });
}

var initStartDate = function (elem) {
    $(elem).datepicker({
        //changeMonth: true,
        //changeYear: true,
        //yearRange: "1910:2015"
    });
}