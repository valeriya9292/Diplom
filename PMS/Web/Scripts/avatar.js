$(document).ready(function() {
    $("#register-avatar").change(function () {
        $(this).blur().focus();
    });

    var maxSize = 52428800;
    $(".js-form").validate({
        rules: {
            file: {
                fileSize: maxSize,
                required: false
            }
        },
        errorClass: 'field-validation-error'
    });
    $.validator.addMethod('fileSize', function(value, element, param) {
        return (element.files[0].size <= param);
    }, "File must be less then " + maxSize / 1048576 + " MB!");
});
