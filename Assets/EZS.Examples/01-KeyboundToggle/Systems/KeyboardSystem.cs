// TODO: Explain demonstration

using UnityEngine;

namespace EZS.Examples
{
    public class KeyboardSystem : EZS.System
    {
        private KeyboardComponent keyboardComponent;

        public override void InitSystem()
        {
            RegisterComponent<KeyboardComponent>(a => a.PushComponent(ref keyboardComponent), b => b.PopComponent(ref keyboardComponent));
        }

        protected override void UpdateSystem()
        {
            foreach(KeyboardBinding keybind in keyboardComponent.KeyboardBindings)
            {
                if(Input.GetKeyDown(keybind.Key) && keybind.TriggerWhen == KeyTrigger.Press)
                {
                    keybind.Event.Invoke();
                } else if(Input.GetKeyUp(keybind.Key) && keybind.TriggerWhen == KeyTrigger.Release)
                {
                    keybind.Event.Invoke();
                }
            }
        }
    }
}