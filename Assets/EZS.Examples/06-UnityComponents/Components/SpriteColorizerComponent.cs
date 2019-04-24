using UnityEngine;

public class SpriteColorizerComponent : EZS.Component
{
	public AnimationCurve RedCurve = new AnimationCurve(new Keyframe(0, 0), new Keyframe(1, 1));
	public AnimationCurve GreenCurve = new AnimationCurve(new Keyframe(0, 1), new Keyframe(1, 0));
	public AnimationCurve BlueCurve = new AnimationCurve(new Keyframe(0, 1), new Keyframe(1, 0));

    // To run a curve indepedent of others
    public float Time;
}
