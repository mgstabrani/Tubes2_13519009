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

    // public Graph(const Graph& graf){
    //     this.numOfNode = graf.numOfNode;
    //     this.node = new List<string>();
    //     for(int i = 0; i < this.numOfNode; i++){
    //         mode.Add(graf.node[i]);
    //     }
    // }

    // //     this.numOfConnectedNode = new int[255];
    // //     for(int i = 0; i < this.numOfNode; i++){
    // //         this.numOfConnectedNode[i] = graf.numOfConnectedNode[i];
    // //     }

    // //     this.connectedNode = new int[255][255];
    // //     for(int i = 0; i < this.numOfNode; i++){
    // //         for(int j = 0; j < this.numOfConnectedNode[i]; j++){
    // //             this.connectedNode[i][j] = graf.connectedNode[i][j];
    // //         }
    // //     }
    // // }

    // // public Graph& operator=(const Graph&){
    // //     this.numOfNode = graf.numOfNode;
    // //     for(int i = 0; i < this.numOfNode; i++){
    // //         mode[i] = graf.node[i];
    // //     }

    // //     for(int i = 0; i < this.numOfNode; i++){
    // //         this.numOfConnectedNode[i] = graf.numOfConnectedNode[i];
    // //     }

    // //     for(int i = 0; i < this.numOfNode; i++){
    // //         for(int j = 0; j < this.numOfConnectedNode[i]; j++){
    // //             this.connectedNode[i][j] = graf.connectedNode[i][j];
    // //         }
    // //     }
    // // }

    // public ~Graph(){
    //     delete this.node;
    //     delete this.numOfConnectedNode;
    //     delete this.connectedNode;
    // }

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
