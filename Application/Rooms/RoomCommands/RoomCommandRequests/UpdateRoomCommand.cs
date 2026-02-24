using Application.Result;
using Application.Rooms.RoomDtos;
using Domain.Enums;
using MediatR;

namespace Application.Rooms.RoomCommands.RoomCommandRequests;

public class UpdateRoomCommand : IRequest<Result<RoomDto>>
{
    public Guid Id { get; set; }
    public int Number { get; set; }
    public RoomType Type { get; set; }
    public decimal PricePerNight { get; set; }
    public Guid? HotelId { get; set; }
}