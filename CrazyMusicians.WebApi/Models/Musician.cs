namespace CrazyMusicians.Models;
using System.ComponentModel.DataAnnotations;

public class Musician
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Profession is required.")]
    [StringLength(50, ErrorMessage = "Profession cannot exceed 50 characters.")]
    public string Profession { get; set; }

    [StringLength(200, ErrorMessage = "FunFact cannot exceed 200 characters.")]
    public string FunFact { get; set; }
}