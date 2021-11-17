using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Arkanoid1986
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Rectangle> _bricks = new List<Rectangle>();       
        DispatcherTimer timer = new DispatcherTimer();
        MediaPlayer mp = new MediaPlayer();
        SoundPlayer hit = new SoundPlayer();
      
        SortedSet<int> fromScoreFile = new SortedSet<int>();
        int score = 0;
        double topCoordBall;
        double leftCoordBall;       
        double leftCoordRocket;
        string path = "score.bin";
        bool loose = false;
        bool win = false;
        int speedTop = 5;
        int speedLeft = 3;
        int level = 1;
        int life = 3;
        int speedRocket = 20;
        HighScore high = new HighScore();
        bool top = true, left = true;
        bool soud = true;
        int highscore = 0;
        bool paus = false;
        bool load = false;

        public MainWindow()
        {
            InitializeComponent();
            
            ReadScoreFromFile();
            FillHighScore();
            topCoordBall = Canvas.GetTop(Ball);
            leftCoordBall = Canvas.GetLeft(Ball);            
            leftCoordRocket = Canvas.GetLeft(rocket);
            mp.Play();
            CheckSoundMain();


            Level.Text = "Level:    " + level.ToString();
            Score.Text += "     " + score.ToString();
            if (fromScoreFile.Count()!=0)
            {
                highscore = fromScoreFile.Max();
            }
           
            Highscore.Text = "High Score:  " + highscore.ToString();

            timer.Interval = TimeSpan.FromMilliseconds(10);
            timer.Tick += timer_Tick;

        }
        void CheckSoundMain()
        {
            try
            {
                
                mp.Open(new Uri(@"Sound\MainTheme.wav", UriKind.Relative));
                mp.Volume = 0.3;
                mp.Balance = 0;
                mp.Position = new TimeSpan(0, 0, 0);
                mp.SpeedRatio = 1;
                mp.Play();
            }
            catch (Exception)
            {

                throw;
            }
        }
        void CheckSoundHit()
        {
            try
            {
                if (File.Exists(@"Sound\hit.wav"))
                {
                    hit.SoundLocation = @"Sound\hit.wav";

                    hit.Play();
                }                

            }
            catch (Exception)
            {

                throw;
            }
            
        }
        public void LoadGame(string name)
        {
            List<Rectangle> temp = new List<Rectangle>();
            try
            {
                using (BinaryReader reader = new BinaryReader(File.Open(name, FileMode.Open)))
                {
                    // пока не достигнут конец файла
                    // считываем каждое значение из файла
                    while (reader.PeekChar() > -1)
                    {
                        Rectangle rectangle = new Rectangle();
                        rectangle.Width = 30;
                        rectangle.Height = 10;
                        rectangle.RadiusX = 5;
                        rectangle.RadiusY = 5;
                        Canvas.SetTop(rectangle, reader.ReadDouble());
                        Canvas.SetLeft(rectangle, reader.ReadDouble());                        
                        var converter = new System.Windows.Media.BrushConverter();
                        var brush = (Brush)converter.ConvertFromString(reader.ReadString());
                        rectangle.Fill = brush;
                        temp.Add(rectangle);
                        score = reader.ReadInt32();
                        life = reader.ReadInt32();
                        level = reader.ReadInt32();
                        speedTop = reader.ReadInt32();
                        speedLeft = reader.ReadInt32();

                    }
                }
                if (life==0)
                {
                    life1.Visibility = Visibility.Hidden;
                    life2.Visibility = Visibility.Hidden;
                    life3.Visibility = Visibility.Hidden;
                }
                if (life==1)
                {
                    life1.Visibility = Visibility.Hidden;
                    life2.Visibility = Visibility.Hidden;
                    life3.Visibility = Visibility.Visible;
                }
                if (life==2)
                {
                    life1.Visibility = Visibility.Hidden;
                    life2.Visibility = Visibility.Visible;
                    life3.Visibility = Visibility.Visible;
                }
                if (life==3)
                {
                    life1.Visibility = Visibility.Visible;
                    life2.Visibility = Visibility.Visible;
                    life3.Visibility = Visibility.Visible;
                }
                Score.Text = "Score    " + score.ToString();
                Level.Text = "Level    " + level.ToString();
                _bricks.Clear();
                canvasGame.Children.RemoveRange(11, 32);
                foreach (var item in temp)
                {
                    _bricks.Add(item);
                    canvasGame.Children.Add(item);
                }
                Canvas.SetTop(Ball, topCoordBall);
                Canvas.SetLeft(Ball, leftCoordBall);
                Canvas.SetLeft(rocket, leftCoordRocket);
                temp.Clear();
            }
            catch (Exception)
            {

                throw;
            }
        }
        void SaveGame(string name)
        {
            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(name, FileMode.Create)))
                {
                    // записываем в файл значение каждого поля структуры
                    foreach (var s in _bricks)
                    {
                        writer.Write(Canvas.GetTop(s));
                        writer.Write(Canvas.GetLeft(s));
                        Brush brush = s.Fill;
                        writer.Write(brush.ToString());
                        writer.Write(score);
                        writer.Write(life);
                        writer.Write(level);
                        writer.Write(speedTop);
                        writer.Write(speedLeft);
                        
                    }
                }
                MessageBox.Show("Game saved");
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        void FillHighScore()
        {
            if (fromScoreFile.Count()!=0)
            {
                IEnumerable<int> vs = fromScoreFile.Reverse();
                int place = 1;
                foreach (int item in vs)
                {
                    high.table.Items.Add(place.ToString() + ". " + item.ToString());
                    place++;
                }
                place = 1;
            }
           
        }
        void ReadScoreFromFile()
        {
            try
            {
                using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.OpenOrCreate)))
                {
                    // пока не достигнут конец файла
                    // считываем каждое значение из файла
                    while (reader.PeekChar() > -1)
                    {
                        fromScoreFile.Add(reader.ReadInt32());

                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
           
        }
        void SaveToFile()
        {
            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
                {
                   
                    foreach (int s in fromScoreFile)
                    {
                        writer.Write(Convert.ToInt32(s));
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (labelStartGame.Visibility == Visibility.Visible&&paus == false && load == false)
            {
                mp.Stop();
                labelStartGame.Visibility = Visibility.Hidden;
                Fill();                
                timer.Start();

            }
            if (labelStartGame.Visibility == Visibility.Visible && paus == false && load == true)
            {
                mp.Stop();
                labelStartGame.Visibility = Visibility.Hidden;               
                timer.Start();
            }
            
            else if (labelStartGame.Visibility == Visibility.Visible && paus == true)
            {
                labelStartGame.Visibility = Visibility.Hidden;
                timer.Start();
            }
            
           
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            MoveBall();
            
        }
        bool CheckCollisionBlocks()
        {
            Rect b = new Rect((double)Ball.GetValue(Canvas.LeftProperty), (double)Ball.GetValue(Canvas.TopProperty), Ball.Width, Ball.Height);
            foreach (var item in _bricks)
            {
                if (item is Rectangle)
                {
                   
                    Rect rect = new Rect((double)item.GetValue(Canvas.LeftProperty), (double)item.GetValue(Canvas.TopProperty), item.Width, item.Height);
                    if (b.IntersectsWith(rect))
                    {
                        _bricks.Remove(item);
                        canvasGame.Children.Remove(item);
                        return true;
                        
                    }
                }
            }
            return false;
        }
        bool CheckStartGame()
        {
            if (labelStartGame.Visibility == Visibility.Visible)
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }
       void Fill()
        {
            int x = 0, y = 0;
            //красные прямоугольники
            for (int i = 0; i <= 5; i++)
            {
                Brush brush = new SolidColorBrush(Colors.Red);
                Rectangle rectangle = new Rectangle();
                rectangle.Fill = brush;
                rectangle.Width = 30;
                rectangle.Height = 10;
                rectangle.RadiusX = 5;
                rectangle.RadiusY = 5;
                Canvas.SetLeft(rectangle, 120+x); Canvas.SetTop(rectangle, 100+y);
                x += 10;
                y += 20;
                _bricks.Add(rectangle);
            }
            x = 0; y = 0;
            //зеленые прямоугольники
            for (int i = 0; i <= 5; i++)
            {
                Brush brush = new SolidColorBrush(Colors.Green);
                Rectangle rectangle = new Rectangle();
                rectangle.Fill = brush;
                rectangle.Width = 30;
                rectangle.Height = 10;
                rectangle.RadiusX = 5;
                rectangle.RadiusY = 5;
                Canvas.SetLeft(rectangle, 230 + x); Canvas.SetTop(rectangle, 100 + y);
                x += 10;
                y += 20;
                _bricks.Add(rectangle);
            }
            x = 0; y = 0;
            //белые прямоугольники
            for (int i = 0; i <= 5; i++)
            {
                Brush brush = new SolidColorBrush(Colors.White);
                Rectangle rectangle = new Rectangle();
                rectangle.Fill = brush;
                rectangle.Width = 30;
                rectangle.Height = 10;
                rectangle.RadiusX = 5;
                rectangle.RadiusY = 5;
                Canvas.SetLeft(rectangle, 330 + x); Canvas.SetTop(rectangle, 100 + y);
                x += 10;
                y += 20;
                _bricks.Add(rectangle);
            }
            x = 0; y = 0;
            //черные прямоугольники
            for (int i = 0; i <= 5; i++)
            {
                Brush brush = new SolidColorBrush(Colors.Black);
                Rectangle rectangle = new Rectangle();
                rectangle.Fill = brush;
                rectangle.Width = 30;
                rectangle.Height = 10;
                rectangle.RadiusX = 5;
                rectangle.RadiusY = 5;
                Canvas.SetLeft(rectangle, 430 + x); Canvas.SetTop(rectangle, 100 + y);
                x += 10;
                y += 20;
                _bricks.Add(rectangle);
            }
       
            foreach (var brick in _bricks)
            {
                canvasGame.Children.Add(brick);
            }
        }
        
        bool CheckColisionBallRocket()
        {
            Rect b = new Rect((double)Ball.GetValue(Canvas.LeftProperty), (double)Ball.GetValue(Canvas.TopProperty), Ball.Width, Ball.Height);
            Rect r = new Rect((double)rocket.GetValue(Canvas.LeftProperty), (double)rocket.GetValue(Canvas.TopProperty), rocket.Width, rocket.Height);
            if (b.IntersectsWith(r))
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
       
        bool CheckLoose()
        {
            if (Canvas.GetTop(Ball)>=600)
            {
                return true;
            }
            return false;
        }
       
        
       
        void MoveBall()
        {
            
            if (top == true)
            {
                Canvas.SetTop(Ball, Canvas.GetTop(Ball) - speedTop);

            }
            if (top == false)
            {
                Canvas.SetTop(Ball, Canvas.GetTop(Ball) + speedTop);
            }
            if (Canvas.GetTop(Ball) <= 70)
            {
                top = false;
            }           
            if (left == true)
            {
                Canvas.SetLeft(Ball, Canvas.GetLeft(Ball) - speedLeft);
            }
            if (left == false)
            {
                Canvas.SetLeft(Ball, Canvas.GetLeft(Ball) + speedLeft);
            }
            if (Canvas.GetLeft(Ball) <= 70)
            {
                left = false;
            }
            if (Canvas.GetLeft(Ball) >= 530)
            {
                left = true;
            }
            if (CheckColisionBallRocket()==true)
            {
                top = true;
                //hit.Play();
            }
            else if(CheckLoose() == true)
            {
                if (life==0)
                {
                    timer.Stop();
                    MessageBox.Show("You loose");
                    _bricks.Clear();
                    life1.Visibility = Visibility.Visible;
                    life2.Visibility = Visibility.Visible;
                    life3.Visibility = Visibility.Visible;
                    canvasGame.Children.RemoveRange(11, 20);
                    Fill();
                    Canvas.SetTop(Ball, topCoordBall);
                    Canvas.SetLeft(Ball, leftCoordBall);
                    Canvas.SetLeft(rocket, leftCoordRocket);

                    fromScoreFile.Add(score);
                    SaveToFile();
                    high.table.Items.Clear();
                    FillHighScore();
                    highscore = fromScoreFile.Max();
                    Highscore.Text = "High Score:  " + highscore.ToString();
                    loose = true;
                    score = 0;
                    Score.Text = "SCORE:     " + score.ToString();
                    speedLeft = 3;
                    speedTop = 5;
                    level = 1;                   
                    Level.Text = "Level:    " + level.ToString();
                }
                else
                {
                    life--;
                    if (life1.Visibility == Visibility.Visible)
                    {
                        life1.Visibility = Visibility.Hidden;
                    }
                    else if (life2.Visibility == Visibility.Visible)
                    {
                        life2.Visibility = Visibility.Hidden;
                    }
                    else if (life3.Visibility == Visibility.Visible)
                    {
                        life3.Visibility = Visibility.Hidden;
                    }
                    
                    
                  
                    timer.Stop();
                    Canvas.SetTop(Ball, topCoordBall);
                    Canvas.SetLeft(Ball, leftCoordBall);
                    Canvas.SetLeft(rocket, leftCoordRocket);
                }
                
            }
            if (CheckCollisionBlocks() == true)
            {
                top = false;
                score += 10;
                Score.Text = "SCORE:     " + score.ToString();
                if (soud == true)
                {
                    CheckSoundHit();
                    
                }               
            }
            if (_bricks.Count()==0)
            {
                timer.Stop();
                MessageBox.Show("You win");
                Fill();
                Canvas.SetTop(Ball, topCoordBall);
                Canvas.SetLeft(Ball, leftCoordBall);
                Canvas.SetLeft(rocket, leftCoordRocket);
                win = true;
                speedLeft += 1;
                speedTop += 1;
                level++;               
                Level.Text = "Level:    " + level.ToString();
            }
        }
        
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationWindow win = new NavigationWindow();
            win.Content = high;
            
            win.ShowsNavigationUI = false;
            win.Height = 681;
            win.Width = 754;
           
            win.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            soud = true;
           
        }

        private void Notsound_Click(object sender, RoutedEventArgs e)
        {
            mp.Stop();
            soud = false;
           
        }
       
        private void pause_Click(object sender, RoutedEventArgs e)
        {
            if (CheckStartGame()==true)
            {
                timer.Stop();
                labelStartGame.Visibility = Visibility.Visible;
                labelStartGame.Content = "Pause. Press Start Game or G";
                paus = true;
            }
            
        }
       
        private void SaveGame_Click(object sender, RoutedEventArgs e)
        {
            SaveLoadGame saveLoadGame = new SaveLoadGame();
            pause_Click(sender, e);
            if (saveLoadGame.ShowDialog()==true)
            {
                if (NewSaveName.SaveName.Length!=0)
                {
                    SaveGame(NewSaveName.SaveName);
                    NewSaveName.SaveName = "";
                }
                if (SaveLoadGame.NameFile.Length!=0)
                {
                    load = true;
                    LoadGame(SaveLoadGame.NameFile);                    
                    SaveLoadGame.NameFile = "";

                }
                
                
            }
            //SaveGame();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
           
            if (e.Key == Key.G && CheckStartGame() == false&& load ==false)
            {
                canvasGame.Focus();
                mp.Stop();
                Button_Click(sender, e);

            }
            if (e.Key == Key.G && CheckStartGame() == false && load == true)
            {
                mp.Stop();
                labelStartGame.Visibility = Visibility.Hidden;
                //timer.Interval = TimeSpan.FromMilliseconds(10);
                //timer.Tick += timer_Tick;
                timer.Start();

                //pause_Click(sender, e);
            }
            if (e.Key == Key.P && CheckStartGame() == true )
            {
                pause_Click(sender, e);
            }
            if (e.Key == Key.Right)
            {
                if (Canvas.GetLeft(rocket) <= 450)
                {
                    if (CheckStartGame() == false)
                    {
                        Canvas.SetLeft(Ball, Canvas.GetLeft(Ball) + speedRocket);
                        Canvas.SetLeft(rocket, Canvas.GetLeft(rocket) + speedRocket);
                    }
                    else
                    {
                        Canvas.SetLeft(rocket, Canvas.GetLeft(rocket) + speedRocket);
                    }

                }

            }

            if (e.Key == Key.Left)
            {
                if (Canvas.GetLeft(rocket) >= 80)
                {
                    if (CheckStartGame() == false)
                    {
                        Canvas.SetLeft(Ball, Canvas.GetLeft(Ball) - speedRocket);
                        Canvas.SetLeft(rocket, Canvas.GetLeft(rocket) - speedRocket);
                    }
                    else
                    {
                        Canvas.SetLeft(rocket, Canvas.GetLeft(rocket) - speedRocket);
                    }

                }

            }
            if (loose == true&&e.Key == Key.G)
            {
                loose = false;
                life = 3;
                timer.Start();
            }
            if (win==true&&e.Key==Key.G)
            {
                timer.Start();
            }
            if ((life == 2||life == 1||life==0)&&e.Key==Key.G)
            {
                timer.Start();
            }
           
            //if (e.Key == Key.P && CheckStartGame() == true)
            //{
            //    timer.Stop();
            //    startGame = false;
            //}
        }
    }
}
