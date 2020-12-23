using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksSummariesApp.Models
{
    public enum MenuItemType
    {
        Home,
        AddNewBook,
        Details,
        About
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }
        public string Title { get; set; }
    }
    public class Book
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
//new HomeMenuItem { Id = MenuItemType.Home, Title = "La page Principale" },
//                new HomeMenuItem { Id = MenuItemType.Home, Title = "Ajouter un résumé" },
//                new HomeMenuItem { Id = MenuItemType.Home, Title = "À propos de l'application" },