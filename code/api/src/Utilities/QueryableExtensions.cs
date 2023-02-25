namespace IOL.GreatOffice.Api.Utilities;

public static class QueryableExtensions
{
    public static IQueryable<T> ForTenant<T>(this IQueryable<T> queryable, LoggedInUserModel loggedInUserModel) where T : BaseWithOwner {
        return queryable.Where(c => c.TenantId == loggedInUserModel.TenantId);
    }

    public static IQueryable<T> ForUser<T>(this IQueryable<T> queryable, LoggedInUserModel loggedInUserModel) where T : BaseWithOwner {
        return queryable.Where(c => c.UserId == loggedInUserModel.Id);
    }
}