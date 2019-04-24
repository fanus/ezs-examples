// TODO: Explain demonstration

namespace EZS.Examples
{
    public class KeyboardCharacterSystem : EZS.System
    {
        private KeyboardComponent keyboardComponent;
        private CharacterComponent characterComponent;

        public override void InitSystem()
        {
            isIntermediate = true;
            RegisterComponent<KeyboardComponent>(a => a.PushComponent(ref keyboardComponent), b => b.PopComponent(ref keyboardComponent));
            RegisterComponent<CharacterComponent>(a => a.PushComponent(ref characterComponent), b => b.PopComponent(ref characterComponent));
        }

        protected override void UpdateSystem()
        {
            BridgeEvents(ref keyboardComponent, ref characterComponent);
            BridgeEvents(ref characterComponent, ref keyboardComponent);
        }
    }
}