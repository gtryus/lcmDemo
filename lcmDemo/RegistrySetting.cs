// --------------------------------------------------------------------------------------------
// <copyright file="RegistrySetting.cs" from='2010' to='2018' company='SIL International'>
//      Copyright ( c ) 2018, SIL International. All Rights Reserved.
//
//      Distributable under the terms of either the Common Public License or the
//      GNU Lesser General Public License, as specified in the LICENSING.txt file.
// </copyright>
// <author>TE Team</author>
// Last reviewed:
//
// <remarks>
// </remarks>
// --------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Microsoft.Win32;
using SIL.PlatformUtilities;

namespace SIL.Tool
{
    public class RegistrySetting
	{
		public static string FallbackStringValue(string key)
		{
			return FallbackStringValue(key, null);
		}

		public static string FallbackStringValue(string key, string value)
		{
			object result;
			if (CheckSoftwareKey(Registry.CurrentUser, key, value, out result)) return (string) result;
			if (Platform.IsLinux) return UnixFallbackStringValue(key, value);
			if (CheckSoftwareKey(Registry.LocalMachine, key, value, out result)) return (string) result;
			// See: https://stackoverflow.com/questions/974038/reading-64bit-registry-from-a-32bit-application
			using (var hive64 = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64))
			{
				if (CheckSoftwareKey(hive64, key, value, out result)) return (string)result;
			}
			using (var hive64 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
			{
				if (CheckSoftwareKey(hive64, key, value, out result)) return (string)result;
			}
			return null;
		}

		private static bool CheckSoftwareKey(RegistryKey hive, string key, string value, out object result)
		{
			var levels = new List<string> {"software"};
			levels.AddRange(key.Split('/'));
			result = GetLevelValue(hive, levels, value);
			return result != null;
		}

		private static object GetLevelValue(RegistryKey hive, IList<string> levels, string value)
		{
			using (var key = hive.OpenSubKey(levels[0]))
			{
				if (key == null) return null;
				if (levels.Count <= 1) return key.GetValue(value);
				levels.RemoveAt(0);
				return GetLevelValue(key, levels, value);
			}
		}

		private static readonly XmlDocument XDoc = new XmlDocument();
		private static string UnixFallbackStringValue(string key, string value)
		{
			var userName = Environment.UserName;
			foreach (var program in new List<string> { "paratext", "fieldworks" })
			{
				var registryPath = "/home/" + userName + "/.config/"+ program +"/registry/LocalMachine/software/";
				var valueFile = Path.Combine(registryPath, key.ToLower(), "values.xml");
				if (!File.Exists(valueFile)) continue;
				XDoc.RemoveAll();
				var xr = XmlReader.Create(valueFile);
				XDoc.Load(xr);
				xr.Close();
				var node = value != null? XDoc.SelectSingleNode("//*[@name='" + value + "']"): XDoc.DocumentElement;
				if (node != null) return node.InnerText;
			}
			return null;
		}

    }
}
