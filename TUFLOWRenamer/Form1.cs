using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security;
using System.IO;

namespace TUFLOWRenamer
{
    public partial class Form1 : Form
    {
        string path = "";
        bool delete;
        List<string> oldReplacedFiles = new List<string>();
        List<string> replacedFiles = new List<string>();
        List<string> filestodelete = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void btBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "TUFLOW Control files (*.tcf)|*.tcf";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //Console.WriteLine("This was successful :" + ofd.FileName);
                    tbPath.Text = ofd.FileName;

                    //Data validation

                    if (path == "")
                    {
                        path = tbPath.Text;
                    }
                    else if (path == tbPath.Text)
                        return;

                    path = tbPath.Text;

                    if (!(File.Exists(tbPath.Text)))
                    {
                        tbPath.BackColor = Color.Red;
                        return;
                    }
                    else
                    {
                        tbPath.BackColor = Color.White;
                    }

                    UpdateTree();
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }

        private void UpdateTree()
        {
            //Tree Creation Logic

            string folderpath = path;
            folderpath = folderpath.Replace(Path.GetFileName(path).ToString(), "");

            tvFolders.BeginUpdate();
            tvFolders.Nodes.Clear();
            tvFolders.EndUpdate();

            string[] folders = Directory.GetDirectories(folderpath);

            Console.WriteLine("Folders Found:");

            tvFolders.BeginUpdate();


            foreach (string s in folders)
            {
                
                tvFolders.Nodes.Add(Path.GetFileName(s).ToString());

                Console.WriteLine("\t" + Path.GetFileName(s).ToString());
            }

            UpdateNodes(tvFolders.Nodes);
            UpdateFileNodes(tvFolders.Nodes);

            tvFolders.EndUpdate();
            tvFolders.ExpandAll();

            Console.WriteLine("Tree Updated");
        }

        private string GetParentNode(TreeNode n)
        {
            if (n.Parent == null)
                return n.Text;
            else
                return  GetParentNode(n.Parent) + @"\" + n.Text;
        }

        private void UpdateFileNodes(TreeNodeCollection c)
        {
            foreach(TreeNode n in c)
            {
                string folderpath = Path.Combine(path.Replace(Path.GetFileName(path).ToString(), ""), GetParentNode(n));

                if (!File.Exists(folderpath))
                {
                    string[] files = Directory.GetFiles(folderpath);

                    foreach (string s in files)
                    {
                        TreeNode nn = new TreeNode();
                        nn.Text = Path.GetFileName(s).ToString();
                        nn.ForeColor = Color.Blue;
                        n.Nodes.Add(nn);
                    }
                }
                UpdateFileNodes(n.Nodes);
            }
        }

        private void UpdateNodes(TreeNodeCollection c)
        {
            foreach (TreeNode n in c)
            {
                string folderpath = Path.Combine(path.Replace(Path.GetFileName(path).ToString(), ""), GetParentNode(n));

                string[] folders = Directory.GetDirectories(folderpath);

                if (!(folders.Length == 0))
                {
                    foreach (string s in folders)
                    {
                        n.Nodes.Add(Path.GetFileName(s).ToString());
                    }

                    UpdateNodes(n.Nodes);

                    Console.WriteLine("Sub-Tree Updated");
                }
            }

            

        }

        private void GetFileList(ref List<string> sl, TreeNodeCollection c)
        {
            foreach(TreeNode n in c)
            {
                string filepath = Path.Combine(path.Replace(Path.GetFileName(path).ToString(), ""), GetParentNode(n));

                if (File.Exists(filepath))
                {
                    sl.Add(filepath);
                }
                else
                {
                    GetFileList(ref sl, n.Nodes);
                }
            }
        }

        private void ChangeNodeColors(TreeNodeCollection c)
        {
            foreach (TreeNode n in c)
            {
                string filepath = Path.Combine(path.Replace(Path.GetFileName(path).ToString(), ""), GetParentNode(n));

                if (File.Exists(filepath))
                {
                    foreach(string s in oldReplacedFiles)
                        if(filepath == s)
                        {
                            n.Text = Path.GetFileName(replacedFiles[oldReplacedFiles.FindIndex(a => a.Contains(s))]).ToString();
                            n.ForeColor = Color.Green;
                        }
                    foreach(string s in replacedFiles)
                        if(s == filepath)
                        {
                            delete = true;
                            filestodelete.Add(filepath);
                            n.ForeColor = Color.Red;
                        }
                }
                else
                {
                    ChangeNodeColors(n.Nodes);
                }
            }
        }

        private void tbPath_Leave(object sender, EventArgs e)
        {
            UpdateTree();
        }

        private void tbPath_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                UpdateTree();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            UpdateTree();

            string find = tbFind.Text;
            string replace = tbReplace.Text;

            if (find.Length == 0 || replace.Length == 0)
                return;

            List<string> files = new List<string>();
            oldReplacedFiles.Clear();
            replacedFiles.Clear();
            filestodelete.Clear();
            delete = false;


            GetFileList(ref files, tvFolders.Nodes);

            foreach (string s in files)
            {
                if (Path.GetFileName(s).Contains(find))
                {
                    oldReplacedFiles.Add(s);
                    string file = Path.Combine(Path.GetDirectoryName(s),Path.GetFileName(s).ToString().Replace(find,replace));
                    replacedFiles.Add(file);
                }
            }

            tvFolders.BeginUpdate();
            ChangeNodeColors(tvFolders.Nodes);
            tvFolders.EndUpdate();

            Console.WriteLine("Node Colors Updated.");
        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            if (delete)
            {
                var confirmResult = MessageBox.Show("There are files that have matching names, would you like to delete them?",
                                         "Confirm Delete", MessageBoxButtons.YesNo);

                if (confirmResult == DialogResult.No)
                    return;
                try 
                {
                    foreach (string s in filestodelete)
                        File.Delete(s);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                }

            try
            {
                for (int x = 0; x < replacedFiles.Count; x++)
                {
                    File.Move(oldReplacedFiles[x], replacedFiles[x]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            MessageBox.Show("Files Renamed Successfully!");

            replacedFiles.Clear();
            oldReplacedFiles.Clear();
            filestodelete.Clear();

            UpdateTree();
        }
    }
}
