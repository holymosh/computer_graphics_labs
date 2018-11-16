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

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += Window_Loaded;

        }
        Model3DGroup modelGroup = new Model3DGroup();
        PerspectiveCamera myPCamera = new PerspectiveCamera();
        DirectionalLight myDirLight = new DirectionalLight();
        GeometryModel3D teapotModel = new GeometryModel3D();
        Transform3DCollection myTransforms = new Transform3DCollection();
        Viewport3D myViewport = new Viewport3D();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            myPCamera.FarPlaneDistance = 20;
            myPCamera.NearPlaneDistance = 1;
            myPCamera.FieldOfView = 45;
            myPCamera.Position = new Point3D(-5, 2, 3);
            myPCamera.LookDirection = new Vector3D(5, -2, -3);
            myPCamera.UpDirection = new Vector3D(0, 1, 0);

            //Add light sources to the scene.
            myDirLight.Color = Colors.White;
            myDirLight.Direction = new Vector3D(-3, -4, -5);
            teapotModel.Geometry = (MeshGeometry3D)Application.Current.Resources["myTeapot"];

            //Define material and apply to the mesh geometries.
            DiffuseMaterial teapotMaterial = new DiffuseMaterial(new SolidColorBrush(Colors.Tomato));

            teapotModel.Material = teapotMaterial;
            RotateTransform3D myRotateTransform3D = new RotateTransform3D();

            Quaternion q1 = new Quaternion(new Vector3D(0, 1, 0), 45);
            QuaternionRotation3D myQuaternionRotation3D1 = new QuaternionRotation3D(q1);
            myRotateTransform3D.Rotation = myQuaternionRotation3D1;
            teapotModel.Transform = myRotateTransform3D;
            QuaternionAnimation fst = new QuaternionAnimation(new Quaternion(new Vector3D(0, 1, 0), -180), new Quaternion(new Vector3D(0, 1, 0), 180), new Duration(TimeSpan.FromSeconds(1)));
            fst.RepeatBehavior = RepeatBehavior.Forever;
            fst.UseShortestPath = false;
            myRotateTransform3D.Rotation.BeginAnimation(QuaternionRotation3D.QuaternionProperty, fst);
            ColorAnimationUsingKeyFrames frameAnimation = new ColorAnimationUsingKeyFrames();
            modelGroup.Children.Add(teapotModel);
            modelGroup.Children.Add(myDirLight);

            ModelVisual3D modelsVisual = new ModelVisual3D();
            modelsVisual.Content = modelGroup;

            //Add the visual and camera to the Viewport3D.
            myViewport.Camera = myPCamera;
            myViewport.Children.Add(modelsVisual);

            this.Content = myViewport;

        }
    }

}

