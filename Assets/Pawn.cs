using UnityEngine;
using System.Collections;

public class Pawn : MonoBehaviour {
    int posX = 0;
    int posY = 0;

    GridControl gc;
    
   // Dette script kan finde ud af hvilke tiles der kan gås på og det kan rykke
   // en brik frem og tilbage.

	void Start () {
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GridControl>();
        UpdatePosition();
         
    }

    bool TryDirection(GameObject go) {
        if (go.GetComponent<Tile>().walkable == true)
        {
            return true;
        }
        else {
            return false;
        }
    }
    


    void WalkDirection(int md) {
        switch (md)
        {
            //posX-1> -1 && TryDirection(gc.rageGrid[posX-1, posY])
            case 1:
                if (posX - 1 > -1 && gc.rageGrid[posX -1, posY].gameObject.GetComponent<Tile>().walkable == true)
                {
                    posX -= 1;
                    UpdatePosition();
                }
                break;

            case 2:
                
                    if (posY+1< 10 && TryDirection(gc.rageGrid[posX, posY + 1])) {
                        posY += 1;
                        UpdatePosition();
                     }
                break;

            case 3:
                if (posX + 1 < 10 && gc.rageGrid[posX + 1, posY].gameObject.GetComponent<Tile>().walkable == true)
                {
                    posX += 1;
                    UpdatePosition();
                }
                break;

            case 4:
                if (posY-1 > -1 && TryDirection(gc.rageGrid[posX, posY - 1]))
                {
                    posY -= 1;
                    UpdatePosition();
                }
                break;

            default:
                break;
        }


        
    }

    public void UpdatePosition() {
        gameObject.transform.position = new Vector3((float)posX, 1, (float)posY);
    }

		void Update () {
        if (Input.GetKeyDown("d"))
        {
            WalkDirection(3);
        }
        if (Input.GetKeyDown("a")) {
            WalkDirection(1);
        }
        if (Input.GetKeyDown("w"))
        {
            WalkDirection(2);
        }
        if (Input.GetKeyDown("s"))
        {
            WalkDirection(4);
        }
    }
}
