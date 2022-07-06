using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Shizounu.AI;
public class AnimalManager : StateMachine
{
    [Header("Animal References")]
    public AnimalStats AnimalStats;
    public TileManager currentTile;
    public List<TileManager> currentPath;
    public int Count;
    public bool doVisuals = true;
    public int type = 0;
    public void RegisterWithTile(TileManager tileManager){
        tileManager.Animals.Add(this);
        currentTile = tileManager;
    }

    public void Tick(){
        doTick();
    }

    public void Reproduce(){
        if(Count >= AnimalStats.RabbitReproductionRate){
            for (int i = 0; i < AnimalStats.RabbitReproductionAmount; i++){
                GameManager.Instance.summonAnimal(GameManager.Instance.RabbitPrefab, currentTile);
            }
        }
    }

    private IEnumerator doPathVisual(){
        for (int i = 0; i < currentPath.Count; i++){
            transform.position = currentPath[i].transform.position;
            yield return new WaitForSeconds(GameManager.Instance.AnimationTime / currentPath.Count);
        }
    }
    public void doPath(){
        doVisuals = false;
        StartCoroutine(doPathVisual());
        RegisterWithTile(currentPath[currentPath.Count - 1]);
        doVisuals = true;
    }
    public void generatePath(TileManager goal){
            //Outer reached edge
			PriorityQueue<TileManager> frontier = new PriorityQueue<TileManager>();
			frontier.Enqueue(currentTile, 0);

			//From which tile this tile has been reached
			Dictionary<TileManager, TileManager> cameFrom = new();
			cameFrom[currentTile] = null;

			//which cost you need to reach this tile
			Dictionary<TileManager, float> costSoFar = new();
			costSoFar[currentTile] = 0;

			while(frontier.Count > 0) {
				var current = frontier.Dequeue();
				if(current == goal)
					break;

				foreach(var next in current.Adjacencies) {
					float newCost = costSoFar[current] + next.TraversalCost;
					if(!costSoFar.ContainsKey(next) || newCost < costSoFar[next]) {
						costSoFar[next] = newCost;
						frontier.Enqueue(next, newCost + Vector3.Distance(next.transform.position, goal.transform.position));
						cameFrom[next] = current;
					}
				}
			}
            
            List<TileManager> Path = new();
            var cur = goal;
            while(cur != currentTile){
                Path.Add(cur);
                cur = cameFrom[cur];
            }
            Path.Add(currentTile);
            Path.Reverse();

			currentPath = Path;
        }
}
