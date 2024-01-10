using Newtonsoft.Json; //Giving the reference of the package so that we can use it's method
using BisleriumCafé.Data.Models;
using BisleriumCafé.Data.Utils;

// This class provides methods for saving, retrieving, and manipulating Coffee data.
namespace BisleriumCafé.Data.Services;

public class CoffeeServices
{
    public static void SaveCoffeeToJson(List<Coffee> coffee)
    {
        // Gets the file path where form data will be stored from ApplicationFilePath method
        // in FormUtils class in Utils Folder and stores it in the variable filePath.
        string filePath = FormUtils.CoffeeFilePath();

        // Serialize the list of hobbies to JSON format with formatting Indented and store it in Variable jsonData
        string jsonData = JsonConvert.SerializeObject(coffee, Formatting.Indented);

        // Write the JSON data to the file given from filePath variable and data from jsonData variable.
        File.WriteAllText(filePath, jsonData);
    }

    //This method Injects the data Into the Json File Manually by creating the multiple objects and Passing it to the list only if the data inside the file is empty.
    public static void InjectSampleCoffeeData()
    {
        // Gets the file path where coffee data will be stored from CoffeeFilePath method
        // in FormUtils class in Utils Folder and stores it in the variable filePath.
        string filePath = FormUtils.CoffeeFilePath();

        // Read existing data from the file and store it in variable existingData
        var existingData = File.ReadAllText(filePath);

        // If the file is empty, injects a list of sample coffee data in a object of List<Coffee> called sampleCoffee first and saves it in a Json File by calling method SaveCoffeeToJson.
        if (string.IsNullOrEmpty(existingData))
        {
            List<Coffee> sampleCoffee = new()
            {
                new Coffee { CoffeeName = "Espresso", CoffeePrice = 350 },
                new Coffee { CoffeeName = "Black Coffee", CoffeePrice = 250  },
                new Coffee { CoffeeName = "Cappuccino", CoffeePrice = 350  },
                new Coffee { CoffeeName = "Americano", CoffeePrice = 200  },
            };
            SaveCoffeeToJson(sampleCoffee); // Save the sample coffee data to the JSON file by calling SaveHobbiesToJson Method and passing sampleHobbies as it Argument.
        }
    }

    // Retrieves coffee data from the JSON file.
    public static List<Coffee> RetrieveCoffeeData()
    {
        // Gets the file path where hobby data is stored from CoffeeFilePath method
        // in FormUtils class in Utils Folder and stores it in the variable filePath.
        string filePath = FormUtils.CoffeeFilePath();
        try
        {
            string existingJsonData = File.ReadAllText(filePath); // Read existing JSON data from the file.

            // If the existing JSON data is empty, return an empty list;
            // otherwise, deserialize the data into a list of Coffee objects.
            if (string.IsNullOrEmpty(existingJsonData))
            {
                return new List<Coffee>();
            }
            return JsonConvert.DeserializeObject<List<Coffee>>(existingJsonData);
        }
        catch (Exception ex)
        {
            // Handle exceptions by displaying an alert with the error message.
            Console.WriteLine($"Error reading JSON file: {ex.Message}");
            return new List<Coffee>();
        }
    }

    // Retrieves a specific Coffee by its Id.
    public static Coffee GetCoffeeById(Guid id)
    {
        List<Coffee> coffee = RetrieveCoffeeData();

        // Return the first Coffee with the specified Id.
        return coffee.FirstOrDefault(x => x.Id == id); //creating arrow function and checking whether the Id of Coffee is equal to the id of parameter that recieves value later on.
    }
}