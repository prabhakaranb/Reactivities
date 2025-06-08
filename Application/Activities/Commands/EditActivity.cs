using AutoMapper;
using MediatR;
using Persistence;
using Domain;

namespace Application.Activities.Commands;

public class EditActivity
{
    public class Command : IRequest
    {
        public required Activity Activity { get; set; }
    }

    public class Handler(AppDbContext context, IMapper mapper) : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var activity = await context.Activities.FindAsync([request.Activity.Id], cancellationToken)
                ?? throw new Exception("Activity not found");

            mapper.Map(request.Activity, activity);
            await context.SaveChangesAsync(cancellationToken);

            // activity.Title = request.Activity.Title;
            // activity.Description = request.Activity.Description;
            // activity.Date = request.Activity.Date;
            // activity.Category = request.Activity.Category;
            // activity.City = request.Activity.City;
            // activity.Venue = request.Activity.Venue;
            // return Unit.Value;
        }
    }
}
