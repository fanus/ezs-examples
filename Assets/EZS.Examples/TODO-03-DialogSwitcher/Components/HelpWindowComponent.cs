public class HelpWindowComponent : EZS.Component
{
    public bool Active;

//#if UNITY_EDITOR
//    [EventField]
//#endif
// this is wrong, it should be an UnityEvent
    public int OnActiveEvent;
}
