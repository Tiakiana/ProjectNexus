using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AstarGrid : MonoBehaviour {
   

    internal GameObject[,] aStarGrid = new GameObject[10, 10];
    // Use this for initialization

    void Awake() {
        
    }
    void Start()
    {

        for (int x = 0; x < 10; x++)
        {

            for (int z = 0; z < 10; z++)
            {
                GameObject go = GameObject.CreatePrimitive(PrimitiveType.Plane);
                go.AddComponent<AstarTile>().AstarTileSet(x,z);
                go.transform.position = new Vector3(x, 0, z);
                go.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                aStarGrid[x, z] = go;
                
                            }
        }


    }

    public List<GameObject> GetNeighbours(GameObject node)
    {
        List<GameObject> neighbours = new List<GameObject>();

        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if (x == 0 && y == 0)
                    continue;

                int checkX = node.GetComponent<AstarTile>().gridX + x;
                int checkY = node.GetComponent<AstarTile>().gridY + y;

                if (checkX >= 0 && checkX < 9 && checkY >= 0 && checkY < 9)
                {
                    neighbours.Add(aStarGrid[checkX, checkY]);
                }
            }
        }

        return neighbours;
    }
	
	
	void Update () {
	
	}
}
