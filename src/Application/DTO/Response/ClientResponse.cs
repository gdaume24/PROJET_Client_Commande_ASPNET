

public class ClientResponse
{
	public Guid Id { get; set; }
	public string Nom { get; set; }
	public string Prenom { get; set; }
	public string Email { get; set; }
	public string Telephone { get; set; }
	public string Adresse { get; set; }
	public DateTime DateCreation { get; set; }

	public static ClientResponse FromDomain(Client c) => new ClientResponse
	{
		Id = c.Id,
		Nom = c.Nom,
		Prenom = c.Prenom,
		Email = c.Email,
		Telephone = c.Telephone,
		Adresse = c.Adresse,
		DateCreation = c.DateCreation
	};
}