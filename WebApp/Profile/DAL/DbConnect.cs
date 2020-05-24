using Microsoft.Extensions.Configuration;

using MySql.Data.MySqlClient;

namespace Profile.DAL
{
    public class DbConnect
    {
        protected MySqlConnection connection;

        public DbConnect()
        {
            //GetConnection();
        }

        public MySqlConnection GetConnection()
        {
            try
            {
                IConfigurationBuilder builder = new ConfigurationBuilder().SetBasePath(System.IO.Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                IConfigurationRoot configuration = builder.Build();
                IConfigurationSection configurationSection = configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection");
                connection = new MySqlConnection(configurationSection.Value);
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }
                else
                {
                    connection.Close();
                }
            }

            catch (MySqlException mysqlEx)
            {
                throw mysqlEx;
            }

            return connection;
        }
    }
}