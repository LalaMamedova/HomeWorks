using ProxyPattern.Classes;
using ProxyPattern.Interface;

ICreateCharacther characther = new ProxyCreateCharacther();
int choice = 0; 

while (choice !=2)
{
    characther.CreateCharacther();

    Console.WriteLine(
         "Выйти?" +
        "\n1.Нет. " +
        "\n2.Да");

    choice = Int32.Parse(Console.ReadLine());
    Console.Clear();
}