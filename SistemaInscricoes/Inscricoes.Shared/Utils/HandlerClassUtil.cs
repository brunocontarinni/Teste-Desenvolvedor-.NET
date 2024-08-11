namespace Inscricoes.Shared.Utils;

public static class HandlerClassUtil
{
	public static void TrimAllStrings(object obj)
	{
		var properties = obj.GetType().GetProperties();

		foreach (var property in properties)
		{
			if (property.PropertyType == typeof(string))
			{
				var value = property.GetValue(obj) as string;
				if (value != null)
				{
					var trimmedValue = value.Trim();
					property.SetValue(obj, trimmedValue);
				}
			}
		}
	}
}