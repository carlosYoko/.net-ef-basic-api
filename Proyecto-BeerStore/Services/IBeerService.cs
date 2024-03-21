using Proyecto_BeerStore.DTOs;

namespace Proyecto_BeerStore.Services;

public interface IBeerService
{
    Task<IEnumerable<BeerDto>> Get();
    Task<BeerDto> GetById();
    Task<BeerDto> Add(BeerInsertDto beerInsertDto);
    Task<BeerDto> Update(BeerUpdateDto beerUpdateDto);
    Task<BeerDto> Delete(int id);
}