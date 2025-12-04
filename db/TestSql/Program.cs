using System;
using Microsoft.Data.SqlClient;

class Program
{
    static void Main()
    {
        var conn = "Server=127.0.0.1,1433;User Id=sa;Password=\"StrongPass2025!\";Encrypt=False;TrustServerCertificate=True;";

        try
        {
            using var c = new SqlConnection(conn);
            c.Open();
            Console.WriteLine("🔥 CONNEXION SQL OK !");
        }
        catch (Exception ex)
        {
            Console.WriteLine("❌ ERREUR SQL : " + ex.Message);
        }
    }
}