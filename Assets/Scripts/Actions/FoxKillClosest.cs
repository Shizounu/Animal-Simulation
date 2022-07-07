using System.Collections;
using System.Collections.Generic;
using Shizounu.AI;
using UnityEngine;

[CreateAssetMenu(menuName = "Action/Fox kill closest", fileName = "new FoxKillClosest")]
public class FoxKillClosest : Shizounu.AI.Action
{
    public AnimalStats stats;
    public override void Act(StateMachine stateMachine){
        if(((AnimalManager)stateMachine).currentPath.Count < stats.FoxEatDistance){
            foreach (var Animal in ((AnimalManager)stateMachine).currentPath[((AnimalManager)stateMachine).currentPath.Count - 1].Animals){
                if(Animal.type == (int)Animals.Rabbit){
                    ((AnimalManager)stateMachine).Count += 1;
                    Destroy(Animal.gameObject);
                }
            }
        }
        if(((AnimalManager)stateMachine).Count > stats.FoxReproduceThreshhold){
            for (int i = 0; i < stats.FoxReproduceAmount; i++)
                GameManager.Instance.summonAnimal(GameManager.Instance.FoxPrefab, ((AnimalManager)stateMachine).currentTile);
            
        }
    }
}
