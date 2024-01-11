using Newtonsoft.Json; //Giving the reference of the package so that we can use it's method
using BisleriumCafé.Data.Models; 
using BisleriumCafé.Data.Utils; 


// This class provides methods for saving, retrieving, and manipulating addins data.
namespace BisleriumCafé.Data.Services;

public class AddInsServices
{
    // Saves lists of addins data Injected to a JSON file.
    public static void SaveAddInsToJson(List<AddIns> addins)
    {
        // Gets the file path where form data will be stored from ApplicationFilePath method
        // in FormUtils class in Utils Folder and stores it in the variable filePath.
        string filePath = FormUtils.AddInsFilePath();

        // Serialize the list of addins to JSON format with formatting Indented and store it in Variable jsonData
        string jsonData = JsonConvert.SerializeObject(addins, Formatting.Indented);

        // Write the JSON data to the file given from filePath variable and data from jsonData variable.
        File.WriteAllText(filePath, jsonData);
    }

    //This method Injects the data Into the Json File Manually by creating the multiple objects and Passing it to the list only if the data inside the file is empty.
    public static void InjectSampleAddInsData()
    {
        // Gets the file path where addins data will be stored from AddinsFilePath method
        // in FormUtils class in Utils Folder and stores it in the variable filePath.
        string filePath = FormUtils.AddInsFilePath();

        // Read existing data from the file and store it in variable existingData
        var existingData = File.ReadAllText(filePath);

        // If the file is empty, injects a list of sample addins data in a object of List<addins> called sampleHobbies first and saves it in a Json File by calling method SaveAddinsToJson.
        if (string.IsNullOrEmpty(existingData))
        {
            List<AddIns> sampleAddIns = new()
            {
                new AddIns { Name = "Cayenne pepper", Price = 25 },
                new AddIns { Name = "Cardamom", Price = 15 },
                new AddIns { Name = "Cinnamon", Price = 12.5 },
                new AddIns { Name = "Coconut oil", Price = 10 },
                new AddIns { Name = "Nutmeg", Price = 100 },
                new AddIns { Name = "Maple syrup", Price = 150 },
                new AddIns { Name = "Honey", Price = 25 },
                new AddIns { Name = "Cream", Price = 45 },
                new AddIns { Name = "Vanilla extract", Price = 150 },
                new AddIns { Name = "Marshmallows", Price = 30},
            };
            SaveAddInsToJson(sampleAddIns); 
        }
    }

    // Retrieves addins data from the JSON file.
    public static List<AddIns> RetrieveAddInsData()
    {
        // Gets the file path where addins data is stored from AddinsFilePath method
        // in FormUtils class in Utils Folder and stores it in the variable filePath.
        string filePath = FormUtils.AddInsFilePath();
        try
        {
            string existingJsonData = File.ReadAllText(filePath); // Read existing JSON data from the file.

            // If the existing JSON data is empty, return an empty list;
            // otherwise, deserialize the data into a list of addins objects.
            if (string.IsNullOrEmpty(existingJsonData))
            {
                return new List<AddIns>();
            }
            return JsonConvert.DeserializeObject<List<AddIns>>(existingJsonData);
        }
        catch (Exception ex)
        {
            // Handle exceptions by displaying an alert with the error message.
            Console.WriteLine($"Error reading JSON file: {ex.Message}");
            return new List<AddIns>();
        }
    }

    // Retrieves a specific addins by its Id.
    public static AddIns GetAddInsById(Guid id)
    {
        List<AddIns> addins = RetrieveAddInsData(); // Retrieves the list of addins and stores it in addins object

        // Return the first addins with the specified Id.
        return addins.FirstOrDefault(x => x.Id == id); //creating arrow function and checking whether the Id of addins is equal to the id of parameter that recieves value later on.
    }

    // Edits the name of a specific addins.
    public static List<AddIns> EditAddIns(Guid id, string newName, double newPrice)
    {
        // Retrieve the list of addins.
        List<AddIns> addins = RetrieveAddInsData();
        // Find the addins with the specified Id.
        AddIns editAddIns = addins.FirstOrDefault(x => x.Id == id);
        // If the addins is not found, throw an exception.
        if (editAddIns == null)
        {
            throw new Exception("Add-Ins not found");
        }
        // Update the name of the addins.
        editAddIns.Name = newName;
        // Update the price of the addins.
        editAddIns.Price = newPrice;
        SaveAddInsToJson(addins); // Save the updated list of addins to the JSON file by calling method SaveAddinsToJson
        return addins;  // Return the updated list of addins.
    }
}