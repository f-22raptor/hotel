using Application.Hotels.HotelDtos;
using Application.Hotels.HotelQueries.HotelQueryRequests;
using Application.Result;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.Hotels.HotelQueries.HotelQueryHandlers;

public class GetHotelByIdHandler(IHotelRepository hotelRepository, IMapper mapper)
    : IRequestHandler<GetHotelByIdQuery, Result<HotelDto>>
{
    public async Task<Result<HotelDto>> Handle(GetHotelByIdQuery request, CancellationToken cancellationToken)
    {
        var hotel = await hotelRepository.GetByIdAsync(request.HotelId, cancellationToken);
        if (hotel == null)
            return Result<HotelDto>.Failure(errorMessage: $"hotel {request.HotelId} not found", code: 404);
        var hotelDto = mapper.Map<HotelDto>(hotel);
        return Result<HotelDto>.Success(hotelDto);
    }
}