using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsPersonData
    {   
        public static bool GetPersonInfoByID(int PersonID, ref string NationalNo,ref string FirstName, ref string SecondName,
                ref string ThirdName,ref string LastName,ref byte Gender, ref string Email, ref string Phone, ref string Address,
                ref DateTime DateOfBirth, ref int NationalityCountryID, ref string ImagePath)
            {
                bool isFound = false;

                SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

                string query = "SELECT * FROM People WHERE PersonID = @PersonID";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@PersonID", PersonID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        // The record was found
                        isFound = true;
                        NationalNo = (string)reader["NationalNo"];
                        FirstName = (string)reader["FirstName"];
                        SecondName = (string)reader["SecondName"];
                    //ThirdName,Email and imagepath: allow null in database so we should handle null                        
                        if (reader["ThirdName"] != DBNull.Value)
                        {
                            ThirdName = (string)reader["ThirdName"];
                        }
                        else
                        {
                            ThirdName = "";
                        }
                         LastName = (string)reader["LastName"];                                             
                        if (reader["Email"] != DBNull.Value)
                        {
                            Email = (string)reader["Email"];
                        }
                        else
                        {
                            Email = "";
                        }
                        Gender = (byte)reader["Gendor"];
                        Phone = (string)reader["Phone"];
                        Address = (string)reader["Address"];
                        DateOfBirth = (DateTime)reader["DateOfBirth"];
                        NationalityCountryID = (int)reader["NationalityCountryID"];

                        //ImagePath: allows null in database so we should handle null
                        if (reader["ImagePath"] != DBNull.Value)
                        {
                            ImagePath = (string)reader["ImagePath"];
                        }
                        else
                        {
                            ImagePath = "";
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

        public static bool GetPersonInfoByNationalNo(string NationalNo, ref int PersonID, ref string FirstName, ref string SecondName,
                ref string ThirdName, ref string LastName, ref byte Gender, ref string Email, ref string Phone, ref string Address,
                ref DateTime DateOfBirth, ref int NationalityCountryID, ref string ImagePath)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM People WHERE NationalNo = @NationalNo";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;
                    PersonID = (int)reader["PersonID"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];
                    //ThirdName,Email and imagepath: allow null in database so we should handle null
                    ThirdName = (string)reader["ThirdName"];
                    if (reader["ThirdName"] != DBNull.Value)
                    {
                        ThirdName = (string)reader["ThirdName"];
                    }
                    else
                    {
                        ThirdName = "";
                    }
                    LastName = (string)reader["LastName"];
                    if (reader["Email"] != DBNull.Value)
                    {
                        Email = (string)reader["Email"];
                    }
                    else
                    {
                        Email = "";
                    }
                    Gender = (byte)reader["Gendor"];
                    Phone = (string)reader["Phone"];
                    Address = (string)reader["Address"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    NationalityCountryID = (int)reader["NationalityCountryID"];

                    //ImagePath: allows null in database so we should handle null
                    if (reader["ImagePath"] != DBNull.Value)
                    {
                        ImagePath = (string)reader["ImagePath"];
                    }
                    else
                    {
                        ImagePath = "";
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

        public static int AddNewPerson(string FirstName, string SecondName, string ThirdName, string LastName,string NationalNo,
               byte Gender, string Email, string Phone, string Address, DateTime DateOfBirth, int NationalityCountryID, string ImagePath)
        {
            //this function will return the new contact id if succeeded and -1 if not.
            int PersonId = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO People (FirstName,SecondName,ThirdName,LastName,NationalNo,Gendor, Email, Phone, Address,DateOfBirth,
                             NationalityCountryID,ImagePath)
                             VALUES (@FirstName, @SecondName,@ThirdName, @LastName,@NationalNo,@Gendor, @Email, @Phone, @Address,@DateOfBirth, 
                             @NationalityCountryID,@ImagePath);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            if (ThirdName != "" && ImagePath != null)
                command.Parameters.AddWithValue("@ThirdName", ThirdName);
            else
                command.Parameters.AddWithValue("@ThirdName", System.DBNull.Value);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@Gendor", Gender);
            if (Email != "" && Email != null)
                command.Parameters.AddWithValue("@Email", Email);
            else
                command.Parameters.AddWithValue("@Email", System.DBNull.Value);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);          
            if (ImagePath != "" && ImagePath != null)
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
                command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    PersonId = insertedID;
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
            return PersonId;
        }




        public static int FindPersonID(string NationalNo)
        {
            int PersonID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT PersonID FROM People WHERE NationalNo = @NationalNo";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                                        
                    PersonID = (int)reader["PersonID"];                    

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

            return PersonID;
        }
       

            public static bool UpdatePerson(int PersonID,string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName,
                byte Gender,string Email, string Phone, string Address, DateTime DateOfBirth, int CountryID, string ImagePath)
            {

                int rowsAffected = 0;
                SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

                string query = @"Update  People  
                            set FirstName = @FirstName, 
                                SecondName = @SecondName, 
                                ThirdName = @ThirdName, 
                                LastName = @LastName, 
                                NationalNo = @NationalNo,
                                Gendor = @Gender, 
                                Email = @Email, 
                                Phone = @Phone, 
                                Address = @Address, 
                                DateOfBirth = @DateOfBirth,
                                NationalityCountryID = @NationalityCountryID,
                                ImagePath =@ImagePath
                                where PersonID = @PersonID";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@PersonId", PersonID);
                command.Parameters.AddWithValue("@FirstName", FirstName);
                command.Parameters.AddWithValue("@SecondName", SecondName);
                if (ThirdName != "" && ThirdName != null)
                    command.Parameters.AddWithValue("@ThirdName", ThirdName);
                else
                    command.Parameters.AddWithValue("@ThirdName", System.DBNull.Value);
                command.Parameters.AddWithValue("@LastName", LastName);
                command.Parameters.AddWithValue("@NationalNo", NationalNo);
                command.Parameters.AddWithValue("@Gender", Gender);
                if (Email != "" && Email != null)
                    command.Parameters.AddWithValue("@Email", Email);
                else
                    command.Parameters.AddWithValue("@Email", System.DBNull.Value);
                command.Parameters.AddWithValue("@Phone", Phone);
                command.Parameters.AddWithValue("@Address", Address);
                command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                command.Parameters.AddWithValue("@NationalityCountryID", CountryID);             
               
                if (ImagePath != "" && ImagePath != null)
                    command.Parameters.AddWithValue("@ImagePath", ImagePath);
                else
                    command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);


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

            public static DataTable GetAllPeople()
            {

                DataTable dt = new DataTable();
                SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT  People.PersonID, People.NationalNo, People.FirstName, People.SecondName, People.ThirdName,People.LastName,
                             case 
                                  when Gendor = 0 then 'Male' else 'Woman' 
                             end as 
                             GendorCaption,People.DateOfBirth,Countries.CountryName as Nationality,People.Phone, People.Email 
                             FROM Countries INNER JOIN People ON Countries.CountryID = People.NationalityCountryID
                             order by People.PersonID asc";


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

            public static bool DeletePerson(int PersonID)
            {

                int rowsAffected = 0;

                SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

                string query = @"Delete People 
                                where PersonId = @PersonId";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@PersonId", PersonID);

                try
                {
                    connection.Open();

                    rowsAffected = command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                finally
                {

                    connection.Close();

                }

                return (rowsAffected > 0);

            }

          

            
           // this function no need to create it, because it will slow down my project eaxh time read from database
           // however you can use data that was retrieved firstt time in datagridview
            //public static DataTable FilterData(string ColumnName,string SearchQuery)
            //{

            //      DataTable dt = new DataTable();
            //      SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
                  
            //      string query = "SELECT  *from People where " + ColumnName + " like @SearchQuery";
                  
            //      SqlCommand command = new SqlCommand(query, connection);
            //      command.Parameters.AddWithValue("@SearchQuery", SearchQuery+"%");
                  
                  
            //      try
            //      {
            //          connection.Open();
                  
            //          SqlDataReader reader = command.ExecuteReader();
                  
            //          if (reader.HasRows)
                  
            //          {
            //              dt.Load(reader);
            //          }
                  
            //          reader.Close();
                  
                  
            //      }
                  
            //      catch (Exception ex)
            //      {
            //          Console.WriteLine("Error: " + ex.Message);
            //      }
            //      finally
            //      {
            //          connection.Close();
            //      }
                  
            //      return dt;

            //}
           public static bool IsPersonExist(int PersonID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM People WHERE PersonId = @PersonId";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonId", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

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
           public static bool IsPersonExist(string NationalNo)
           {
                bool isFound = false;
            
                SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
                 
                 string query = "SELECT  found =1 from People where NationalNo = @NationalNo";

                 
                 SqlCommand command = new SqlCommand(query, connection);
                 command.Parameters.AddWithValue("@NationalNo", NationalNo);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                isFound = reader.HasRows;
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
            return isFound;           

            }

    }
    
}
