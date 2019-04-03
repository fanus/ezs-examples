using UnityEngine;

public class CharacterCollectionSystem : EZS.SystemCore
{
	private CharacterComponent[] characterComponents;
	private SpriteRenderer[] characterSprites;

	public enum CharactersEvents
	{
		ToggleWeapons,
		EquipWeapons,
		UnequipWeapons
	}

	public override void InitSystem()
	{
		RegisterEventEnum<CharactersEvents>();
		RegisterComponents<CharacterComponent>(a => a.PushComponent(ref characterComponents), b => b.PopComponent(ref characterComponents));
	}

	public override void Ready()
	{
		// by now we know that every CharacterComponent will have a SpriteRenderer. It should have [RequireCompnent(typeof(SpriteRenderer))]
		characterSprites = new SpriteRenderer[characterComponents.Length];
		for (int c = 0; c < characterComponents.Length; c++) {
			characterSprites[c] = characterComponents[c].GetComponent<SpriteRenderer>();
		}
	}

	[EnumAction(typeof(CharactersEvents))]
	public void InvokeCharacterEvent(int e)
	{
		InvokeEventsOnComponents(AsInt(e), characterComponents);
	}

	protected override void UpdateSystem()
	{
		for (int c = 0; c < characterComponents.Length; c++) {
			CharacterComponent characterComponent = characterComponents[c];
			SpriteRenderer characterSprite = characterSprites[c];
			if (characterComponent.HasEvent(AsInt(CharactersEvents.EquipWeapons))) {
				characterSprite.sprite = characterComponent.EquipedSprite;
			}
			if (characterComponent.HasEvent(AsInt(CharactersEvents.UnequipWeapons))) {
				characterSprite.sprite = characterComponent.UnequipSprite;
			}
			if (characterComponent.HasEvent(AsInt(CharactersEvents.ToggleWeapons))) {
				characterSprite.sprite = (characterSprite.sprite == characterComponent.EquipedSprite) ? characterComponent.UnequipSprite : characterComponent.EquipedSprite;
			}
		}
	}
}