namespace IOL.GreatOffice.Api.Endpoints.V1;

/// <summary>
/// A base class for an endpoint that accepts parameters.
/// </summary>
public static class RouteBaseSync
{
    public static class WithRequest<TRequest>
    {
        public abstract class WithResult<TResponse> : V1_EndpointBase
        {
            public abstract TResponse Handle(TRequest request);
        }

        public abstract class WithoutResult : V1_EndpointBase
        {
            public abstract void Handle(TRequest request);
        }

        public abstract class WithActionResult<TResponse> : V1_EndpointBase
        {
            public abstract ActionResult<TResponse> Handle(TRequest request);
        }

        public abstract class WithActionResult : V1_EndpointBase
        {
            public abstract ActionResult Handle(TRequest request);
        }
    }

    public static class WithoutRequest
    {
        public abstract class WithResult<TResponse> : V1_EndpointBase
        {
            public abstract TResponse Handle();
        }

        public abstract class WithoutResult : V1_EndpointBase
        {
            public abstract void Handle();
        }

        public abstract class WithActionResult<TResponse> : V1_EndpointBase
        {
            public abstract ActionResult<TResponse> Handle();
        }

        public abstract class WithActionResult : V1_EndpointBase
        {
            public abstract ActionResult Handle();
        }
    }
}