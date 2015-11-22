using UnityEngine;
using System.Collections;

public class GridControl : MonoBehaviour {

   internal GameObject[,] rageGrid = new GameObject[10,10];
    
    

	void Start () {
      
           

            for (int x = 0; x < 10; x++)
            {

            for (int z = 0; z < 10; z++)
            {
                GameObject go = GameObject.CreatePrimitive(PrimitiveType.Plane);
                go.AddComponent<Tile>();
                go.transform.position = new Vector3(x,0,z);
                go.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                rageGrid[x, z] = go;
                int rnd = Random.Range(1,4);

                switch (rnd)
                {
                    case 1:
                        go.GetComponent<Tile>().terr = Tile.terrainType.mountain;
                        go.GetComponent<Tile>().walkable = false;
                        go.GetComponent<Renderer>().material.color = new Color(255, 0, 0, 1);
                        break;
                    case 2:
                        go.GetComponent<Tile>().terr = Tile.terrainType.grass;
                        break;
                    case 3:
                        go.GetComponent<Tile>().terr = Tile.terrainType.sand;
                        
                        break;
                    default:
                        break;
                }
            }
        }
	}

    
	
	void Update () {
	
	}
}
