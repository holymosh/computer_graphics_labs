using System;
using System.Collections.Generic;
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

namespace Bezie
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_OnLoaded_Circle(object sender, RoutedEventArgs e)
        {
            EllipseGeometry ellipseGeometry = new EllipseGeometry(new Point(150,150),100,100);
            var path = new Path();
            path.Stroke = Brushes.Green;
            path.Data = ellipseGeometry.GetFlattenedPathGeometry();
            this.gr.Children.Add(path);
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            EllipseGeometry el = new EllipseGeometry(new Point(150, 150), 100, 50);
            EllipseGeometry el1 = new EllipseGeometry(new Point(200, 150), 100, 100);
            Geometry gl = el;
            Geometry gl1 = el1;
            CombinedGeometry CombineG = new CombinedGeometry(GeometryCombineMode.Xor,gl,gl1);
            var path = new Path();
            path.Fill = Brushes.Red;
            path.Stroke = Brushes.Green;
            path.Data = CombineG.GetFlattenedPathGeometry();
            this.gr.Children.Add(path);
        }
        private void MainWindow_OnLoaded_Beze(object sender, RoutedEventArgs e)
        {
            PolyBezierSegment polyBezierSegment =
                new PolyBezierSegment(new List<Point>() {
                        new Point(0, 100), new Point(50, 200), new Point(100, 100),
                        new Point(150,0),new Point(200,50),new Point(250,100)
                        //new Point(100, 50),new Point(175, 0), new Point(200, 100)
                    },
                    true);
            PathFigure fig = new PathFigure(new Point(0, 100),new List<PathSegment>(){polyBezierSegment},false );
            PathGeometry geometry = new PathGeometry(new []{fig});
            Path path = new Path();
            path.Stroke = Brushes.Green;
            path.Data = geometry;
            gr.Children.Add(path);
        }
    }
}
