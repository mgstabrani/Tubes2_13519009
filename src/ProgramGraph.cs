using System;
using System.IO;
using System.Collections.Generic;

class ProgramGraph{
    static void Main(string[] args) {
            Graph globalGraph = new Graph();
            bool graphReady = false;
            Console.Write("Masukkan file: ");
            string fileName = Console.ReadLine();
            
            string[] lines = File.ReadAllLines(fileName);

            string count = lines[0];
            int n = Int32.Parse(count);


            string node = "";
            for (int j = 1; j < n+1; j++)
            {
                int idxNodeFrom = -1;
                string line = lines[j] + '\n';
                //Console.Write(line);
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] == '\n')
                    {
                        if (globalGraph.getIdxNode(node) == -1)
                        {
                            globalGraph.addNode(node);
                        }
                        globalGraph.addConnectedNode(idxNodeFrom, globalGraph.getIdxNode(node));
                        globalGraph.addConnectedNode(globalGraph.getIdxNode(node), idxNodeFrom);
                        node = "";
                    }
                    else if (line[i] == ',')
                    {
                        //Console.WriteLine(" --> " + node);
                        if (globalGraph.getIdxNode(node) == -1)
                        {
                            globalGraph.addNode(node);

                        }
                        idxNodeFrom = globalGraph.getIdxNode(node);
                        node = "";
                    }
                    else
                    {
                        //Console.Write(file[i]);
                        node += line[i];
                    }
                }
            }

            graphReady = true;
            //Console.WriteLine("Graph is Ready!!");
            globalGraph.print();
            List<int> result = new List<int>();
            List<int> kunjung = new List<int>();
            List<int> dibfs = new List<int>();
            for(int i = 0; i < globalGraph.getNumOfNode(); i++){
                kunjung.Add(0);
                dibfs.Add(0);
            }

            int awal = Convert.ToInt32(Console.ReadLine());
            int akhir = Convert.ToInt32(Console.ReadLine());
            //DFS(globalGraph, awal, akhir, ref kunjung, ref result);
            BFS(globalGraph, awal, akhir, ref kunjung, ref dibfs,ref result);
            for(int i = 0; i < result.Count; i++){
                Console.WriteLine(result[i]);
            }
    }


    static void DFS(Graph g, int nodeFrom, int nodeTo, ref List<int> dikunjungi, ref List<int> hasil){
        if(dikunjungi[nodeFrom] == 0){
            dikunjungi[nodeFrom] = 1;
            hasil.Add(nodeFrom);
        }
        if(nodeFrom == nodeTo){
            return;
        }else{
            if(g.getNumOfConnectedNode(nodeFrom) == 0){
                hasil.RemoveAt(hasil.Count - 1);
                DFS(g, hasil[hasil.Count-1], nodeTo, ref dikunjungi, ref hasil);
            }else{
                bool isExist = false;

                //sorting graph
                List<string> connectNodes = new List<string>();
                for(int i = 0; i < g.getNumOfConnectedNode(nodeFrom); i++){
                    connectNodes.Add(g.getNode(g.getIdxConnectedNode(nodeFrom,i)));
                }
                connectNodes.Sort();

                for(int i = 0; i < g.getNumOfConnectedNode(nodeFrom); i++){
                    if(dikunjungi[g.getIdxNode(connectNodes[i])] == 0){
                        // Console.WriteLine(connectNodes[i]);
                        // Console.WriteLine(g.getIdxNode(connectNodes[i]));
                        DFS(g, g.getIdxNode(connectNodes[i]), nodeTo, ref dikunjungi, ref hasil);
                        isExist = true;
                        break;
                    }
                }
                if(! isExist){
                    hasil.RemoveAt(hasil.Count - 1);
                    DFS(g, hasil[hasil.Count-1], nodeTo, ref dikunjungi, ref hasil);
                }
            }
        
        }
    }

    static bool BFS(Graph g, int nodeFrom, int nodeTo, ref List<int> dikunjungi, ref List<int> dibfs,ref List<int> hasil){
        if(dikunjungi[nodeFrom] == 0){
            dikunjungi[nodeFrom] = 1;
            hasil.Add(nodeFrom);
        }
        // for(int i = 0; i < g.getNumOfConnectedNode(nodeFrom); i++){
        //     dibfs[g.getIdxConnectedNode(nodeFrom,i)] = 0;
        // }

        if (isAllVisited(dikunjungi))
        {
            return false;
        }
        else if(nodeFrom == nodeTo){
            return true; 
        }else{
            if(g.getNumOfConnectedNode(nodeFrom) == 0){
                hasil.RemoveAt(hasil.Count - 1);
                // for(int i = 0; i < g.getNumOfConnectedNode(nodeFrom); i++){
                //     dikunjungi[g.getIdxConnectedNode(nodeFrom,i)]--;
                // }
                return BFS(g, hasil[hasil.Count-1], nodeTo, ref dikunjungi, ref dibfs,ref hasil);
            }else{
                bool isExist = false;

                //Sorting graph
                List<string> connectNodes = new List<string>();
                for(int i = 0; i < g.getNumOfConnectedNode(nodeFrom); i++){
                    connectNodes.Add(g.getNode(g.getIdxConnectedNode(nodeFrom,i)));
                }
                connectNodes.Sort();


                for(int i = 0; i < g.getNumOfConnectedNode(nodeFrom); i++){
                    if(dikunjungi[g.getIdxNode(connectNodes[i])] == 0 && dibfs[g.getIdxNode(connectNodes[i])] == 0){
                        for(int j = 0; j < g.getNumOfConnectedNode(nodeFrom); j++){
                            if(j != i){
                                dibfs[g.getIdxNode(connectNodes[j])] = 1;
                            }
                        }

                        // Console.WriteLine(connectNodes[i]);
                        // Console.WriteLine(g.getIdxNode(connectNodes[i]));
                        return BFS(g, g.getIdxNode(connectNodes[i]), nodeTo, ref dikunjungi, ref dibfs,ref hasil);
                        isExist = true;
                        break;
                    }
                }
                if(! isExist){
                    hasil.RemoveAt(hasil.Count - 1);
                    return BFS(g, hasil[hasil.Count-1], nodeTo, ref dikunjungi, ref dibfs,ref hasil);
                }
            }
        
        }
    }

    static bool isAllVisited(List<int> vis)
    {
        for (int i = 0; i < vis.Count; i++)
        {
            if (vis[i] == 0)
                return false;
        }

        return true;
    }
}