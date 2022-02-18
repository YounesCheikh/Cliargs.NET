﻿using System;
namespace Cliargs
{
	public static class TypeExtensions
	{
		internal static string GetNameWithoutGenericArity(this Type t)
		{
			string name = t.Name;
			int index = name.IndexOf('`');
			return index == -1 ? name : name.Substring(0, index);
		}
	}
}

