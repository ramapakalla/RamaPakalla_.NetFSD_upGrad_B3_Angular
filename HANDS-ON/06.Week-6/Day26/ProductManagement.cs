using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n==== PRODUCT MANAGEMENT ====");
                Console.WriteLine("1. Insert Product");
                Console.WriteLine("2. View All Products");
                Console.WriteLine("3. Update Product");
                Console.WriteLine("4. Delete Product");
                Console.WriteLine("5. Get Product By Id");
                Console.WriteLine("6. Exit");

                Console.Write("Enter choice: ");
                int choice;

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        InsertProduct();
                        break;

                    case 2:
                        GetAllProducts();
                        break;

                    case 3:
                        UpdateProduct();
                        break;

                    case 4:
                        DeleteProduct();
                        break;

                    case 5:
                        GetProductById();
                        break;

                    case 6:
                        return;
                }
            }
        }

        static string GetConnectionString()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            return config.GetConnectionString("DefaultConnection");
        }

        static void InsertProduct()
        {
            try
            {
                Console.Write("Enter Product Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Category: ");
                string category = Console.ReadLine();

                Console.Write("Enter Price: ");
                decimal price = Convert.ToDecimal(Console.ReadLine());

                string connStr = GetConnectionString();

                using (SqlConnection conn = new SqlConnection(connStr))
                using (SqlCommand cmd = new SqlCommand("sp_InsertProduct", conn))
                {
                    conn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@ProductName", SqlDbType.VarChar) { Value = name });
                    cmd.Parameters.Add(new SqlParameter("@Category", SqlDbType.VarChar) { Value = category });
                    cmd.Parameters.Add(new SqlParameter("@Price", SqlDbType.Decimal) { Value = price });

                    int n = cmd.ExecuteNonQuery();

                    Console.WriteLine("No.of rows affected: " + n);
                    Console.WriteLine("Product inserted successfully.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error inserting product: " + ex.Message);
            }
        }

        static void GetAllProducts()
        {
            try
            {
                string connStr = GetConnectionString();

                using (SqlConnection conn = new SqlConnection(connStr))
                using (SqlCommand cmd = new SqlCommand("sp_GetAllProducts", conn))
                {
                    conn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(
                                reader["ProductId"] + " " +
                                reader["ProductName"] + " " +
                                reader["Category"] + " " +
                                reader["Price"]
                            );
                        }
                    }

                    Console.WriteLine("Products retrieved successfully.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving products: " + ex.Message);
            }
        }

        static void UpdateProduct()
        {
            try
            {
                Console.Write("Enter Product Id: ");
                int id = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter New Product Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Category: ");
                string category = Console.ReadLine();

                Console.Write("Enter Price: ");
                decimal price = Convert.ToDecimal(Console.ReadLine());

                string connStr = GetConnectionString();

                using (SqlConnection conn = new SqlConnection(connStr))
                using (SqlCommand cmd = new SqlCommand("sp_UpdateProduct", conn))
                {
                    conn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@ProductId", SqlDbType.Int) { Value = id });
                    cmd.Parameters.Add(new SqlParameter("@ProductName", SqlDbType.VarChar) { Value = name });
                    cmd.Parameters.Add(new SqlParameter("@Category", SqlDbType.VarChar) { Value = category });
                    cmd.Parameters.Add(new SqlParameter("@Price", SqlDbType.Decimal) { Value = price });

                    int n = cmd.ExecuteNonQuery();

                    Console.WriteLine("No.of rows affected: " + n);
                    Console.WriteLine("Product updated successfully.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating product: " + ex.Message);
            }
        }

        static void DeleteProduct()
        {
            try
            {
                Console.Write("Enter Product Id to delete: ");
                int id = Convert.ToInt32(Console.ReadLine());

                string connStr = GetConnectionString();

                using (SqlConnection conn = new SqlConnection(connStr))
                using (SqlCommand cmd = new SqlCommand("sp_DeleteProduct", conn))
                {
                    conn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@ProductId", SqlDbType.Int) { Value = id });

                    int n = cmd.ExecuteNonQuery();

                    Console.WriteLine("No.of rows affected: " + n);
                    Console.WriteLine("Product deleted successfully.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting product: " + ex.Message);
            }
        }

        static void GetProductById()
        {
            try
            {
                Console.Write("Enter Product Id: ");
                int id = Convert.ToInt32(Console.ReadLine());

                string connStr = GetConnectionString();

                using (SqlConnection conn = new SqlConnection(connStr))
                using (SqlCommand cmd = new SqlCommand("sp_GetProductById", conn))
                {
                    conn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@ProductId", SqlDbType.Int) { Value = id });

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Console.WriteLine(
                                reader["ProductId"] + " " +
                                reader["ProductName"] + " " +
                                reader["Category"] + " " +
                                reader["Price"]
                            );

                            Console.WriteLine("Product retrieved successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Product not found.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving product: " + ex.Message);
            }
        }
    }
}