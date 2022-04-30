using System;

namespace GlobalAzure2022.Wasm.Shared.Configuration
{
    public class AppState
    {
        public event Action OnChange;

        public void NotifiyStateChanged()
        {
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}