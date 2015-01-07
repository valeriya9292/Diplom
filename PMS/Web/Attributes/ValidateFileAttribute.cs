using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Attributes
{
    public class ValidateFileAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var maxContentLength = 1024*1024*3; //3 MB
            var allowedFileExtensions = new [] {".jpeg", ".jpg", ".gif", ".png", ".pdf"};

            var file = value as HttpPostedFileBase;

            if (file == null)
                return false;
            if (!allowedFileExtensions.Contains(file.FileName.Substring(file.FileName.LastIndexOf('.'))))
            {
                ErrorMessage = "Please upload Your Photo of type: " + string.Join(", ", allowedFileExtensions);
                return false;
            }
            if (file.ContentLength > maxContentLength)
            {
                ErrorMessage = "Your Photo is too large, maximum allowed size is : " +
                               (maxContentLength / 1024) + "MB";
                return false;
            }
            return true;
        }

    }
}