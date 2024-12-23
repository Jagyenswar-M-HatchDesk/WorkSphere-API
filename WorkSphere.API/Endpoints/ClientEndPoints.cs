using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;
using WorkSphere.Application.DTOs.ClientDTO;
using WorkSphere.Application.Interfaces.IServices;
using WorkSphere.Domain;
using WorkSphere.Infrastructure;

namespace WorkSphere.API.Endpoints
{
    public static class ClientEndPoints

    {
        public static void Client_Endpoints(this IEndpointRouteBuilder erb)
        {
            var app = erb.MapGroup("").WithTags("CLient");

            app.MapGet("SearchClient", async (WorkSphereDbContext context, string? Name) =>
            {
                var client = await context.Clients.Where(e => e.IsActive == true).ToListAsync();

                var selectedclients = client.Where(c => (string.IsNullOrEmpty(Name) || c.ClientName.Contains(Name, StringComparison.OrdinalIgnoreCase)));

                var rslt = selectedclients.Select(c => new ClientDTO() { Name = c.ClientName });

                return Results.Ok(rslt);
            });

            app.MapPost("createClient", async ( IClientServices service, ClientCreateDTO dto) =>
            {
                var client =  await service.AddClientAsync(dto);

                return Results.Ok(new
                {
                    Message = "New Client Had been Creted",
                    Client = new ClientShowDTO()
                    {
                        ClientID = client.ClientID,
                        ClientName = client.ClientName,
                        PhoneNumber = client.PhoneNumber,
                        Email = client.Email,
                        ModifiedOn = client.ModifiedOn,
                        CreatedBy = client.CreatedBy,
                        CreatedOn = client.CreatedOn,
                        IsActive = client.IsActive,
                        IsDelete = client.IsDelete
                    }
                });
            });

            app.MapGet("GetAllClients", async (IClientServices service) =>
            {
                var clients = await service.GetClientsAsync();
                return Results.Ok( clients.Select(c => new ClientShowDTO()
                {
                    ClientID = c.ClientID,
                    ClientName = c.ClientName,
                    PhoneNumber = c.PhoneNumber,
                    Email = c.Email,
                    ModifiedOn = c.ModifiedOn,
                    CreatedBy = c.CreatedBy,
                    CreatedOn = c.CreatedOn,
                    IsActive = c.IsActive,
                    IsDelete = c.IsDelete

                }));
            });

            app.MapPut("UpdateClient/{id}", async (IClientServices services, ClientCreateDTO dto, int id) =>
            {
                var updateClient = await services.GetClientByIdAsync(id);
                if (updateClient == null) return Results.NotFound();

                //updateClient.ClientID = dto.ClientID,
                updateClient.ClientName = dto.ClientName;
                updateClient.PhoneNumber = dto.PhnoneNumber;
                updateClient.Email = dto.Email;
                updateClient.ModifiedOn = DateTime.Now;
                //updateClient.IsActive = dto.IsActive;
                //updateClient.IsDelete = dto.IsDelete;

                var client = new ClientShowDTO()
                {
                    ClientID = id,
                    ClientName = updateClient.ClientName,
                    PhoneNumber = updateClient.PhoneNumber,
                    Email = updateClient.Email,
                    ModifiedOn = updateClient.ModifiedOn,
                    CreatedBy = updateClient.CreatedBy,
                    CreatedOn = updateClient.CreatedOn,
                    IsActive = updateClient.IsActive,
                    IsDelete = updateClient.IsDelete

                };

                return Results.Ok(new
                {
                    Message = "Client Updated Successfully",
                    Client = client
                });

            });

            app.MapGet("GetClientbyId/{id}", async (IClientServices service, int id) =>
            {
                var clientid = await service.GetClientByIdAsync(id);
                return Results.Ok( new ClientShowDTO()
                {
                    ClientID = clientid.ClientID,
                    ClientName = clientid.ClientName,
                    PhoneNumber = clientid.PhoneNumber,
                    Email = clientid.Email,
                    ModifiedOn = clientid.ModifiedOn,
                    CreatedBy = clientid.CreatedBy,
                    CreatedOn = clientid.CreatedOn,
                    IsActive = clientid.IsActive,
                    IsDelete = clientid.IsDelete

                });
            });

            
        }
    }
}
