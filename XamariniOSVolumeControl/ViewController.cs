using System;
using AVFoundation;
using Foundation;
using UIKit;

namespace XamariniOSVolumeControl
{
	public partial class ViewController : UIViewController
	{
		public AVAudioPlayer player;
		public float MusicVolume { get; set; } = 0;
		public bool MusicOn { get; set; } = true;
		protected ViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			volumeControlSlider.MaxValue = 10;
			volumeControlSlider.MinValue = 0;
			volumeControlSlider.ValueChanged += (sender, e) => {
				MusicVolume = volumeControlSlider.Value;
				lblVoume.Text =Math.Round( volumeControlSlider.Value).ToString();
			};
		}
		partial void BtnPlay_TouchUpInside(UIButton sender)
		{
			PlayMusic();
		}
		//Play Music
		public void PlayMusic()
		{
			NSUrl songURL;
			if (!MusicOn) return;
			songURL = new NSUrl("Sounds/song.mp3");
			NSError err;
			player = new AVAudioPlayer(songURL, "mp3", out err);
			player.Volume = MusicVolume;
			player.FinishedPlaying += delegate
			{
				player = null;
			};
			player.Play();
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}
