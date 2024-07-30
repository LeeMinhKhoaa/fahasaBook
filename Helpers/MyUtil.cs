using System.Text;

namespace EComereceMVC.Helpers
{
    public class MyUtil
    {
        public static string UploadHinh(IFormFile Hinh , string folder)
        {
            try
            {
                var fullpaht = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img",Hinh.FileName);
                using (var myfile = new FileStream(fullpaht, FileMode.CreateNew))
                {
                    Hinh.CopyTo(myfile);
                }
                return Hinh.FileName;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
        public  static string GenerateRandomKey(int lenght = 5)
        {
            var pattern = "qwertyuiopjkfanzbvzQWFNMANFCCQXJLKIIOP123545346<>?/|";
             var sb = new StringBuilder();
            var rd = new Random();
            for (int i = 0; i < lenght; i++)
            {
                sb.Append(pattern[rd.Next(0,pattern.Length)]);
            }
            return sb.ToString();
        }
    }
}
