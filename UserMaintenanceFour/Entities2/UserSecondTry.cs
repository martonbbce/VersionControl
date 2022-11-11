using System;

/// <summary>
/// Summary description for Class1
/// </summary>
namespace UserMaintenanceFour.Entities
{
	public class UserSecondTry
	{
		public Guid ID { get; set; } = Guid.NewGuid();
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string FullName
		{
			get
			{
				return string.Format("{0} {1}", LastName, FirstName);
			}
		}
		public UserSecondTry()
		{
			//
			// TODO: Add constructor logic here
			//
		}
	}
}
