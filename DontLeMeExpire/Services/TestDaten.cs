using System;
using System.Collections.Generic;
using System.Text;
using DontLeMeExpire.Models;

namespace DontLeMeExpire.Services
{
    public class TestDaten
    {
        // Ersetze alle Vorkommen von "LagerID" durch "AufbewahrungsortId" in den Aufbewahrungsort-Objekten
        public static List<Aufbewahrungsort> Orte { get; } = [
            
            new Aufbewahrungsort {
                AufbewahrungsortId ="",
                Lagername = GetTranslation("Freezer", "Gefrierschrank"),
                Icon ="\uf2dc"
            },

            new Aufbewahrungsort {
                    AufbewahrungsortId ="f765f62-d61c-48d4-ac2a-bcd8e1dce89e",
                Lagername = GetTranslation("Pantry","Vorratsschrank"),
                Icon ="\uf2dc"
            },
            new Aufbewahrungsort {
                AufbewahrungsortId = "fc0111d-1e47-406a-b695-04cf7bf4f521",
                Lagername = GetTranslation("Fridge", "Kühlschrank"),
                Icon = "\uf767" // Thermometer/Fridge style
            },

            new Aufbewahrungsort {
                AufbewahrungsortId = "a2b3c4d5-e6f7-48d9-bc01-23456789abcd",
                Lagername = GetTranslation("Spices", "Gewürzregal"),
                Icon = "\uf5d0" // Mortar pestle
            },

            new Aufbewahrungsort {
                AufbewahrungsortId = "b3c4d5e6-f7a8-49e0-cd12-3456789abcde",
                Lagername = GetTranslation("Cellar", "Keller"),
                Icon = "\uf01c" // Archive/Box
            },

            new Aufbewahrungsort {
                AufbewahrungsortId = "c4d5e6f7-a8b9-40f1-de23-456789abcdef",
                Lagername = GetTranslation("Fruit Bowl", "Obstschale"),
                Icon = "\uf5d1" // Apple
            },

            new Aufbewahrungsort {
                AufbewahrungsortId = "d5e6f7a8-b9c0-41a2-ef34-56789abcdef0",
                Lagername = GetTranslation("Bread Box", "Brotkasten"),
                Icon = "\uf7ec" // Bread slice
            },

            new Aufbewahrungsort {
                AufbewahrungsortId = "e6f7a8b9-c0d1-42b3-f045-6789abcdef01",
                Lagername = GetTranslation("Beverage Crate", "Getränkekiste"),
                Icon = "\uf0fc" // Glass/Beer
            },

            new Aufbewahrungsort {
                AufbewahrungsortId = "f7a8b9c0-d1e2-43c4-0156-789abcdef012",
                Lagername = GetTranslation("Cleaning Cabinet", "Putzmittelschrank"),
                Icon = "\uf717" // Soap/Cleaning
            },

            new Aufbewahrungsort {
                AufbewahrungsortId = "0a1b2c3d-4e5f-44d5-1267-89abcdef0123",
                Lagername = GetTranslation("Medicine Chest", "Hausapotheke"),
                Icon = "\uf0f1" // Medical
            },

            new Aufbewahrungsort {
                AufbewahrungsortId = "1b2c3d4e-5f6a-45e6-2378-9abcdef01234",
                Lagername = GetTranslation("Garage", "Garage"),
                Icon = "\uf1b9" // Car
            },

            new Aufbewahrungsort {
                AufbewahrungsortId = "2c3d4e5f-6a7b-46f7-3489-abcdef012345",
                Lagername = GetTranslation("Utility Room", "Hauswirtschaftsraum"),
                Icon = "\uf0ad" // Tools
            }

        ];

