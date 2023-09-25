using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration;
using ReaolMarkedet.Model;

namespace ReaolMarkedet.Controller
{
    internal class SaleRepository
    {
        private string connectionString;

        public SaleRepository()
        {
            IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            string connectionString = config.GetConnectionString("MyDBConnection");
            this.connectionString = connectionString;
        }

        public void AddSale(Sale sale)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = "INSERT INTO RM_SALE (SaleId, Price, DiscountInPercentage, PriceOfSale) VALUES (@SaleId, @Price, @DiscountInPercentage, @PriceOfSale)";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@SaleId", sale.SaleId);
                    command.Parameters.AddWithValue("@Price", sale.Price);
                    command.Parameters.AddWithValue("@DiscountInPercentage", sale.DiscountInPercentage);
                    command.Parameters.AddWithValue("@PriceOfSale", sale.PriceOfSale);

                    command.ExecuteNonQuery();
                }
            }
        }

        public Sale GetSale(int saleId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = "SELECT SaleId, Price, DiscountInPercentage, PriceOfSale FROM RM_SALE WHERE SaleId = @saleId";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@SaleId", saleId.ToString());

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            
                            string barcodeInNumbers = reader.GetString(reader.GetOrdinal("AssociatedBarcodeInNumbers"));
                            double price = reader.GetDouble(reader.GetOrdinal("Price"));
                            double discountInPercentage = reader.GetDouble(reader.GetOrdinal("DiscountInPercentage"));
                            double priceOfSale = reader.GetDouble(reader.GetOrdinal("PriceOfSale"));

                            Barcode associatedBarcode = BarcodeRepository.GetBarcode(barcodeInNumbers);

                            return new Sale(saleId, associatedBarcode, price, discountInPercentage, priceOfSale);
                        }
                    }
                }
            }

            return null;
        }

        public void RemoveSale(int saleId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = "DELETE FROM RM_SALE WHERE SaleId = @SaleId";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@SaleId", saleId.ToString());
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
