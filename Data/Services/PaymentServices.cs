using Newtonsoft.Json;  //Giving the reference of the package so that we can use it's method
using BisleriumCafé.Data.Models;  //Giving the path of the files that are in Model folder i.e. AddForm.cs and Hobby.cs, Allowing us to use it
using BisleriumCafé.Data.Utils;  //Giving the path of the files that is in Utils folder i.e. FormUtils.cs, allowing us to use it's methods

namespace BisleriumCafé.Data.Services;

// Service class responsible for handling operations like Saving, Retrieving overall Manipulating related to form data.
public class PaymentServices
{
    // Saves user Input in Form to a JSON file.
    public static void SavePaymentDataInJson(MakePayment payment)
    {
        // Gets the file path where form data will be stored from ApplicationFilePath method
        // in FormUtils class in Utils Folder and stores it in the variable filePath.
        string filePath = FormUtils.PaymentDataFilePath();
        try // Deserialize existing JSON data from the file into a list of AddForm objects called formList.
        {
            List<MakePayment> paymentList; // object of List of AddForm i.e. formList
            string existingJsonData = File.ReadAllText(filePath); //ReadAllText reads the datas inside the file from filePath Variable and Stores in variable called existingJsonData

            // If the existingJSONData variable is empty, initialize a new list; otherwise, deserialize the data.
            if (string.IsNullOrEmpty(existingJsonData))
            {
                paymentList = new List<MakePayment>();
            }
            else
            {
                paymentList = JsonConvert.DeserializeObject<List<MakePayment>>(existingJsonData);
            }
            // Add the current form to the list.
            paymentList.Add(payment);

            // Serialize the updated list of form data to JSON format with formatting Indented and store it in a variable formJsonData
            string paymentJsonData = JsonConvert.SerializeObject(paymentList, Formatting.Indented);

            // Write the JSON data back to the file.
            File.WriteAllText(filePath, paymentJsonData);
        }
        catch (Exception ex)
        {
            // Handle exceptions by displaying an alert with the error message.
            Console.WriteLine($"Error reading JSON file: {ex.Message}");
            App.Current.MainPage.DisplayAlert("Error", $"Error Saving Data", "OK");
        }
    }

    // Retrieves form data from the JSON file.
    public static List<MakePayment> RetrievePaymentData()
    {
        // Gets the file path where form data is stored from ApplicationFilePath method
        // in FormUtils class in Utils Folder and stores it in the variable filePath.
        string filePath = FormUtils.PaymentDataFilePath();
        try
        {
            string existingJsonData = File.ReadAllText(filePath); //ReadAllText reads the datas inside the file from filePath Variable and Stores in variable called existingJsonData

            // If the existing JSON data is empty, return an empty list;
            // otherwise, deserialize the data into a list of AddForm objects.
            if (string.IsNullOrEmpty(existingJsonData))
            {
                return new List<MakePayment>();
            }
            return JsonConvert.DeserializeObject<List<MakePayment>>(existingJsonData);
        }
        catch (Exception ex)
        {
            // Handle exceptions by displaying an alert with the error message.
            Console.WriteLine($"Error reading JSON file: {ex.Message}");
            App.Current.MainPage.DisplayAlert("Error", "Error Retrieving Data from Json", "OK");
            return new List<MakePayment>();
        }
    }

    public static int GetTotalPaymentsCount()
    {
        // Load payment data from the JSON file
        var payments = RetrieveFormData();

        var uniquePurchaseIds = new HashSet<Guid>(payments.Select(purchase => purchase.PaymentId));

        // Calculate the count of unique PurchaseId values
        int uniquePurchaseIdCount = uniquePurchaseIds.Count;

        // Return the total payments count
        return uniquePurchaseIdCount;
    }
}