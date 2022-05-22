// See https://aka.ms/new-console-template for more information
using BillingReport;

Console.WriteLine("Hello, World!");

var billingService = new BillingService();
var billArgs = new BillingArgs(
    billingId: 12340,
    clientBillingName: "Otto Chamo",
    clientEmail: "cheleyotto98@gmail.com",
    clientBillingId: "12345678",
    deliveryAddress: "X Avenida, X Calle, Zona 0, Guatemala, Guatemala",
    totalPurchase: 450.25m,
    billingItemModels: new List<BillingItemModel>()
    {
        new BillingItemModel("Telefono Galaxy S3", 2, 100.00m),
        new BillingItemModel("Telefono Note 20 Ultra", 2, 100.00m),
        new BillingItemModel("Huawei X Ultra", 1, 0.25m)
    }
);
billingService.SendBill(billArgs);


Console.ReadLine();