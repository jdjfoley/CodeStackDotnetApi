using System.ComponentModel.DataAnnotations.Schema;

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
}
