﻿using System;
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

        public ShelfTenantRepository()
        {
            IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            string connectionString = config.GetConnectionString("MyDBConnection");
            this.connectionString = connectionString;
        }

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

        public ShelfTenant GetShelfTenant(string tenantId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = "SELECT TenantId, FirstName, LastName, Phone, Email, TotalSale, AccountDetails FROM RM_SHELFTENANT WHERE TenantId = @TenantId";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@TenantId", tenantId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new ShelfTenant
                            (
                                tenantId = reader["TenantId"].Toint3(),
                                firstName = reader["FirstName"].ToString(),
                                lastName, email, phone, bankAccountDetails
                            )
                            {
                                TenantId = reader["TenantId"].ToString(),
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                Phone = reader["Phone"].ToString(),
                                Email = reader["Email"].ToString(),
                                TotalSale = Convert.ToDouble(reader["TotalSale"]),
                                // You can retrieve other properties as needed
                            };
                        }
                    }
                }
            }

            return null;
        }

        public void RemoveShelfTenant(string tenantId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = "DELETE FROM RM_SHELFTENANT WHERE TenantId = @TenantId";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@TenantId", tenantId);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
