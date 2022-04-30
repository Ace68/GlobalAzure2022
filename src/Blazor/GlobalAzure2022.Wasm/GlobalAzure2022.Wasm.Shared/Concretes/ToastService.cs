using System;
using System.Timers;
using GlobalAzure2022.Wasm.Shared.Enums;

namespace GlobalAzure2022.Wasm.Shared.Concretes
{
    public class ToastService : IDisposable
    {
        public event Action<string, ToastLevel> OnShow;
        public event Action OnHide;
        private Timer _countdown;

        public void ShowToast(string message, ToastLevel level)
        {
            this.OnShow?.Invoke(message, level);
            this.StartCountdown();
        }

        private void StartCountdown()
        {
            this.SetCountdown();

            if (this._countdown.Enabled)
            {
                this._countdown.Stop();
                this._countdown.Start();
            }
            else
            {
                this._countdown.Start();
            }
        }

        private void SetCountdown()
        {
            if (this._countdown is null)
            {
                this._countdown = new Timer(5000);
                this._countdown.Elapsed += this.HideToast;
                this._countdown.AutoReset = false;
            }
        }

        private void HideToast(object source, ElapsedEventArgs args)
        {
            this.OnHide?.Invoke();
        }

        public void Dispose()
        {
            this._countdown?.Dispose();
        }
    }
}