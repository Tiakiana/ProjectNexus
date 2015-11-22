using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AstarAlgorithm : MonoBehaviour {
    List<GameObject> open;
    List<GameObject> closed;
   GameObject goal;
    GameObject crnt;
    public GameObject grid;
    AstarGrid ag;
    void Awake()
    {
        ag = grid.GetComponent<AstarGrid>();
    }

    void Start () {
        open = new List<GameObject>();
        closed = new List<GameObject>();
	}

    internal void SetStartingPoint(GameObject sp) {
        open.Add(sp);
    }

    internal void SetGoal(GameObject g) {
        goal = g;
    }

    internal int GetDistance(GameObject a, GameObject b) {
        int distanceX = Mathf.Abs(a.GetComponent<AstarTile>().gridX - b.GetComponent<AstarTile>().gridX);
        int distanceY = Mathf.Abs(a.GetComponent<AstarTile>().gridY - b.GetComponent<AstarTile>().gridY);

        if (distanceX > distanceY)
        {
            return 14 * distanceY + 10 * (distanceX - distanceY);
        }
        else {
            return 14 * distanceX + 10 * (distanceY - distanceX);

        }
    }

    public void CheckingNeighbours(GameObject startNode, GameObject endNode)
    {
        List<GameObject> openSet = new List<GameObject>();
        List<GameObject> closedSet = new List<GameObject>();
        openSet.Add(startNode);
        goal = endNode;
        crnt = startNode;

        for (int i = 1; i < openSet.Count; i++)
        {
            if (openSet[i].GetComponent<AstarTile>().f < crnt.GetComponent<AstarTile>().f || openSet[i].GetComponent<AstarTile>().f == crnt.GetComponent<AstarTile>().f && openSet[i].GetComponent<AstarTile>().h < crnt.GetComponent<AstarTile>().h)
            {
                crnt.GetComponent<AstarTile>().parens = crnt;
                crnt = openSet[i];
            }
        }
        openSet.Remove(crnt);
        closedSet.Add(crnt);

        if (crnt == goal)
        {
            return;

        }


        foreach (GameObject neighbour in ag.GetNeighbours(crnt))
        {
            if (!neighbour.GetComponent<AstarTile>().walkable || closedSet.Contains(neighbour))
            {
                continue;
            }
            int newMovementCostToNeighbour = crnt.GetComponent<AstarTile>().g + GetDistance(crnt, neighbour);
            if (newMovementCostToNeighbour < neighbour.GetComponent<AstarTile>().g || !openSet.Contains(neighbour))
            {
                neighbour.GetComponent<AstarTile>().g = newMovementCostToNeighbour;
                neighbour.GetComponent<AstarTile>().h = GetDistance(neighbour, goal);
                neighbour.GetComponent<AstarTile>().parens = crnt;

                if (!openSet.Contains(neighbour))
                    openSet.Add(neighbour);
            }
        }
    }

    void HighlightPath() {
        GameObject cr = a;
        Debug.Log("hej igen");
        while (cr.GetComponent<AstarTile>().parens != null) {
            cr.GetComponent<Renderer>().material.color = new Color(255, 255, 0);
            cr = cr.GetComponent<AstarTile>().parens;
            Debug.Log("hej igen igen");

        }
    }
    

    // Testing purposes

    public GameObject a;
    public GameObject b;
    public List<GameObject> path = new List<GameObject>();
    void Update () {
        if (Input.GetKeyDown("i"))
        {
            Debug.Log("Hey");
            CheckingNeighbours(a, b);
            HighlightPath();
        }
	}
}
