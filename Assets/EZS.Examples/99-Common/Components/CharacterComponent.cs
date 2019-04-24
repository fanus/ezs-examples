using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Rigidbody2D))]
public class CharacterComponent : EZS.Component
{
    public Sprite EquipedSprite;
    public Sprite UnequipSprite;
}
