using DependencyInjection.Logger.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection.Logger
{
	public class LogManager
	{
		private ILogger _ilogger;

		public LogManager(ILogger logger)
		{
			_ilogger = logger;
		}

		public string Log(string message)
		{
			return _ilogger.SaveLog(message);
		}
	}
}
