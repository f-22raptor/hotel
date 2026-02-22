using Application.Rooms.RoomDtos;
using Application.Rooms.RoomQueries.RoomQueryRequests;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.Rooms.RoomQueries.RoomQueryHandlers;

public class GetRoomByIdHandlerAsync(IRoomRepository roomRepository, IMapper mapper) : IRequestHandler<GetRoomByIdQuery, RoomDto?>
{
    public async Task<RoomDto?> Handle(GetRoomByIdQuery request, CancellationToken cancellationToken)
    {
        var room = await roomRepository.GetByIdAsync(request.RoomId, cancellationToken);
        var roomDto=mapper.Map<RoomDto>(room);
        return roomDto;
    }
}