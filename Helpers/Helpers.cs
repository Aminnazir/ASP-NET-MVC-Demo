using System.IO;
using System.Web;

namespace AspMVCDemo.Helpers
{
    public static class FileHelper
    {
        public static string SaveFile(HttpPostedFileBase file, string directory)
        {
            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(HttpContext.Current.Server.MapPath(directory), fileName);
                file.SaveAs(path);
                return path;
            }
            return null;
        }

        public static byte[] ReadFile(string path)
        {
            if (File.Exists(path))
            {
                return File.ReadAllBytes(path);
            }
            return null;
        }
    }
}