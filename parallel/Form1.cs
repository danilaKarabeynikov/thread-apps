using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadApp
{
    public partial class Form1 : Form
    {
        Butt cl1 = new Butt();
        SortMessage sm1 = new SortMessage();
        SortMessage sm2 = new SortMessage();
        SortMessage sm3 = new SortMessage();
        TextBox text1, text2, text3;
        Button btn1;
        public Form1()
        {
            InitializeComponent();
            cl1.CreateMyButt(btn1, this, "RUN", 50, 200, 150, 50, Click);
            sm1.CreateSortMessageBox(ref text1, this, "First Sort", 50, 50, 150, 100);
            sm2.CreateSortMessageBox(ref text2, this, "Second Sort", 50, 100, 150, 100);
            sm3.CreateSortMessageBox(ref text3, this, "Third Sort", 50, 150, 150, 100);
        }
        public void Click(object sneder,  EventArgs e)
        {
            fillArr();
            Thread firstSortThread = new Thread(new ParameterizedThreadStart(firstSort));
            Thread secondSortThread = new Thread(new ParameterizedThreadStart(secondSort));
            Thread thirdSortThread = new Thread(new ParameterizedThreadStart(thirdSort));
            firstSortThread.Start(text1);
            secondSortThread.Start(text2);
            thirdSortThread.Start(text3);
        }

        static int[] firstArr;
        static int[] secondArr;
        static int[] thirdArr;
        static int N = 50000;
        static void fillArr()
        {
            Random rnd = new Random();
            firstArr = new int[N];
            secondArr = new int[N];
            thirdArr = new int[N];
            for (int i = 0; i < N; ++i)
            {
                int r = rnd.Next();
                firstArr[i] = r;
                secondArr[i] = r;
                thirdArr[i] = r;
            }
        }

        public static void firstSort(object msg)
        {
            Thread t = Thread.CurrentThread;
            TextBox sm = (TextBox)msg;
            sm.Text = "running...";
            int tmp;
            for (int i = 0; i < N - 1; ++i) // i - номер прохода
            {
                for (int j = 0; j < N - 1; ++j) // внутренний цикл прохода
                {
                    if (firstArr[j + 1] < firstArr[j])
                    {
                        tmp = firstArr[j + 1];
                        firstArr[j + 1] = firstArr[j];
                        firstArr[j] = tmp;
                    }
                }
            }
            sm.Text = "SORTED!";
            t.Abort();
        }

        public static void secondSort(object msg)
        {
           
            Thread t = Thread.CurrentThread;
            TextBox sm = (TextBox)msg;
            sm.Text = "running...";
            int tmp;
            for (int i = 0; i < N; ++i) // i - номер текущего шага
            {
                int pos = i;
                tmp = secondArr[i];
                for (int j = i + 1; j < N; ++j) // цикл выбора наименьшего элемента
                {
                    if (secondArr[j] < tmp)
                    {
                        pos = j;
                        tmp = secondArr[j];
                    }
                }
                secondArr[pos] = secondArr[i];
                secondArr[i] = tmp; // меняем местами наименьший с a[i]
            }
            sm.Text = "SORTED!";
            t.Abort();
            
        }

        public static void thirdSort(object msg)
        {
            Thread t = Thread.CurrentThread;
            TextBox sm = (TextBox)msg;
            sm.Text = "running...";

            int tmp;
            for (int i = 0; i < N - 1; ++i) // i - номер прохода
            {
                for (int j = 0; j < N - 1; ++j) // внутренний цикл прохода
                {
                    if (firstArr[j + 1] < firstArr[j])
                    {
                        tmp = firstArr[j + 1];
                        firstArr[j + 1] = firstArr[j];
                        firstArr[j] = tmp;
                    }
                }
            }

            sm.Text = "SORTED!";
            t.Abort();
        }
    }
}
