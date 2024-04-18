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

    public IEnumerable<Animal> GetAnimals(string? orderBy)
    {
        using SqlConnection connection = new SqlConnection(Configuration.GetConnectionString("Default"));
        connection.Open();
        
        using SqlCommand command = new SqlCommand();
        command.Connection = connection;
        if (orderBy==null)
        {
            command.CommandText = $"SELECT * FROM Animal Order BY Name ASC";
        }
        else
        {
            command.CommandText = $"SELECT * FROM Animal Order BY {orderBy} ASC";
        }

        var reader = command.ExecuteReader();
        var animalsList = new List<Animal>();
        
        int idAnimalOrdinal = reader.GetOrdinal("IdAnimal");
        int nameOrdinal = reader.GetOrdinal("Name");
        int descriptionOrdinal = reader.GetOrdinal("Description");
        int categoryOrdinal = reader.GetOrdinal("Category");
        int areaOrdinal = reader.GetOrdinal("Area");
        
        while (reader.Read())
        {
            animalsList.Add(new Animal()
            {
                IdAnimal = reader.GetInt32(idAnimalOrdinal),
                Name = reader.GetString(nameOrdinal),
                Description = reader.GetString(descriptionOrdinal),
                Category = reader.GetString(categoryOrdinal),
                Area = reader.GetString(areaOrdinal)
            });
        }

        return animalsList;
    }
    
    

    public int UpdateAnimal(int id, AddAnimal animal)
    {
        using SqlConnection connection = new SqlConnection(Configuration.GetConnectionString("Default"));
        connection.Open();
        
        using SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "" +
                              "UPDATE Animal SET Name=@animalName," +
                              " Description = @animalDesc," +
                              " Category = @animalCategory," +
                              " Area = @animalArea WHERE IdAnimal = @animalIdAnimal";
        command.Parameters.AddWithValue("@animalIdAnimal", id);
        command.Parameters.AddWithValue("@animalName", animal.Name);
        command.Parameters.AddWithValue("@animalDesc", animal.Description);
        command.Parameters.AddWithValue("@animalCategory", animal.Category);
        command.Parameters.AddWithValue("@animalArea", animal.Area);

        var odp = command.ExecuteNonQuery();
        return odp;
    }

    public void AddAnimal(AddAnimal animal)
    {
        using SqlConnection connection = new SqlConnection(Configuration.GetConnectionString("Default"));
        connection.Open();
        
        using SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "INSERT INTO Animal VALUES(@animalName,@animalDesc,@animalCategory,@animalArea)";
        command.Parameters.AddWithValue("@animalName", animal.Name);
        command.Parameters.AddWithValue("@animalDesc", animal.Description);
        command.Parameters.AddWithValue("@animalCategory", animal.Category);
        command.Parameters.AddWithValue("@animalArea", animal.Area);
        
        command.ExecuteNonQuery();
    }

    public void DeleteAnimal(int idAnimal)
    {
        using SqlConnection connection = new SqlConnection(Configuration.GetConnectionString("Default"));
        connection.Open();
        
        using SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "DELETE FROM animal WHERE idAnimal=@idAnimal";
        command.Parameters.AddWithValue("@idAnimal", idAnimal);

        command.ExecuteNonQuery();
        
    }
}