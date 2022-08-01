namespace BlazorWASM_Localization.Shared
{
    public partial class CultureSelector
    {
       [Inject]public IJSRuntime _jsRuntime { get; set; }
       [Inject]public NavigationManager _navigationManager { get; set; }

        private CultureInfo[] cultures = new[]
        {
            new CultureInfo("en-US"),
            new CultureInfo("ar-EG"),
        };
        private CultureInfo Culture 
        { get => CultureInfo.CurrentCulture ;
            set {
                if (CultureInfo.CurrentCulture != value)
                {
                    var js = (IJSInProcessRuntime)_jsRuntime;
                    js.InvokeVoid("blazorCulture.set", value.Name);

                    _navigationManager.NavigateTo(_navigationManager.Uri, forceLoad: true);
                }
            } 
        }
    }
}
