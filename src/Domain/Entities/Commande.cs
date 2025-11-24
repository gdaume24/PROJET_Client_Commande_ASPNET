
using System.Text.Json.Serialization;

public class Commande
{
public int Id { get; set; }
public required string NumeroCommande { get; set; }
public DateTime DateCommande { get; set; } = DateTime.Now;
public decimal MontantTotal { get; set; }
public required string Statut { get; set; }
public int ClientId { get; set; }
[JsonIgnore]
public Client? Client { get; set; }
}