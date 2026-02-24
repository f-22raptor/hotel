using Application.Hotels.HotelDtos;
using Application.Result;
using MediatR;

namespace Application.Hotels.HotelCommands.HotelCommandRequests;

public class DeleteHotelCommand : IRequest<Result<HotelDto>>
{
    public Guid HotelId { get; set; }
}