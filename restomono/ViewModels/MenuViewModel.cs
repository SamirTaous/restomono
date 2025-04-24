using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using restomono.Models;
using restomono.Services;
using System.Collections.ObjectModel;
using System.Linq;

namespace restomono.ViewModels
{
    public partial class MenuViewModel : ObservableObject
    {
        private readonly DataService _dataService = new();

        public ObservableCollection<Plat> Plats { get; } = new();
        public ObservableCollection<CartItem> CartItems { get; } = new();

        [ObservableProperty]
        private decimal total;

        public MenuViewModel()
        {
            foreach (var plat in _dataService.GetMenu())
                Plats.Add(plat);
        }

        [RelayCommand]
        void AddToCart(Plat plat)
        {
            var existing = CartItems.FirstOrDefault(p => p.Plat.Id == plat.Id);
            if (existing == null)
                CartItems.Add(new CartItem { Plat = plat, Quantity = 1 });
            else
                existing.Quantity++;

            Total = CartItems.Sum(x => x.TotalPrice);
        }
    }
}
