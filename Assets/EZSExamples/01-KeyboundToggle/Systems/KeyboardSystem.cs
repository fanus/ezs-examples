using UnityEditor;
using UnityEngine;

public class KeyboardSystem : EZS.SystemCore
{
	private KeyboardComponent keyboardComponent;

	public override void InitSystem()
	{
		RegisterComponents<KeyboardComponent>(a => a.PushComponent(ref keyboardComponent), b => b.PopComponent(ref keyboardComponent));
	}

	protected override void UpdateSystem()
	{
		foreach (KeyboardBinding keybind in keyboardComponent.KeyboardBindings) {
			if (Input.GetKeyDown(keybind.Key) && keybind.TriggerWhen == KeyTrigger.Press) {
				InvokeEventsOnComponents(keybind.Event, keyboardComponent);
			} else if (Input.GetKeyUp(keybind.Key) && keybind.TriggerWhen == KeyTrigger.Release) {
				InvokeEventsOnComponents(keybind.Event, keyboardComponent);
			}
		}
	}
}