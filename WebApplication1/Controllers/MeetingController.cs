using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using BigBlueButtonLibrary;
using ConferenceApp.Data;
using ConferenceApp.Models;
using Finbuckle.MultiTenant;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConferenceApp.Controllers
{
    public class MeetingController : Controller
    {
        private readonly ServerConfig serverConfig; 

        private readonly MultiTenantEntitiesContext dbContext;

        private readonly BigBlueButton bigBlueButton;
        public MeetingController(MultiTenantEntitiesContext dbContext)
        {
            this.dbContext = dbContext;
            this.serverConfig = new ServerConfig() { ServerUrl = "https://meetnxt.com/bigbluebutton/api", ServerSecret = "LW428BJRRGlXa4HNeCST4ydjwGiBHczcCWpLKsaE" };
            this.bigBlueButton = new BigBlueButton(serverConfig);
        }

        [EnableQuery]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Meeting>>> Get(Guid id)
        {
            if (id != Guid.Empty)
            {
                var meeting = await dbContext.Meetings.FindAsync(id);

                if (meeting == null)
                {
                    return NotFound();
                }

                return new List<Meeting> { meeting };
            }

            return await this.dbContext.Meetings.ToListAsync();
        }

        [HttpPost]
        public IActionResult Create([FromQuery]string meetingName, string meetingID, string attendeePW, string moderatorPW)
        {
           
            if (HttpContext.GetMultiTenantContext<TenantInfo>()?.TenantInfo != null)
            {
                DataTable dt = this.bigBlueButton.CreateMeeting(meetingName, meetingID);//, meetingID, attendeePW, moderatorPW);
                return CreatedAtAction(nameof(Create), new { id = dt.Rows[0][2] });
            }
            return new EmptyResult();
            //DataTable dt = this.bigBlueButton.CreateMeeting("random-3166867", "random-3166867", "ap", "mp");
            //return Ok(); //"Url of meeting";

        }

        [HttpGet]
        public string Join([FromQuery]string userName, string meetingID, string attendeePW)
        {
            if (HttpContext.GetMultiTenantContext<TenantInfo>()?.TenantInfo != null)
            {
                return this.bigBlueButton.JoinMeeting(userName, meetingID);//, attendeePW);
            }
            return "";
        }

    }
}
