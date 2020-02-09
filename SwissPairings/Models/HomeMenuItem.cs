using System;
using System.Collections.Generic;
using System.Text;

namespace SwissPairings.Models
{
    public enum MenuItemType
    {
        Browse,
        About,
        Login, 
        Player
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
