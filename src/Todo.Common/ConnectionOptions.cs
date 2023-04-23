namespace Todo.Common
{
    public class ConnectionOptions
    {
        private static ConnectionOptions _instance;

        public string ConnSqlServer { get; set; }
        public string ConnPostgres { get; set; }

        public struct FieldsName
        {
            public static readonly string ConnSqlServer = "ConnSqlServer";
            public static readonly string ConnPostgres = "ConnPostgres";
        }

        protected ConnectionOptions() { }

        public ConnectionOptions(string connStr)
        {
            GetInstance().ConnSqlServer = connStr;
        }

        public static ConnectionOptions GetInstance()
        {
            if (_instance is null)
                _instance = new ConnectionOptions();

            return _instance;
        }
    }
}
