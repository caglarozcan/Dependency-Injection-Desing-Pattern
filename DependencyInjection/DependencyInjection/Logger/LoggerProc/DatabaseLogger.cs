using System;
using DependencyInjection.Logger.Core;

namespace DependencyInjection.Logger.LoggerProc
{
	public class DatabaseLogger : ILogger
	{
		public string SaveLog(string message)
		{
			return "Log bilgisi veritabanına kaydedildi! : [" + DateTime.Now.ToString() + " | " + message + "]";
		}
	}
}
