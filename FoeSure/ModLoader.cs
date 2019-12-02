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
			var ፙ = typeof(GameImpl).Assembly.GetType("FoeFrenzy.Main.Program");
			var ㄱ_ㄱ = ፙ.GetMethod("InitLog", BindingFlags.Static | BindingFlags.NonPublic);
			var ㅇㅅㅇ = ፙ.GetField("logStream", BindingFlags.Static | BindingFlags.NonPublic);
			var ꅃ = ፙ.GetMethod("SaveCrashReport", BindingFlags.Static | BindingFlags.NonPublic);

			if (ㄱ_ㄱ == null || ㅇㅅㅇ == null || ꅃ == null)
			{
				throw new Exception("ELLPECKINATOR. WHAT HAVE YOU DONE!?");
			}

			try
			{
				ㄱ_ㄱ.Invoke(null, new object[0]);
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
				ꅃ.Invoke(null, new object[] {ex});
			}
			finally
			{
				var logStream = (StreamWriter) ㅇㅅㅇ.GetValue(null);
				logStream?.Close();
			}
		}
	}
}
