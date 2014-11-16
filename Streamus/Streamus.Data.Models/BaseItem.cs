namespace Streamus.Data.Models
{
	using System;
	using System.ComponentModel.DataAnnotations;

	public class BaseItem : IBaseItem
	{
		public BaseItem()
		{
			this.Id = Guid.NewGuid().ToString();
		}

		[Key]
		public string Id { get; set; }
	}
}