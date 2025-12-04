#r "nuget: Microsoft.Data.SqlClient, 5.2.0"

using Microsoft.Data.SqlClient;

var conn = "Server=127.0.0.1,1433;User Id=sa;Password=StrongPass2025!;Encrypt=False;TrustServerCertificate=True;";

try {
    using var c = new SqlConnection(conn);
    c.Open();
    Console.WriteLine("CONNEXION SQL OK !");
}
catch (Exception ex) {
    Console.WriteLine("ERREUR SQL : " + ex.Message);
}