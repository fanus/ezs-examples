using EZS;

public class HelpWindowSystem : EZS.System
{
    public HelpWindowComponent helpWindowComponent;

    public enum MainMenuEvents
    {
        ToggleHelpWindow,
        ShowHelpWindow,
        HideHelpWindow
    }

    public override void InitSystem()
    {
        RegisterEventEnum<MainMenuEvents>();
        RegisterComponent<HelpWindowComponent>(a => a.PushComponent(ref helpWindowComponent), b => b.PopComponent(ref helpWindowComponent));
    }

    [EnumAction(typeof(MainMenuEvents))]
    public void InvokeMainMenuEvent(int e)
    {
        InvokeEventsOnComponents(AsInt(e), helpWindowComponent);
    }

    protected override void UpdateSystem()
    {
        if(helpWindowComponent.HasEvent(AsInt(MainMenuEvents.ToggleHelpWindow)))
        {
            InvokeEventsOnComponents(helpWindowComponent.OnActiveEvent, helpWindowComponent);

            ToggleHelpWindow();
        }
        if(helpWindowComponent.HasEvent(AsInt(MainMenuEvents.HideHelpWindow)))
        {
            HideHelpWindow();
        }
    }

    private void ToggleHelpWindow()
    {
        helpWindowComponent.Active = !helpWindowComponent.Active;
        helpWindowComponent.gameObject.SetActive(!helpWindowComponent.gameObject.activeSelf);
    }

    private void HideHelpWindow()
    {
        helpWindowComponent.Active = false;
        helpWindowComponent.gameObject.SetActive(false);
    }

    private void ShowHelpWindow()
    {
        helpWindowComponent.Active = true;
        helpWindowComponent.gameObject.SetActive(true);
    }
}