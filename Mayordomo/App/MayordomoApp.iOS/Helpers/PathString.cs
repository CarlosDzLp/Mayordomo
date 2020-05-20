using System;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.IO;
using MayordomoApp.iOS.Helpers;
using MayordomoApp.Helpers;
using MayordomoApp.DataBase;

[assembly: Dependency(typeof(PathString))]
namespace MayordomoApp.iOS.Helpers
{
    public class PathString : IPathBase
    {
        public string PathFile()
        {
            try
            {
                string docFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                string libFolder = System.IO.Path.Combine(docFolder, "..", "Library", "Databases");

                if (!Directory.Exists(libFolder))
                {
                    Directory.CreateDirectory(libFolder);
                }

                return Path.Combine(libFolder, "mayordomo.db3");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
