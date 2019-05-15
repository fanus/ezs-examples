using EZS;

public class SettingsWindowSystem : EZS.System
{
    public SettingsWindowComponent settingsWindowComponent;

    public enum MainMenuEvents
    {
        ToggleSettingsWindow,
        ShowSettingsWindow,
        HideSettingsWindow
    }

    public override void InitSystem()
    {
        RegisterEventEnum<MainMenuEvents>();
        RegisterComponent<SettingsWindowComponent>(a => a.PushComponent(ref settingsWindowComponent), b => b.PopComponent(ref settingsWindowComponent));
    }

    [EnumAction(typeof(MainMenuEvents))]
    public void InvokeMainMenuEvent(int e)
    {
        InvokeEventsOnComponents(AsInt(e), settingsWindowComponent);
    }

    protected override void UpdateSystem()
    {
        if(settingsWindowComponent.HasEvent(AsInt(MainMenuEvents.ToggleSettingsWindow)))
        {
            InvokeEventsOnComponents(settingsWindowComponent.OnActiveEvent, settingsWindowComponent);

            ToggleSettingsWindow();
        }
        if(settingsWindowComponent.HasEvent(AsInt(MainMenuEvents.HideSettingsWindow)))
        {
            HideSettingsWindow();
        }
    }

    private void ToggleSettingsWindow()
    {
        settingsWindowComponent.Active = !settingsWindowComponent.Active;
        settingsWindowComponent.gameObject.SetActive(!settingsWindowComponent.gameObject.activeSelf);
    }

    private void HideSettingsWindow()
    {
        settingsWindowComponent.Active = false;
        settingsWindowComponent.gameObject.SetActive(false);
    }

    private void ShowSettingsWindow()
    {
        settingsWindowComponent.Active = true;
        settingsWindowComponent.gameObject.SetActive(true);
    }
}
