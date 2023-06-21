using C10_Exercises.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace C10_Exercises.ViewModel
{
    public partial class ChatDataViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<ChatData> _chatDataList;
        private ChatDataModel _chatDataModel;
        public event EventHandler<string> ResultEventHandler;
        public ChatDataViewModel()
        {
            _chatDataModel = new ChatDataModel();
            GetChatDetailsList();

        }

        public void GetChatDetailsList()
        {
            _chatDataModel.GetChatDataList();
            ChatDataList = _chatDataModel.ChatDataList;
        }
        [RelayCommand]
        public async void DeleteChat(ChatData chatData)
        {
            bool result = await Application.Current.MainPage.DisplayAlert("Delete Chat", "“Are you sure you want to delete this chat?","Yes","No");
            if (result)
            {
                ChatDataList.Remove(chatData);
                ResultEventHandler?.Invoke(this, "Chat deleted successfully");
            }
        }
    }
}
