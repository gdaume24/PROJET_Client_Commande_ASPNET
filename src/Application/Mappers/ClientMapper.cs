public static class ClientMapper
{
    public static ClientResponseWithoutCommands ToResponse(this Client client)
        => new ClientResponseWithoutCommands
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