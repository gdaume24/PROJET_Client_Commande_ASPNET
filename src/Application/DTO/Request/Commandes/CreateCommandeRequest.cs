public record CreateCommandeRequest
{
public required string NumeroCommande { get; set; }
public required decimal MontantTotal { get; set; }
public required string Statut { get; set; }
public int ClientId { get; set; }
}