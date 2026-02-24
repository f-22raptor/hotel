using Application.Hotels.HotelCommands.HotelCommandRequests;
using Application.Hotels.HotelDtos;
using Application.Result;
using AutoMapper;
using Domain.Models;
using Domain.Repositories;
using MediatR;

namespace Application.Hotels.HotelCommands.HotelCommandHandlers;

public class UpdateHotelHandler(IHotelRepository hotelRepository, IMapper mapper)
    : IRequestHandler<UpdateHotelCommand, Result<HotelDto>>
{
    public async Task<Result<HotelDto>> Handle(UpdateHotelCommand request, CancellationToken cancellationToken)
    {
        var hotel = await hotelRepository.GetByIdAsync(request.Id, cancellationToken);
        if (hotel == null)
            return Result<HotelDto>.Failure($"hotel {request.Id} not found", 404);

        mapper.Map(request, hotel);
        var updatedHotel = await hotelRepository.UpdateAsync(hotel, cancellationToken);
        if (updatedHotel == null)
            return Result<HotelDto>.Failure($"update hotel {request.Id} failed", 400);
        var updatedHotelDto=mapper.Map<HotelDto>(updatedHotel);
        return Result<HotelDto>.Success(mapper.Map<HotelDto>(updatedHotelDto));
    }
}