﻿using System;

namespace GlobalAzure2022.Wasm.Shared.Configuration
{
    public class AppState
    {
        public event Action OnChange;

        public void NotifiyStateChanged()
        {
            this.NotifyStateChanged();
        }

        private void NotifyStateChanged() => this.OnChange?.Invoke();
    }
}