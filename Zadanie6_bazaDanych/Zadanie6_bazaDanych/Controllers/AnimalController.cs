using Microsoft.AspNetCore.Mvc;
using Zadanie6_bazaDanych.Models.DTOs;
using Zadanie6_bazaDanych.Repository;

namespace Zadanie6_bazaDanych.Controllers;

[ApiController]
// [Route("api/[controller]")]
public class AnimalController : ControllerBase
{
    private readonly IAnimalRepository AnimalRepository;

    public AnimalController(IAnimalRepository animalRepository)
    {
        AnimalRepository = animalRepository;
    }

    [HttpGet]
    [Route("api/animal")]
    public IActionResult GetAnimals(string? orderer)
    {
        var animalsList = AnimalRepository.GetAnimals(orderer);
        return Ok(animalsList);
    }

    [HttpPost]
    [Route("api/animal")]
    public IActionResult AddAnimal(AddAnimal animal)
    {
        AnimalRepository.AddAnimal(animal);
        return Created("", null);
    }

    [HttpPut]
    [Route("api/animal/{id:int}")]
    public IActionResult PutAnimal(int id, AddAnimal animal)
    {
        AnimalRepository.UpdateAnimal(id, animal);
        return Ok();
    }

    [HttpDelete]
    [Route("api/animal/{id:int}")]
    public IActionResult DeleteAnimal(int id)
    {
        AnimalRepository.DeleteAnimal(id);
        return Ok();
    }

}