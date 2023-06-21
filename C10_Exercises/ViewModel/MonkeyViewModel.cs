using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C10_Exercises.ViewModel
{
    public partial class MonkeyViewModel: ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Monkey> _monkeyDetails;
        public MonkeyViewModel()
        {
            MonkeyDetails = new ObservableCollection<Monkey>
            {
                    new Monkey()
                    {
                        Name = "Baboon",
                        Location="America"
                    },
                    new Monkey()
                    {
                        Name = "Blue",
                        Location="Other"
                    },
                    new Monkey()
                    {
                        Name = "Squirrel",
                        Location="America"
                    },
                    new Monkey()
                    {
                        Name = "Howler",
                        Location="Other"
                    }
            };
        }
    }

}
