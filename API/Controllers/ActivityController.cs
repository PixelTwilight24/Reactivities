using Application.Activities;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ActivitiesController: BaseAPIController
    {

        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities(CancellationToken ct)
        {
            return await Mediator.Send(new List.Query(), ct);
        } 

        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivity(Guid id)
        {
            return await Mediator.Send(new Details.Query{Id = id});
        }

        [HttpPost]
        public async Task<ActionResult<Activity>> CreateActivity(Activity activity)
        {
            await Mediator.Send(new Create.Command{ Activity = activity});
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Activity>> EditActivity(Guid id, Activity activity)
        {
            activity.Id = id;
            await Mediator.Send(new Edit.Command{ Activity = activity});
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Activity>> DeleteActivity(Guid id)
        {
            await Mediator.Send(new Delete.Command{ Id = id});
            return Ok();
        }
    }
}