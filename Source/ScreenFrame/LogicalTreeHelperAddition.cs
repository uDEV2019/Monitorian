﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ScreenFrame
{
	/// <summary>
	/// Additional methods for <see cref="System.Windows.LogicalTreeHelper"/>
	/// </summary>
	public static class LogicalTreeHelperAddition
	{
		/// <summary>
		/// Enumerates descendant objects of a specified object.
		/// </summary>
		/// <typeparam name="T">Type of descendant dependency object</typeparam>
		/// <param name="reference">Ancestor dependency object</param>
		/// <returns>Enumerable collection of descendant objects</returns>
		public static IEnumerable<T> EnumerateDescendants<T>(DependencyObject reference) where T : DependencyObject
		{
			if (reference is null)
				yield break;

			foreach (DependencyObject child in LogicalTreeHelper.GetChildren(reference).OfType<DependencyObject>())
			{
				if (child is T buffer)
					yield return buffer;

				foreach (T grandchild in EnumerateDescendants<T>(child))
					yield return grandchild;
			}
		}
	}
}