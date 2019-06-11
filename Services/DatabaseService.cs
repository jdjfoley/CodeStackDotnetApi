using System.Collections.Generic;
using System.Linq;
using LiteDB;

public class DatabaseService
{
	// https://github.com/mbdavid/LiteDB
	private LiteDatabase database;
	//Context
	private LiteCollection<Inventory> inventory;

	public DatabaseService(string dbLocation)
	{
		database = new LiteDatabase(dbLocation);
		using (database)
		{
			inventory = database.GetCollection<Inventory>("inventory");
		}
	}

	public IEnumerable<Inventory> GetList()
	{
		return inventory.FindAll();
	}

	public Inventory GetInventoryItem(int id)
	{
		return inventory.Find(x => x.Id == id).FirstOrDefault();
	}

	public int Insert(Inventory item)
	{
		return inventory.Insert(item);
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
}
