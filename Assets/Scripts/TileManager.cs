using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{

    [Header("Traversal")]
    public float TraversalCost;
    public List<TileManager> Adjacencies;

    [Header("Misc references")]
    public LayerMask TileLayer;
    public float ConnectionDistance = 15;
    public List<AnimalManager> Animals;
    public List<Transform> VisualPositions;

    private void OnEnable() {
        Collider[] tiles = Physics.OverlapSphere(transform.position, ConnectionDistance, TileLayer);
        foreach (var item in tiles)
            Adjacencies.Add(item.gameObject.GetComponent<TileManager>());
    }    

    public void Tick(){
        int i = 0;
        while (i < Animals.Count){
            if(Animals[i].currentTile != this){
                Animals.Remove(Animals[i]);
            } else {
                Animals[i].Tick();
                i += 1;
            }
        }
    }

    private void Update() {
        int i = 0;
        foreach (var Animal in Animals){
            if(!Animal.doVisuals)
                continue;
            Animal.transform.position = VisualPositions[i].position;
            i+=1;
            if(i > VisualPositions.Count)
                i = 0;
        }
    }
}
