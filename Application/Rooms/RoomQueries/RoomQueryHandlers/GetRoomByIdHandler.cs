using Application.Result;
using Application.Rooms.RoomDtos;
using Application.Rooms.RoomQueries.RoomQueryRequests;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.Rooms.RoomQueries.RoomQueryHandlers;

public class GetRoomByIdHandler(IRoomRepository roomRepository, IMapper mapper) : IRequestHandler<GetRoomByIdQuery, Result<RoomDto>>
{
    public async Task<Result<RoomDto>> Handle(GetRoomByIdQuery request, CancellationToken cancellationToken)
    {
        var room = await roomRepository.GetByIdAsync(request.RoomId, cancellationToken);
        if (room == null)
            return Result<RoomDto>.Failure(errorMessage: $"room {request.RoomId} not found", code: 404);
        var roomDto=mapper.Map<RoomDto>(room);
        return Result<RoomDto>.Success(roomDto);
    }
}