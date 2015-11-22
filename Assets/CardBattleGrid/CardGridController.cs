using UnityEngine;
using System.Collections;

public class CardGridController : MonoBehaviour {
  internal  GameObject[,] player1Board = new GameObject[5,3];
   internal GameObject[,] player2Board = new GameObject[5,3];
   public GameObject clone;
    // [01234,0] = artillery row 
    // [01234,1] = auxilary row
    // [01234,2] = frontline row

    void CreateGrid()
    {
        for (int x = 0; x < 5; x++)
        {

            for (int z = 0; z < 3; z++)
            {
                GameObject go = GameObject.Instantiate(clone);
                go.AddComponent<CardTile>();
                go.transform.position = new Vector3(x, 0, z);
                go.transform.localScale = new Vector3(1f, 1f, 1f);
                player1Board[x, z] = go;
            }
        }
    }
    void Start () {
        
        CreateGrid();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
