// using Domain.Models;
// using Domain.Repositories;
// using Microsoft.EntityFrameworkCore;
//
// namespace Infrastructure.Repositories;
//
// public class GuestRepository(AppDbContext context) : BaseRepository<Guest, Guid>(context), IGuestRepository
// {
//     protected override IQueryable<Guest> CustomContext()
//     {
//         return context.Guests.Include(g => g.Reservations);
//     }
// }
