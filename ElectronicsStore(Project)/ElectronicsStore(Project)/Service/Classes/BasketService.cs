using ElectronicsStore_Project_.Model;
using ElectronicsStore_Project_.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ElectronicsStore_Project_.Service.Classes;

public class BasketService
{

    public static void  AddToBasket(Basket basket)
    {
        bool checkExist = false;

        foreach (var item in BasketViewModel.Basket)
        {
            if (item.Electronic.ID == basket.Electronic.ID)
            {
                checkExist = true;
                break;
            }
            else checkExist = false;
        }

        if (!checkExist)
        {
            BasketViewModel.Basket.Add(basket);
            MessageBox.Show($"{basket.Electronic.Name} был успешно добавлен в корзину", "Покупка",MessageBoxButton.OK);
        }
        else
            MessageBox.Show("Данный товар уже есть в корзине","Ошибка при добавлении");
    }
}
