using Zadanie6_bazaDanych.Models;
using Zadanie6_bazaDanych.Models.DTOs;

namespace Zadanie6_bazaDanych.Repository;

public interface IAnimalRepository
{
    IEnumerable<Animal> GetAnimals();
    IEnumerable<Animal> GetAnimal();
    void AddAnimal(AddAnimal animal);
    
}