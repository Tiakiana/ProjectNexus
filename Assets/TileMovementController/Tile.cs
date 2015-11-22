using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {
    
    public bool walkable = true;

    //tilets vigtigste opgave er at fortælle om der kan sættes noget på det.
   public enum terrainType {
        sand = 1,
        mountain = 2,
        grass = 3

    }
    
    public terrainType terr;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
