using System;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n1 Insert Product");
            Console.WriteLine("2 View Products");
            Console.WriteLine("3 Update Product");
            Console.WriteLine("4 Delete Product");
            Console.WriteLine("5 Exit");

            Console.Write("Enter choice: ");
            int ch = Convert.ToInt32(Console.ReadLine());

            switch (ch)
            {
                case 1: InsertProduct(); break;
                case 2: ViewProducts(); break;
                case 3: UpdateProduct(); break;
                case 4: DeleteProduct(); break;
                case 5: return;
            }
        }
    }

    static string GetConnectionString()
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        return config.GetConnectionString("DefaultConnection");
    }

    // INSERT
    static void InsertProduct()
    {
        using SqlConnection con = new SqlConnection(GetConnectionString());

        SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Products", con);
        SqlCommandBuilder cb = new SqlCommandBuilder(da);

        DataSet ds = new DataSet();
        da.Fill(ds, "Products");

        DataRow row = ds.Tables["Products"].NewRow();

        Console.Write("Product Name: ");
        row["ProductName"] = Console.ReadLine();

        Console.Write("Category: ");
        row["Category"] = Console.ReadLine();

        Console.Write("Price: ");
        row["Price"] = Convert.ToDecimal(Console.ReadLine());

        ds.Tables["Products"].Rows.Add(row);

        da.Update(ds, "Products");

        Console.WriteLine("Product inserted successfully");
    }

    // READ
    static void ViewProducts()
    {
        using SqlConnection con = new SqlConnection(GetConnectionString());

        SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Products", con);

        DataSet ds = new DataSet();
        da.Fill(ds, "Products");

        foreach (DataRow row in ds.Tables["Products"].Rows)
        {
            Console.WriteLine(
                row["ProductId"] + " | " +
                row["ProductName"] + " | " +
                row["Category"] + " | " +
                row["Price"]);
        }
    }

    // UPDATE
    static void UpdateProduct()
    {
        using SqlConnection con = new SqlConnection(GetConnectionString());

        SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Products", con);
        SqlCommandBuilder cb = new SqlCommandBuilder(da);

        DataSet ds = new DataSet();
        da.Fill(ds, "Products");

        Console.Write("Enter Product Id: ");
        int id = Convert.ToInt32(Console.ReadLine());

        bool found = false;

        foreach (DataRow row in ds.Tables["Products"].Rows)
        {
            if ((int)row["ProductId"] == id)
            {
                found = true;

                Console.Write("New Name: ");
                row["ProductName"] = Console.ReadLine();

                Console.Write("New Category: ");
                row["Category"] = Console.ReadLine();

                Console.Write("New Price: ");
                row["Price"] = Convert.ToDecimal(Console.ReadLine());
            }
        }

        if (found)
        {
            da.Update(ds, "Products");
            Console.WriteLine("Product updated successfully");
        }
        else
        {
            Console.WriteLine("Product not found");
        }
    }

    // DELETE
    static void DeleteProduct()
    {
        using SqlConnection con = new SqlConnection(GetConnectionString());

        SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Products", con);
        SqlCommandBuilder cb = new SqlCommandBuilder(da);

        DataSet ds = new DataSet();
        da.Fill(ds, "Products");

        Console.Write("Enter Product Id to delete: ");
        int id = Convert.ToInt32(Console.ReadLine());

        bool found = false;

        foreach (DataRow row in ds.Tables["Products"].Rows)
        {
            if ((int)row["ProductId"] == id)
            {
                row.Delete();
                found = true;
                break;
            }
        }

        if (found)
        {
            da.Update(ds, "Products");
            Console.WriteLine("Product deleted successfully");
        }
        else
        {
            Console.WriteLine("Product not found");
        }
    }
}