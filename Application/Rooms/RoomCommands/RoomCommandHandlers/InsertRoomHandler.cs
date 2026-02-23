using Application.Rooms.RoomCommands.RoomCommandRequests;
using Application.Rooms.RoomDtos;
using AutoMapper;
using Domain.Models;
using Domain.Repositories;
using FluentValidation;
using MediatR;

namespace Application.Rooms.RoomCommands.RoomCommandHandlers;

public class InsertRoomHandler(IRoomRepository roomRepository, IMapper mapper, IValidator<InsertRoomCommand> validator) : IRequestHandler<InsertRoomCommand, RoomDto?>
{
    public async Task<RoomDto?> Handle(InsertRoomCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);
        var room = mapper.Map<Room>(request);
        var result = await roomRepository.InsertAsync(room, cancellationToken);
        if(result == null)
            return null;
        var roomDto = mapper.Map<RoomDto>(room);
        return roomDto;
    }
}