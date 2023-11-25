using PatternsBusStorage.Application.Repositories;
using PatternsBusStorage.Bll.Repositories;
using PatternsBusStorage.Domain.Aggregates;

namespace PatternsBusStorage.Bll.Services;

public class CityServices
{
    private readonly CityRepository _cityRepository;

    public CityServices(CityRepository cityRepository)
    {
        _cityRepository = cityRepository;
    }

    public async Task<City> AddCity(City city)
    {
        await _cityRepository.Add(city);
        return new City();
    }
    
    public async Task<IEnumerable<City>> GetAllCities()
    {
        return await _cityRepository.GetAll();
    }

    public async Task<City> UpdateCity(City city, int id)
    {
        return await _cityRepository.Update(city, id);
    }

    public async Task<City> GetCityById(int id)
    {
        return await _cityRepository.GetById(id);
    }
}