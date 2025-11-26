public class UpdateCommandeResult
{
    public UpdateCommandeResultStatus Status { get; init; }
    public Commande? Commande { get; init; }
}

public enum UpdateCommandeResultStatus
{
    Success,
    CommandeNotFound,
    ClientNotFound
}