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

		#region EndpointsUsingMock
		[HttpGet] public ActionResult<IList<string>> MockLowInventory()
			=> db.MockGetNameListOfLowInventory().ToList();

		[HttpGet] public ActionResult<Inventory> MockGetItemByName([FromQuery] string name)
			=> db.MockGetItemByName(name);
		#endregion

		// GET api/inventory/list
		[HttpGet]
		public ActionResult<IEnumerable<Inventory>> List()
			=> db.GetList().ToList();

		// GET api/inventory/get/5
		[HttpGet("{id}")]
		public ActionResult<Inventory> Get(int id)
			=>db.GetInventoryItem(id);

		// POST api/inventory/insert
		[HttpPost]
		public ActionResult<int> Insert([FromBody] Inventory value)
			=> db.Insert(value);

		// POST api/inventory/update
		[HttpPost]
		public ActionResult<bool> Update([FromBody] Inventory value)
			=> db.Update(value);

		// DELETE api/inventory/delete/1
		[HttpDelete("{id}")]
		public ActionResult<int> Delete(int id)
			=> db.Delete(id);
	}
}
