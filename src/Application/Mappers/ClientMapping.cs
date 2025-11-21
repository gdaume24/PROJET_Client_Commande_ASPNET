public static class ClientMapping
{
    public static Client ToEntity(this CreateClientDto dto)
    {
        return new Client
        {
            Nom = dto.Nom,
            Prenom = dto.Prenom,
            Email = dto.Email,
            Adresse = dto.Adresse,
            Telephone = dto.Telephone
        };
    }
    public static Client ToEntity(this UpdateClientDto dto, int id)
    {
        return new Client
        {
            Id = id,
            Nom = dto.Nom,
            Prenom = dto.Prenom,
            Email = dto.Email,
            Adresse = dto.Adresse,
            Telephone = dto.Telephone
        };
    }
    public static ClientDto ToDto(this Client entity)
    {
        return new ClientDto
        {
            Nom = entity.Nom,
            Prenom = entity.Prenom,
            Email = entity.Email,
            Adresse = entity.Adresse,
            Telephone = entity.Telephone
        };
    }
}