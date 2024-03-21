using Microsoft.EntityFrameworkCore;
using Proyecto_BeerStore.DTOs;
using Proyecto_BeerStore.Models;

namespace Proyecto_BeerStore.Services;

public class BeerService : IBeerService
{
    private readonly StoreContext _context;

    public BeerService(StoreContext context)
    {
        _context = context;
    }
    
    
    public async Task<IEnumerable<BeerDto>> Get()
    {
        return await _context.Beers.Select(b => new BeerDto()
        {
            Id = b.BeerId,
            Name = b.Name,
            BrandId = b.BrandId,
            Alcohol = b.Alcohol
        }).ToListAsync();
    }

    public async Task<BeerDto?> GetById(int id)
    {
        var beer = await _context.Beers.FindAsync(id);

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

        await _context.Beers.AddAsync(beer);
        await _context.SaveChangesAsync();
        
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
        var beer = await _context.Beers.FindAsync(id);
        if (beer != null)
        {
            beer.BeerId = beerUpdateDto.Id;
            beer.Name = beerUpdateDto.Name;
            beer.Alcohol = beerUpdateDto.Alcohol;
            beer.BrandId = beerUpdateDto.BrandId;
            
            await _context.SaveChangesAsync();
            
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
        var beer = await _context.Beers.FindAsync(id);
        if (beer != null)
        {
            var beerDto = new BeerDto()
            {
                Id = beer.BeerId,
                Name = beer.Name,
                Alcohol = beer.Alcohol,
                BrandId = beer.BrandId
            };
            
            _context.Remove(beer);
            await _context.SaveChangesAsync();
            
            return beerDto;
        }
        return null;
        
    }
}
