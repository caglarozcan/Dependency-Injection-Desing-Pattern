using System;
using DependencyInjection.Logger.Core;

namespace DependencyInjection.Logger.LoggerProc
{
	public class XMLLogger : ILogger
	{
		public string SaveLog(string message)
		{
			return "Log bilgisi XML dosyasına kaydedildi! : [" + DateTime.Now.ToString() + " | " + message + "]";
		}
	}
}
