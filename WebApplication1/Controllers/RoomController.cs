using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConferenceApp.Data;
using ConferenceApp.Models;
using Finbuckle.MultiTenant;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
namespace ConferenceApp.Controllers
{
    public class RoomController : ControllerBase
    {
        private readonly MultiTenantEntitiesContext dbContext;

        public RoomController(MultiTenantEntitiesContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [EnableQuery]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Room>>> GetRoom(Guid id)
        {
            if (id != Guid.Empty)
            {
                var room = await dbContext.Rooms.FindAsync(id);

                if (room == null)
                {
                    return NotFound();
                }

                return new List<Room> { room };
            }

            return await this.dbContext.Rooms.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Room>> Create([FromBody]Room room)
        {
            if (HttpContext.GetMultiTenantContext<TenantInfo>()?.TenantInfo != null)
            {
                room.CreatedBy = this.User.Identity.Name;
                room.RoomSetting.CreatedBy = this.User.Identity.Name;
                dbContext.Rooms.Add(room);
                await dbContext.SaveChangesAsync();

                return CreatedAtAction(nameof(Create), new { id = room.ID }, room);
            }
            return new EmptyResult();
        }
    }
}
