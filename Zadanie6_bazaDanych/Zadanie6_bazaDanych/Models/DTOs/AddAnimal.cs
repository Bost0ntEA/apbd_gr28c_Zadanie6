using System.ComponentModel.DataAnnotations;

namespace Zadanie6_bazaDanych.Models.DTOs;

public class AddAnimal
{
    [Required]
    [MinLength(3)]
    public string Name { get; set; }
    
    public string? Description { get; set; }

    public string Category { get; set; }

    public string Area { get; set; }
}