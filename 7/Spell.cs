using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Spell")]
public class Spell : ScriptableObject
{
    // Ở đây ta cần SerializeReference, vì giúp ref đến các class con của SpellEffect
    // Nếu k, ta chỉ ref đc đến SpellEffect
    [SerializeReference] public List<SpellEffect> Effects;

    // Các hàm để thêm spell vào 1 skill
    #region MenuItems
    [ContextMenu(nameof(AddDamageEffect))]
    void AddDamageEffect()
    {
        Effects.Add(new Damage());
    }

    [ContextMenu(nameof(AddAoeDamageEffect))]
    void AddAoeDamageEffect()
    {
        Effects.Add(new AoeDamage());
    }

    [ContextMenu(nameof(AddHealEffect))]
    void AddHealEffect()
    {
        Effects.Add(new Heal());
    }

    [ContextMenu(nameof(AddTeleport))]
    void AddTeleport()
    {
        Effects.Add(new Teleport());
    }
    #endregion
}

[Serializable]
public class SpellEffect
{
    public virtual void Apply() { }

    [Tooltip("How long the effect delays")]
    public float Delay;
}

[Serializable]
public class Heal : SpellEffect
{
    public override void Apply()
    {
        // Player.Health += Amount;
    }
    public int Amount;
}

[Serializable]
public class Damage : SpellEffect
{
    public int MinAmount;
    public int MaxAmount;
}

[Serializable]
public class AoeDamage : Damage
{
    public float AoeRange;
    public int AoeMaxTargets;
}

[Serializable]
public class Teleport : SpellEffect
{
    public float Distance;
}

