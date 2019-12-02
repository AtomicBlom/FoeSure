using System;
using System.IO;
using System.Linq;
using System.Reflection;
using FoeFrenzy.Main;

namespace FoeSure
{
	public class ModLoader
	{
		public static void Main(string[] args)
		{
			var program = typeof(GameImpl).Assembly.GetType("FoeFrenzy.Main.Program");
			var initLog = program.GetMethod("InitLog", BindingFlags.Static | BindingFlags.NonPublic);
			var fieldInfo = program.GetField("logStream", BindingFlags.Static | BindingFlags.NonPublic);
			var saveCrashReport = program.GetMethod("SaveCrashReport", BindingFlags.Static | BindingFlags.NonPublic);

			if (initLog == null || fieldInfo == null || saveCrashReport == null)
			{
				throw new Exception("ELLPECKINATOR. WHAT HAVE YOU DONE!?");
			}

			try
			{
				initLog.Invoke(null, new object[0]);
				using (var impl = new ModdedGameImpl(args))
				{
					if (Directory.Exists(@".\mods"))
					{
						foreach (var file in Directory.EnumerateFiles(@".\mods", "*.dll").Select(f => new FileInfo(f)))
						{
							var assembly = Assembly.LoadFile(file.FullName);
							foreach (var type in assembly.GetExportedTypes().Where(t => t.IsSubclassOf(typeof(FoeFrenzyMod))))
							{
								Activator.CreateInstance(type);
							}
						}
					}

					impl.Run();
				}
			}
			catch (Exception ex)
			{
				saveCrashReport.Invoke(null, new object[] {ex});
			}
			finally
			{
				var logStream = (StreamWriter) fieldInfo.GetValue(null);
				logStream?.Close();
			}
		}
	}
}
