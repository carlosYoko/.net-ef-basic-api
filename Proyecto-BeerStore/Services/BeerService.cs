using Proyecto_BeerStore.DTOs;
using Proyecto_BeerStore.Models;
using Proyecto_BeerStore.Repository;

namespace Proyecto_BeerStore.Services;

public class BeerService : ICommonService<BeerDto, BeerInsertDto, BeerUpdateDto>
{
    private readonly IRepository<Beer> _beerRepository;

    public BeerService(IRepository<Beer> beerRepository)
    {
        _beerRepository = beerRepository;
    }
    
    public async Task<IEnumerable<BeerDto>> Get()
    {
        var beers = await _beerRepository.Get();

        return beers.Select(b => new BeerDto()
        {
            Id = b.BeerId,
            Name = b.Name,
            Alcohol = b.Alcohol,
            BrandId = b.BrandId
        });
    }

    public async Task<BeerDto?> GetById(int id)
    {
        var beer = await _beerRepository.GetById(id);

        if (beer != null)
        {
            var beerDto = new BeerDto()
            {
                Id = beer.BeerId,
                Name = beer.Name,
                BrandId = beer.BrandId,
                Alcohol = beer.Alcohol

            };
            return beerDto;
        }
        return null;
    }

    public async Task<BeerDto> Add(BeerInsertDto beerInsertDto)
    {
        var beer = new Beer()
        {
            Name = beerInsertDto.Name,
            BrandId = beerInsertDto.BrandId,
            Alcohol = beerInsertDto.Alcohol
        };

        await _beerRepository.Add(beer);
        await _beerRepository.Save();
        
        var beerDto = new BeerDto()
        {
            Id = beer.BeerId,
            Name = beer.Name,
            Alcohol = beer.Alcohol,
            BrandId = beer.BrandId
        };

        return beerDto;
    }

    public async Task<BeerDto?> Update(int id, BeerUpdateDto beerUpdateDto)
    {
        var beer = await _beerRepository.GetById(id);
        if (beer != null)
        {
            beer.BeerId = beerUpdateDto.Id;
            beer.Name = beerUpdateDto.Name;
            beer.Alcohol = beerUpdateDto.Alcohol;
            beer.BrandId = beerUpdateDto.BrandId;
            
            _beerRepository.Update(beer);
            await _beerRepository.Save();
            
            var beerDto = new BeerDto()
            {
                Id = beer.BeerId,
                Name = beer.Name,
                Alcohol = beer.Alcohol,
                BrandId = beer.BrandId
            };
            return beerDto;
        }
        return null;
    }

    public async Task<BeerDto?> Delete(int id)
    {
        var beer = await _beerRepository.GetById(id);
        if (beer != null)
        {
            var beerDto = new BeerDto()
            {
                Id = beer.BeerId,
                Name = beer.Name,
                Alcohol = beer.Alcohol,
                BrandId = beer.BrandId
            };
            
            _beerRepository.Delete(beer);
            await _beerRepository.Save();
            
            return beerDto;
        }
        return null;
        
    }
}
