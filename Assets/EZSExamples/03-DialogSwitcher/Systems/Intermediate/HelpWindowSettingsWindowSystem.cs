using System;
using System.Linq;
using UnityEngine;

public class HelpWindowSettingsWindowSystem : EZS.SystemCore
{
    public HelpWindowComponent helpWindowComponent;
    public SettingsWindowComponent settingsWindowComponent;

    public override void InitSystem()
    {
        isIntermediate = true;
        RegisterComponents<HelpWindowComponent>(a => a.PushComponent(ref helpWindowComponent), b => b.PopComponent(ref helpWindowComponent));
        RegisterComponents<SettingsWindowComponent>(a => a.PushComponent(ref settingsWindowComponent), b => b.PopComponent(ref settingsWindowComponent));
    }

    protected override void UpdateSystem()
    {
        BridgeEvents(ref helpWindowComponent, ref settingsWindowComponent);
        BridgeEvents(ref settingsWindowComponent, ref helpWindowComponent);
    }
}