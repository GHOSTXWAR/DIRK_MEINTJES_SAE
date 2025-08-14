using UnityEngine;

public class ManaSystem : MonoBehaviour 
{
    public float maxMana = 100f;
    public float MP = 50f;

    private void OnEnable()
    {
        if (MP > maxMana) MP = maxMana;
    }
    public void DrainMana(float mana)
    {

    }

    public void RecoverMana(float mana)
    {

    }
}
