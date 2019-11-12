using Xamarin.Forms;

namespace demo.Common {
    public static class ImagePathResources {
        public static readonly string BackgroundImagePath =
            Device.RuntimePlatform == Device.iOS ? "background.jpg" : "rainBus.jpg";
    }
}