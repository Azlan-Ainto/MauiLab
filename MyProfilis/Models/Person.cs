using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations;

namespace MyProfilis.Models;

public class Person
{
    [Key]
    public int ID { get; set; }

    [Required]
    [MaxLength(50)]
    public string? Vorname { get; set; }

    [Required]
    [MaxLength(50)]
    public string? Nachname { get; set; }

    public DateTime Geburtsdatum { get; set; }
    //[MaxLength(25)]
    //public string gender { get; set; }=string.Empty; 
    
    //public double Einkommen {  get; set; }
    //[MaxLength(100)]
    //public string Company { get; set; }
    //[MaxLength(100)]
    //public string Beruf { get; set; }

    //public string Abteilung { get; set; }

    [EmailAddress]
    [MaxLength(155)]    
    public string? EMail { get; set; }
    
    [MaxLength(20)]
    public string? Telefon { get; set; }
    
    [MaxLength(2)]
    public string? Land { get; set; }
    
    [MaxLength(50)]
    public string? Stadt { get; set; }
    
    [MaxLength(5)]
    public string? Postleitzahl { get; set; }
    
    [MaxLength(50)]
    public string? Straße { get; set; }
    
    [MaxLength(50)]
    public string? Hausnummer { get; set; }
}
