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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp3
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

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            Viewport3D myViewport3D = new Viewport3D();

            Model3DGroup myModel3DGroup = new Model3DGroup();

            GeometryModel3D myGeometryModel = new GeometryModel3D();

            ModelVisual3D myModelVisual3D = new ModelVisual3D();

            OrthographicCamera myOCamera = new OrthographicCamera(new Point3D(0, 0, 6), new Vector3D(0, 0, -1), new Vector3D(0, 1, 0), 8);

            myViewport3D.Camera = myOCamera;

            AmbientLight myDirectionalLight = new AmbientLight();

            myDirectionalLight.Color = Colors.White;

            //myDirectionalLight.Direction = new Vector3D(0, 0, -3);

            myModel3DGroup.Children.Add(myDirectionalLight);

            MeshGeometry3D myMeshGeometry3D = new MeshGeometry3D();


            Vector3DCollection myNormalCollection = new Vector3DCollection();

            myNormalCollection.Add(new Vector3D(0, 0, 1));

            myNormalCollection.Add(new Vector3D(0, 0, 1));

            myNormalCollection.Add(new Vector3D(0, 0, 1));

            myMeshGeometry3D.Normals = myNormalCollection;


            Point3DCollection myPositionCollection = new Point3DCollection();

            
            myPositionCollection.Add(new Point3D(0.0, 1.0, 1.0));

            myPositionCollection.Add(new Point3D(1.0, 1.0, 1.0));

            myPositionCollection.Add(new Point3D(1.0, 1.0, 0.0));

            myPositionCollection.Add(new Point3D(1.0, 1.0, 0.0));

            myPositionCollection.Add(new Point3D(0.0, 1.0, 0.0));

            myPositionCollection.Add(new Point3D(0.0, 1.0, 1.0));

            //2

            myPositionCollection.Add(new Point3D(0.0, 0.0, 1.0));

            myPositionCollection.Add(new Point3D(0.0, 0.0, 0.0));

            myPositionCollection.Add(new Point3D(1.0, 0.0, 0.0));

            myPositionCollection.Add(new Point3D(1.0, 0.0, 0.0));

            myPositionCollection.Add(new Point3D(1.0, 0.0, 1.0));

            myPositionCollection.Add(new Point3D(0.0, 0.0, 1.0));

            //3
            myPositionCollection.Add(new Point3D(0.0, 1.0, 1.0));

            myPositionCollection.Add(new Point3D(0.0, 0.0, 1.0));   //4

            myPositionCollection.Add(new Point3D(1.0, 0.0, 1.0));

            myPositionCollection.Add(new Point3D(1.0, 0.0, 1.0));

            myPositionCollection.Add(new Point3D(1.0, 1.0, 1.0));

            myPositionCollection.Add(new Point3D(0.0, 1.0, 1.0));

            //4
            myPositionCollection.Add(new Point3D(1.0, 1.0, 1.0));

            myPositionCollection.Add(new Point3D(1.0, 0.0, 1.0));

            myPositionCollection.Add(new Point3D(1.0, 0.0, 0.0));

            myPositionCollection.Add(new Point3D(1.0, 0.0, 0.0));

            myPositionCollection.Add(new Point3D(1.0, 1.0, 0.0));

            myPositionCollection.Add(new Point3D(1.0, 1.0, 1.0));

            //5
            myPositionCollection.Add(new Point3D(1.0, 1.0, 0.0));

            myPositionCollection.Add(new Point3D(1.0, 0.0, 0.0));

            myPositionCollection.Add(new Point3D(0.0, 0.0, 0.0));

            myPositionCollection.Add(new Point3D(0.0, 0.0, 0.0));

            myPositionCollection.Add(new Point3D(0.0, 1.0, 0.0));

            myPositionCollection.Add(new Point3D(1.0, 1.0, 0.0));


            //6
            myPositionCollection.Add(new Point3D(0.0, 1.0, 1.0));

            myPositionCollection.Add(new Point3D(0.0, 1.0, 0.0));

            myPositionCollection.Add(new Point3D(0.0, 0.0, 0.0));

            myPositionCollection.Add(new Point3D(0.0, 0.0, 0.0));

            myPositionCollection.Add(new Point3D(0.0, 0.0, 1.0));

            myPositionCollection.Add(new Point3D(0.0, 1.0, 1.0));



            myMeshGeometry3D.Positions = myPositionCollection;


            Int32Collection myTriangleIndicesCollection = new Int32Collection();


            for (int i = 0; i < myTriangleIndicesCollection.Count; i++)
                myTriangleIndicesCollection.Add(i);

            myMeshGeometry3D.TextureCoordinates.Add(new Point(1, 0));
            myMeshGeometry3D.TextureCoordinates.Add(new Point(1, 1));
            myMeshGeometry3D.TextureCoordinates.Add(new Point(0, 1));
            myMeshGeometry3D.TextureCoordinates.Add(new Point(0, 1));
            myMeshGeometry3D.TextureCoordinates.Add(new Point(0, 0));
            myMeshGeometry3D.TextureCoordinates.Add(new Point(1, 0));

            myMeshGeometry3D.TextureCoordinates.Add(new Point(1, 0));
            myMeshGeometry3D.TextureCoordinates.Add(new Point(1, 1));
            myMeshGeometry3D.TextureCoordinates.Add(new Point(0, 1));
            myMeshGeometry3D.TextureCoordinates.Add(new Point(0, 1));
            myMeshGeometry3D.TextureCoordinates.Add(new Point(0, 0));
            myMeshGeometry3D.TextureCoordinates.Add(new Point(1, 0));

            myMeshGeometry3D.TextureCoordinates.Add(new Point(1, 0));
            myMeshGeometry3D.TextureCoordinates.Add(new Point(1, 1));
            myMeshGeometry3D.TextureCoordinates.Add(new Point(0, 1));
            myMeshGeometry3D.TextureCoordinates.Add(new Point(0, 1));
            myMeshGeometry3D.TextureCoordinates.Add(new Point(0, 0));
            myMeshGeometry3D.TextureCoordinates.Add(new Point(1, 0));

            myMeshGeometry3D.TextureCoordinates.Add(new Point(1, 0));
            myMeshGeometry3D.TextureCoordinates.Add(new Point(1, 1));
            myMeshGeometry3D.TextureCoordinates.Add(new Point(0, 1));
            myMeshGeometry3D.TextureCoordinates.Add(new Point(0, 1));
            myMeshGeometry3D.TextureCoordinates.Add(new Point(0, 0));
            myMeshGeometry3D.TextureCoordinates.Add(new Point(1, 0));

            myMeshGeometry3D.TextureCoordinates.Add(new Point(1, 0));
            myMeshGeometry3D.TextureCoordinates.Add(new Point(1, 1));
            myMeshGeometry3D.TextureCoordinates.Add(new Point(0, 1));
            myMeshGeometry3D.TextureCoordinates.Add(new Point(0, 1));
            myMeshGeometry3D.TextureCoordinates.Add(new Point(0, 0));
            myMeshGeometry3D.TextureCoordinates.Add(new Point(1, 0));

            myMeshGeometry3D.TextureCoordinates.Add(new Point(1, 0));
            myMeshGeometry3D.TextureCoordinates.Add(new Point(1, 1));
            myMeshGeometry3D.TextureCoordinates.Add(new Point(0, 1));
            myMeshGeometry3D.TextureCoordinates.Add(new Point(0, 1));
            myMeshGeometry3D.TextureCoordinates.Add(new Point(0, 0));
            myMeshGeometry3D.TextureCoordinates.Add(new Point(1, 0));


            myMeshGeometry3D.TriangleIndices = myTriangleIndicesCollection;


            myGeometryModel.Geometry = myMeshGeometry3D;


            BitmapImage bm1 = new BitmapImage();
            bm1.BeginInit();
            bm1.UriSource = new Uri("dog.jpg", UriKind.RelativeOrAbsolute);
            bm1.EndInit();

            ImageBrush imgBrush = new ImageBrush(bm1);
            var brush = new SolidColorBrush(Color.FromRgb(100, 200, 100));
            DiffuseMaterial myMaterial = new DiffuseMaterial(imgBrush);

            myGeometryModel.Material = myMaterial;


            RotateTransform3D myRotateTransform3D = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(1, 1, 0), 0), new Point3D(0, 0, 0));

            Transform3DGroup trGrp = new Transform3DGroup();

            RotateTransform3D nrt1 = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(0, 0, 1), 45));

            RotateTransform3D nrt2 = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(0, 1, 0), 45));

            TranslateTransform3D trs = new TranslateTransform3D(new Vector3D(0, 0, 0));

            trGrp.Children.Clear();

            trGrp.Children.Add(nrt1);

            trGrp.Children.Add(nrt2);

            trGrp.Children.Add(myRotateTransform3D);

            trGrp.Children.Add(trs);

            myGeometryModel.Transform = trGrp;

            DoubleAnimation rotAnimaion = new DoubleAnimation(0, 360, new Duration(TimeSpan.FromSeconds(2)));

            rotAnimaion.RepeatBehavior = RepeatBehavior.Forever;

            myRotateTransform3D.Rotation.BeginAnimation(AxisAngleRotation3D.AngleProperty, rotAnimaion);

            myModel3DGroup.Children.Add(myGeometryModel);

            myModelVisual3D.Content = myModel3DGroup;


            myViewport3D.Children.Add(myModelVisual3D);
            this.Content = myViewport3D;
        }
    }
}
