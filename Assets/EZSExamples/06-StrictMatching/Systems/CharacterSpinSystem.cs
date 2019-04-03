public class CharacterSpinSystem : EZS.SystemCore
{
	private CharacterComponent[] characterComponents;
	private SpinComponent[] spinComponents;

	public override void InitSystem()
	{
		RegisterComponents<CharacterComponent, SpinComponent>(a => a.PushComponent(ref characterComponents, ref spinComponents), b => b.PopComponent(ref characterComponents, ref spinComponents));
	}

	protected override void UpdateSystem()
	{
		for (int c = 0; c < characterComponents.Length; c++) {
			CharacterComponent characterComponent = characterComponents[c];
			SpinComponent spinComponent = spinComponents[c];
			characterComponent.transform.Rotate(0, 0, spinComponent.Speed);
		}
	}
}
