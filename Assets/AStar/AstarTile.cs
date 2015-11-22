using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class AstarTile : MonoBehaviour {
    public int h;
    public int f;
    public int g;
    public bool walkable = true;
    public bool closed = false;
    public List<GameObject> neighbors = new List<GameObject>();
    public int gridX;
    public int gridY;
    public GameObject parens;
    int state= 0;
    void Start() {

    }

    void SetBlank() {
        gameObject.GetComponent<Renderer>().material.color = new Color(255, 255, 255);
    }

    public void AstarTileSet(int _X, int _Y) {
        gridX = _X;
        gridY = _Y;
    }
    internal void SetColor() {
        gameObject.GetComponent<Renderer>().material.color = new Color(255, 0, 0);
    }

    internal void SetGreen() {
        gameObject.GetComponent<Renderer>().material.color = new Color(0, 255, 0);

    }
    internal void SetBlu() {
        gameObject.GetComponent<Renderer>().material.color = new Color(0, 0, 255);

    }

    void OnMouseDown() {
        state++;
        if (state > 3) {
            state = 0;
            SetBlank();
            walkable = true;

        }
        if (state == 1) {
            walkable = false;
            SetColor();
        }
        if (state ==2)
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<AstarAlgorithm>().a = gameObject;
            SetGreen();
        }
        if (state == 3) {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<AstarAlgorithm>().b = gameObject;
            SetBlu();
        }
    }
	
	void Update () {
	
	}
}
