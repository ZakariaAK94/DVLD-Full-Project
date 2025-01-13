using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;

namespace DVLD_DataAccess
{
    public class clsTestsData
    {

        //public static bool GetTestInfoByID(int TestID, ref int TestAppointmentID, ref bool TestResult, ref string Notes, 
        //    ref int CreatedByUserID)
        //{
        //    bool isFound = false;

        //    SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

        //    string query = "SELECT * FROM Tests WHERE TestID = @TestID";

        //    SqlCommand command = new SqlCommand(query, connection);

        //    command.Parameters.AddWithValue("@TestID", TestID);

        //    try
        //    {
        //        connection.Open();
        //        SqlDataReader reader = command.ExecuteReader();

        //        if (reader.Read())
        //        {

        //            // The record was found
        //            isFound = true;
        //            TestAppointmentID = (int)reader["TestAppointmentID"];
        //            CreatedByUserID = (int)reader["CreatedByUserID"];
        //            TestResult = (bool)reader["TestResult"];                    
        //            if (reader["Notes"] != DBNull.Value)
        //            {
        //                Notes = (string)reader["Notes"];
        //            }
        //            else
        //            {
        //                Notes = "";
        //            }

        //        }
        //        else
        //        {
        //            // The record was not found
        //            isFound = false;
        //        }

        //        reader.Close();


        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Error: " + ex.Message);
        //        isFound = false;
        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }

        //    return isFound;
        //}

        public static DataTable GetAllTests()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Tests order by TestID";

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
        public static int AddNewTest(int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {
            //this function will return the new contact id if succeeded and -1 if not.
            int TestID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Tests (TestAppointmentID,TestResult,Notes,CreatedByUserID)
                             VALUES (@TestAppointmentID, @TestResult,@Notes,@CreatedByUserID);

                             update TestAppointment
                             set IsLocked =1 where TestAppointmentID = @TestAppointmentID;
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("@TestResult", TestResult);
            if (Notes != "")
                command.Parameters.AddWithValue("@Notes", Notes);
            else
                command.Parameters.AddWithValue("@Notes", System.DBNull.Value);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    TestID = insertedID;
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
        public static bool UpdateTest(int TestID, int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update Tests  
                            set TestAppointmentID=@TestAppointmentID,
                                TestResult=@TestResult,
                                Notes=@Notes,
                                CreatedByUserID=@CreatedByUserID                              
                                where TestID = @TestID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestID", TestID);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("@TestResult", TestResult);
            if (Notes != "")
                command.Parameters.AddWithValue("@Notesh", Notes);
            else
                command.Parameters.AddWithValue("@Notes", System.DBNull.Value);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);            

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
        public static bool GetTestByTestID(int TestID, ref int TestAppointmentID, ref bool TestResult, ref string Notes, ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Tests WHERE TestID = @TestID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestID", TestID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;
                    TestAppointmentID = (int)reader["TestAppointmentID"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    TestResult = (bool)reader["TestResult"];
                    if (reader["Notes"] != DBNull.Value)
                    {
                        Notes = (string)reader["Notes"];
                    }
                    else
                    {
                        Notes = "";
                    }


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

        public static byte GetPassedtestCount(int LocalDrivingLicenseApplication)
        {
            byte TotalPassedTest =0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT TotalPassedTests = count(TestTypeID)
                              FROM Tests INNER JOIN TestAppointments on Tests.TestAppointmentID = TestAppointments.TestAppointmentID
                              WHERE TestResult =1 and LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplication);

            try
            {
                connection.Open();
                object  Result = command.ExecuteScalar();

                if (Result!=null && byte.TryParse(Result.ToString(), out byte TotalTest))                    
                {

                    TotalPassedTest = TotalTest;
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

            return TotalPassedTest;
        }

        public static bool GetLastTestByPersonAndTestTypeAndLicenseClass(int PersonID, int TestTypeID, int LicenseClassID,
            ref int TestID,ref int TestAppointmentID, ref bool TestResult,ref string Notes, ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT    top 1 Tests.TestID, Tests.TestAppointmentID, Tests.TestResult, Tests.Notes, Tests.CreatedByUserID, Applications.ApplicantPersonID
            FROM Tests INNER JOIN TestAppointments ON  Tests.TestAppointmentID = TestAppointments.TestAppointmentID
            INNER JOIN LocalDrivingLicenseApplications on  LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID
            inner join Applications ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
            where Applications.ApplicantPersonID = @ApplicantPersonID 
            and TestAppointments.TestTypeID =@TestTypeID 
            and LocalDrivingLicenseApplications.ClassLicenseID = @ClassLicenseID
            order by Tests.TestAppointmenID desc;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicantPersonID", PersonID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@ClassLicenseID", LicenseClassID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if(reader.Read())
                {
                    isFound = true;
                    TestID = (int)reader["TestID"];
                    TestAppointmentID = (int)reader["TestAppointmentID"];
                    TestResult = (bool)reader["TestResult"];                 
                    if (reader["Notes"] != DBNull.Value)
                    {
                        Notes = (string)reader["Notes"];
                    }
                    else
                    {
                        Notes = "";
                    }
                    CreatedByUserID = (int)reader["CreatedByUserID"];
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

            return isFound;
        }

    }
}












