using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReaolMarkedet.Model;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration;


namespace ReaolMarkedet.Controller
{
    internal class ShelfTenantRepository
    {
        private string connectionString;
        
        // Creates connection between Database and the program using the apsettings.json file and the string above
        public ShelfTenantRepository()
        {
            IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            string connectionString = config.GetConnectionString("MyDBConnection");
            this.connectionString = connectionString;
        }

        // method for adding shelftenant to repository.
        public void AddShelfTenant(ShelfTenant shelfTenant)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = "INSERT INTO RM_SHELFTENANT (TenantId, FirstName, LastName, Phone, Email, TotalSale, AccountDetails) VALUES (@TenantId, @FirstName, @LastName, @Phone, @Email, @TotalSale, @AccountDetails)";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@TenantId", shelfTenant.TenantId);
                    command.Parameters.AddWithValue("@FirstName", shelfTenant.FirstName);
                    command.Parameters.AddWithValue("@LastName", shelfTenant.LastName);
                    command.Parameters.AddWithValue("@Phone", shelfTenant.Phone);
                    command.Parameters.AddWithValue("@Email", shelfTenant.Email);
                    command.Parameters.AddWithValue("@TotalSale", shelfTenant.TotalSale);
                    command.Parameters.AddWithValue("@AccountDetails", shelfTenant.GetBankAccountDetails());

                    command.ExecuteNonQuery();
                }
            }
        }

        // method for retreiving shelftenant from DB.
        public ShelfTenant GetShelfTenant(int tenantId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = "SELECT TenantId, FirstName, LastName, Phone, Email, TotalSale, AccountDetails FROM RM_SHELFTENANT WHERE TenantId = @TenantId";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@TenantId", tenantId.ToString());

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new ShelfTenant
                            (
                                reader.GetInt32(reader.GetOrdinal("TenantId")),
                                reader["FirstName"].ToString(),
                                reader["LastName"].ToString(),
                                reader["Email"].ToString(),
                                reader["Phone"].ToString(),
                                reader["AccountDetails"].ToString(),
                                reader.GetDouble(reader.GetOrdinal("TotalSale"))
                            );

                        }
                    }
                }
            }

            return null;
        }

        public void UpdateShelfTenant(int tenantId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

               //
               //   add method for updating shelftenant here
               //
            }
        }

        // method for deleting shelftenant.
        public void RemoveShelfTenant(int tenantId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = "DELETE FROM RM_SHELFTENANT WHERE TenantId = @TenantId";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@TenantId", tenantId.ToString());
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
