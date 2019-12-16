using System;
using System.ComponentModel;
using System.Threading;

namespace Lab4GameControls
{
    
    internal class Scene : INotifyPropertyChanged
    {
    
        private Timer _t;

      
        public Panzer Panzer { get; set; }
           public Bomber Bomber { get; set; }
      
        public Bomb Bomb { get; set; }

      
        public bool IsBuisy { get; set; }

      
        public void Init()
        {
            this.Panzer.Init();
            this.Bomber.Init();
        }

      
        public void Start()
        {
         
            if (this.IsBuisy)
            {
                return;
            }

        
            Counter c = new Counter();

        
            this._t = new Timer
                (
             
                state =>
                {
                    this.Bomber.Update();

                    if (!this.Bomb.IsEnabled)
                    {
                        return;
                    }

                    this.Bomb.Update();

                    if (this.Bomb.ObjectRect.IntersectsWith(this.Panzer.ObjectRect))
                    {
                        if (this.Bomb.IsActive)
                        {
                            this.Bomb.IsActive = false;
                            this.Bomb.Destroy();
                            this.Panzer.Destroy();
                        }

                        if (c.Value >= 50)
                        {
                            this.Bomb.IsEnabled = false;
                            this.Panzer.IsEnabled = false;
                        }
                    }
                    else
                        if (this.Bomb.ObjectRect.Y < 0)
                        {
                            if (this.Bomb.IsActive)
                            {
                                this.Bomb.IsActive = false;
                                this.Bomb.Destroy();
                            }
                            if (c.Value >= 50)
                            {
                                this.Bomb.IsEnabled = false;
                                c.Value = 0;
                            }
                        }
                },
                null,
           
                0,
           
                10);
           
            this.IsBuisy = true;
        }

       
        public void Pause()
        {
            if (this.IsBuisy)
            {
                this._t.Dispose();
                this.IsBuisy = false;
            }
        }

       
        public event PropertyChangedEventHandler PropertyChanged;

     
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
           
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
