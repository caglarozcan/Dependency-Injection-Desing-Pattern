using System;
using DependencyInjection.Logger.Core;

namespace DependencyInjection.Logger.LoggerProc
{
	public class TextLogger : ILogger
	{
		public string SaveLog(string message)
		{
			return "Log bilgisi TXT dosyasına kaydedildi! : [" + DateTime.Now.ToString() + " | " + message + "]";
		}
	}
}
