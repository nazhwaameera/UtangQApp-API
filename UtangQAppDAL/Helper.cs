using Microsoft.Extensions.Configuration;

namespace UtangQAppDAL
{
    public class Helper
    {
        public static string GetConnectionString()
        {
            if (System.Configuration.ConfigurationManager.ConnectionStrings["MyDbConnectionString"] == null)
            {
                var MyConfig = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
                return MyConfig.GetConnectionString("MyDbConnectionString");
            }
            var connString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDbConnectionString"].ConnectionString;
            return connString;
        }
    }
}
