using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_DataAccess
{
    public class clsInternationalLicensesDataAccess
    {
        //public static bool GetLicenseInfoByApplicationID(int ApplicationID, ref int LicenseID, ref int DriverID, ref int LicenseClass, ref DateTime IssueDate,
        //    ref DateTime ExpirationDate, ref string Notes, ref decimal PaidFees, ref bool IsActive, ref byte IssueReason, ref int CreatedByUserID)
        //{
        //    bool isFound = false;

        //    SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

        //    string query = "SELECT * FROM Licenses WHERE ApplicationID = @ApplicationID";

        //    SqlCommand command = new SqlCommand(query, connection);

        //    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

        //    try
        //    {
        //        connection.Open();
        //        SqlDataReader reader = command.ExecuteReader();

        //        if (reader.Read())
        //        {
        //            // The record was found
        //            isFound = true;
        //            LicenseID = (int)reader["LicenseID"];
        //            DriverID = (int)reader["DriverID"];
        //            LicenseClass = (int)reader["LicenseClass"];
        //            IssueDate = (DateTime)reader["IssueDate"];
        //            ExpirationDate = (DateTime)reader["ExpirationDate"];
        //            if (reader["Notes"] != DBNull.Value)
        //            {
        //                Notes = (string)reader["Notes"];
        //            }
        //            else
        //            {
        //                Notes = "";
        //            }
        //            IssueReason = (byte)reader["IssueReason"];
        //            IsActive = (bool)reader["IsActive"];
        //            PaidFees = (decimal)reader["PaidFees"];
        //            CreatedByUserID = (int)reader["CreatedByUserID"];

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
        //        //Console.WriteLine("Error: " + ex.Message);
        //        isFound = false;
        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }

        //    return isFound;
        //}
        
        //public static bool GetInternationalLicenseInfoByLicenseID(int InternationalLicenseID, ref int IssuedUsingLocalLicenseID, ref int ApplicationID, 
        //    ref int DriverID, ref DateTime IssueDate, ref DateTime ExpirationDate, ref bool IsActive, ref int CreatedByUserID)
        //{
        //    bool isFound = false;

        //    SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

        //    string query = "SELECT * FROM InternationalLicenses WHERE InternationalLicenseID = @InternationalLicenseID";

        //    SqlCommand command = new SqlCommand(query, connection);

        //    command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);

        //    try
        //    {
        //        connection.Open();
        //        SqlDataReader reader = command.ExecuteReader();

        //        if (reader.Read())
        //        {
        //            // The record was found
        //            isFound = true;

        //            IssuedUsingLocalLicenseID = (int)reader["IssuedUsingLocalLicenseID"];
        //            ApplicationID = (int)reader["ApplicationID"];
        //            DriverID = (int)reader["DriverID"];
        //            IssueDate = (DateTime)reader["IssueDate"];
        //            ExpirationDate = (DateTime)reader["ExpirationDate"];                   
        //            IsActive = (bool)reader["IsActive"];                    
        //            CreatedByUserID = (int)reader["CreatedByUserID"];

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


        public static bool GetInternationalLicenseInfoByInterLicenseID(int InternationalLicenseID, ref int ApplicationID, ref int DriverID, ref int IssuedUsingLocalLicenseID,
          ref DateTime IssueDate, ref DateTime ExpirationDate, ref bool IsActive, ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM InternationalLicenses WHERE InternationalLicenseID = @InternationalLicenseID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;
                    ApplicationID = (int)reader["ApplicationID"];
                    DriverID = (int)reader["DriverID"];
                    IssuedUsingLocalLicenseID = (int)reader["IssuedUsingLocalLicenseID"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    IsActive = (bool)reader["IsActive"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];

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

        public static int AddNewInternationalLicense(int ApplicationID, int DriverID, int IssuedUsingLocalLicenseID, DateTime IssueDate,
            DateTime ExpirationDate, bool IsActive, int CreatedByUserID)
        {
            //this function will return the new contact id if succeeded and -1 if not.
            int InternationalLicenseID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update InternationalLicenses
                             set IsActive =0 where DriverID = @DriverID;                   
                             INSERT INTO InternationalLicenses (ApplicationID,DriverID,IssuedUsingLocalLicenseID, IssueDate,ExpirationDate,IsActive,CreatedByUserID)
                             VALUES (@ApplicationID,@DriverID,@IssuedUsingLocalLicenseID,@IssueDate,@ExpirationDate,@IsActive,@CreatedByUserID);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);     
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    InternationalLicenseID = insertedID;
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
            return InternationalLicenseID;
        }
        public static bool UpdateInternationalLicense(int InternationalLicenseID, int ApplicationID, int DriverID, int IssuedUsingLocalLicenseID, DateTime IssueDate,
            DateTime ExpirationDate, bool IsActive, int CreatedByUserID)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update InternationalLicenses  
                            set ApplicationID=@ApplicationID,
                                DriverID=@DriverID,
                                IssuedUsingLocalLicenseID=@IssuedUsingLocalLicenseID,
                                IssueDate=@IssueDate,
                                ExpirationDate=@ExpirationDate,                               
                                IsActive=@IsActive,                                
                                CreatedByUserID=@CreatedByUserID
                                where InternationalLicenseID = @InternationalLicenseID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            command.Parameters.AddWithValue("@IsActive", IsActive);           
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);

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

        public static DataTable GetDriverInternationalLicenses(int DriverID)
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select InternationalLicenseID, ApplicationID,IssuedUsingLocalLicenseID,IssueDate,ExpirationDate,IsActive
                             from InternationalLicenses WHERE DriverID =@DriverID order by ExpirationDate desc";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DriverID", DriverID);

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

        public static DataTable GetAllInternationalLicenses()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT InternationalLicenseID, ApplicationID,DriverID,IssuedUsingLocalLicenseID ,
                             IssueDate, ExpirationDate, IsActive FROM InternationalLicenses order by IsActive, ExpirationDate desc";

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

        public static int GetActiveInternationalLicenseIDByDriverID(int DriverID)
        {
            int ActiveInternationalLicenseID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT top 1 InternationalID FROM InternationalLicenses 
                            WHERE DriverID = @DriverID and GetDate() between IssueDate and ExpirationDate
                            order by ExpirationDate desc;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DriverID", DriverID);

            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();

                if(Result != null && int.TryParse(Result.ToString(),out int ID))
                {
                    ActiveInternationalLicenseID = ID;
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

            return ActiveInternationalLicenseID;
        }


        //public static DataTable FilterData(string ColumnName, string SearchQuery)
        //{

        //    DataTable dt = new DataTable();
        //    SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

        //    string query = "SELECT  *from InternationalLicenses where " + ColumnName + " like @SearchQuery";

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

        //public static DataTable CheckIfPersonHasAlreadySignUp(int PersonID)
        //{

        //    DataTable dt = new DataTable();
        //    SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

        //    string query = "SELECT LocalDrivingLicenseApplications.LicenseClassID,Applications.ApplicationStatus,Applications.ApplicationID " +
        //                   "FROM  Applications INNER JOIN  LocalDrivingLicenseApplications " +
        //                   "ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID" +
        //                   " where ApplicantPersonID = @PersonID";

        //    SqlCommand command = new SqlCommand(query, connection);
        //    command.Parameters.AddWithValue("@PersonID", PersonID);

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

