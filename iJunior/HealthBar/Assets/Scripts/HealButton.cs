using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealButton : MonoBehaviour
{
    [SerializeField] private float _healAmount = 10;

    public void GiveHeal(Player player)
    {
        player.GetHeal(_healAmount);
    }
}
