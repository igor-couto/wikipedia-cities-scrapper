using System;
using System.Collections.Generic;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Linq;
using System.Text.RegularExpressions;

namespace WikipediaCitiesScrapper
{
    public class CityService
    {
    //     private IMongoCollection<City> _cityCollection;
    //     private IMongoCollection<City> _statesCollection;

    //     public CityService() 
    //     {
    //         var client = new MongoClient("mongodb://localhost:27017");
    //         var _database = client.GetDatabase("citiesbr");

    //         _cityCollection = _database.GetCollection<City>("cities");
    //         _statesCollection = _database.GetCollection<City>("states");
    //     }

    //     public List<City> GetByState(string state)
    //     {
    //         var builder = Builders<City>.Filter;
    //         var filter = builder.Empty;

    //         filter = builder.And(new [] {filter, builder.Eq("State", state)}); 
    //         return _cityCollection.Find(filter).ToList();
    //     }

    //     public List<string> GetStates()
    //     {
    //         var builder = Builders<City>.Filter;
    //         var filter = builder.Empty;

    //         return _statesCollection.ToList();
    //     }
   }    
}