using System.Security.Cryptography.X509Certificates;

namespace IOL.GreatOffice.Api.Models.Models;

public class AppConfiguration
{
    /// <summary>
    /// An reachable ip address or url that points to a postgres database.
    /// </summary>
    public string DB_HOST { get; set; }

    /// <summary>
    /// The port number to use with DB_HOST to point to the postgres database.
    /// </summary>
    public string DB_PORT { get; set; }

    /// <summary>
    /// The database user to authenticate against postgres with.
    /// </summary>
    public string DB_USER { get; set; }

    /// <summary>
    /// The password for the database user to authenticate against postgres with.
    /// </summary>
    public string DB_PASSWORD { get; set; }

    /// <summary>
    /// The name of the main app database.
    /// </summary>
    public string DB_NAME { get; set; }

    /// <summary>
    /// An reachable ip address or url that points to a postgres(quartz) database.
    /// </summary>
    public string QUARTZ_DB_HOST { get; set; }

    /// <summary>
    /// The port number to use with QUARTZ_DB_HOST to point to the postgres(quartz) database.
    /// </summary>
    public string QUARTZ_DB_PORT { get; set; }

    /// <summary>
    /// The database user to authenticate against postgres(quartz) with.
    /// </summary>
    public string QUARTZ_DB_USER { get; set; }

    /// <summary>
    /// The password for the database user to authenticate against postgres(quartz) with.
    /// </summary>
    public string QUARTZ_DB_PASSWORD { get; set; }

    /// <summary>
    /// The name of the quartz database.
    /// </summary>
    public string QUARTZ_DB_NAME { get; set; }

    /// <summary>
    /// API key to use when pushing logs to SEQ
    /// </summary>
    public string SEQ_API_KEY { get; set; }

    /// <summary>
    /// Url pointing to the seq instance that processes server logs
    /// </summary>
    public string SEQ_API_URL { get; set; }

    /// <summary>
    /// A token used when sending email via Postmakr
    /// </summary>
    public string POSTMARK_TOKEN { get; set; }

    /// <summary>
    /// The address to send emails from, needs to be setup as a sender in postmark
    /// </summary>
    public string EMAIL_FROM_ADDRESS { get; set; }

    /// <summary>
    /// The absolute url to the frontend app
    /// </summary>
    public string CANONICAL_FRONTEND_URL { get; set; }

    /// <summary>
    /// The absolute url to the backend api
    /// </summary>
    public string CANONICAL_BACKEND_URL { get; set; }

    /// <summary>
    /// A random string used to encrypt/decrypt for general purposes
    /// </summary>
    public string APP_AES_KEY { get; set; }

    /// <summary>
    /// A base64 string containing a passwordless pfx cert
    /// </summary>
    public string APP_CERT { get; set; }

    public X509Certificate2 CERT1() => new(Convert.FromBase64String(APP_CERT));

    public object GetPublicObject()
    {
        return new
        {
            DB_HOST,
            DB_PORT,
            DB_USER,
            DB_PASSWORD = DB_PASSWORD.Obfuscate() ?? "",
            QUARTZ_DB_HOST,
            QUARTZ_DB_PORT,
            QUARTZ_DB_USER,
            QUARTZ_DB_PASSWORD = QUARTZ_DB_PASSWORD.Obfuscate() ?? "",
            SEQ_API_KEY = SEQ_API_KEY.Obfuscate() ?? "",
            SEQ_API_URL,
            POSTMARK_TOKEN = POSTMARK_TOKEN.Obfuscate() ?? "",
            EMAIL_FROM_ADDRESS,
            APP_AES_KEY = APP_AES_KEY.Obfuscate() ?? "",
            CERT1 = CERT1().PublicKey.Oid.FriendlyName,
            CANONICAL_FRONTEND_URL
        };
    }
}