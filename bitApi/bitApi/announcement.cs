using bitApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations;

namespace bitApi
{
    public class announcement
    {
        public int id { get; set; }
        public string link { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public DateTime date { get; set; }
    }


    public static class announcementEndpoints
    {
        public static void MapannouncementEndpoints(this IEndpointRouteBuilder routes)
        {

            var group = routes.MapGroup("/api/announcement");
            
            //Get todos los announcements     
            group.MapGet("/", async (bitApiContext db) =>
            {
                return await db.announcement.ToListAsync();
            })
            .WithName("GetAllannouncements");

            //Get announcement por id
            group.MapGet("/{id}", async Task<Results<Ok<announcement>, NotFound>> (int id, bitApiContext db) =>
            {
                return await db.announcement.AsNoTracking()
                    .FirstOrDefaultAsync(model => model.id == id)
                    is announcement model
                        ? TypedResults.Ok(model)
                        : TypedResults.NotFound();
            })
            .WithName("GetannouncementById");
        }
    }
}
