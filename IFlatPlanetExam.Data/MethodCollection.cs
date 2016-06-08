using IFlatPlanetExam.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace IFlatPlanetExam.Data
{
    public  class MethodCollection
    {
        /// <summary>
        /// Save click count
        /// </summary>
        /// <param name="count">count of clicked</param>
        /// <returns>number of affected rows</returns>
        public int Insert(int count)
        {
            int affectedRow = 0;
            using (SqlConnection con = new SqlConnection(AppConnectionString()))
            {
                //Validates if connectionstring was successfully read from app.config
                if (string.IsNullOrEmpty(con.ConnectionString)) return 0;

                SqlCommand cmd = new SqlCommand("spInsertCount", con);
                con.Open();
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@inClick", SqlDbType.Int).Value = count;
                    affectedRow = cmd.ExecuteNonQuery();
                }

                catch (Exception e)
                {
                    Console.Write("Error {0}", e.InnerException);
                }
                finally
                {
                    con.Close();
                }
            }
            return affectedRow;
        }

        /// <summary>
        /// Reads total clicked 
        /// </summary>
        /// <returns>Total count</returns>
        public int Count()
        {
            PressViewModel press = new PressViewModel();
            SqlConnection con = new SqlConnection(AppConnectionString());

            //Validates if connectionstring was successfully read from app.config
            if (string.IsNullOrEmpty(con.ConnectionString)) return 0;

            try
            {
                using (con)
                {
                    SqlCommand cmd = new SqlCommand("spGetClickCount", con);
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                press.count = Convert.ToInt32(dr["Counts"]);
                            }
                        }
                        dr.Close();
                        dr.Dispose();
                    }
                }
            }
            catch (Exception e)
            {
                Console.Write("Error {0}", e.InnerException);
            }
            finally
            {
                con.Close();
            }
            return press.count;
        }

         public string AppConnectionString()
        {
            String connStr;
            return connStr = System.Configuration.ConfigurationSettings.AppSettings["AppConnectionString"];
            //return "Data Source=.\\SQLEXPRESS;Initial Catalog=IFlatPlanet; Integrated Security=True";
        }
    }
}
