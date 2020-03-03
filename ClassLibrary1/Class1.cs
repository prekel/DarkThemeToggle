using System;
using System.Diagnostics;
using DarkThemeToggle.Core;

namespace ClassLibrary1
{
	public class Class1 : IInterface1
	{
		public void Abc()
		{
			Debug.Write("ClassLibrary1");
		}

		public int Hello(int x)
		{
			return x * x;
		}
	}
}
