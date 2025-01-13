using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsTestAppointmentsViewData
    {
        public static DataTable GetViewOfAllTestAppointementsByDLApplicationIDAndTypeTitle(int LocalDrivingLicenseApplicationID, string TestTypeTitle)
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT TestAppointmentID as AppointmentID,AppointmentDate,PaidFees,IsLocked FROM TestAppointments_View where" +
                " LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID and TestTypeTitle = @TestTypeTitle ORDER BY TestAppointmentID desc;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeTitle", TestTypeTitle);
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)

                {
                    dt.Load(reader);
                }

                reader.Close();


            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;

        }

        //public static DataTable GetViewOfAllTestAppointementsByTestAppointmentID(int TestAppointmentID)
        //{

        //    DataTable dt = new DataTable();
        //    SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

        //    string query = "SELECT TestAppointmentID as AppointmentID,AppointmentDate,PaidFees,IsLocked FROM TestAppointments_View where" +
        //        " TestAppointmentID = @TestAppointmentID";

        //    SqlCommand command = new SqlCommand(query, connection);
        //    command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
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
        //        // Console.WriteLine("Error: " + ex.Message);
        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }

        //    return dt;

        //}







        
    }
}
