using Firebase.Database;

namespace LogIn;

public partial class App : Application
{
	public static FirebaseClient client = new("https://sampledb-b355e-default-rtdb.asia-southeast1.firebasedatabase.app/");
	public static string email, key;
	public App()
	{
		InitializeComponent();
		MainPage = new NavigationPage(new pages.WelcomePage());
	}
}
