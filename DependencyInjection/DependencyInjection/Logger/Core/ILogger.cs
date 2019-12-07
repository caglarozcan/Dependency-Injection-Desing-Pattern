using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection.Logger.Core
{
	public interface ILogger
	{
		string SaveLog(string message);
	}
}
