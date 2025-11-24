
public class Commande
{
public Guid Id { get; set; }
public required string NumeroCommande { get; set; }
public DateTime DateCommande { get; set; } = DateTime.Now;
public decimal MontantTotal { get; set; }
public required string Statut { get; set; }
public Guid ClientId { get; set; }
public Client? Client { get; set; }
}