namespace IOL.GreatOffice.Api.Services;

public class MailService
{
    private readonly ILogger<MailService> _logger;
    private static string _fromEmail;
    private readonly HttpClient _httpClient;

    public MailService(ILogger<MailService> logger, HttpClient httpClient)
    {
        _fromEmail = Program.AppConfiguration.EMAIL_FROM_ADDRESS;
        _logger = logger;
        httpClient.DefaultRequestHeaders.Add("X-Postmark-Server-Token", Program.AppConfiguration.POSTMARK_TOKEN);
        _httpClient = httpClient;
    }

    /// <summary>
    /// Send an email.
    /// </summary>
    /// <param name="message"></param>
    /// <exception cref="ArgumentException"></exception>
    public async Task SendMailAsync(PostmarkEmail message)
    {
        try
        {
            if (message.MessageStream.IsNullOrWhiteSpace())
            {
                message.MessageStream = "outbound";
            }

            if (message.From.IsNullOrWhiteSpace() && _fromEmail.HasValue())
            {
                message.From = _fromEmail;
            }
            else
            {
                throw new ApplicationException("Not one from-email is available");
            }

            if (message.To.IsNullOrWhiteSpace())
            {
                throw new ArgumentNullException(nameof(message.To), "A recipient should be specified.");
            }

            if (!message.To.IsValidEmailAddress())
            {
                throw new ArgumentException(nameof(message.To), "To is not a valid email address");
            }

            if (message.HtmlBody.IsNullOrWhiteSpace() && message.TextBody.IsNullOrWhiteSpace())
            {
                throw new ArgumentNullException(nameof(message), "Both HtmlBody and TextBody is empty, nothing to send");
            }
#if DEBUG
            _logger.LogInformation("Sending email: {0}", JsonSerializer.Serialize(message, new JsonSerializerOptions() { WriteIndented = true }));
#endif
            var response = await _httpClient.PostAsJsonAsync("https://api.postmarkapp.com/email", message);
            _logger.LogInformation("Postmark returned with message: {0}", (await response.Content.ReadFromJsonAsync<PostmarkSendResponse>()).Message);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "A silent exception occured while trying to send an email");
        }
    }

    private class PostmarkSendResponse
    {
        /// <summary>
        ///   The Message ID returned from Postmark.
        /// </summary>
        public Guid MessageID { get; set; }

        /// <summary>
        ///   The message from the API.
        ///   In the event of an error, this message may contain helpful text.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        ///   The time the request was received by Postmark.
        /// </summary>
        public DateTime SubmittedAt { get; set; }

        /// <summary>
        ///   The recipient of the submitted request.
        /// </summary>
        public string To { get; set; }

        /// <summary>
        ///   The error code returned from Postmark.
        ///   This does not map to HTTP status codes.
        /// </summary>
        public int ErrorCode { get; set; }
    }

    public class PostmarkEmail
    {
        /// <summary>
        ///   The message subject line.
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        ///   The message body, if the message contains
        /// </summary>
        public string HtmlBody { get; set; }

        /// <summary>
        ///   The message body, if the message is plain text.
        /// </summary>
        public string TextBody { get; set; }

        /// <summary>
        ///   The message stream used to send this message.
        /// </summary>
        public string MessageStream { get; set; }

        /// <summary>
        ///   The sender's email address.
        /// </summary>
        public string From { get; set; }

        /// <summary>
        ///   Any recipients. Separate multiple recipients with a comma.
        /// </summary>
        public string To { get; set; }

        /// <summary>
        ///   Any CC recipients. Separate multiple recipients with a comma.
        /// </summary>
        public string Cc { get; set; }

        /// <summary>
        ///   Any BCC recipients. Separate multiple recipients with a comma.
        /// </summary>
        public string Bcc { get; set; }

        /// <summary>
        ///   The email address to reply to. This is optional.
        /// </summary>
        public string ReplyTo { get; set; }
    }
}