using Application.Hotels.HotelCommands.HotelCommandRequests;
using Application.Hotels.HotelDtos;
using Application.Result;
using AutoMapper;
using Domain.Models;
using Domain.Repositories;
using MediatR;

namespace Application.Hotels.HotelCommands.HotelCommandHandlers;

public class InsertHotelHandler(IHotelRepository hotelRepository, IMapper mapper) : IRequestHandler<InsertHotelCommand, Result<HotelDto>>
{
    public async Task<Result<HotelDto>> Handle(InsertHotelCommand request, CancellationToken cancellationToken)
    {
        var hotel = mapper.Map<Hotel>(request);
        var result = await hotelRepository.InsertAsync(hotel, cancellationToken);
        if (result == null)
            return Result<HotelDto>.Failure("insert hotel failed", 400);           
        var hotelDto = mapper.Map<HotelDto>(hotel);
        return Result<HotelDto>.Success(hotelDto);
    }
}