using HearthStoneForum.Model.DTOView;

namespace HearthStoneForum.Client.Shared
{
    public class SearchState
    {
        public string? SearchText { get;private set; }
        public event Action? OnChange;

        public void SetSearchText(string? value)
        {
            SearchText = value;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
