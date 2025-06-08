using Application.Activities.Queries;
using Application.Activities.Commands;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ActivitiesController : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<List<Activity>>> GetActivities()
    {
        return await Mediator.Send(new GetActivityList.Query());
        // return await context.Activities.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Activity>> GetActivity(string id)
    {
        return await Mediator.Send(new GetActivityDetails.Query { Id = id });
        // var activity = await context.Activities.FindAsync(id);
        // if (activity == null) return NotFound();
        // return activity;
    }

    [HttpPost]
    public async Task<ActionResult<string>> CreateActivity(Activity activity)
    {
        return await Mediator.Send(new CreateActivity.Command { Activity = activity });
        // context.Activities.Add(activity);
        // await context.SaveChangesAsync();
        // return activity.Id;
    }

    [HttpPut]
    public async Task<IActionResult> EditActivity(Activity activity)
    {
        await Mediator.Send(new EditActivity.Command { Activity = activity });

        return NoContent();
        // var existingActivity = await context.Activities.FindAsync(activity.Id);
        // if (existingActivity == null) return NotFound();
        // existingActivity.Title = activity.Title;
        // existingActivity.Description = activity.Description;
        // existingActivity.Date = activity.Date;
        // existingActivity.Category = activity.Category;
        // existingActivity.City = activity.City;
        // existingActivity.Venue = activity.Venue;
        // await context.SaveChangesAsync();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteActivity(string id)
    {
        await Mediator.Send(new DeleteActivity.Command { Id = id });
        return Ok();
        // var activity = await context.Activities.FindAsync(id);
        // if (activity == null) return NotFound();
        // context.Activities.Remove(activity);
        // await context.SaveChangesAsync();
    }   
}
