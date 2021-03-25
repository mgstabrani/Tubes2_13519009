using System.Collections.Generic;
using System;

public class Graph
{
    protected int numOfNode;
    protected List<string> node;
    protected List<int> numOfConnectedNode; // 
    protected List<List<int>> connectedNode; // (numOfNode*numOfNode)

    public Graph()
    {
        this.numOfNode = 0;
        this.node = new List<string>();
        this.numOfConnectedNode = new List<int>();
        this.connectedNode = new List<List<int>>();
    }

    public Graph(List<string> node, List<int> numOfConnect, List<List<int>> connect)
    {
        this.numOfNode = node.Count;

        this.node = new List<string>();
        this.numOfConnectedNode = new List<int>();
        this.connectedNode = new List<List<int>>();

        //this.node.Clear();
        foreach (string no in node)
            this.node.Add(no);

        //this.numOfConnectedNode.Clear();
        foreach (int num in numOfConnect)
            this.numOfConnectedNode.Add(num);

        //this.connectedNode.Clear();
        foreach (List<int> con in connect)
            this.connectedNode.Add(con);
    }

    /*
    public void setNode(List<string> node)
    {
        this.node = node;
        this.numOfNode = node.Count;
    }

    public void setNumOfConnectedNode(List<int> numOfConnectedNode)
    {
        this.numOfConnectedNode = numOfConnectedNode;
    }

    public void setConnectedNode(List<List<int>> connectedNode)
    {
        this.connectedNode = connectedNode;
    }
    */

    public void addNode(string node)
    {
        this.node.Add(node);
        this.numOfNode++;
        connectedNode.Add(new List<int>());
        this.numOfConnectedNode.Add(0);
    }

    public string getNode(int idxNode)
    {
        return this.node[idxNode];
    }

    public void addConnectedNode(int idxNode, int idxConnectNode)
    {
        this.numOfConnectedNode[idxNode]++;
        this.connectedNode[idxNode].Add(idxConnectNode);
    }

    public List<int> getListConnectedNode(int idxNode)
    {
        return connectedNode[idxNode];
    }

    public List<List<int>> getListListConnectedNode()
    {
        return connectedNode;
    }

    public List<int> getListNumOfConnectedNode()
    {
        return numOfConnectedNode;
    }

    public List<string> getListNode()
    {
        return node;
    }

    public int getNumOfNode()
    {
        return this.numOfNode;
    }

    public int getNumOfConnectedNode(int idxNode)
    {
        return this.numOfConnectedNode[idxNode];
    }

    public int getIdxConnectedNode(int idxNode, int idxConnect)
    {
        return connectedNode[idxNode][idxConnect];
    }

    public string getConnectedNode(int idxNode, int idxConnect)
    {
        return node[this.getIdxConnectedNode(idxNode, idxConnect)];
    }

    public void print()
    {

        if (this.numOfNode < 1)
            return;

        for (int i = 0; i < this.numOfNode; i++)
            Console.Write(this.node[i] + " ");

        Console.WriteLine();

        for (int i = 0; i < this.numOfNode; i++)
        {
            Console.Write(i + ": ");
            for (int j = 0; j < this.numOfConnectedNode[i]; j++)
            {
                Console.Write(connectedNode[i][j] + " ");
            }
            Console.WriteLine();
        }
    }

    public int getIdxNode(string node)
    {
        for (int i = 0; i < this.numOfNode; i++)
        {
            if (this.node[i] == node)
            {
                return i;
            }
        }
        return -1;
    }
}
