using System;
using System.Linq;
using UnityEngine;
using EZS;

public class HelpWindowSettingsWindowSystem : EZS.System
{
    public HelpWindowComponent helpWindowComponent;
    public SettingsWindowComponent settingsWindowComponent;

    public override void InitSystem()
    {
        isIntermediate = true;
        RegisterComponent<HelpWindowComponent>(a => a.PushComponent(ref helpWindowComponent), b => b.PopComponent(ref helpWindowComponent));
        RegisterComponent<SettingsWindowComponent>(a => a.PushComponent(ref settingsWindowComponent), b => b.PopComponent(ref settingsWindowComponent));
    }

    protected override void UpdateSystem()
    {
        BridgeEvents(ref helpWindowComponent, ref settingsWindowComponent);
        BridgeEvents(ref settingsWindowComponent, ref helpWindowComponent);
    }
}