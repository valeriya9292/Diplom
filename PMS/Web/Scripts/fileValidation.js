function GetFileSize(fileid) {
    try {
        var fileSize = 0;
        //for IE
        if ($.browser.msie) {
            //before making an object of ActiveXObject,
            //please make sure ActiveX is enabled in your IE browser
            var objFSO = new ActiveXObject("Scripting.FileSystemObject"); var filePath = $("#" + fileid)[0].value;
            var objFile = objFSO.getFile(filePath);
            var fileSize = objFile.size; //size in kb
            fileSize = fileSize / 1048576; //size in mb
        }
            //for FF, Safari, Opeara and Others
        else {
            fileSize = $("#" + fileid)[0].files[0].size; //size in kb
            fileSize = fileSize / 1048576; //size in mb
        }

        return fileSize;
    }
    catch (e) {
        alert("Error is :" + e);
    }
}

//get file path from client system
function getNameFromPath(strFilepath) {
    var objRE = new RegExp(/([^\/\\]+)$/);
    var strName = objRE.exec(strFilepath);

    if (strName == null) {
        return null;
    }
    else {
        return strName[0];
    }
}
$(function () {
    var validClass = "field-validation-valid";
    var invalidClass = "field-validation-error";
    var fileSize = 5;
    $("#Avatar").change(function () {
        var file = getNameFromPath($(this).val());
        if (file != null) {
            var extension = file.substr((file.lastIndexOf('.') + 1));
            switch (extension) {
                case 'jpg':
                case 'jpeg':
                case 'png':
                case 'gif':
                case 'bmp':
                    flag = true;
                    break;
                default:
                    flag = false;
            }
        }
        if (flag == false) {
            $(".lifile > span").removeClass(validClass).addClass(invalidClass).text("only jpg, jpeg, png, gif, bmp extension file");
            return false;
        }
        else {
            var size = GetFileSize('Avatar');
            if (size > fileSize) {
                $(".lifile > span").removeClass(validClass).addClass(invalidClass).text("file should be less then 5 MB");
                $(".formbutton").attr("disabled", "disabled");
            }
            else {
                $(".lifile > span").removeClass(invalidClass).addClass(validClass).text("");
                $(".formbutton").removeAttr("disabled");
            }
        }
    });
});