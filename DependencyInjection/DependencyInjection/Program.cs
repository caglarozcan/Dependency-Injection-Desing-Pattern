using DependencyInjection.Logger;
using DependencyInjection.Logger.LoggerProc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
	class Program
	{
		static void Main(string[] args)
		{
			LogManager logManager = null;
			
			string logType = "database";
			Console.Write("Log türü girin -> ");
			logType = Console.ReadLine().ToLower();

			switch (logType)
			{
				case "database":
					logManager = new LogManager(new DatabaseLogger());
					break;
				case "txt":
					logManager = new LogManager(new TextLogger());
					break;
				case "mail":
					logManager = new LogManager(new MailLogger());
					break;
				case "xml":
					logManager = new LogManager(new XMLLogger());
					break;
				default:
					Console.WriteLine("Geçersiz Log Türü!");
					break;
			}

			if(logManager != null)
			{
				Console.WriteLine(logManager.Log("Hata Mesajı!"));
			}

			Console.ReadKey();
		}
	}
}
