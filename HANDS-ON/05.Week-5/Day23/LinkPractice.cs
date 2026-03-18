using System;
using System.Collections.Generic;

namespace LinqPractice
{
    internal class Product
    {
        public int ProCode { get; set; }
        public string ProName { get; set; }
        public string ProCategory { get; set; }
        public double ProMrp { get; set; }

        public List<Product> GetProducts()
        {
            return new List<Product>
            {
                 new Product{ProCode=1001,ProName="Colgate-100gm",ProCategory="FMCG",ProMrp=55 },
                 new Product{ProCode=1002,ProName="Colgate-50gm",ProCategory="FMCG",ProMrp=30 },
                 new Product{ProCode=1009,ProName="DaburRed-100gm",ProCategory="FMCG",ProMrp=50 },
                 new Product{ProCode=1006,ProName="DaburRed-50gm",ProCategory="FMCG",ProMrp=28 },
                 new Product{ProCode=1008,ProName="Himalaya Neem Face Wash",ProCategory="FMCG",ProMrp=70 },
                 new Product{ProCode=1007,ProName="Niviea Face Wash",ProCategory="FMCG",ProMrp=120 },
                 new Product{ProCode=1010,ProName="Daawat-Basmati",ProCategory="Grain",ProMrp=130 },
                 new Product{ProCode=1011,ProName="Delhi Gate-Basmati",ProCategory="Grain",ProMrp=120 },
                 new Product{ProCode=1014,ProName="Saffola-Oil",ProCategory="Edible-Oil",ProMrp=160 },
                 new Product{ProCode=1016,ProName="Fortune-Oil",ProCategory="Edible-Oil",ProMrp=150 },
                 new Product{ProCode=1018,ProName="Nescafe",ProCategory="FMCG",ProMrp=70 },
                 new Product{ProCode=1019,ProName="Bru",ProCategory="FMCG",ProMrp=90},
                 new Product{ProCode=1015,ProName="Parachut",ProCategory="Edible-Oil",ProMrp=60}
            };
        }
    }

    internal class Program
    {
        static void Main()
        {
            Product product = new Product();
            var products = product.GetProducts();

            //1.Write a LINQ query to search and display all products with category “FMCG”.
            var categoryFMCG =
                from p in products
                where p.ProCategory == "FMCG"
                select p;

            Console.WriteLine("FMCG Products:");

            foreach (var item in categoryFMCG)
            {
                Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProMrp}\t{item.ProCategory}");
            }


            //2.Write a LINQ query to search and display all products with category “Grain”.
            var categoryGrain =
                from p in products
                where p.ProCategory == "Grain"
                select p;

            Console.WriteLine("\nGrain Products:");

            foreach (var item in categoryGrain)
            {
                Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProMrp}\t{item.ProCategory}");
            }


            //3.Write a LINQ query to sort products in ascending order by product code.
            var productsAscByProCode =
                from p in products
                orderby p.ProCode
                select p;

            Console.WriteLine("\nProducts Sorted By Code:");

            foreach (var item in productsAscByProCode)
            {
                Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProMrp}");
            }


            //4. Write a LINQ query to sort products in ascending order by product Category.
            var productsAscByProCate =
                from p in products
                orderby p.ProCategory
                select p;

            Console.WriteLine("\nProducts Sorted By Category:");

            foreach (var item in productsAscByProCate)
            {
                Console.WriteLine($"{item.ProCategory}\t{item.ProName}\t{item.ProMrp}");
            }


            //5. Write a LINQ query to sort products in ascending order by product Mrp.
            var productsAscByProMrp =
                from p in products
                orderby p.ProMrp
                select p;

            Console.WriteLine("\nProducts Sorted By MRP (Ascending):");

            foreach (var item in productsAscByProMrp)
            {
                Console.WriteLine($"{item.ProName}\t{item.ProMrp}");
            }


            //6.Write a LINQ query to sort products in descending order by product Mrp.
            var productsDescByProMrp =
                from p in products
                orderby p.ProMrp descending
                select p;

            Console.WriteLine("\nProducts Sorted By MRP (Descending):");

            foreach (var item in productsDescByProMrp)
            {
                Console.WriteLine($"{item.ProName}\t{item.ProMrp}");
            }


            //7. Write a LINQ query to display products group by product Category.
            var dispProByProCate =
                from p in products
                group p by p.ProCategory;

            Console.WriteLine("\nProducts Grouped By Category:");

            foreach (var group in dispProByProCate)
            {
                Console.WriteLine($"Category: {group.Key}");

                foreach (var item in group)
                {
                    Console.WriteLine($"{item.ProName}\t{item.ProMrp}");
                }
            }


            //8. Write a LINQ query to display products group by product Mrp.
            var dispProByProMrp =
                from p in products
                group p by p.ProMrp;

            Console.WriteLine("\nProducts Grouped By MRP:");

            foreach (var group in dispProByProMrp)
            {
                Console.WriteLine($"MRP: {group.Key}");

                foreach (var item in group)
                {
                    Console.WriteLine($"{item.ProName}\t{item.ProCategory}");
                }
            }


            //9. Write a LINQ query to display product detail with highest price in FMCG category.
            var highestPriceProdFCMGCate =
                (from p in products
                 where p.ProCategory == "FMCG"
                 orderby p.ProMrp descending
                 select p).First();

            Console.WriteLine($"\nHighest Price FMCG Product:");
            Console.WriteLine($"{highestPriceProdFCMGCate.ProCode}\t{highestPriceProdFCMGCate.ProName}\t{highestPriceProdFCMGCate.ProMrp}");


            //10. Write a LINQ query to display count of total products.
            int totalProductsCount = products.Count();

            Console.WriteLine($"\nTotal Products: {totalProductsCount}");


            //11. Write a LINQ query to display count of total products with category FMCG.
            int totalProductsInFMCG = products.Count(p => p.ProCategory == "FMCG");

            Console.WriteLine($"\nTotal FMCG Products: {totalProductsInFMCG}");


            //12.Write a LINQ query to display Max price.
            double maxPrice = products.Max(p => p.ProMrp);

            Console.WriteLine($"\nMax Price: {maxPrice}");


            //13.Write a LINQ query to display Min price.
            double minPrice = products.Min(p => p.ProMrp);

            Console.WriteLine($"\nMin Price: {minPrice}");


            //14. Write a LINQ query to display whether all products are below Mrp Rs.30 or not.
            bool areAllProductsBelowMrp30OrNot = products.All(p => p.ProMrp < 30);

            Console.WriteLine($"\nAll products below Rs.30: {areAllProductsBelowMrp30OrNot}");


            //15. Write a LINQ query to display whether any products are below Mrp Rs.30 or not.
            bool areAnyProductsBelowMrp30OrNot = products.Any(p => p.ProMrp < 30);

            Console.WriteLine($"\nAny product below Rs.30: {areAnyProductsBelowMrp30OrNot}");

            Console.ReadLine();
        }
    }
}
