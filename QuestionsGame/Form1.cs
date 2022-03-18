using System.IO;
using System.Collections;
namespace QuestionsGame
{
    public partial class Form1 : Form
    {


        List<QA> quiz = new List<QA>();
        int result = 0, ansQ = 0;
        int qNumber = 1;
        QA temp = null;
        int j = 0;
        private void createDataB() {
            qNumber = 1;
            result =ansQ= 0;
            j = 0;
            temp = null;

            quiz.Clear();
            String pathQ = GetMaterialsDocSource() + @"\Questions.txt";
            StreamReader sr = new StreamReader(pathQ);
            while (sr.Peek() != -1) {
            String line = sr.ReadLine();
            quiz.Add(new QA(line));
            
            }
             pathQ = GetMaterialsDocSource() + @"\Choices.txt";
            sr = new StreamReader(pathQ);
            int i = 0;
            while (sr.Peek() != -1)
            {
               
                String line = sr.ReadLine();
                if (line == "") {
                    i++;
                    continue;
                }
                    
              
                quiz[i].setL.Add(line);
                

            }
            i = 0;
            pathQ = GetMaterialsDocSource() + @"\Answers.txt";
            sr = new StreamReader(pathQ);
            while (sr.Peek() != -1)
            {

                String line = sr.ReadLine();
                quiz[i++].setA=line;


            }



        }

        public Form1()
        {
            InitializeComponent();
        }


        private string GetMaterialsDocSource()
        {
            string str = System.IO.Directory.GetCurrentDirectory();
            int FirstIndex = str.IndexOf("QuestionsGame");
            string beginString = str.Substring(0, FirstIndex + "QuestionsGame".Length);
            string result = beginString + @"\materials";
            for (int i = 0; i < result.Length; i++)
                if (result[i] == '\\' && result[i - 1] != '\\')
                    result = result.Insert(i, "\\");
            return result;
        }
        class QA {
            String question;
            String ans;
           List<String> choices = new List<String>();
           public QA(String q) {
                question = q;
                }
            public String setQ {
                set { question = value; }
                get { return question; }
            }    

            public String setA {
                set { ans = value; }
                get { return ans; }
            }
            public List<String> setL
            {
                set { choices = value; }
                get { return choices; }
            }

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        public void getQuestion() {
            
            


            foreach (RadioButton rd in panel1.Controls)
            {

                rd.ForeColor = Color.Black;
                rd.Refresh();

                }

            if (quiz.Count == 0) {
                DialogResult dr= MessageBox.Show("your result is " + result + @"/" + (qNumber-1) + ", do you want to play again ?", "Game End", MessageBoxButtons.YesNo);
                if(dr == DialogResult.Yes)  createDataB();
                else Application.Exit();

                return; 

            }
                

        Random rnd = new Random();
        j=rnd.Next(0,quiz.Count);
        temp = quiz[j];
            quiz.RemoveAt(j);
        radioButton1.Text = temp.setL[0];
        radioButton2.Text= temp.setL[1];
        radioButton3.Text= temp.setL[2];
        radioButton4.Text= temp.setL[3];
            label1.Text = "Question " + qNumber++;
            label2.Text = temp.setQ;

            ansQ++;
            label3.Text = "Result " + result + "/" + ansQ;
        
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            createDataB();
            getQuestion();
        }
        private  void  checkAns() {
            foreach (RadioButton rd in panel1.Controls) {
                    
                if (rd.Checked) {
                    if (rd.Text == temp.setA) 
                            result++;
           
                }
                if (rd.Text == temp.setA)
                {
                    rd.ForeColor = Color.Green;
                    rd.Refresh();
                }
            
            }
            foreach (Control c in this.Controls) {
            c.Refresh();
            }
            
       

        }
        private void button1_Click(object sender, EventArgs e)
        {
            checkAns();
            Thread.Sleep(3000);
            getQuestion();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}