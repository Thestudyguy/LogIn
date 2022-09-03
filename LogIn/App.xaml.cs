using Firebase.Database;

namespace LogIn;

public partial class App : Application
{
	public static FirebaseClient client = new("https://sampledb-b355e-default-rtdb.asia-southeast1.firebasedatabase.app/");
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
