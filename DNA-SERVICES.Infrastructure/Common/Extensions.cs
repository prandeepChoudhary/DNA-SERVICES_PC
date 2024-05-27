﻿using System;
using System.Data;

namespace DNA_SERVICES.Infrastructure.Common
{
	public static class Extensions
	{
		public static bool HasColumn(this IDataRecord dr, string columnName)
		{
			for(int i = 0; i <dr.FieldCount; i++)
			{
				if (dr.GetName(i).Equals(columnName, StringComparison.InvariantCultureIgnoreCase))
					return true;
			}
			return false;
		}
	}
}

