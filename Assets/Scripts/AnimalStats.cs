using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Animal Stats", fileName = "new Animal Stats")]
public class AnimalStats : ScriptableObject
{
    [Header("Rabbit")]
    public int RabbitReproductionRate;
    public int RabbitReproductionAmount;

    [Header("Fox")]
    public int FoxEatDistance;
    public int FoxReproduceThreshhold;
    public int FoxReproduceAmount;

    [Header("Bear")]
    public int BearChaseDistance;
    public int BearReproduceThreshhold;
    public int BearReproductionAmount;

    [Header("Hawk")]
    public int HawkReproductionThreshhold;
    public int HawkReproductionAmount;
}
