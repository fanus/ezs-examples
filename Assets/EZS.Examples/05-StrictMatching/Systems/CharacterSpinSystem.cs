// TODO: Explain demonstration

using EZS;
using UnityEngine;

    public class CharacterSpinSystem : EZS.System
    {
        private SpinComponent[] spinComponents;
        private Rigidbody2D[] rigidbodyComponents;

        public override void InitSystem()
        {
            RegisterComponents<CharacterComponent, SpinComponent>(a => a.PushComponent(ref spinComponents, ref rigidbodyComponents), b => b.PopComponent(ref spinComponents, ref rigidbodyComponents));
        }

        protected override void UpdateSystem()
        {
            for(int c = 0; c < spinComponents.Length; c++)
            {
                SpinComponent spinComponent = spinComponents[c];
                Rigidbody2D rigidbodyComponent = rigidbodyComponents[c];
                rigidbodyComponent.transform.Rotate(0, 0, spinComponent.Speed);
            }
        }
    }
