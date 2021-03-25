using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace People_May_You_Know
{
    
    public partial class main : Form
    {
        string algorithm = "none";
        int accountChoosen_index = -1;

        Graph globalGraph = new Graph();

        bool graphReady = false;

        public main()
        {
            InitializeComponent();
            alertLabel.Text = "";
        }
        

        #region function
        private void browse()
        {
            Console.Out.WriteLine("Browse!!");
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "C# Corner Open File Dialog";
            //fdlg.InitialDirectory = @"c:\";
            fdlg.InitialDirectory = System.AppDomain.CurrentDomain.BaseDirectory;


            fdlg.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;
           
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                
                filePathText.Text = fdlg.FileName;
                convertToGraph(filePathText.Text);

                if (graphReady)
                {
                    resetGraphVisualization();
                    showGraphVisualization(globalGraph);
                    setNodeDropDownList(globalGraph);
                    
                    resetRecommendationPanel();
                }
                else
                {
                    resetGraphVisualization();
                    resetNodeDropDownList();
                    resetRecommendationPanel();
                }
            }

        }

        private void convertToGraph(string fileName){
            globalGraph = new Graph();
            graphReady = false;

            try
            {
                string[] lines = File.ReadAllLines(fileName);

                string count = lines[0];
                int n = Int32.Parse(count);


                string node = "";
                for (int j = 1; j < n + 1; j++)
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
                //globalGraph.print();
            }
            catch (Exception e)
            {
                graphReady = false;
            }

            
        }



        

        private void submit()
        {
            if (!graphReady)
            {
                showAlert("Graph is not ready!!");
                return;
            }
            else if (algorithm == "none")
            {
                showAlert("Algorithm is not selected!!");
                return;
            }
            else if (accountNodeDropDown.SelectedIndex < 0 || exploreNodeDropDown.SelectedIndex < 0)
            {
                showAlert("Account is not selected!!");
                return;
            }

            showAlert("");

            //Console.Out.WriteLine("Submit!!");

            //resetGraphNodeVisualizationColor();

            if (algorithm == "bfs")
            {
                dfsRecommendationFriends(globalGraph, accountNodeDropDown.SelectedIndex);
                exploreFriendWith(globalGraph, accountNodeDropDown.SelectedIndex, exploreNodeDropDown.SelectedIndex);
            }
            else if (algorithm == "dfs")
            {
                dfsRecommendationFriends(globalGraph, accountNodeDropDown.SelectedIndex);
                exploreFriendWith(globalGraph, accountNodeDropDown.SelectedIndex, exploreNodeDropDown.SelectedIndex);
            }
                
        }

        public void showAlert(string m)
        {
            alertLabel.Text = m;
        }

        private void setAlgorithm(string al)
        {
            algorithm = al;
            Console.Out.WriteLine(algorithm);
        }

        public void dfsRecommendationFriends(Graph g, int search)
        {
            int search1 = search;
            int numOf1 = g.getNumOfConnectedNode(search1);

            Graph gHasil = new Graph();
            List<int> searchChild = g.getListConnectedNode(search1);
            for(int i = 0; i < numOf1; i++)
            {
                int search2 = g.getIdxConnectedNode(search1, i);
                int numOf2 = g.getNumOfConnectedNode(search2);
                
                for (int j = 0; j < numOf2; j++)
                {
                    int idxRecNode = g.getIdxConnectedNode(search2, j);
                    
                    if (idxRecNode == search1 || searchChild.Contains(idxRecNode))
                        continue;
                    
                    string recNode = g.getNode(idxRecNode);
                    int idx = gHasil.getIdxNode(recNode);

                    if (idx == -1)
                    {
                        gHasil.addNode(recNode);
                    }

                    idx = gHasil.getIdxNode(recNode);

                    gHasil.addConnectedNode(idx, search2);
                }
            }
            //gHasil.print();
            //Console.WriteLine("---------------");

            if (gHasil.getNumOfNode() > 1)
            {
                int num = gHasil.getNumOfNode();
                List<string> nodeTemp = gHasil.getListNode();
                List<int> numOfConnectedNodeTemp = gHasil.getListNumOfConnectedNode();
                List<List<int>> connectedNodeTemp = gHasil.getListListConnectedNode();

                for (int i = 0; i < num - 1; i++)
                {
                    int idxMax = i;
                    for (int j = i + 1; j < num; j++)
                    {
                        if (numOfConnectedNodeTemp[idxMax] < numOfConnectedNodeTemp[j])
                            idxMax = j;
                    }

                    string tempNode = nodeTemp[i];
                    nodeTemp[i] = nodeTemp[idxMax];
                    nodeTemp[idxMax] = tempNode;

                    int tempNumOfMutual = numOfConnectedNodeTemp[i];
                    numOfConnectedNodeTemp[i] = numOfConnectedNodeTemp[idxMax];
                    numOfConnectedNodeTemp[idxMax] = tempNumOfMutual;

                    List<int> tempMutual = connectedNodeTemp[i];
                    connectedNodeTemp[i] = connectedNodeTemp[idxMax];
                    connectedNodeTemp[idxMax] = tempMutual;
                }

                /*
                Graph gHasilTemp = new Graph();

                foreach (string no in nodeTemp)
                    gHasilTemp.addNode(no);

                for (int i = 0; i < numOfConnectedNodeTemp.Count; i++)
                {
                    int numtemp = numOfConnectedNodeTemp[i];
                    for (int j = 0; j < numtemp; j++)
                    {
                        gHasilTemp.addConnectedNode(i, connectedNodeTemp[i][j]);
                    }
                }

                gHasilTemp.print();

                //Graph gHasil2 = new Graph();

                //foreach(string no in Node)
                */
                gHasil = new Graph(nodeTemp, numOfConnectedNodeTemp, connectedNodeTemp);
            }
            
           
            showRecommendation(g, gHasil);
            

        }

        public void bfsRecommendationFriends(Graph g, int search)
        {
            int account = search;
            List<int> idxSearchs = new List<int>();
            idxSearchs.Add(account);

            int numOfNode = g.getNumOfNode();

            bool[] nodeSign = new bool[numOfNode];
            for (int i = 0; i < numOfNode; i++)
                nodeSign[i] = false;


            List<string> recNode = new List<string>();
            List<int> countRec = new List<int>();
            bool fr = true;
            int k = 0;
            int count = 0;
            while (k < idxSearchs.Count)
            {
                int idxSearch = idxSearchs[k];
                int num = g.getNumOfConnectedNode(idxSearch);
                nodeSign[idxSearch] = true;
                count = 0;
                for (int i = 0; i < num; i++)
                {
                    int idxNode = g.getIdxConnectedNode(idxSearch, i);
                    if (!nodeSign[idxNode])
                    {
                        if (fr)
                        {
                            nodeSign[idxNode] = true;
                            idxSearchs.Add(idxNode);
                        }
                        else
                        {
                            recNode.Add(g.getNode(idxNode));
                        }
                        count++;
                    }
                }
                k++;
                fr = false;
                countRec.Add(count);
            }

            List<string> tempRecNode = new List<string>();
            List<int> numOfMutual = new List<int>();
            List<List<int>> mutual = new List<List<int>>();
            
            k = 1;
            int n = 0;
            for(int i = 0; i < recNode.Count; i++)
            {
                string temp = recNode[i];
                if (!tempRecNode.Contains(temp))
                {
                    tempRecNode.Add(temp);
                    numOfMutual.Add(0);
                    mutual.Add(new List<int>());
                }

                int idx = tempRecNode.IndexOf(temp);
                if (n >= countRec[k])
                {
                    n = 0;
                    k++;
                    numOfMutual[idx]++;
                    mutual[idx].Add(idxSearchs[k]);
                }
                else
                {
                    numOfMutual[idx]++;
                    mutual[idx].Add(idxSearchs[k]);
                }
                n++;
            }
            
            /*
            printList(tempRecNode);
            printList(numOfMutual);
            foreach(List<int> mut in mutual)
            {
                printList(mut);
            }
            */

            if (tempRecNode.Count > 1)
            {
                int num = tempRecNode.Count;
                for(int i = 0; i < num-1; i++)
                {
                    int idxMax = i;
                    for(int j = i+1; j < num; j++)
                    {
                        if (numOfMutual[idxMax] < numOfMutual[j])
                            idxMax = j;
                    }

                    string tempNode = tempRecNode[i];
                    tempRecNode[i] = tempRecNode[idxMax];
                    tempRecNode[idxMax] = tempNode;

                    int tempNumOfMutual = numOfMutual[i];
                    numOfMutual[i] = numOfMutual[idxMax];
                    numOfMutual[idxMax] = tempNumOfMutual;

                    List<int> tempMutual = mutual[i];
                    mutual[i] = mutual[idxMax];
                    mutual[idxMax] = tempMutual;
                }
            }


            Graph gResult = new Graph();

            for(int i = 0; i < tempRecNode.Count; i++)
            {
                gResult.addNode(tempRecNode[i]);
                int numOfConnected = numOfMutual[i];
                for(int j = 0; j < numOfConnected; j++)
                {
                    gResult.addConnectedNode(i, mutual[i][j]);
                }
            }

            showRecommendation(g, gResult);
            
        }


        public void changeGraphNodeVisualizationColor(List<int> node)
        {
            resetGraphNodeVisualizationColor();
            for(int i = 0; i < node.Count; i++)
            {
                string nodeName = globalGraph.getNode(node[i]);

                if (gViewer1.Graph.FindNode(nodeName).Attr.FillColor != Microsoft.Msagl.Drawing.Color.Magenta)
                {
                    gViewer1.Graph.FindNode(nodeName).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Magenta;
                }

                if (i != node.Count-1)
                {
                    string node2 = globalGraph.getNode(node[i + 1]);
                    foreach(var edge in gViewer1.Graph.Edges)
                    {
                        if ((edge.SourceNode.LabelText == nodeName && edge.TargetNode.LabelText == node2) || 
                            (edge.SourceNode.LabelText == node2 && edge.TargetNode.LabelText == nodeName))
                        {
                            edge.Attr.Color = Microsoft.Msagl.Drawing.Color.Blue;
                        }

                        //Console.WriteLine(edge.SourceNode.LabelText + " --- " + edge.TargetNode.LabelText);
                    }
                }
            }

            gViewer1.Refresh();
        }

        public void resetGraphNodeVisualizationColor()
        {
            for(int i = 0; i < globalGraph.getNumOfNode(); i++)
            {
                string node = globalGraph.getNode(i);
                gViewer1.Graph.FindNode(node).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Cyan;
            }

            foreach (var edge in gViewer1.Graph.Edges)
            {
                edge.Attr.Color = Microsoft.Msagl.Drawing.Color.DarkOrange;
            }

            gViewer1.Refresh();
        }


        public void showGraphVisualization(Graph g)
        {
            visGraphLabel.Visible = false;

            //create a viewer object 
            //Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            //create a graph object 
            Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");


            int num = g.getNumOfNode();
            for(int i = 0; i < num; i++)
            {
                int numConnect = g.getNumOfConnectedNode(i);
                for(int j = 0; j < numConnect; j++)
                {
                    
                    int idx = g.getIdxConnectedNode(i, j);
                    if (idx >= i)
                    {
                        var edge = graph.AddEdge(g.getNode(i), g.getNode(idx));
                        edge.Attr.ArrowheadAtTarget = Microsoft.Msagl.Drawing.ArrowStyle.None;
                        edge.Attr.Color = Microsoft.Msagl.Drawing.Color.DarkOrange;

                        graph.FindNode(g.getNode(i)).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Cyan;
                        graph.FindNode(g.getNode(idx)).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Cyan;
                    }
                }
            }


            //viewer.Graph = graph;
            //viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            gViewer1.Graph = graph;
            //graphVisualizationPanel.Controls.Add(viewer);
        }

        public void showRecommendation(Graph g, Graph gRec)
        {
            resetRecommendationPanel();
            textFriendRecommendationLabel.Text = "Friends Recommendation for " + g.getNode(accountNodeDropDown.SelectedIndex) + " : ";

            
            int numOfRec = gRec.getNumOfNode();
            for (int i = 0; i < numOfRec; i++)
            {
                string nodeRec = (i + 1).ToString() + ". ";
                nodeRec += gRec.getNode(i);

                int numOfMutual_i = gRec.getNumOfConnectedNode(i);

                string mutualRec = "    ";
                mutualRec += numOfMutual_i.ToString();
                mutualRec += " Mutual : ";

                for (int j = 0; j < numOfMutual_i; j++)
                {
                    int idx = gRec.getIdxConnectedNode(i, j);
                    mutualRec += g.getNode(idx);

                    if (j != numOfMutual_i - 1)
                        mutualRec += ", ";
                }

                System.Windows.Forms.Panel l = createPanelRec(nodeRec, mutualRec);

                if (i % 2 == 0)
                    l.BackColor = System.Drawing.Color.LightGray;
                else
                    l.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);

                if (numOfRec > 8)
                    l.Size = new System.Drawing.Size(446, l.Height);

                recLayout.Controls.Add(l);
            }
        }

        public void resetExplorer()
        {
            exploreLabel.Text = " Path is not found!";
        }

        public void resetRecommendationPanel()
        {
            textFriendRecommendationLabel.Text = "Friends Recommendation for : ";
            
            recLayout.Controls.Clear();
        }


        public void exploreFriendWith(Graph g, int awal, int akhir)
        {
            List<int> result = new List<int>();
            List<int> kunjung = new List<int>();
            List<int> dibfs = new List<int>();
            for (int i = 0; i < g.getNumOfNode(); i++)
            {
                kunjung.Add(0);
                dibfs.Add(0);
            }

            //int awal = Convert.ToInt32(Console.ReadLine());
            //int akhir = Convert.ToInt32(Console.ReadLine());

            bool found = false;

            if (algorithm == "bfs")
            {
                found = bfsExploreFriend(globalGraph, awal, akhir, ref kunjung, ref dibfs, false, ref result);
            }
            else
            {
                found = dfsExploreFriend(g, awal, akhir, ref kunjung, ref result);
            }

            if (found)
                showExplore(g, result);
            else
            {
                resetExplorer();
                resetGraphNodeVisualizationColor();
            }
        }

        public bool dfsExploreFriend(Graph g, int nodeFrom, int nodeTo, ref List<int> dikunjungi, ref List<int> hasil)
        {
            if (dikunjungi[nodeFrom] == 0)
            {
                dikunjungi[nodeFrom] = 1;
                hasil.Add(nodeFrom);
                changeGraphNodeVisualizationColor(hasil);
            }

            if (nodeFrom == nodeTo)
            {
                return true;
            }
            else
            {
                if (g.getNumOfConnectedNode(nodeFrom) == 0)
                {
                    hasil.RemoveAt(hasil.Count - 1);
                    return dfsExploreFriend(g, hasil[hasil.Count - 1], nodeTo, ref dikunjungi, ref hasil);
                }
                else
                {
                    bool isExist = false;
                    int i;
                    //sorting graph
                    List<string> connectNodes = new List<string>();
                    for (i = 0; i < g.getNumOfConnectedNode(nodeFrom); i++)
                    {
                        connectNodes.Add(g.getNode(g.getIdxConnectedNode(nodeFrom, i)));
                    }
                    connectNodes.Sort();

                    for (i = 0; i < g.getNumOfConnectedNode(nodeFrom); i++)
                    {
                        if (dikunjungi[g.getIdxNode(connectNodes[i])] == 0)
                        {
                            // Console.WriteLine(connectNodes[i]);
                            // Console.WriteLine(g.getIdxNode(connectNodes[i]));
                            isExist = true;
                            break;
                        }
                    }

                    if (!isExist)
                    {
                        hasil.RemoveAt(hasil.Count - 1);
                        if (hasil.Count == 0)
                        {
                            return false;
                        }
                        else
                        {
                            return dfsExploreFriend(g, hasil[hasil.Count - 1], nodeTo, ref dikunjungi, ref hasil);
                        }
                    }
                    else
                    {
                        return dfsExploreFriend(g, g.getIdxNode(connectNodes[i]), nodeTo, ref dikunjungi, ref hasil);
                    }
                }

            }
        }

        public bool bfsExploreFriend(Graph g, int nodeFrom, int nodeTo, ref List<int> dikunjungi, ref List<int> dibfs, bool timeToReset,ref List<int> hasil)
        {
            if (dikunjungi[nodeFrom] == 0)
            {
                dikunjungi[nodeFrom] = 1;
                hasil.Add(nodeFrom);
                changeGraphNodeVisualizationColor(hasil);
            }

            if (timeToReset)
                for(int i = 0; i < g.getNumOfConnectedNode(nodeFrom); i++){
                     dibfs[g.getIdxConnectedNode(nodeFrom,i)] = 0;
                    //Console.WriteLine("----" + g.getNode(g.getIdxConnectedNode(nodeFrom, i)));
                }

            /*
            if (isAllVisited(dikunjungi))
            {
                return false;
            }
            else 
            */
            if (nodeFrom == nodeTo)
            {
                return true;
            }
            else
            {
                if (g.getNumOfConnectedNode(nodeFrom) == 0)
                {
                    hasil.RemoveAt(hasil.Count - 1);
                    // for(int i = 0; i < g.getNumOfConnectedNode(nodeFrom); i++){
                    //     dikunjungi[g.getIdxConnectedNode(nodeFrom,i)]--;
                    // }
                    return bfsExploreFriend(g, hasil[hasil.Count - 1], nodeTo, ref dikunjungi, ref dibfs, true, ref hasil);
                }
                else
                {
                    bool isExist = false;
                    int i;
                    //Sorting graph
                    List<string> connectNodes = new List<string>();
                    for (i = 0; i < g.getNumOfConnectedNode(nodeFrom); i++)
                    {
                        connectNodes.Add(g.getNode(g.getIdxConnectedNode(nodeFrom, i)));
                    }
                    connectNodes.Sort();

                    
                    for (i = 0; i < g.getNumOfConnectedNode(nodeFrom); i++)
                    {
                        if (dikunjungi[g.getIdxNode(connectNodes[i])] == 0 && dibfs[g.getIdxNode(connectNodes[i])] == 0)
                        {
                            for (int j = 0; j < g.getNumOfConnectedNode(nodeFrom); j++)
                            {
                                if (j != i)
                                {
                                    dibfs[g.getIdxNode(connectNodes[j])] = 1;
                                }
                            }

                            // Console.WriteLine(connectNodes[i]);
                            // Console.WriteLine(g.getIdxNode(connectNodes[i]);
                            isExist = true;
                            break;
                        }
                    }

                    if (!isExist)
                    {
                        hasil.RemoveAt(hasil.Count - 1);

                        if (hasil.Count != 0)
                            return bfsExploreFriend(g, hasil[hasil.Count - 1], nodeTo, ref dikunjungi, ref dibfs, true, ref hasil);
                        else
                            return false;
                    }
                    else
                    {
                        return bfsExploreFriend(g, g.getIdxNode(connectNodes[i]), nodeTo, ref dikunjungi, ref dibfs, false, ref hasil);
                    }
                }

            }
        }

        public bool isAllVisited(List<int> vis)
        {
            for (int i = 0; i < vis.Count; i++)
            {
                if (vis[i] == 0)
                    return false;
            }

            return true;
        }

        public void showExplore(Graph g, List<int> path)
        {

            if (path.Count < 2)
            {
                resetExplorer();
                return;
            }
                
            
            int degree = path.Count-2;
            string ex = "";
            for(int i = 0; i < path.Count; i++)
            {
                ex += g.getNode(path[i]);

                if (i != path.Count - 1)
                    ex += " -> ";
            }

            string th = "";
            if (degree % 10 == 1)
                th = "st";
            else if (degree % 10 == 2)
                th = "nd";
            else
                th = "th";

            ex += ", " + degree + th + " degree";

            exploreLabel.Text = ex;
        }

        public void printList(List<int> l)
        {
            for(int i = 0; i < l.Count; i++)
            {
                Console.Out.Write(l[i] + " ");
            }
            Console.Out.WriteLine();
        }
        
        public void setNodeDropDownList(Graph g)
        {
            int numOfNode = g.getNumOfNode();

            string[] acc = new string[numOfNode];

            for (int i = 0; i < numOfNode; i++)
                acc[i] = g.getNode(i);

            resetNodeDropDownList();
            accountNodeDropDown.Items.AddRange(acc);
            exploreNodeDropDown.Items.AddRange(acc);
        }

        public void resetNodeDropDownList()
        {
            accountNodeDropDown.SelectedIndex = -1;
            exploreNodeDropDown.SelectedIndex = -1;
            accountNodeDropDown.Items.Clear();
            exploreNodeDropDown.Items.Clear();
        }

        public void resetGraphVisualization()
        {
            /*
            graphVisualizationPanel.Controls.Clear();
            visGraphLabel.Visible = true;
            graphVisualizationPanel.Controls.Add(visGraphLabel);
            */
            gViewer1.Graph = null;
        }

        public System.Windows.Forms.Panel createPanelRec(string node, string mutual)
        {
            System.Windows.Forms.Panel p = new System.Windows.Forms.Panel();
            System.Windows.Forms.Label nodeLabel = new System.Windows.Forms.Label();
            System.Windows.Forms.Label mutualLabel = new System.Windows.Forms.Label();

            p.Size = new System.Drawing.Size(460, 42);

            nodeLabel.Text = node;
            mutualLabel.Text = mutual;

            nodeLabel.Location = new System.Drawing.Point(3, 0);
            nodeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            nodeLabel.Size = new System.Drawing.Size(nodeLabel.Width, 15);
            
            mutualLabel.Location = new System.Drawing.Point(3, nodeLabel.Height+3);
            mutualLabel.Size = new System.Drawing.Size(p.Width-20, mutualLabel.Height);

            p.Controls.Add(nodeLabel);
            p.Controls.Add(mutualLabel);

            

            return p;
        }

        #endregion funciton



        private void browseButton_Click(object sender, EventArgs e)
        {
            browse();
        }
        private void submitButton_Click(object sender, EventArgs e)
        {
            submit();
        }

        private void dfsRadionButton_CheckedChanged(object sender, EventArgs e)
        {
            if (dfsRadioButton.Checked)
                setAlgorithm("dfs");
        }

        private void bfsRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (bfsRadioButton.Checked)
                setAlgorithm("bfs");
        }

        private void accountNodeDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (accountNodeDropDown.SelectedItem == null)
                return;
            
            accountChoosen_index = accountNodeDropDown.SelectedIndex;
            Console.Out.WriteLine(accountNodeDropDown.Items[accountChoosen_index]);
        }

        private void filenameLabel_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
