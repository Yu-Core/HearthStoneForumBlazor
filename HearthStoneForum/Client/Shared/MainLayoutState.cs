using HearthStoneForum.Model.DTOView;

namespace HearthStoneForum.Client.Shared
{
    public class MainLayoutState
    {
        public UserInfoDTOViewSimple UserInfoSimple { get; private set; } = new UserInfoDTOViewSimple() { Name=string.Empty,PortraitUrl=string.Empty};
        public string? SearchText { get;set; } = string.Empty;

        public event Action OnChange;

        public void SetUserInfoSimple(UserInfoDTOViewSimple userInfo)
        {
            UserInfoSimple = userInfo;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
