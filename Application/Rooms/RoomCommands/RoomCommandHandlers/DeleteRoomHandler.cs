using Application.Result;
using Application.Rooms.RoomCommands.RoomCommandRequests;
using Application.Rooms.RoomDtos;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.Rooms.RoomCommands.RoomCommandHandlers;

public class DeleteRoomHandler(IRoomRepository roomRepository, IMapper mapper)
    : IRequestHandler<DeleteRoomCommand, Result<RoomDto>>
{
    public async Task<Result<RoomDto>> Handle(DeleteRoomCommand request, CancellationToken cancellationToken)
    {
        if (await roomRepository.GetByIdAsync(request.RoomId, cancellationToken) == null)
            return Result<RoomDto>.Failure($"room {request.RoomId} not found", 404);
        var result = await roomRepository.DeleteAsync(request.RoomId, cancellationToken);
        if (result == null)
            return Result<RoomDto>.Failure($"insert room failed", 400);
        var roomDto = mapper.Map<RoomDto>(result);
        return Result<RoomDto>.Success(roomDto);
    }
}