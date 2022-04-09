using Ardalis.ApiEndpoints;
using BlazorTrails.Api.Persistence;
using BlazorTrails.Api.Persistence.Entities;
using BlazorTrails.Client.Features.ManageTrails;
using Microsoft.AspNetCore.Mvc;

namespace BlazorTrails.Api.Features.ManageTrails
{
    public class AddTrailEndpoint : BaseAsyncEndpoint.WithRequest<AddTrailRequest>.WithResponse<int>
    {
        private readonly AppDbContext _database;

        public AddTrailEndpoint(AppDbContext database)
        {
            _database = database;
        }

        [HttpPost(AddTrailRequest.RouteTemplate)]
        public override async Task<ActionResult<int>> HandleAsync(AddTrailRequest request,CancellationToken cancellationToken = default)
        {
            var trail = new Trail
            {
                Name = request.Trail.Name,
                Description = request.Trail.Description,
                Location = request.Trail.Location,
                TimeInMinutes = request.Trail.TimeInMinutes,
                Length = request.Trail.Length
            };

            await _database.Trails.AddAsync(trail, cancellationToken);
            var routeInstructions = request.Trail.Route.Select(x => new RouteInstruction
            {
                Stage = x.Stage,
                Description = x.Description,
                Trail = trail
            });

            await _database.RouteInstructions.AddRangeAsync(routeInstructions, cancellationToken);
            await _database.SaveChangesAsync(cancellationToken);
            return Ok(trail.Id);
        }
    }
}
