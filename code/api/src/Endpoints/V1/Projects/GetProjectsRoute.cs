using MR.AspNetCore.Pagination;

namespace IOL.GreatOffice.Api.Endpoints.V1.Projects;

public class GetProjectsRoute : RouteBaseAsync.WithRequest<GetProjectsQueryParameters>.WithActionResult<KeysetPaginationResult<GetProjectsResponseDto>>
{
    private readonly MainAppDatabase _database;
    private readonly PaginationService _pagination;

    public GetProjectsRoute(MainAppDatabase database, PaginationService pagination) {
        _database = database;
        _pagination = pagination;
    }

    [HttpGet("~/v{version:apiVersion}/projects")]
    public override async Task<ActionResult<KeysetPaginationResult<GetProjectsResponseDto>>> HandleAsync([FromQuery] GetProjectsQueryParameters request, CancellationToken cancellationToken = default) {
        var result = await _pagination.KeysetPaginateAsync(
            _database.Projects.ForTenant(LoggedInUser).ConditionalWhere(() => request.NameQuery.HasValue(), p => p.Name.Contains(request.NameQuery)),
            b => b.Descending(x => x.CreatedAt),
            async id => await _database.Projects.FindAsync(id),
            query => query.Select(p => new GetProjectsResponseDto() {
                Id = p.Id,
                Name = p.Name
            })
        );
        return Ok(result);
    }
}

public class GetProjectsResponseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}

public class GetProjectsQueryParameters
{
    [FromQuery(Name = "name")]
    public string NameQuery { get; set; }
}