        // Ersetze alle Vorkommen von "LagerID" durch "Aufbewahrungsort" in den Produkt-Objekten
        public static List<Produkt> Produkte { get; } = [

            new Produkt {
                    Id = "1",
                Produktname ="Milch",
                Verfallsdatum = DateTime.Now.AddDays(3),
                Aufbewahrungsort ="fc0111d-1e47-406a-b695-04cf7bf4f521",
                Foto ="milch.png",
                Menge = 1.0m
            },
            new Produkt {
                Id = "2",
                Produktname ="Eier",
                Verfallsdatum = DateTime.Now.AddDays(10),
                Aufbewahrungsort ="fc0111d-1e47-406a-b695-04cf7bf4f521",
                Foto ="eier.png",
                Menge = 12.0m
            },
            new Produkt {
                Id = "3",
                Produktname = "Butter",
                Verfallsdatum = DateTime.Now.AddDays(20),
                Aufbewahrungsort = "fc0111d-1e47-406a-b695-04cf7bf4f521",
                Foto = "butter.png",
                Menge = 1.0m
            },
            new Produkt {
                Id = "4",
                Produktname = "Joghurt",
                Verfallsdatum = DateTime.Now.AddDays(14),
                Aufbewahrungsort = "fc0111d-1e47-406a-b695-04cf7bf4f521",
                Foto = "joghurt.png",
                Menge = 4.0m
            },
            new Produkt {
                Id = "5",
                Produktname = "Käse (Gouda)",
                Verfallsdatum = DateTime.Now.AddDays(12),
                Aufbewahrungsort = "fc0111d-1e47-406a-b695-04cf7bf4f521",
                Foto = "kaese.png",
                Menge = 1.0m
            },
            new Produkt {
                Id = "6",
                Produktname = "Salami",
                Verfallsdatum = DateTime.Now.AddDays(7),
                Aufbewahrungsort = "fc0111d-1e47-406a-b695-04cf7bf4f521",
                Foto = "salami.png",
                Menge = 1.0m
            },
            new Produkt {
                Id = "7",
                Produktname = "Nudeln (Spaghetti)",
                Verfallsdatum = DateTime.Now.AddYears(1),
                Aufbewahrungsort = "f765f62-d61c-48d4-ac2a-bcd8e1dce89e",
                Foto = "nudeln.png",
                Menge = 2.0m
            },
            new Produkt {
                Id = "8",
                Produktname = "Reis",
                Verfallsdatum = DateTime.Now.AddYears(2),
                Aufbewahrungsort = "f765f62-d61c-48d4-ac2a-bcd8e1dce89e",
                Foto = "reis.png",
                Menge = 1.0m
            },
            new Produkt {
                Id = "9",
                Produktname = "Mehl",
                Verfallsdatum = DateTime.Now.AddMonths(8),
                Aufbewahrungsort = "f765f62-d61c-48d4-ac2a-bcd8e1dce89e",
                Foto = "mehl.png",
                Menge = 1.0m
            },
            new Produkt {
                Id = "10",
                Produktname = "Zucker",
                Verfallsdatum = DateTime.Now.AddYears(3),
                Aufbewahrungsort = "f765f62-d61c-48d4-ac2a-bcd8e1dce89e",
                Foto = "zucker.png",
                Menge = 1.0m
            },
            new Produkt {
                Id = "11",
                Produktname = "Tomatendose",
                Verfallsdatum = DateTime.Now.AddYears(2),
                Aufbewahrungsort = "f765f62-d61c-48d4-ac2a-bcd8e1dce89e",
                Foto = "tomatendose.png",
                Menge = 3.0m
            },
            new Produkt {
                Id = "12",
                Produktname = "TK-Erbsen",
                Verfallsdatum = DateTime.Now.AddMonths(6),
                Aufbewahrungsort = "Gefrierschrank",
                Foto = "erbsen_tk.png",
                Menge = 1.0m
            },
            new Produkt {
                Id = "13",
                Produktname = "TK-Pizza",
                Verfallsdatum = DateTime.Now.AddMonths(4),
                Aufbewahrungsort = "Gefrierschrank",
                Foto = "pizza_tk.png",
                Menge = 2.0m
            },
            new Produkt {
                Id = "14",
                Produktname = "Äpfel",
                Verfallsdatum = DateTime.Now.AddDays(21),
                Aufbewahrungsort = "2c3d4e5f-6a7b-46f7-3489-abcdef012345", // Obstschale
                Foto = "aepfel.png",
                Menge = 6.0m
            },
            new Produkt {
                Id = "15",
                Produktname = "Bananen",
                Verfallsdatum = DateTime.Now.AddDays(5),
                Aufbewahrungsort = "2c3d4e5f-6a7b-46f7-3489-abcdef012345", // Obstschale
                Foto = "bananen.png",
                Menge = 4.0m
            },
            new Produkt {
                Id = "16",
                Produktname = "Brot (Vollkorn)",
                Verfallsdatum = DateTime.Now.AddDays(4),
                Aufbewahrungsort = "3d4e5f6a-7b8c-47a8-4590-bcdef0123456", // Brotkasten
                Foto = "brot.png",
                Menge = 1.0m
            },
            new Produkt {
                Id = "17",
                Produktname = "Kaffeebohnen",
                Verfallsdatum = DateTime.Now.AddMonths(6),
                Aufbewahrungsort = "f765f62-d61c-48d4-ac2a-bcd8e1dce89e",
                Foto = "kaffee.png",
                Menge = 1.0m
            },
            new Produkt {
                Id = "18",
                Produktname = "Mineralwasser",
                Verfallsdatum = DateTime.Now.AddYears(1),
                Aufbewahrungsort = "e6f7a8b9-c0d1-42b3-f045-6789abcdef01", // Getränkekiste
                Foto = "wasser.png",
                Menge = 12.0m
            },
            new Produkt {
                Id = "19",
                Produktname = "Olivenöl",
                Verfallsdatum = DateTime.Now.AddMonths(12),
                Aufbewahrungsort = "f765f62-d61c-48d4-ac2a-bcd8e1dce89e",
                Foto = "oel.png",
                Menge = 1.0m
            },
            new Produkt {
                Id = "20",
                Produktname = "Kartoffeln",
                Verfallsdatum = DateTime.Now.AddDays(30),
                Aufbewahrungsort = "b3c4d5e6-f7a8-49e0-cd12-3456789abcde", // Keller
                Foto = "kartoffeln.png",
                Menge = 5.0m
            },
            new Produkt {
                Id = "21",
                Produktname = "Zwiebeln",
                Verfallsdatum = DateTime.Now.AddDays(45),
                Aufbewahrungsort = "b3c4d5e6-f7a8-49e0-cd12-3456789abcde", // Keller
                Foto = "zwiebeln.png",
                Menge = 1.0m
            },
            new Produkt {
                Id = "22",
                Produktname = "Honig",
                Verfallsdatum = DateTime.Now.AddYears(5),
                Aufbewahrungsort = "f765f62-d61c-48d4-ac2a-bcd8e1dce89e",
                Foto = "honig.png",
                Menge = 1.0m
            }

        ];


        private static string GetTranslation(string english, string german)
        {
            return Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName == "de" ? german : english;
        }
    
    }
}
