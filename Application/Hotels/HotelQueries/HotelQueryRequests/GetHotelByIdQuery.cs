using Application.Hotels.HotelDtos;
using Application.Result;
using MediatR;

namespace Application.Hotels.HotelQueries.HotelQueryRequests;

public class GetHotelByIdQuery : IRequest<Result<HotelDto>>
{
    public Guid  HotelId { get; set; }
}