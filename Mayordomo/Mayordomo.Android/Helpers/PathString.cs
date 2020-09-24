using System;
using Mayordomo.DataBases;
using Mayordomo.Droid.Helpers;
using Xamarin.Forms;

[assembly: Dependency(typeof(PathString))]
namespace Mayordomo.Droid.Helpers
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
