public static class CommandeMapping
{
    public static Commande ToEntity(this CreateCommandeDto dto)
    {
        return new Commande
        {
            NumeroCommande = dto.NumeroCommande,
            MontantTotal = dto.MontantTotal,
            Statut = dto.Statut,
            ClientId = dto.ClientId
        };
    }
    public static Commande ToEntity(this UpdateCommandeDto dto, int id)
    {
        return new Commande
        {
            Id = id,
            NumeroCommande = dto.NumeroCommande,
            MontantTotal = dto.MontantTotal,
            Statut = dto.Statut,
            ClientId = dto.ClientId
        };
    }
    public static CommandeDto ToDto(this Commande entity)
    {
        return new CommandeDto
        {
            Id = entity.Id,
            NumeroCommande = entity.NumeroCommande,
            DateCommande = entity.DateCommande,
            MontantTotal = entity.MontantTotal,
            Statut = entity.Statut,
            ClientId = entity.ClientId
        };
    }
}






