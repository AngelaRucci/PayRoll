using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MazeGeneratorScript : MonoBehaviour
{
    private const int NODE_LENGTH = 4;
    private const int NORTH = 0;
    private const int SOUTH = 1;
    private const int EAST = 2;
    private const int WEST = 3;
    private Node[,] nodeMatrix = new Node[NODE_LENGTH, NODE_LENGTH];
    private Node currentNode;
    private ArrayList nodeOrderToDisplay;
    private ArrayList allPossibleEdges;

    void Start()
    {
        nodeOrderToDisplay = new ArrayList();

        for (int i = 0; i < NODE_LENGTH; i++)
        {
            for (int j = 0; j < NODE_LENGTH; j++)
            {
                Node n = new Node();
                n.visited = false;
                n.xIndex = i;
                n.yIndex = j;
                n.parent = null;
                nodeMatrix[i, j] = n;
            }
        }

        for (int i = 0; i < NODE_LENGTH; i++)
        {
            Vector3[] line = { new Vector3(i, 0, n.parent.yIndex), new Vector3(n.parent.xIndex, 0, n.parent.yIndex) };

        }

        currentNode = nodeMatrix[Random.Range(0, NODE_LENGTH), Random.Range(0, NODE_LENGTH)];
        Node startNode = currentNode;
        recursiveBackTracker();

        //for (int i = -1; i < NODE_LENGTH; i++){
        //    DrawLine(new Vector3(-1, 0, i), new Vector3(-1, 0, i+1), Color.black);
        //    DrawLine(new Vector3(i, 0, -1), new Vector3(i+1, 0, -1), Color.black);
        //    DrawLine(new Vector3(NODE_LENGTH, 0, i), new Vector3(NODE_LENGTH, 0, i + 1), Color.black);
        //    DrawLine(new Vector3(i, 0, NODE_LENGTH), new Vector3(i + 1, 0, NODE_LENGTH), Color.black);
        //}

        for (float i = -0.5f; i < NODE_LENGTH - 0.5f; i++)
        {
            DrawLine(new Vector3(-0.5f, 0, i - 0), new Vector3(-0.5f, 0, i + 1), Color.black);
            DrawLine(new Vector3(i, 0, -0.5f), new Vector3(i + 1, 0, -0.5f), Color.black);
            DrawLine(new Vector3((float)(NODE_LENGTH - 0.5), 0, i), new Vector3(NODE_LENGTH - 0.5f, 0, i + 1), Color.black);
            DrawLine(new Vector3(i, 0, NODE_LENGTH - 0.5f), new Vector3(i + 1, 0, NODE_LENGTH - 0.5f), Color.black);
        }


        foreach (Node n in nodeOrderToDisplay)
        {
            if (n.parent != null)
            {
                DrawLine(new Vector3(n.parent.xIndex, 0, n.parent.yIndex), new Vector3(n.xIndex, 0, n.yIndex), Color.red);
            }

        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void recursiveBackTracker()
    {
        ArrayList adjacentNodes = adjacentNodesArrayList();
        if (!currentNode.visited)
        {
            currentNode.visited = true;
            nodeOrderToDisplay.Add(currentNode);
        }

        if (adjacentNodes.Count != 0)
        {
            Node nextNode = (Node)adjacentNodes[Random.Range(0, adjacentNodes.Count)];
            nextNode.parent = currentNode;
            currentNode = nextNode;
            recursiveBackTracker();

        }
        else if (currentNode.parent != null)
        {
            currentNode = currentNode.parent;
            recursiveBackTracker();
        }
    }

    void DrawLine(Vector3 start, Vector3 end, Color color)
    {
        GameObject myLine = new GameObject();
        myLine.transform.position = start;
        myLine.AddComponent<LineRenderer>();
        LineRenderer lr = myLine.GetComponent<LineRenderer>();
        lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
        lr.startColor = color;
        lr.endColor = color;
        lr.startWidth = 0.1f;
        lr.endWidth = 0.1f;
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
    }

    private ArrayList adjacentNodesArrayList()
    {
        ArrayList adjacentNodes = new ArrayList();
        int xpos = currentNode.xIndex;
        int ypos = currentNode.yIndex;

        if (xpos != 0)
        {
            Node leftNode = nodeMatrix[xpos - 1, ypos];
            if (!leftNode.visited)
            {
                leftNode.directionTraveled = WEST;
                adjacentNodes.Add(leftNode);
            }
        }

        if (xpos != NODE_LENGTH - 1)
        {
            Node rightNode = nodeMatrix[xpos + 1, ypos];
            if (!rightNode.visited)
            {
                rightNode.directionTraveled = EAST;
                adjacentNodes.Add(rightNode);
            }
        }

        if (ypos != 0)
        {
            Node topNode = nodeMatrix[xpos, ypos - 1];
            if (!topNode.visited)
            {
                topNode.directionTraveled = NORTH;
                adjacentNodes.Add(topNode);
            }
        }

        if (ypos != NODE_LENGTH - 1)
        {
            Node bottomNode = nodeMatrix[xpos, ypos + 1];
            if (!bottomNode.visited)
            {
                bottomNode.directionTraveled = SOUTH;
                adjacentNodes.Add(bottomNode);
            }
        }

        return adjacentNodes;
    }
}
