using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace People_May_You_Know
{
    
    public partial class main : Form
    {
        string algorithm = "none";
        int accountChoosen_index = -1;

        public main()
        {
            InitializeComponent();
            //int numOfNode = 8;
            string[] node = { "A", "B", "C", "D", "E", "F", "G", "H" };
            int[] numOfConnectedNode = { 3, 4, 4, 3, 3, 5, 2, 2 };
            int[,] connectedNode = {
                {1, 2, 3, -1, -1},
                {0, 2, 4, 5, -1},
                {0, 1, 5, 6, -1},
                {0, 5, 6, -1, -1},
                {1, 5, 7, -1, -1},
                {1, 2, 3, 4, 7},
                {2, 3, -1, -1, -1},
                {4, 5, -1, -1, -1,} };
            showGraph(node, numOfConnectedNode, connectedNode);
            setNodeDropDownList(node);
        }


        #region function
        private void browse()
        {
            Console.Out.WriteLine("Browse!!");
        }

        private void submit()
        {
            Console.Out.WriteLine("Submit!!");
            if (algorithm == "bfs")
                bfsRecommendationFriends();
            else if (algorithm == "dfs")
                dfsRecommendationFriends();
        }

        private void setAlgorithm(string al)
        {
            algorithm = al;
            Console.Out.WriteLine(algorithm);
        }

        public void dfsRecommendationFriends()
        {

        }

        public void bfsRecommendationFriends()
        {
            recLayout.Controls.Clear();
            
            if (accountChoosen_index < 0)
                return;


            int account = accountChoosen_index;
            List<int> idxSearchs = new List<int>();
            idxSearchs.Add(account);

            int numOfNode = 8;
            string[] node = { "A", "B", "C", "D", "E", "F", "G", "H" };
            int[] numOfConnectedNode = { 3, 4, 4, 3, 3, 5, 2, 2 };
            int[,] connectedNode = { 
                {1, 2, 3, -1, -1}, 
                {0, 2, 4, 5, -1}, 
                {0, 1, 5, 6, -1}, 
                {0, 5, 6, -1, -1},
                {1, 5, 7, -1, -1},
                {1, 2, 3, 4, 7}, 
                {2, 3, -1, -1, -1}, 
                {4, 5, -1, -1, -1,} };

            showExplore(node);

            /*
            for(int i = 0; i < numOfNode; i++)
            {
                int num = numOfConnectedNode[i];
                Console.Out.Write(node[i] + " : ");
                for(int j = 0; j < num; j++)
                {
                    int idx = connectedNode[i, j];
                    Console.Out.Write(node[idx] + " ");
                }
                Console.Out.WriteLine();
            }
            */

            bool[] nodeSign = new bool[numOfNode];
            for (int i = 0; i < numOfNode; i++)
                nodeSign[i] = false;


            List<int> recNode = new List<int>();
            List<int> countRec = new List<int>();
            bool fr = true;
            int k = 0;
            int count = 0;
            while (k < idxSearchs.Count)
            {
                int idxSearch = idxSearchs[k];
                int num = numOfConnectedNode[idxSearch];
                nodeSign[idxSearch] = true;
                count = 0;
                for (int i = 0; i < num; i++)
                {
                    int idxNode = connectedNode[idxSearch, i];
                    if (!nodeSign[idxNode])
                    {
                        if (fr)
                        {
                            nodeSign[idxNode] = true;
                            idxSearchs.Add(idxNode);
                        }
                        else
                        {
                            recNode.Add(idxNode);
                        }
                        count++;
                    }
                }
                k++;
                fr = false;
                countRec.Add(count);
            }

            List<int> tempRecNode = new List<int>();
            List<int> numOfMutual = new List<int>();
            List<List<int>> mutual = new List<List<int>>();
            
            k = 1;
            int n = 0;
            for(int i = 0; i < recNode.Count; i++)
            {
                int temp = recNode[i];
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

                    int tempNode = tempRecNode[i];
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


            showRecommendation(node, tempRecNode, numOfMutual, mutual);
            
        }

        public void showGraph(string[] node, int[] numOfConnectedNode, int[,] connectedNode)
        {
            visGraphLabel.Visible = false;

            //create a viewer object 
            Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            //create a graph object 
            Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");


            int num = node.Length;
            for(int i = 0; i < num; i++)
            {
                int numConnect = numOfConnectedNode[i];
                for(int j = 0; j < numConnect; j++)
                {
                    
                    int idx = connectedNode[i, j];
                    if (idx >= i)
                    {
                        var edge = graph.AddEdge(node[i], node[idx]);
                        edge.Attr.ArrowheadAtTarget = Microsoft.Msagl.Drawing.ArrowStyle.None;
                        edge.Attr.Color = Microsoft.Msagl.Drawing.Color.DarkOrange;

                        graph.FindNode(node[i]).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Cyan;
                        graph.FindNode(node[idx]).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Cyan;
                    }
                }
            }

            
            viewer.Graph = graph;
            viewer.Dock = System.Windows.Forms.DockStyle.Fill;

            graphVisualizationPanel.Controls.Add(viewer);
        }

        public void showRecommendation(string[] node, List<int> recNode, List<int> numOfMutual, List<List<int>> mutual)
        {
            if (accountChoosen_index < 0)
                return;

            textFriendRecommendationLabel.Text = "Friends Recommendation for " + node[accountChoosen_index] + " : ";

            int numOfRec = recNode.Count;
            for (int i = 0; i < numOfRec; i++)
            {
                string nodeRec = (i + 1).ToString() + ". ";
                nodeRec += node[recNode[i]];

                int numOfMutual_i = numOfMutual[i];

                string mutualRec = "    ";
                mutualRec += numOfMutual_i.ToString();
                mutualRec += " Mutual : ";

                for (int j = 0; j < numOfMutual_i; j++)
                {
                    int idx = mutual[i][j];
                    mutualRec += node[idx];

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

        public void showExplore(string[] node)
        {
            int[] explore = { 1, 4, 0, 5, 7 };

            if (explore.Length < 2)
                return;
            
            int degree = explore[0];
            string ex = "";
            for(int i = 1; i < explore.Length; i++)
            {
                ex += node[explore[i]];

                if (i != explore.Length - 1)
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
        
        public void setNodeDropDownList(string[] node)
        {
            int numOfNode = node.Length;
            accountNodeDropDown.Items.Clear();
            exploreNodeDropDown.Items.Clear();
            accountNodeDropDown.Items.AddRange(node);
            exploreNodeDropDown.Items.AddRange(node);
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


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void graphPictureBox_Click(object sender, EventArgs e)
        {

        }

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
    }

    public class Graph
    {
        protected int numOfNode;
        protected List<string> node;
        protected List<int> numOfConnectedNode; // 
        protected List<List<int>> connectedNode; // (numOfNode*numOfNode)
        
        public Graph(){
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
            
        public void addNode(string node){
            this.node.Add(node);
            this.numOfNode++;
            connectedNode.Add(new List<int>());
            this.numOfConnectedNode.Add(0);
        }

        public string getNode(int idxNode){
            return this.node[idxNode];
        }

        public void addConnectedNode(int idxNode, int idxConnectNode){
            this.numOfConnectedNode[idxNode]++;
            this.connectedNode[idxNode].Add(idxConnectNode);
        }

        public int getNumOfNode(){
            return this.numOfNode;
        }

        public int getNumOfConnectedNode(int idxNode){
            return this.numOfConnectedNode[idxNode];
        }

        public int getIdxConnectedNode(int idxNode, int idxConnect){
            return connectedNode[idxNode][idxConnect];
        }

        public string getConnectedNode(int idxNode, int idxConnect){
            return node[this.getIdxConnectedNode(idxNode,idxConnect)];
        }

        public void print(){
            for(int i = 0; i < this.numOfNode; i++){
                Console.Write(i + ": ");
                for(int j = 0; j < this.numOfConnectedNode[i]; j++){
                    Console.Write(connectedNode[i][j] + " ");
                }
                Console.WriteLine();
            }
        }

        public int getIdxNode(string node){
            for(int i = 0; i < this.numOfNode; i++){
                if(this.node[i] == node){
                    return i;
                }
            }
            return -1;
        }
    }
}
