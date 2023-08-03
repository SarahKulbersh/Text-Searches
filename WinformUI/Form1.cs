using BLL_TanachLibrary;

namespace WinformUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1_Click(this, new EventArgs());
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (ClassBLL.searchDictionary1(textBox1.Text).Count > 0)
                {
                    //search by any string
                    if (checkBox2.Checked || (checkBox2.Checked && checkBox1.Checked))
                    {
                        List<int> keyListLetter = new List<int>();
                        keyListLetter = ClassBLL.highlight(textBox1.Text, richTextBox2.Text);

                        foreach (var i in keyListLetter)
                        {
                            richTextBox2.SelectionStart = i;
                            richTextBox2.SelectionLength = textBox1.Text.Length;
                            richTextBox2.SelectionBackColor = Color.Yellow;
                        }
                    }
                    //search by word
                    else
                    {
                        string all = richTextBox2.Text;
                        string[] words = all.Split(' ');
                        List<int> keyListLetter = new List<int>();
                        keyListLetter = ClassBLL.searchDictionary1(textBox1.Text);

                        foreach (var i in keyListLetter)
                        {
                            richTextBox2.SelectionStart = i;
                            richTextBox2.SelectionLength = textBox1.Text.Length;
                            richTextBox2.SelectionBackColor = Color.Yellow;
                        }

                        List<int> ListLetter = new List<int>();
                        ListLetter = ClassBLL.indexOfLetter(textBox1.Text);

                        foreach (var i in ListLetter)
                        {
                            richTextBox2.SelectionStart = i;
                            richTextBox2.SelectionLength = textBox1.Text.Length;
                            richTextBox2.SelectionBackColor = Color.Yellow;
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        // button that shows all the indexes of the current word
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBox1.Text = ClassBLL.searchDictionary(textBox1.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        int i = 0;
        int index = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkBox2.Checked || (checkBox2.Checked && checkBox1.Checked))
                {
                    if (index < 0)
                        index = 0;
                    // will highlight the next word
                    richTextBox2.Find(textBox1.Text, index, richTextBox2.TextLength, RichTextBoxFinds.None);
                    richTextBox2.SelectionBackColor = Color.LightSkyBlue;
                    richTextBox2.Select(index, index + textBox1.Text.Length);
                    // so it will scroll
                    richTextBox2.ScrollToCaret();
                    index = richTextBox2.Text.IndexOf(textBox1.Text, index + textBox1.Text.Length) - 1;
                }
                else
                {
                   
                    List<int> keyListLetter = new List<int>();
                    keyListLetter = ClassBLL.indexOfLetter(textBox1.Text);

                    if (i == keyListLetter.Count)
                        i = 0;
                    richTextBox2.Select(keyListLetter[i], keyListLetter[i] + textBox1.Text.Length);
                    richTextBox2.ScrollToCaret();
                    i++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader sr = File.OpenText("C://sarah kayla//Programing//C#//project//tanachWithChanges.txt");
            richTextBox2.Text = sr.ReadToEnd();
            sr.Close();
        }

        // previous button
        private void button6_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked || (checkBox2.Checked && checkBox1.Checked))
            {
                index = richTextBox2.Text.IndexOf(textBox1.Text, index - textBox1.Text.Length-1);
                // will highlight the next word
                richTextBox2.Find(textBox1.Text, index, richTextBox2.TextLength, RichTextBoxFinds.None);
                richTextBox2.SelectionBackColor = Color.LightSkyBlue;
                richTextBox2.Select(index, index + textBox1.Text.Length);
                // so it will scroll
                richTextBox2.ScrollToCaret();
            }
            else
            {
                try
                {
                    if (i > 1)
                        i = i - 2;

                    List<int> keyListLetter = new List<int>();
                    keyListLetter = ClassBLL.indexOfLetter(textBox1.Text);

                    if (i == keyListLetter.Count)
                        i = 0;
                    richTextBox2.Select(keyListLetter[i], keyListLetter[i] + textBox1.Text.Length);
                    richTextBox2.ScrollToCaret();
                    i--;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("there are no previous searches");    
                }
            }
        }
    }
}