using LogIn.Model;

namespace LogIn.pages;

public partial class HomePage : ContentPage
{
	private Users userlist = new();
	public HomePage()
	{
		InitializeComponent();
		ListUsers.ItemsSource = userlist.GetUserList();
	}

	private async void ListUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		App.email = (e.CurrentSelection.FirstOrDefault() as Users)?.Email;
		App.key = await userlist.GetUserKey(App.email);
		
	}

	private async void edititem_Clicked(object sender, EventArgs e)
	{

		//var Showtext = await ("Shesh");
		if (!string.IsNullOrEmpty(App.key))
		{
			await Navigation.PushAsync(new EditPage());
		}
		else
		{
			await DisplayAlert("Data", "Select item to modify", "Shesh!");
		}
	}

	private async void Deleteitem_Clicked(object sender, EventArgs e)
	{

		var result = await DisplayAlert("Information", "Are you sure you want to delete this?", "Yes", "No");
		if (result)
		{
			await userlist.DeleteData();
		}
	}
}