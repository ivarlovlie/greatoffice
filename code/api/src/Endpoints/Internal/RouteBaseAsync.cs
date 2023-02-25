namespace IOL.GreatOffice.Api.Endpoints.Internal;

/// <summary>
/// A base class for an endpoint that accepts parameters.
/// </summary>
public static class RouteBaseAsync
{
	public static class WithRequest<TRequest>
	{
		public abstract class WithResult<TResponse> : INT_EndpointBase
		{
			public abstract Task<TResponse> HandleAsync(
					TRequest request,
					CancellationToken cancellationToken = default
			);
		}

		public abstract class WithoutResult : INT_EndpointBase
		{
			public abstract Task HandleAsync(
					TRequest request,
					CancellationToken cancellationToken = default
			);
		}

		public abstract class WithActionResult<TResponse> : INT_EndpointBase
		{
			public abstract Task<ActionResult<TResponse>> HandleAsync(
					TRequest request,
					CancellationToken cancellationToken = default
			);
		}

		public abstract class WithActionResult : INT_EndpointBase
		{
			public abstract Task<ActionResult> HandleAsync(
					TRequest request,
					CancellationToken cancellationToken = default
			);
		}
	}

	public static class WithoutRequest
	{
		public abstract class WithResult<TResponse> : INT_EndpointBase
		{
			public abstract Task<TResponse> HandleAsync(
					CancellationToken cancellationToken = default
			);
		}

		public abstract class WithoutResult : INT_EndpointBase
		{
			public abstract Task HandleAsync(
					CancellationToken cancellationToken = default
			);
		}

		public abstract class WithActionResult<TResponse> : INT_EndpointBase
		{
			public abstract Task<ActionResult<TResponse>> HandleAsync(
					CancellationToken cancellationToken = default
			);
		}

		public abstract class WithActionResult : INT_EndpointBase
		{
			public abstract Task<ActionResult> HandleAsync(
					CancellationToken cancellationToken = default
			);
		}
	}
}
