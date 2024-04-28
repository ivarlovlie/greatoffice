namespace IOL.GreatOffice.Api.Models.Misc;

public class KnownProblemModel
{
    public KnownProblemModel(string title = default, string subtitle = default, Dictionary<string, string[]> errors = default)
    {
        Title = title;
        Subtitle = subtitle;
        Errors = errors ?? new();
    }

    public string Title { get; set; }
    public string Subtitle { get; set; }
    public Dictionary<string, string[]> Errors { get; set; }
    public string TraceId { get; set; }

    public void AddError(string field, string errorText)
    {
        if (!Errors.ContainsKey(field))
        {
            Errors.Add(field, [errorText]);
        }
        else
        {
            var currentErrors = Errors[field];
            var newErrors = currentErrors.Concat(new[] { errorText });
            Errors.Remove(field);
            Errors.Add(field, newErrors.ToArray());
        }
    }
}