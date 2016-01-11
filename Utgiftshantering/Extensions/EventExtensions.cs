using System;

namespace Utgiftshantering.Extensions
{
	public static class EventExtensions
	{
		public static void SafeRaise<T>(this EventHandler<T> eventHandler, object sender, T eventArgs) where T : EventArgs
		{
			if (eventHandler != null)
			{
				eventHandler(sender, eventArgs);
			}
		}

		public static void SafeRaise(this EventHandler eventHandler, object sender, EventArgs eventArgs)
		{
			if (eventHandler != null)
			{
				eventHandler(sender, eventArgs);
			}
		}
	}
}
