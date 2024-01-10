using Newtonsoft.Json;  //Giving the reference of the package so that we can use it's method
using BisleriumCafé.Data.Models;  
using BisleriumCafé.Data.Utils;  

namespace BisleriumCafé.Data.Services;

// Service class responsible for handling operations like Saving, Retrieving overall Manipulating related to Payment data.
public class PaymentServices
{
    // Saves user Input in Form to a JSON file.
    public static void SavePaymentDataInJson(MakePayment payment)
    {
        // Gets the file path where form data will be stored from ApplicationFilePath method
        // in FormUtils class in Utils Folder and stores it in the variable filePath.
        string filePath = FormUtils.PaymentDataFilePath();
        try 
        {
            List<MakePayment> paymentList; 
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

    //Function to get total number of payment in json
    public static int GetTotalPaymentsCount()
    {
        // Load payment data from the JSON file
        var payments = RetrievePaymentData();

        var uniquePurchaseIds = new HashSet<Guid>(payments.Select(purchase => purchase.PaymentId));

        // Calculate the count of unique PurchaseId values
        int uniquePurchaseIdCount = uniquePurchaseIds.Count;

        // Return the total payments count
        return uniquePurchaseIdCount;
    }

    //Function for updatin the order json after payment
    public static void UpdateOrderDataInJson(AddOrder updatedOrder)
    {
        try
        {
            var orders = OrderServices.RetrieveOrderData();

            // Find the index of the existing order with the same OrderId
            int index = orders.FindIndex(order => order.OrderId == updatedOrder.OrderId);

            if (index != -1)
            {
                // Replace the existing order with the updated order
                orders[index] = updatedOrder;

                // Serialize the updated list of orders back to JSON and overwrite the file
                SaveUpdatedOrderDataInJson(orders);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading or updating JSON file: {ex.Message}");
            // Handle exceptions accordingly (logging, displaying an error message, etc.)
        }
    }

    //Function to save the json file after payment
    public static void SaveUpdatedOrderDataInJson(List<AddOrder> orders)
    {
        try
        {
            string filePath = FormUtils.OrderDataFilePath();

            // Serialize the list of form data to JSON format with formatting Indented
            string orderJsonData = JsonConvert.SerializeObject(orders, Formatting.Indented);

            // Write the JSON data back to the file.
            File.WriteAllText(filePath, orderJsonData);
        }
        catch (Exception ex)
        {
            // Handle exceptions by displaying an alert with the error message.
            Console.WriteLine($"Error writing JSON file: {ex.Message}");
            App.Current.MainPage.DisplayAlert("Error", $"Error Saving Data", "OK");
        }
    }

    // Function to get the number of payments made by a user with a specific email address
    public static int GetPaymentsCountByEmail(string userEmail)
    {
        try
        {
            var payments = PaymentServices.RetrievePaymentData();

            // Filter payments based on the provided email address
            var userPayments = payments.Where(payment => payment.Email.Equals(userEmail, StringComparison.OrdinalIgnoreCase)).ToList();

            return userPayments.Count;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading or parsing JSON file: {ex.Message}");
            // Handle exceptions accordingly (logging, displaying an error message, etc.)
            return 0;
        }
    }
}