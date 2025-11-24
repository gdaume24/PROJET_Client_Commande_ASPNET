public static class ClientMapper
{
    public static ClientResponse ToResponse(this Client client)
        => new ClientResponse
        {
            Id = client.Id,
            Nom = client.Nom,
            Prenom = client.Prenom,
            Email = client.Email,
            Telephone = client.Telephone,
            Adresse = client.Adresse,
            DateCreation = client.DateCreation
        };
}