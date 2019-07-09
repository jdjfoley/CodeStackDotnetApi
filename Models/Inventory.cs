using System.ComponentModel.DataAnnotations.Schema;

namespace ShopApi.Models
{
	public class Inventory
	{
		public int Id { get; set; }
		public string Description { get; set; }
		public string Name { get; set; }
		public double Price { get; set; }
		public string Sku { get; set; }
		public string StorageLocation { get; set; }
		public int Quantity { get; set; }
		[NotMapped] public bool HasDescription => Description != null && Description != "";

		public Inventory() {}

		public Inventory(int id, string desc, string Name, double price, string sku, string loc, int quantity) {
			Id = id;
			Description = desc;
			this.Name = Name;
			Price = price;
			Sku = sku;
			StorageLocation = loc;
			Quantity = quantity;
		}
	}
}
