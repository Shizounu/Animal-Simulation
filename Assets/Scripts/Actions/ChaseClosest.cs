using System.Collections;
using System.Collections.Generic;
using Shizounu.AI;
using UnityEngine;

[CreateAssetMenu(menuName = "Action/Chase closest", fileName = "new Chase Closest")]
public class ChaseClosest : Shizounu.AI.Action
{
    //0 = Rabbit
    //1 = fox
    //2 = Bear
    //3 = Hawk
    public Animals targetAnimal;
    public Animals forAnimal;
    public AnimalStats stats;
    public override void Act(StateMachine stateMachine)
    {
        List<List<TileManager>> RabbitPaths = new();
        foreach (var tile in GameManager.Instance.Tiles){
            foreach (var animal in tile.Animals){
                if(animal.type == (int)targetAnimal){
                    ((AnimalManager)stateMachine).generatePath(animal.currentTile);
                    RabbitPaths.Add(((AnimalManager)stateMachine).currentPath);
                }
            }
        }

        int length = int.MaxValue;
        List<TileManager> closest = new();
        foreach (var item in RabbitPaths){
            if(item.Count < length && item.Count < ((forAnimal == Animals.Bear) ? stats.BearChaseDistance : int.MaxValue)){
                closest = item;
                length = item.Count;
            }
        }
        ((AnimalManager)stateMachine).currentPath = closest;
    }
}

public enum Animals{
    Rabbit, 
    Fox,
    Bear,
    Hawk
}