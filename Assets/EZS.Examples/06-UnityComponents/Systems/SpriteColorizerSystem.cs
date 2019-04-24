// TODO: Explain demonstration

using System.Linq;
using UnityEngine;

namespace EZS.Examples
{
    public class SpriteColorizerSystem : EZS.System
    {
        private SpriteColorizerComponent[] spriteColorizerComponents;
        private SpriteRenderer[] spriteRendererComponents;

        public override void InitSystem()
        {
            RegisterComponents<SpriteColorizerComponent>(a => a.PushComponent(ref spriteColorizerComponents, ref spriteRendererComponents), b => b.PopComponent(ref spriteColorizerComponents, ref spriteRendererComponents));
        }

        protected override void UpdateSystem()
        {
            for(int s = 0; s < spriteColorizerComponents.Length; s++)
            {
                SpriteColorizerComponent spriteColorizerComponent = spriteColorizerComponents[s];
                SpriteRenderer spriteRendererComponent = spriteRendererComponents[s];

                spriteColorizerComponent.Time += Time.deltaTime;
                spriteRendererComponent.color = new Color(spriteColorizerComponent.RedCurve.Evaluate(spriteColorizerComponent.Time % spriteColorizerComponent.RedCurve.keys.Last().time), spriteColorizerComponent.GreenCurve.Evaluate(spriteColorizerComponent.Time % spriteColorizerComponent.RedCurve.keys.Last().time), spriteColorizerComponent.BlueCurve.Evaluate(spriteColorizerComponent.Time % spriteColorizerComponent.RedCurve.keys.Last().time));
            }
        }
    }
}
