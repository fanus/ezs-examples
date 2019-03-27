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
        RegisterComponent<HelpWindowComponent>(a => a.DefineComponent(ref helpWindowComponent), b => b.NullComponent(ref helpWindowComponent));
        RegisterComponent<SettingsWindowComponent>(a => a.DefineComponent(ref settingsWindowComponent), b => b.NullComponent(ref settingsWindowComponent));
    }

    protected override void UpdateSystem()
    {
        BridgeEvents(ref helpWindowComponent, ref settingsWindowComponent);
        BridgeEvents(ref settingsWindowComponent, ref helpWindowComponent);
    }
}