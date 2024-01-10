using Newtonsoft.Json;  //Giving the reference of the package so that we can use it's method
using BisleriumCafé.Data.Models;
using BisleriumCafé.Data.Utils;  

namespace BisleriumCafé.Data.Services;

// Service class responsible for handling operations like Saving, Retrieving overall Manipulating related to Order data.
public class OrderServices
{
    // Saves user Input in Order to a JSON file.
    public static void SaveOrderDataInJson(AddOrder order)
    {
        // Gets the file path where Order data will be stored from ApplicationFilePath method
        // in OrderUtils class in Utils Folder and stores it in the variable filePath.
        string filePath = FormUtils.OrderDataFilePath();
        try // Deserialize existing JSON data from the file into a list of AddOrder objects called formList.
        {
            List<AddOrder> orderList; // object of List of AddOrder
            string existingJsonData = File.ReadAllText(filePath); //ReadAllText reads the datas inside the file from filePath Variable and Stores in variable called existingJsonData

            // If the existingJSONData variable is empty, initialize a new list; otherwise, deserialize the data.
            if (string.IsNullOrEmpty(existingJsonData))
            {
                orderList = new List<AddOrder>();
            }
            else
            {
                orderList = JsonConvert.DeserializeObject<List<AddOrder>>(existingJsonData);
            }
            // Add the current Order to the list.
            orderList.Add(order);

            // Serialize the updated list of Order data to JSON format with formatting Indented and store it in a variable OrderJsonData
            string orderJsonData = JsonConvert.SerializeObject(orderList, Formatting.Indented);

            // Write the JSON data back to the file.
            File.WriteAllText(filePath, orderJsonData);
        }
        catch (Exception ex)
        {
            // Handle exceptions by displaying an alert with the error message.
            Console.WriteLine($"Error reading JSON file: {ex.Message}");
            App.Current.MainPage.DisplayAlert("Error", $"Error Saving Data", "OK");
        }
    }

    // Retrieves Order data from the JSON file.
    public static List<AddOrder> RetrieveOrderData()
    {
        // Gets the file path where Order data is stored from ApplicationFilePath method
        // in OrderUtils class in Utils Folder and stores it in the variable filePath.
        string filePath = FormUtils.OrderDataFilePath();
        try
        {
            string existingJsonData = File.ReadAllText(filePath); //ReadAllText reads the datas inside the file from filePath Variable and Stores in variable called existingJsonData

            // If the existing JSON data is empty, return an empty list;
            // otherwise, deserialize the data into a list of AddOrder objects. 
            if (string.IsNullOrEmpty(existingJsonData))
            {
                return new List<AddOrder>();
            }
            return JsonConvert.DeserializeObject<List<AddOrder>>(existingJsonData);
        }
        catch (Exception ex)
        {
            // Handle exceptions by displaying an alert with the error message.
            Console.WriteLine($"Error reading JSON file: {ex.Message}");
            App.Current.MainPage.DisplayAlert("Error", "Error Retrieving Data from Json", "OK");
            return new List<AddOrder>();
        }
    }
}