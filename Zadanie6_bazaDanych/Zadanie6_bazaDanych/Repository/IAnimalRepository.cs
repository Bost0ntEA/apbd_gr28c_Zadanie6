using Zadanie6_bazaDanych.Models;
using Zadanie6_bazaDanych.Models.DTOs;

namespace Zadanie6_bazaDanych.Repository;

public interface IAnimalRepository
{
    IEnumerable<Animal> GetAnimals(string? orderBy);
    int UpdateAnimal(int id,AddAnimal animal);
    void AddAnimal(AddAnimal animal);
    void DeleteAnimal(int idAnimal);

}