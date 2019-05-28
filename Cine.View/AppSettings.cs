namespace Cine.View
{
    public class AppSettings
    {
        public string MovieDBUrl { get; set; }
        public string CineApiUrl { get; set; }

        public string MovieDBKey { get; set; }

        //public Logging Logging { get; set; }

    }

    public class Connectionstrings
    {
        public string DefaultConnection { get; set; }
    }

    //public class Logging
    //{
    //    public bool IncludeScopes { get; set; }
    //    public Loglevel LogLevel { get; set; }
    //}

    //public class Loglevel
    //{
    //    public string Default { get; set; }
    //    public string System { get; set; }
    //    public string Microsoft { get; set; }
    //}
}
