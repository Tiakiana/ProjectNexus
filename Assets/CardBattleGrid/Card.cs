using UnityEngine;
using System.Collections;

public class Card : MonoBehaviour {
    public int attack;
    public int health;


    public bool canAct = true;
    CardGridController cgc;
    
    public enum row {
        artillery = 1,
        auxilary = 2,
        front = 3,
        
    }
    row myRow = row.front;
    
	void Start () {
        
        StartCoroutine("jakob");
        //gameObject.transform.SetParent(cgc.player1Board[2, 2].transform, false);
        //gameObject.transform.localPosition = new Vector3(0, 0, 0);
    }

    public GameObject FindEmptyInRow(int zAxis) {
        for (int i = 0; i < 5; i++)
        {
            if (cgc.player1Board[i, zAxis].GetComponent<CardTile>().empty) {
                cgc.player1Board[i, zAxis].GetComponent<CardTile>().empty = false;
                return cgc.player1Board[i, zAxis];
            }
        }
        return null;

    }

    public void PlaceCard() {
        switch ((int)myRow)
        {
            case 1:
                gameObject.transform.SetParent(FindEmptyInRow(0).transform);
                gameObject.transform.localPosition = new Vector3(0, 0, 0);
                
                break;
            case 2:
                gameObject.transform.SetParent(FindEmptyInRow(1).transform);
                gameObject.transform.localPosition = new Vector3(0, 0, 0);
                break;
            case 3:
                gameObject.transform.SetParent(FindEmptyInRow(2).transform);
                gameObject.transform.localPosition = new Vector3(0, 0, 0);

                break;
            default:
                break;
        }
        
    }



    IEnumerator jakob() {
        cgc = GameObject.FindGameObjectWithTag("GameController").GetComponent<CardGridController>();

        yield return new WaitForSeconds(2);
        PlaceCard();
    }

    // Update is called once per frame
    void Update () {
        
    }
}