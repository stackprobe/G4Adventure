using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charlotte.Tools;
using Charlotte.Common.Options;

namespace Charlotte.Games
{
	public class NamedCrash
	{
		public string Name;
		public DDCrash Crash;

		public NamedCrash(string name, DDCrash crash)
		{
			this.Name = name;
			this.Crash = crash;
		}
	}
}
