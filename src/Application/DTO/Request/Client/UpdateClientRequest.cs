public class UpdateClientRequest
{
public string ?Nom { get; set; }
public string ?Prenom { get; set; }
public string ?Email { get; set; }
public string ?Telephone { get; set; }
public string ?Adresse { get; set; }
    public Client ToDomain(Guid id)
    {
        return new Client
        {
            Id = id,
            Nom = this.Nom,
            Prenom = this.Prenom,
            Email = this.Email,
            Telephone = this.Telephone,
            Adresse = this.Adresse
        };

    }
}