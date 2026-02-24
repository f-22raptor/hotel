using Domain.Models;

namespace Domain.Repositories;

public interface IRoomRepository : IBaseRepository<Room, Guid>
{
    Task<bool> IsRoomNumberUniqueAsync(Guid hotelId, int roomNumber, CancellationToken cancellationToken);
}