using Application.Hotels.HotelDtos;
using Application.Result;
using MediatR;

namespace Application.Hotels.HotelCommands.HotelCommandRequests;

public class UpdateHotelCommand : IRequest<Result<HotelDto>>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public float Rating { get; set; }
}