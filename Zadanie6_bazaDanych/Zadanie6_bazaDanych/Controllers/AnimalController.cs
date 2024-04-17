using Microsoft.AspNetCore.Mvc;
using Zadanie6_bazaDanych.Repository;

namespace Zadanie6_bazaDanych.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AnimalController : ControllerBase
{
    private readonly IAnimalRepository AnimalRepository;

    public AnimalController(IAnimalRepository animalRepository)
    {
        AnimalRepository = animalRepository;
    }

    [HttpGet]
    [Route("api/Animal")]
    public IActionResult GetAnimals()
    {
        
    }

}