using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisleriumCafé.Data.Services;

// CoffeeService.cs
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using BisleriumCafé.Data.Models;

public class CoffeeService
{
    public List<CoffeeAdmin> GetCoffeeAdmins(string filePath)
    {
        string jsonString = File.ReadAllText(filePath);
        List<CoffeeAdmin> coffeeAdmins = JsonSerializer.Deserialize<List<CoffeeAdmin>>(jsonString);
        return coffeeAdmins;
    }
}


