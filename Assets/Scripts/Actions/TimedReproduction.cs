using System.Collections;
using System.Collections.Generic;
using Shizounu.AI;
using UnityEngine;

[CreateAssetMenu(menuName = "Action/timed reproduction", fileName = "new Timed Reproduction")]
public class TimedReproduction : Shizounu.AI.Action
{
    public override void Act(StateMachine stateMachine){
        ((AnimalManager)stateMachine).Count += 1;
        ((AnimalManager)stateMachine).Reproduce();

    }
}
