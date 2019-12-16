using System;
using System.Windows.Media.Imaging;

namespace Lab4GameControls
{

    class Panzer : GameObject
    {
       
        public override void Init()
        {
            this.IsEnabled = true;
            this.Image = BitmapFrame.Create(new Uri("Assets/target.png", UriKind.RelativeOrAbsolute));
        }
    }
}
