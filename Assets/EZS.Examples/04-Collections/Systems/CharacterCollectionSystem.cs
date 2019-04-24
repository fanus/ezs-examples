// TODO: Explain demonstration

using UnityEngine;

namespace EZS.Examples
{
    public class CharacterCollectionSystem : EZS.System
    {
        private CharacterComponent[] characterComponents;
        private SpriteRenderer[] spriteRendererComponents;

        public enum CharactersEvents
        {
            ToggleWeapons,
            EquipWeapons,
            UnequipWeapons
        }

        public override void InitSystem()
        {
            RegisterEventEnum<CharactersEvents>();
            RegisterComponents<CharacterComponent>(a => a.PushComponent(ref characterComponents, ref spriteRendererComponents), b => b.PopComponent(ref characterComponents, ref spriteRendererComponents));
        }

        [EnumAction(typeof(CharactersEvents))]
        public void InvokeCharacterEvent(int e)
        {
            InvokeEventsOnComponents(AsInt(e), characterComponents);
        }

        protected override void UpdateSystem()
        {
            for(int c = 0; c < characterComponents.Length; c++)
            {
                CharacterComponent characterComponent = characterComponents[c];
                SpriteRenderer characterSprite = spriteRendererComponents[c];
                if(characterComponent.HasEvent(AsInt(CharactersEvents.EquipWeapons)))
                {
                    characterSprite.sprite = characterComponent.EquipedSprite;
                }
                if(characterComponent.HasEvent(AsInt(CharactersEvents.UnequipWeapons)))
                {
                    characterSprite.sprite = characterComponent.UnequipSprite;
                }
                if(characterComponent.HasEvent(AsInt(CharactersEvents.ToggleWeapons)))
                {
                    characterSprite.sprite = (characterSprite.sprite == characterComponent.EquipedSprite) ? characterComponent.UnequipSprite : characterComponent.EquipedSprite;
                }
            }
        }
    }
}