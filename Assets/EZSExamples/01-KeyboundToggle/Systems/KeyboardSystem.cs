using UnityEngine;

public class KeyboardSystem : EZS.SystemCore
{
    public KeyboardComponent keyboardComponent;

    public override void InitSystem()
    {
        RegisterComponent<KeyboardComponent>(a => a.DefineComponent(ref keyboardComponent), b => b.NullComponent(ref keyboardComponent));
    }

    protected override void UpdateSystem()
    {
        foreach(KeyboardBinding keybind in keyboardComponent.KeyboardBindings)
        {
            if(Input.GetKeyDown(keybind.Key))
            {
                InvokeEventsOnComponents(keybind.Event, keyboardComponent);
            }
        }
    }
}