using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C10_Exercises.Model
{
     public partial class ChatDataModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<ChatData> _chatDataList;

        public void GetChatDataList()
        {
            ChatDataList = new ObservableCollection<ChatData>()
            {
                new ChatData(){ ProfilePicture="woman",UserName="Clara McDaneil",Message = "Hello there, could you send us some help", Work = "Work",OptionImage="options"},
                new ChatData(){ ProfilePicture="woman",UserName="Emily Stelmann",Message = "Thanks! I will have a look on that as soon as possible", Work = "Work",OptionImage="options"},
                new ChatData(){ ProfilePicture="woman",UserName="Monica Geller",Message = "Hello there, could you send us some help", Work = "Work",OptionImage="options"},
                new ChatData(){ ProfilePicture="woman",UserName="Rachel Green",Message = "Coming back to you with an estimation of the work of my project", Work = "Work",OptionImage="options"},
            };
        }
    }
}
