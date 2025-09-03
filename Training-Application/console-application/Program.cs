// See https://aka.ms/new-console-template for more information
using handlers;

WebClass webClassObject = new WebClass();
webClassObject.Number = 22;
int updatedNumber = webClassObject.processPrivateNumber();
Console.WriteLine("updatedNumber : " + updatedNumber);
Console.WriteLine("Hello, World!");



