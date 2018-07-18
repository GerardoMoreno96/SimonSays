using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace SimonSays
{
    public partial class Form1 : Form
    {
        Queue<int> order = new Queue<int>();
        Queue<int> userOrder = new Queue<int>();
        int tries = 1, level = 1; 

        public Form1()
        {
            InitializeComponent();
            list1.Columns.Add("Queue", 100);
        }

        public async void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            foreach (int number in order)
            {
                switch (number)
                {
                    case 1:
                            btn1.BackColor = Color.Purple;
                            await Task.Delay(1000);
                            btn1.BackColor = Color.Blue;
                        break;
                    case 2:
                            btn2.BackColor = Color.Purple;
                            await Task.Delay(1000);
                            btn2.BackColor = Color.Red;
                        break;
                    case 3:
                            btn3.BackColor = Color.Purple;
                            await Task.Delay(1000);
                            btn3.BackColor = Color.Green;
                        break;
                    case 4:
                        btn4.BackColor = Color.Purple;
                        await Task.Delay(1000);
                        btn4.BackColor = Color.Gold;
                        break;
                }
                await Task.Delay(1000);
            }
            playersTurn(); 
        }
        public async void playersTurn()
        {
            try
            {
                MessageBox.Show("It's your turn to play!");
                int count = 0;
                for (int i = 5; i >= 0; i--)
                {
                    label2.Text = i.ToString();
                    await Task.Delay(1000);
                }
                for (int i = 0; i < tries; i++)
                {
                    if (order.ElementAt(i) != userOrder.ElementAt(i))
                    {
                        count++;
                        MessageBox.Show("Game Over");
                        i = tries +1 ;
                        tries = 1; 
                    }
                }
                if (count == 0)
                {
                    MessageBox.Show("Congratulations!", "Yeah!");
                    tries++;
                    generateRandomNumber();
                }
            }
            catch(Exception e)
            {
                MessageBox.Show("Game Over");
            }
        }
        public void generateRandomNumber()
        {
            list1.Clear();
            list1.Columns.Add("Queue", 100);
            userOrder.Clear();
            label4.Text = tries.ToString();
            Random newNumber = new Random();
            for (int i = 0; i < level; i++)
            {
                order.Enqueue(newNumber.Next(1, 5));
            }
            lightRectangles(order);
        }
        public void lightRectangles(Queue<int> order)
        {
            timer1.Start(); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            order.Clear();
            userOrder.Clear();
            list1.Clear();
            list1.Columns.Add("Queue", 100);
            label2.Text = "";
            label4.Text = tries.ToString();
            generateRandomNumber();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            userOrder.Enqueue(1);
            list1.Items.Add(1.ToString());
            list1.Show();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            userOrder.Enqueue(2);
            list1.Items.Add(2.ToString());
            list1.Show();
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            userOrder.Enqueue(3);
            list1.Items.Add(3.ToString());
            list1.Show();
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            userOrder.Enqueue(4);
            list1.Items.Add(4.ToString());
            list1.Show();
        }
    }
}
