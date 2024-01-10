using System.Text;
using BisleriumCafé.Data.Models;

namespace BisleriumCafé.Data.Services
{
    public class DownloadPDFServices
    {
        // Method to calculate the top five coffee items and add-ins based on quantity and revenue
        public static (List<ReportData>, List<ReportData>) CalculateReportTopFiveItem()
        {
            var orderData = OrderServices.RetrieveOrderData();

            // Calculate top five coffee items based on quantity
            var topCoffees = orderData
                .SelectMany(o => o.Coffee)
                .GroupBy(c => c.CoffeeName)
                .Select(g => new ReportData
                {
                    Name = g.Key,
                    Quantity = g.Sum(c => 1), // Count the occurrences of each coffee type
                    Revenue = g.Sum(c => c.CoffeePrice) // Calculate the total revenue for each coffee type
                })
                .OrderByDescending(r => r.Quantity)
                .Take(5)
                .ToList();

            // Calculate top five add-ins based on quantity
            var topAddIns = orderData
                .SelectMany(o => o.AddIns)
                .GroupBy(a => a.Name)
                .Select(g => new ReportData
                {
                    Name = g.Key,
                    Quantity = g.Sum(a => 1), // Count the occurrences of each add-in
                    Revenue = g.Sum(a => a.Price) // Calculate the total revenue for each add-in
                })
                .OrderByDescending(r => r.Quantity)
                .Take(5)
                .ToList();

            return (topCoffees, topAddIns);
        }

        // Method to calculate the total revenue for the current day and current month
        public static (double, double) CalculateTotalRevenue()
        {
            var paymentData = PaymentServices.RetrievePaymentData();
            DateTime currentDate = DateTime.Now;

            // Calculate total revenue for the current day
            double totalRevenueCurrentDay = paymentData
                .Where(p => p.PaymentDatetime.Date == currentDate.Date)
                .Sum(p => p.PaidPrice);

            // Calculate total revenue for the current month
            double totalRevenueCurrentMonth = paymentData
                .Where(p => p.PaymentDatetime.Month == currentDate.Month && p.PaymentDatetime.Year == currentDate.Year)
                .Sum(p => p.PaidPrice);

            return (totalRevenueCurrentDay, totalRevenueCurrentMonth);
        }

        // Method to generate an HTML report containing top coffee items, top add-ins, and total revenue
        public static string GenerateHtmlReport()
        {
            // Retrieve calculated data
            var (topCoffees, topAddIns) = CalculateReportTopFiveItem();
            var (totalRevenueCurrentDay, totalRevenueCurrentMonth) = CalculateTotalRevenue();

            // Create a StringBuilder to construct the HTML content
            var htmlContent = new StringBuilder();

            // Start the HTML document
            htmlContent.AppendLine("<html><body>");

            // Generate HTML table for top five coffee items
            htmlContent.AppendLine("<h1>Top Five Coffee Items</h1>");
            htmlContent.AppendLine("<table border='1'><tr><th>Name</th><th>Quantity</th><th>Revenue</th></tr>");

            foreach (var coffee in topCoffees)
            {
                htmlContent.AppendLine($"<tr><td>{coffee.Name}</td><td>{coffee.Quantity}</td><td>{coffee.Revenue}</td></tr>");
            }

            htmlContent.AppendLine("</table>");

            // Set the title of the HTML document
            htmlContent.AppendLine("<head><title>Top Coffee and Add-Ins - Revenue Report</title></head>");

            // Generate HTML table for top five add-ins
            htmlContent.AppendLine("<h1>Top Five Add-Ins</h1>");
            htmlContent.AppendLine("<table border='1'><tr><th>Name</th><th>Quantity</th><th>Revenue</th></tr>");

            foreach (var addIn in topAddIns)
            {
                htmlContent.AppendLine($"<tr><td>{addIn.Name}</td><td>{addIn.Quantity}</td><td>{addIn.Revenue}</td></tr>");
            }

            htmlContent.AppendLine("</table>");

            // Generate HTML content for total revenue
            htmlContent.AppendLine("<h1>Total Revenue</h1>");
            htmlContent.AppendLine($"<p>Total Revenue for the Current Day: {totalRevenueCurrentDay}</p>");
            htmlContent.AppendLine($"<p>Total Revenue for the Current Month: {totalRevenueCurrentMonth}</p>");

            // Close the HTML document
            htmlContent.AppendLine("</body></html>");

            // Return the HTML content as a string
            return htmlContent.ToString();
        }
    }
}