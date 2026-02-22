// using Domain.Models;
// using Domain.Repositories;
// using Microsoft.EntityFrameworkCore;
// using System.Globalization;
//
// namespace Infrastructure.Repositories;
//
// public class ReservationRepository(AppDbContext context)
//     : BaseRepository<Reservation, Guid>(context), IReservationRepository
// {
//     protected override IQueryable<Reservation> CustomContext()
//     {
//         return context.Reservations
//             .Include(r => r.Guest)
//             .Include(r => r.Room)
//             .ThenInclude(room => room.Hotel);
//     }
// }
