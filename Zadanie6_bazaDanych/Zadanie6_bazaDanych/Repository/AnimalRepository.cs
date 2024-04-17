using Microsoft.Data.SqlClient;
using Zadanie6_bazaDanych.Models;
using Zadanie6_bazaDanych.Models.DTOs;

namespace Zadanie6_bazaDanych.Repository;

public class AnimalRepository : IAnimalRepository
{
    private readonly IConfiguration Configuration;

    public AnimalRepository(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IEnumerable<Animal> GetAnimals()
    {
        using SqlConnection connection = new SqlConnection(Configuration.GetConnectionString("Default"));
        connection.Open();
        
        using SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "SELECT * FROM Animal";
        
        var reader = command.ExecuteReader();
        var animals = new List<Animal>();
        int 
    }

    public IEnumerable<Animal> GetAnimal()
    {
        using SqlConnection connection = new SqlConnection(Configuration.GetConnectionString("Default"));
        connection.Open();
        
        using SqlCommand command = new SqlCommand();
        command.Connection = connection;

        
        var reader = command.ExecuteReader();
        var animals = new List<Animal>();
        int 
    }

    public void AddAnimal(AddAnimal animal)
    {
        throw new NotImplementedException();
    }
}