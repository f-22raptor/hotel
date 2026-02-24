using Application.Hotels.HotelDtos;
using MediatR;

namespace Application.Hotels.HotelQueries.HotelQueryRequests;

public class GetAllHotelsQuery : IRequest<ICollection<HotelDto>>
{
    // filtering
    public string? FilterOn { get; set; }
    public string? FilterQuery { get; set; }
    // sorting
    public string? OrderBy { get; set; }
    public bool IsAscending { get; set; } = true;
    // pagination
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = int.MaxValue;
}