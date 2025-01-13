using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsDriversViewData
    {
        //public static DataTable GetViewOfAllDrivers()
        //{

        //    DataTable dt = new DataTable();
        //    SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

        //    string query = "SELECT * FROM Drivers_View";

        //    SqlCommand command = new SqlCommand(query, connection);

        //    try
        //    {
        //        connection.Open();

        //        SqlDataReader reader = command.ExecuteReader();

        //        if (reader.HasRows)

        //        {
        //            dt.Load(reader);
        //        }

        //        reader.Close();


        //    }

        //    catch (Exception ex)
        //    {
        //         Console.WriteLine("Error: " + ex.Message);
        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }

        //    return dt;

        //}

        //public static DataTable FilterData(string ColumnName, string SearchQuery)
        //{

        //    DataTable dt = new DataTable();
        //    SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

        //    string query = "SELECT  *from Drivers_View where " + ColumnName + " like @SearchQuery";

        //    SqlCommand command = new SqlCommand(query, connection);
        //    command.Parameters.AddWithValue("@SearchQuery", SearchQuery + "%");


        //    try
        //    {
        //        connection.Open();

        //        SqlDataReader reader = command.ExecuteReader();

        //        if (reader.HasRows)

        //        {
        //            dt.Load(reader);
        //        }

        //        reader.Close();


        //    }

        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Error: " + ex.Message);
        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }

        //    return dt;

        //}

    }
}
