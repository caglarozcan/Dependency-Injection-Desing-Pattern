using System;
using DependencyInjection.Logger.Core;

namespace DependencyInjection.Logger.LoggerProc
{
	public class MailLogger : ILogger
	{
		public string SaveLog(string message)
		{
			return "Log bilgisi Mail olarak gönderildi! : [" + DateTime.Now.ToString() + " | " + message + "]";
		}
	}
}
