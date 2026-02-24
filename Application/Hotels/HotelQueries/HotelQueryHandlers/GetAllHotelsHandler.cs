using Application.Hotels.HotelDtos;
using Application.Hotels.HotelQueries.HotelQueryRequests;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.Hotels.HotelQueries.HotelQueryHandlers;

public class GetAllHotelsHandler(IHotelRepository hotelRepository, IMapper mapper) : IRequestHandler<GetAllHotelsQuery, ICollection<HotelDto>>
{
    public async Task<ICollection<HotelDto>> Handle(GetAllHotelsQuery request, CancellationToken cancellationToken)
    {
        var hotels = await hotelRepository.GetAllAsync(
                cancellationToken,
                filterOn: request.FilterOn,
                filterQuery: request.FilterQuery,
                orderBy: request.OrderBy,
                isAscending: request.IsAscending,
                pageNumber: request.PageNumber,
                pageSize: request.PageSize);
        var hotelDtos = mapper.Map<ICollection<HotelDto>>(hotels);
        return hotelDtos;
    }
}