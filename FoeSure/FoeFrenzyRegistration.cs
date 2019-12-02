using System;
using System.Reflection;
using FoeFrenzy.Items;
using FoeFrenzy.Maps.Structures;
using FoeFrenzy.Maps.Tiles;

namespace FoeSure
{
	public static class FoeFrenzyRegistration
	{
		private static MethodInfo RegisterItemMethod =>
			typeof(GameItems).GetMethod("Register", BindingFlags.Static | BindingFlags.NonPublic) ?? 
			throw new Exception("DANG IT ELLPICK");
		private static MethodInfo RegisterStructureMethod =>
			typeof(GameStructures).GetMethod("Register", BindingFlags.Static | BindingFlags.NonPublic) ?? 
			throw new Exception("DANG IT ELLPUCK");
		private static MethodInfo RegisterTilesMethod =>
			typeof(GameTiles).GetMethod("Register", BindingFlags.Static | BindingFlags.NonPublic) ?? 
			throw new Exception("DANG IT ELLPORK");

		public static void Register(this Item item)
		{
			RegisterItemMethod.Invoke(null, new object[] {item});
		}

		public static void Register(this Structure item)
		{
			RegisterStructureMethod.Invoke(null, new object[] { item });
		}

		public static void Register(this Tile item)
		{
			RegisterTilesMethod.Invoke(null, new object[] { item });
		}
	}
}