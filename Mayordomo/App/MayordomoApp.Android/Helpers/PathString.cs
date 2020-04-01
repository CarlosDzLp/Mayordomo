using System;
using Xamarin.Forms;
using System.Threading.Tasks;
using MayordomoApp.Droid.Helpers;
using MayordomoApp.Helpers;

[assembly: Dependency(typeof(PathString))]
namespace MayordomoApp.Droid.Helpers
{
	public class PathString : IPath
	{
		public string FilePath()
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
