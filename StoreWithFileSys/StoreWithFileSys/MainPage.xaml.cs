using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using StoreWithFileSys;


namespace StoreWithFileSys
{
    public partial class MainPage : ContentPage
    {
        FileEngine fileEngine = new FileEngine();

        public MainPage()
        {
            InitializeComponent();
            Refresh();
        }

        async void saveBtn_Clicked(object sender, EventArgs e)
        {
            string storedText = wroteText.Text;
            await fileEngine.WriteTextAsync(wroteText.Text, "");
            wroteText.Text = "";
            Refresh();         
        }

        async void TextsList_Selected(object sender, SelectedItemChangedEventArgs e)
        {
            string storedText = (string)e.SelectedItem;
            wroteText.Text = storedText;
        }

        async void Refresh()
        {
            textsList.ItemsSource = await fileEngine.GetFilesAsync();
            textsList.SelectedItem = null;
        }
    }
}
