namespace LogIn.pages;

using LogIn.Model;
using static LogIn.App;

public partial class EditPage : ContentPage
{
	private Users users = new();
	public EditPage()
	{
		InitializeComponent();
	}
	protected override void OnAppearing()
	{
		base.OnAppearing();
		entryFirstName.Text = firstname;
        entryLastName.Text = lastname;
		entryPassword.Text = password;
    }

	private async void btncancel_Clicked(object sender, EventArgs e)
	{
        await Navigation.PushAsync(new EditPage());
    }

	private async void btnmodify_Clicked(object sender, EventArgs e)
	{
		if(!string.IsNullOrEmpty(entryFirstName.Text) || !string.IsNullOrEmpty(entryLastName.Text))
		{
			var a =  await users.EditData(entryFirstName.Text, entryLastName.Text, entryPassword.Text);
			if (!a)
			await DisplayAlert("Information", "Done", "OK");
			await Navigation.PopAsync();
            return;
        }
		await DisplayAlert("Information", "Not Done", "OK");

	}
}