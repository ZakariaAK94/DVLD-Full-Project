using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsTestAppointmentsData
    {

        public static bool GetTestAppointementsInfoByID(int TestAppointmentID, ref int TestTypeID,
            ref int LocalDrivingLicenseApplicationID, ref int CreatedByUserID, ref bool IsLocked, 
            ref DateTime AppointmentDate, ref float PaidFees, ref int RetakeTestApplID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM TestAppointments WHERE TestAppointmentID = @TestAppointmentID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;
                    TestTypeID = (int)reader["TestTypeID"];
                    LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IsLocked = (bool)reader["IsLocked"];
                    AppointmentDate = (DateTime)reader["AppointmentDate"];               
                    PaidFees = (float)reader["PaidFees"];
                    if (reader["RetakeTestApplicationID"] == DBNull.Value)
                        RetakeTestApplID = -1;
                    else
                        RetakeTestApplID = (int)reader["RetakeTestApplicationID"];
                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static int AddNewtestAppointment(int TestTypeID, int LocalDrivingLicenseApplicationID,int CreatedByUserID,
            bool IsLocked,DateTime AppointmentDate, float PaidFees, int RetakeTestApplID)
        {
            //this function will return the new contact id if succeeded and -1 if not.
            int TestAppointmentID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO TestAppointments (TestTypeID,LocalDrivingLicenseApplicationID,CreatedByUserID,IsLocked,
                                         AppointmentDate,PaidFees,RetakeTestApplicationID)
                         VALUES (@TestTypeID,@LocalDrivingLicenseApplicationID, @CreatedByUserID,@IsLocked,@AppointmentDate, @PaidFees,@RetakeTestApplicationID);
                         SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@IsLocked", IsLocked);
            command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            if(RetakeTestApplID == -1)
            {
                command.Parameters.AddWithValue("@RetakeTestApplicationID", DBNull.Value);
            }else
                command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    TestAppointmentID = insertedID;
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);

            }
            finally
            {
                connection.Close();
            }
            return TestAppointmentID;
        }

            

        public static bool UpdateTestAppointement(int TestAppointmentID, int TestTypeID, int LocalDrivingLicenseApplicationID,
            int CreatedByUserID, bool IsLocked, DateTime AppointmentDate, float PaidFees, int RetakeTestApplID)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update TestAppointments  
                            set TestTypeID=@TestTypeID,
                                LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID,
                                CreatedByUserID=@CreatedByUserID,
                                IsLocked=@IsLocked,
                                AppointmentDate=@AppointmentDate,
                                PaidFees=@PaidFees,
                                RetakeTestApplicationID = @RetakeTestApplicationID
                                where TestAppointmentID = @TestAppointmentID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@IsLocked", IsLocked);
            command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            if (RetakeTestApplID == -1)
            {
                command.Parameters.AddWithValue("@RetakeTestApplicationID", DBNull.Value);
            }
            else
                command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplID);
            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

        public static DataTable GetAllTestAppointements()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM TestAppointments_View order by AppointementDate desc";

            SqlCommand command = new SqlCommand(query, connection);

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

        public static DataTable GetApplicationTestAppointmentsPerTestType(int LocalDrivingLicenseApplicationID,
            int TestTypeID)
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT TestAppointmentID as AppointmentID,AppointmentDate,PaidFees,IsLocked 
                            FROM TestAppointments where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                             and TestTypeID = @TestTypeID ORDER BY TestAppointmentID desc;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
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

        public static bool GetLastTestAppointment (int LocalDrivingLicenseApplicationID, int TestTypeID,ref int TestAppointmentID, 
            ref DateTime AppointmentDate,ref float PaidFees, ref int CreatedByUserID, ref bool IsLocked, ref int RetakeTestApplicationID)
        {

            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT top 1 * FROM TestAppointments 
                            where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                             and TestTypeID = @TestTypeID 
                             ORDER BY TestAppointmentID desc;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    IsFound = true;
                    TestTypeID = (int)reader["TestTypeID"];
                    LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IsLocked = (bool)reader["IsLocked"];
                    AppointmentDate = (DateTime)reader["AppointmentDate"];
                    PaidFees = (float)reader["PaidFees"];
                    if (reader["RetakeTestApplicationID"] == DBNull.Value)
                        RetakeTestApplicationID = -1;
                    else
                        RetakeTestApplicationID = (int)reader["RetakeTestApplicationID"];
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

            return IsFound;

        }

        public static int GetTestID(int TestAppointmentID)
        {
            int TestID =-1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT TestID FROM TestAppointments where TestAppointmentID = @TestAppointmentID ;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            try
            {
                connection.Open();

                object Result = command.ExecuteScalar();

                if (Result!=null && int.TryParse(Result.ToString(), out int ID))
                {
                    TestID = ID;
                }

            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return TestID;


        }

    }
}












