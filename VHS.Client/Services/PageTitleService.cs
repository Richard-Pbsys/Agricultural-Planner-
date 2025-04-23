using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace VHS.Client.Services
{
    public class PageTitleService : IDisposable
    {
        public event Action? OnChange;
        private string _title = "Home";
        private readonly NavigationManager _navManager;

        public PageTitleService(NavigationManager navManager)
        {
            _navManager = navManager;
            _navManager.LocationChanged += OnLocationChanged;
        }

        public string Title
        {
            get => _title;
            set
            {
                if (_title != value)
                {
                    _title = value;
                    OnChange?.Invoke();
                }
            }
        }

        private void OnLocationChanged(object? sender, LocationChangedEventArgs e)
        { }

        public void Dispose()
        {
            _navManager.LocationChanged -= OnLocationChanged;
        }
    }
}
