namespace IOL.GreatOffice.Api.Endpoints.V1;

/// <summary>
/// A base class for an endpoint that accepts parameters.
/// </summary>
public class RouteBaseAsync
{
    public class WithRequest<TRequest>
    {
        public abstract class WithResult<TResponse> : V1_EndpointBase
        {
            public abstract Task<TResponse> HandleAsync(
                    TRequest request,
                    CancellationToken cancellationToken = default
                );
        }

        public abstract class WithoutResult : V1_EndpointBase
        {
            public abstract Task HandleAsync(
                    TRequest request,
                    CancellationToken cancellationToken = default
                );
        }

        public abstract class WithActionResult<TResponse> : V1_EndpointBase
        {
            public abstract Task<ActionResult<TResponse>> HandleAsync(
                    TRequest request,
                    CancellationToken cancellationToken = default
                );
        }

        public abstract class WithActionResult : V1_EndpointBase
        {
            public abstract Task<ActionResult> HandleAsync(
                    TRequest request,
                    CancellationToken cancellationToken = default
                );
        }
    }

    public static class WithoutRequest
    {
        public abstract class WithResult<TResponse> : V1_EndpointBase
        {
            public abstract Task<TResponse> HandleAsync(
                    CancellationToken cancellationToken = default
                );
        }

        public abstract class WithoutResult : V1_EndpointBase
        {
            public abstract Task HandleAsync(
                    CancellationToken cancellationToken = default
                );
        }

        public abstract class WithActionResult<TResponse> : V1_EndpointBase
        {
            public abstract Task<ActionResult<TResponse>> HandleAsync(
                    CancellationToken cancellationToken = default
                );
        }

        public abstract class WithActionResult : V1_EndpointBase
        {
            public abstract Task<ActionResult> HandleAsync(
                    CancellationToken cancellationToken = default
                );
        }
    }
}