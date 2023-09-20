using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReaolMarkedet.Model;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration.Json;



namespace ReaolMarkedet.Controller
{
    internal class BarcodeRepository
    {
        private readonly string connectionString;

        public BarcodeRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void AddBarcode(Barcode barcode)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = "INSERT INTO RM_BARCODE (BarcodeInNumbers, DiscountInPercentage) VALUES (@BarcodeInNumbers, @DiscountInPercentage)";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@BarcodeInNumbers", barcode.BarcodeInNumbers);
                    command.Parameters.AddWithValue("@DiscountInPercentage", barcode.DiscountInPercentage);

                    command.ExecuteNonQuery();
                }
            }
        }

        public Barcode GetBarcode(string barcodeInNumbers)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = "SELECT BarcodeInNumbers, DiscountInPercentage FROM RM_BARCODE WHERE BarcodeInNumbers = @BarcodeInNumbers";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@BarcodeInNumbers", barcodeInNumbers);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Barcode
                            {
                                BarcodeInNumbers = reader["BarcodeInNumbers"].ToString(),
                                DiscountInPercentage = Convert.ToDouble(reader["DiscountInPercentage"]),
                                // You can retrieve other properties as needed
                            };
                        }
                    }
                }
            }

            return null;
        }

        public void RemoveBarcode(string barcodeInNumbers)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = "DELETE FROM RM_BARCODE WHERE BarcodeInNumbers = @BarcodeInNumbers";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@BarcodeInNumbers", barcodeInNumbers);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
