using System;
using System.Data;
using System.Data.SqlClient;

namespace Dev_DAL
{
    static public class clsDeveloperData
    {
        static public string connectionString = clsDataAccessSettings.ConnectionString;

        // Add a new developer and return the new DeveloperID
        static public int AddDeveloper(string firstName, string lastName, string email)
        {
            int newID = -1;
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("SP_AddDeveloper", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@LastName", lastName);
                cmd.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(email) ? (object)DBNull.Value : email);

                SqlParameter outputId = new SqlParameter("@NewID", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(outputId);

                conn.Open();
                cmd.ExecuteNonQuery();
                newID = (int)outputId.Value;
                return newID;
            }
        }

        // Update a developer by ID, return true if success
        static public bool UpdateDeveloper(int developerID, string firstName, string lastName, string email)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("SP_UpdateDeveloper", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DeveloperID", developerID);
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@LastName", lastName);
                cmd.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(email) ? (object)DBNull.Value : email);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }

        // Delete a developer by ID, return true if success
        static public bool DeleteDeveloper(int developerID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("SP_DeleteDeveloper", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DeveloperID", developerID);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }

        // Get a developer by ID using ref parameters
        static public bool GetDeveloperByID(int developerID, ref string firstName, ref string lastName, ref string email, ref DateTime hireDate)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("SP_GetDeveloperByID", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DeveloperID", developerID);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        firstName = reader["FirstName"].ToString();
                        lastName = reader["LastName"].ToString();
                        email = reader["Email"] != DBNull.Value ? reader["Email"].ToString() : string.Empty;
                        hireDate = (DateTime)reader["HireDate"];
                        return true;
                    }
                    else
                        return false;
                }
            }
        }
        
        // Get all developers
        static public DataTable GetAllDevelopers()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("SP_GetAllDevelopers", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        // Check if developer exists by email
        static public bool DeveloperExists(string email)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("SP_DeveloperExists", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Email", email);

                conn.Open();
                object result = cmd.ExecuteScalar();
                return Convert.ToInt32(result) == 1;
            }
        }
    }
}