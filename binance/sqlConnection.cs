using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace binance
{
    public class sqlConnection
    {
        //private static void DeleteExample()
        //{
        //    using (var context = new binanceEntities())
        //    {
        //        var category = context.Categories.Find(9);
        //        context.Categories.Remove(category);
        //        context.SaveChanges();

        //    }
        //}

        //private static void UpdateExample()
        //{
        //    using (var context = new binanceEntities())
        //    {
        //        var category = context.Categories.Find(9);

        //        category.CategoryName = "Spor";
        //        category.Description = "Bu bir spor kategorisidir.";

        //        context.SaveChanges();
        //    }
        //}

        public static void AddExample()
        {
            using (var context = new binanceEntities4())
            {
                Favorite category = new Favorite() { Id= 20020, bncSymbol = "X" };
                context.Favorite.Add(category);
                context.SaveChanges();
            }
        }

        public static void ReadExample()
        {
            binanceEntities4 context = new binanceEntities4();
            var favorites = context.Favorite.ToList();
            foreach (var item in favorites)
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.bncSymbol);
            }
        }

        public void test()
        {
            //string connectionString = "Data Source=DESKTOP-DUDNBKJ\\SQLEXPRESS;Initial Catalog=binance;Integrated Security=True;";

            //using (SqlConnection conn = new SqlConnection(connectionString))
            //{
            //    using (SqlCommand cmd = new SqlCommand())
            //    {
            //        cmd.CommandType = CommandType.Text;
            //        cmd.CommandText = "INSERT INTO Favorites ([bncID],[bncSymbol]) VALUES (@bncID,@bncSymbol)";
            //        cmd.Parameters.Add("@bncID", SqlDbType.Int).Value = 2;
            //        cmd.Parameters.Add("@bncSymbol", SqlDbType.NVarChar).Value = "wksdksdks";
            //        cmd.Connection = conn;
            //        conn.Open();
            //        int rowsAffected = cmd.ExecuteNonQuery();
            //    }
            //}
        }

    }
}