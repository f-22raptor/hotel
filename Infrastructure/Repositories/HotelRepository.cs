// using Domain.Models;
// using Domain.Repositories;
// using Microsoft.EntityFrameworkCore;
// using System.Globalization;
//
// namespace Infrastructure.Repositories;
//
// public class HotelRepository(AppDbContext context) : BaseRepository<Hotel, Guid>(context), IHotelRepository
// {
//     protected override IQueryable<Hotel> CustomContext()
//     {
//         return context.Hotels.Include(h => h.Rooms);
//     }
// }
