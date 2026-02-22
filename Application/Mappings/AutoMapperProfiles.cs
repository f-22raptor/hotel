using Application.Hotels.HotelDtos;
using Application.Rooms.RoomCommands.RoomCommandRequests;
using Application.Rooms.RoomDtos;
using AutoMapper;
using Domain.Models;

namespace Application.Mappings;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        // room
        CreateMap<Room, RoomDto>();
        CreateMap<InsertRoomCommand, Room>();
        CreateMap<UpdateRoomCommand, Room>();
        // hotel
        CreateMap<Hotel, HotelDto>();
        // CreateMap<InsertHotelCommand, Hotel>();
        // CreateMap<UpdateHotelCommand, Hotel>();
        // reservation

        // guest
    }
}