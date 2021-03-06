﻿// TODO: Explain demonstration

using EZS;
using UnityEngine;

    public class CharacterSystem : EZS.System
    {
        private CharacterComponent characterComponent;
        private SpriteRenderer characterSprite;

        public enum CharacterEvents
        {
            ToggleWeapon,
            EquipWeapon,
            UnequipWeapon
        }

        public override void InitSystem()
        {
            RegisterEventEnum<CharacterEvents>();
            RegisterComponent<CharacterComponent>(a => a.PushComponent(ref characterComponent, ref characterSprite), b => b.PopComponent(ref characterComponent, ref characterSprite));
        }

        [EnumAction(typeof(CharacterEvents))]
        public void InvokeCharacterEvent(int e)
        {
            InvokeEventsOnComponents(AsInt(e), characterComponent);
        }

        protected override void UpdateSystem()
        {
            if(characterComponent.HasEvent(AsInt(CharacterEvents.EquipWeapon)))
            {
                characterSprite.sprite = characterComponent.EquipedSprite;
            }
            if(characterComponent.HasEvent(AsInt(CharacterEvents.UnequipWeapon)))
            {
                characterSprite.sprite = characterComponent.UnequipSprite;
            }
            if(characterComponent.HasEvent(AsInt(CharacterEvents.ToggleWeapon)))
            {
                characterSprite.sprite = (characterSprite.sprite == characterComponent.EquipedSprite) ? characterComponent.UnequipSprite : characterComponent.EquipedSprite;
            }
        }
    }