using System.Collections;
using System.Collections.Generic;
using Shizounu.AI;
using UnityEngine;


[CreateAssetMenu(menuName = "Action/Random walk")]
public class RandomWalk : Shizounu.AI.Action
{
    public override void Act(StateMachine stateMachine)
    {
        TileManager goal = GameManager.Instance.Tiles[(int)Random.Range(0, GameManager.Instance.Tiles.Count)];
        ((AnimalManager)stateMachine).generatePath(goal);
        ((AnimalManager)stateMachine).doPath();
    }
}
