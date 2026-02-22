using Application.Rooms.RoomDtos;
using Application.Rooms.RoomQueries.RoomQueryRequests;
using AutoMapper;
using Domain.Models;
using Domain.Repositories;
using MediatR;

namespace Application.Rooms.RoomQueries.RoomQueryHandlers;

public class GetAllRoomsHandlerAsync(IRoomRepository roomRepository, IMapper mapper) : IRequestHandler<GetAllRoomsQuery, ICollection<RoomDto>>
{
    public async Task<ICollection<RoomDto>> Handle(GetAllRoomsQuery request, CancellationToken cancellationToken)
    {
        var rooms = await roomRepository.GetAllAsync(
            cancellationToken,
            filterOn: request.FilterOn,
            filterQuery: request.FilterQuery,
            orderBy: request.OrderBy,
            isAscending: request.IsAscending,
            pageNumber: request.PageNumber,
            pageSize: request.PageSize);
        // test
        // var room = new Room
        // {
        //     Number = 45
        // };
        // var rooms = new List<Room>()
        // {
        //     room,
        //     room,
        //     room
        // };
        var roomDtos = mapper.Map<List<RoomDto>>(rooms);
        return  roomDtos;
    }
}