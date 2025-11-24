// //GET (tous/un), POST, PUT, DELETE.

// public class CommandeController
// {
//     private readonly ICommandeService CommandeService;

//     public CommandeController(ICommandeService commandeService)
//     {
//         CommandeService = commandeService;
//     }

//     public RouteGroupBuilder MapCommandeEndpoints(WebApplication app)
//     {
//         var group = app.MapGroup("/commandes");

//         group.MapGet("/", () =>
//         {
//             List<CommandeDto> commandes = CommandeService.GetAllCommandes();
//             return Results.Ok(commandes);
//         });

//         group.MapGet("/{id}", (int id) =>
//         {
//             CommandeDto? commande = CommandeService.GetCommandeById(id);
//             return (commande is null) ? Results.NotFound() : Results.Ok(commande);
//         });

//         group.MapPost("/", (CreateCommandeDto newCommande) =>
//         {
//             CommandeService.CreateCommande(newCommande);
//             return Results.Ok("POST new commande");
//         });

//         group.MapPut("/{id}", (int id, UpdateCommandeDto updatedCommande) =>
//         {
//             CommandeService.UpdateCommande(id, updatedCommande);
//             return Results.Ok($"PUT update commande with ID: {id}");
//         });

//         group.MapDelete("/{id}", (int id) =>
//         {
//             CommandeService.DeleteCommande(id);
//             return Results.Ok($"DELETE commande with ID: {id}");
//         });
//         return group;
//     }
// }




