using System.Collections.Generic;
using System.Linq;
using LiteDB;
using ShopApi.Models;

namespace ShopApi.Services
{
	public class DatabaseService
	{
		// https://github.com/mbdavid/LiteDB
		private LiteDatabase database;
		private List<Inventory> fixedData = new List<Inventory> {
			new Inventory(1, "#2 pencil", "Pencil", .50, "38830982031", "A1", 100),
			new Inventory(2, "spiral notebook", "Notebook", 1.50, "3881111131", "A2", 50),
			new Inventory(3, "3 ring binder with dividers", "Binder", 4.50, "54830982031", "A2", 5),
			new Inventory(4, "Scientific calculator", "Ti83+ Calculator", 49.00, "3889462031", "A4", 100),
			new Inventory(5, "black ball point pen", "Pen", .50, "388309867", "A1", 10),
			new Inventory(6, "metallic coaster", "Coaster", 1.50, "388309212", "A6", 1),
			new Inventory(7, "Fuzzy backpack", "Backpack", 24.50, "388309987", "A5", 100)
		};

		//Context
		private LiteCollection<Inventory> inventory;
		private LiteCollection<Shopper> shoppers;

		public DatabaseService(string dbLocation)
		{
			database = new LiteDatabase(dbLocation);
			using (database)
			{
				inventory = database.GetCollection<Inventory>("inventory");
				shoppers = database.GetCollection<Shopper>("shoppers");
			}
		}

		#region MockDB
		public IEnumerable<Inventory> GetListOfLowInventory()
		{
			return fixedData
				.Where(i => i.Quantity <= 10)
				.ToList();
		}

		public IEnumerable<string> MockGetNameListOfLowInventory()
		{
			return fixedData
				.Where(i => i.Quantity <= 100)
				.Select(i =>
				{
					var s = $"{i.Name} {i.Quantity}";
					return s;
				}).ToList();
		}

		public Inventory MockGetItemByName(string name)
		{
			return fixedData
				.Where(i => i.Name.Equals(name))
				.FirstOrDefault();
		}
		#endregion

		#region LiteDB

		// INSERT INVENTORY ITEM INTO DB
		public int Insert(Inventory item)
		{
			return inventory.Insert(item);
		}

		public IEnumerable<Inventory> GetList()
		{
			return inventory.FindAll();
		}

		public Inventory GetInventoryItem(int id)
		{
			return inventory.Find(x => x.Id == id).FirstOrDefault();
		}

		public bool Update(Inventory item)
		{
			return inventory.Update(item);
		}

		// this Db package offeres 'Upsert', which combines Insert and Update.
		// if item.Id matches another record, then update that record with this one.
		// else if no match, create a new record
		public bool Upsert(Inventory item)
		{
			return inventory.Upsert(item);
		}

		public int Delete(int id)
		{
			return inventory.Delete(x => x.Id == id);
		}
		#endregion
	}
}
