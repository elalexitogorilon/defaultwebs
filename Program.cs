using AA.Crew.AppSettings.DbIntermediary;
using AA.Crew.AppSettings.DbIntermediary.ResponseTypes;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;

namespace DBConnect
{
	internal class Program
	{
		public Program()
		{
		}

		private static void Main(string[] args)
		{
			try
			{
				AppSettingsDbIntermediary appSettingsDbIntermediary = new AppSettingsDbIntermediary("AppSettingCon");
				string str = ConfigurationSettings.AppSettings.Get("SettingName").ToString();
				GetAppSettingResponse applicationSetting = appSettingsDbIntermediary.GetApplicationSetting(str);
				if (!applicationSetting.get_IsSuccess() || applicationSetting.get_SettingValues() == null || applicationSetting.get_SettingValues().Count <= 0)
				{
					Console.WriteLine("App setting value was not retrieived");
					Console.ReadLine();
				}
				else
				{
					Console.WriteLine(string.Concat("Value from DB for the setting ", str, " is : "));
					Console.WriteLine(applicationSetting.get_SettingValues()[0].ToString());
					Console.ReadLine();
				}
			}
			catch (Exception exception)
			{
				Console.WriteLine(exception.Message);
				Console.WriteLine(exception.StackTrace);
				Console.ReadLine();
			}
		}
	}
}