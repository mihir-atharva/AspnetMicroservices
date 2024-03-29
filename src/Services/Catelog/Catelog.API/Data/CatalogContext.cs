﻿using Catalog.API.Data.Seed;
using Catelog.API.Entities;
using MongoDB.Driver;

namespace Catelog.API.Data
{
    public interface ICatalogContext
    {
        IMongoCollection<Product> Products { get; }
    }

    public class CatalogContext : ICatalogContext
    {

        public CatalogContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));
            
            Products = database.GetCollection<Product>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            CatalogContextSeed.SeedData(Products);
        }


        public IMongoCollection<Product> Products { get; set; }


    }
}
