using System;
namespace TabuProject.Extension
{
	public static class IQueryableExtension
	{
		public static IQueryable<T> Random<T>(this IQueryable<T> query, int RandomNum)
		{
			Random random = new Random();
			int num = random.Next(0, RandomNum);
			return query.Skip(num); 
		}
	}
}

