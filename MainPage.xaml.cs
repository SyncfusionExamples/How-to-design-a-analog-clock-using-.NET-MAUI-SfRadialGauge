namespace Clock;

public partial class MainPage : ContentPage
{
    public MainPage()
	{
		InitializeComponent();
		secondsPointer.Value = DateTime.Now.Second / 10;
		minutesPointer.Value = (double)(DateTime.Now.Minute / 5.0);
		hoursPointer.Value = DateTime.Now.Hour / 2  + DateTime.Now.Minute / 60.0;
		Dispatcher.StartTimer(TimeSpan.FromSeconds(1), () =>
		{
			Dispatcher.Dispatch(() =>
			{
                if (DateTime.Now.Second / 5.0 == 0)
                {
                    secondsPointer.EnableAnimation = false;
                }

                if (((double)(DateTime.Now.Minute / 5.0) + DateTime.Now.Second / 360.0) == 0)
                {
                    minutesPointer.EnableAnimation = false;
                }

                if ((DateTime.Now.Hour % 12 + DateTime.Now.Minute / 60.0) == 0)
                {
                    hoursPointer.EnableAnimation = false;
                }

                secondsPointer.Value = DateTime.Now.Second / 5.0;
                minutesPointer.Value = (double)(DateTime.Now.Minute / 5.0) + DateTime.Now.Second / 360.0;
                hoursPointer.Value = DateTime.Now.Hour % 12 + DateTime.Now.Minute / 60.0;

                if (secondsPointer.Value == 0)
                {
                    secondsPointer.EnableAnimation = true;
                }

                if (minutesPointer.Value == 0)
                {
                    minutesPointer.EnableAnimation = true;
                }

                if (hoursPointer.Value == 0)
                {
                    hoursPointer.EnableAnimation = true;
                }
            });

			return true;
        });
	}
}

