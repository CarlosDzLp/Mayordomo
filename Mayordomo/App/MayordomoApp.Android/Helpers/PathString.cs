using System;
using Xamarin.Forms;
using System.Threading.Tasks;
using MayordomoApp.Droid.Helpers;
using MayordomoApp.Helpers;
using MayordomoApp.DataBase;

[assembly: Dependency(typeof(PathString))]
namespace MayordomoApp.Droid.Helpers
{
	public class PathString : IPathBase
	{
        public string PathFile()
        {
			try
			{
				var path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
				return System.IO.Path.Combine(path, "mayordomo.db3");
			}
			catch (Exception ex)
			{
				return null;
			}
		}
    }
}
