namespace Hilos
{
    public partial class Form1 : Form
    {
        // atributes
        Thread p1,p2, p3,p4;
        byte r, g, b;
        bool b1, b2, b3, b4;
        static AutoResetEvent thread1Signal = new AutoResetEvent(false);
        static AutoResetEvent thread2Signal = new AutoResetEvent(false);
        static AutoResetEvent thread3Signal = new AutoResetEvent(false);
        static AutoResetEvent thread4Signal = new AutoResetEvent(false);

        // constructor parametrizado
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            r = 0;
            g = 0;
            b = 0;
            b1 = false;
            b2 = false;
            b3 = false;
            b4 = false;
        } // end formLoad

        private void hilo1()
        {
            int i = 0;
            thread1Signal.WaitOne();

            while (true)
            {
                //thread1Signal.WaitOne();

                if (i <= 1)
                {
                    Thread.Sleep(1);
                    if (r >= 0 && r <= 255 && b1 == false)
                    {
                        r++;
                        if (r == 255)
                            b1 = true;
                    }

                    if (r >= 0 && r <= 255 && b1 == true)
                    {
                        r--;
                        if (r == 0)
                        {
                            b1 = false;
                            i++;
                            //MessageBox.Show(i + "");
                        }
                    }
                    pictureBox1.BackColor = Color.FromArgb(r, 80, 100);
                }
                else
                {
                    //p2 = new Thread(new ThreadStart(hilo2));

                    //p2.Start();
                    //p1.Abort();
                    thread2Signal.Set();
                    //thread1Signal.WaitOne();
                }
            } // end while
        } // end hilo1

        private void hilo2()
        {
            int i = 0;
            //thread2Signal.WaitOne();

            while (true)
            {
                thread2Signal.WaitOne();
                if (i <= 2)
                {
                    Thread.Sleep(5);
                    if (g >= 0 && g <= 255 && b2 == false)
                    {
                        g++;
                        if (g == 255)
                            b2 = true;
                    }

                    if (g >= 0 && g <= 255 && b2 == true)
                    {
                        g--;
                        if (g == 0)
                        {
                            b2 = false;
                            i++;
                            //MessageBox.Show(i + "");
                        }
                    }
                    pictureBox2.BackColor = Color.FromArgb(100, g, 100);
                }
                else
                {
                    //p3 = new Thread(new ThreadStart(hilo3));
                    //p3.Start();
                    //p2.Abort();
                    
                    thread3Signal.Set();
                    //thread2Signal.WaitOne();
                }
            } // end while
        } // end hilo2

        private void hilo3()
        {
            int i = 0;
            while (true)
            {
                thread3Signal.WaitOne();
                
                if (i <= 2)
                {
                    Thread.Sleep(5);
                    if (b >= 0 && b <= 255 && b3 == false)
                    {
                        b++;
                        if (b == 255)
                            b3 = true;
                    }

                    if (b >= 0 && b <= 255 && b3 == true)
                    {
                        b--;
                        if (b == 0)
                        {
                            b3 = false;
                            i++;
                        }
                    }
                    pictureBox3.BackColor = Color.FromArgb(100, 100, b);
                }
                else
                {
                    //p4 = new Thread(new ThreadStart(hilo4));
                    //p3.Interrupt();
                    //p4.Start();
                    //p3.Abort();
                    
                    thread4Signal.Set();
                    //thread3Signal.WaitOne();
                }
            } // end while
        } // end hilo3

        private void hilo4()
        {
            int i = 0;
            while (true)
            {
                thread4Signal.WaitOne();

                if (i <= 2)
                {
                    Thread.Sleep(5);
                    if (r >= 0 && r <= 255 && b4 == false)
                    {
                        r++;
                        if (r == 255)
                            b4 = true;
                    }

                    if (r >= 0 && r <= 255 && b4 == true)
                    {
                        r--;
                        if (r == 0)
                        {
                            b4 = false;
                            i++;
                        }
                    }
                    pictureBox4.BackColor = Color.FromArgb(r, 80, 100);
                }
                else
                {
                    //p1 = new Thread(new ThreadStart(hilo1));
                    //p4.Interrupt();
                    //p1.Start();
                    //p4.Abort();
                    
                    thread1Signal.Set();
                    //thread4Signal.WaitOne();
                }
            } // end while
        } // end hilo1

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            // va a hacer nuevo thread, y va a empezar un thread hilo1
            //i = 0;
            p1 = new Thread(new ThreadStart(hilo1));
            p2 = new Thread(new ThreadStart(hilo2));
            p3 = new Thread(new ThreadStart(hilo3));
            p4 = new Thread(new ThreadStart(hilo4));


            p1.Start();
            p2.Start();
            p3.Start();
            p4.Start();

            thread1Signal.Set();

            //p1.Join();
            //p2.Join();
            //p3.Join();
            //p4.Join();

            //hilo1 ();
            //hilo2 ();
        } // end btnIniciar_Click
    } // end class
} // end namespace
