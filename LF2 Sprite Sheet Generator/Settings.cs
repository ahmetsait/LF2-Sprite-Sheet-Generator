using System;
using System.IO;
using System.Xml.Serialization;

namespace LF2.Sprite_Sheet_Generator
{
	public sealed class Settings
	{
		public static Settings Current = new Settings();

		public static readonly string SettingsDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\LF2 Sprite Sheet Generator",
			SettingsPath = SettingsDir + "\\settings.xml";
		
		public void Reload()
		{
			if (File.Exists(SettingsPath))
			{
				try
				{
					using (FileStream settings = new FileStream(SettingsPath, FileMode.Open, FileAccess.Read))
					{
						XmlSerializer xs = new XmlSerializer(typeof(Settings));
						Current = (Settings)xs.Deserialize(settings);
					}
				}
				catch
				{
					try
					{
						File.Delete(SettingsPath);
					}
					finally { }
				}
			}
		}

		public void Save()
		{
			if (!Directory.Exists(SettingsDir))
				Directory.CreateDirectory(SettingsDir);
			using (FileStream settings = new FileStream(SettingsPath, FileMode.Create, FileAccess.Write))
			{
				XmlSerializer xs = new XmlSerializer(typeof(Settings));
				xs.Serialize(settings, Current);
			}
		}
	}
}
