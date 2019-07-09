using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ShopApi.Models;
using ShopApi.Services;

namespace ShopApi.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class InventoryController : ControllerBase
	{
		private DatabaseService db;

		public InventoryController(DatabaseService database)
		{
			db = database;
		}

		[HttpGet] public ActionResult<IList<string>> MockLowInventory() {
			return db.MockGetNameListOfLowInventory().ToList();
		}

		[HttpGet] public ActionResult<Inventory> MockGetItemByName([FromQuery] string name) {
			return db.MockGetItemByName(name);
		}

		// GET api/inventory/list
		[HttpGet]
		public ActionResult<IEnumerable<Inventory>> List()
		{
			return db.GetList().ToList();
		}

		// GET api/inventory/get/5
		[HttpGet("{id}")]
		public ActionResult<Inventory> Get(int id)
		{
			return db.GetInventoryItem(id);
		}







		// POST api/inventory/insert
		[HttpPost]
		public ActionResult<int> Insert([FromBody] Inventory value)
		{
			return db.Insert(value);
		}

		// POST api/inventory/update
		[HttpPost]
		public ActionResult<bool> Update([FromBody] Inventory value)
		{
			return db.Update(value);
		}

		// DELETE api/inventory/delete/1
		[HttpDelete("{id}")]
		public ActionResult<int> Delete(int id)
		{
			return db.Delete(id);
		}
	}
}
