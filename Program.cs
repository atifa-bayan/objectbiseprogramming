using System;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

public class InputValidationSanitization
{
    // Method to validate and sanitize username input
    public static string SanitizeInput(string input)
    {
        // Remove harmful characters to prevent XSS or other malicious injections
        return Regex.Replace(input, @"[<>""'%;]", string.Empty);
    }

    // Method to validate if the input is a valid email format
    public static bool IsValidEmail(string email)
    {
        string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        return Regex.IsMatch(email, emailPattern);
    }

    // Example method to handle login logic with SQL query
    public static bool Login(string username, string password)
    {
        // Sanitize user input before using it in any query or processing
        string sanitizedUsername = SanitizeInput(username);
        string sanitizedPassword = SanitizeInput(password);

        // Check if the email format is valid
        if (!IsValidEmail(sanitizedUsername))
        {
            Console.WriteLine("Invalid email format.");
            return false;
        }

        // Example of a parameterized SQL query to prevent SQL injection
        string connectionString = "YourConnectionStringHere";
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = "SELECT COUNT(*) FROM Users WHERE Email = @Email AND Password = @Password";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                // Use parameterized queries to prevent SQL injection
                cmd.Parameters.AddWithValue("@Email", sanitizedUsername);
                cmd.Parameters.AddWithValue("@Password", sanitizedPassword);

                conn.Open();
                int result = Convert.ToInt32(cmd.ExecuteScalar());
                return result > 0;
            }
        }
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Enter username (email): ");
        string username = Console.ReadLine();

        Console.WriteLine("Enter password: ");
        string password = Console.ReadLine();

        bool isAuthenticated = Login(username, password);

        Console.WriteLine(isAuthenticated ? "Login successful!" : "Login failed.");
    }
}