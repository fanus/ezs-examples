public class KeyboardCharacterSystem : EZS.SystemCore
{
    public KeyboardComponent keyboardComponent;
    public CharacterComponent characterComponent;

    public override void InitSystem()
    {
        isIntermediate = true;
        RegisterComponent<KeyboardComponent>(a => a.DefineComponent(ref keyboardComponent), b => b.NullComponent(ref keyboardComponent));
        RegisterComponent<CharacterComponent>(a => a.DefineComponent(ref characterComponent), b => b.NullComponent(ref characterComponent));
    }

    protected override void UpdateSystem()
    {
        BridgeEvents(ref keyboardComponent, ref characterComponent);
        BridgeEvents(ref characterComponent, ref keyboardComponent);
    }
}