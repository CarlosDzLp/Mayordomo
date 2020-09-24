using System;
using System.IO;
using Mayordomo.DataBases;
using Mayordomo.iOS.Helpers;
using Xamarin.Forms;

[assembly: Dependency(typeof(PathString))]
namespace Mayordomo.iOS.Helpers
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
