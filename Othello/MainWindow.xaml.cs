using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
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

namespace Othello
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private Othellier game;

        public MainWindow()
        {
            InitializeComponent();
            game = new Othellier(this);
            update();
            
        }

        private void initGrid()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Border b = new Border();
                    b.BorderBrush = Brushes.Magenta;
                    b.BorderThickness = new Thickness(2);
                    b.Margin = new Thickness(0);
                    GameGrid.Children.Add(b);
                    Grid.SetRow(b, i);
                    Grid.SetColumn(b, j);
                }
            }
        }

        private void updateBoard()
        {
            foreach (Case c in game.Board)
            {
                if(c.Owner != null)
                {
                    Debug.WriteLine("Position: "+c.Column+c.Row);
                    
                    int columnAsInt = c.Column - 97;

                    Debug.WriteLine("Col as int: " + columnAsInt);
                    Image img = new Image();
                    if (c.Owner.PlayerColor == Othellier.PLAYER_BLACK)
                    {
                        img.Source = new BitmapImage(new Uri("pack://application:,,,/Othello;component/rainbowdash_pawn.png"));
                    }
                    else
                    {
                        img.Source = new BitmapImage(new Uri("pack://application:,,,/Othello;component/pinkiepie_pawn.png"));
                    }
                    GameGrid.Children.Add(img);
                    Grid.SetRow(img, c.Row-1);
                    Grid.SetColumn(img, columnAsInt);
                }
            }
        }

        public void update()
        {
            GameGrid.Children.Clear();
            initGrid();
            updateBoard();
        }

        private void OnClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
           
            var point = Mouse.GetPosition(GameGrid);

            int row = 0;
            int col = 0;
            double accumulatedHeight = 0.0;
            double accumulatedWidth = 0.0;

            // calc row mouse was over
            foreach (var rowDefinition in GameGrid.RowDefinitions)
            {
                accumulatedHeight += rowDefinition.ActualHeight;
                if (accumulatedHeight >= point.Y)
                    break;
                row++;
            }

            // calc col mouse was over
            foreach (var columnDefinition in GameGrid.ColumnDefinitions)
            {
                accumulatedWidth += columnDefinition.ActualWidth;
                if (accumulatedWidth >= point.X)
                    break;
                col++;
            }

            row++;
            char colChar = (char)(col + 97);
            game.playMove(colChar, row);
        }
    }
}
