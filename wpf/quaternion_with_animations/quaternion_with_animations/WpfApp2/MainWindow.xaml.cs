using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Media3D;

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
            var brush = new SolidColorBrush(Colors.Tomato);
            DiffuseMaterial diffuseMaterial = new DiffuseMaterial(brush);
            var specularMaterial = new SpecularMaterial();
            var materials = new MaterialGroup();
            materials.Children.Add(specularMaterial);
            materials.Children.Add(diffuseMaterial);

            teapotModel.Material = materials;
            RotateTransform3D myRotateTransform3D = new RotateTransform3D();

            Quaternion q1 = new Quaternion(new Vector3D(0, 1, 0), 45);
            QuaternionRotation3D myQuaternionRotation3D1 = new QuaternionRotation3D(q1);
            myRotateTransform3D.Rotation = myQuaternionRotation3D1;
            teapotModel.Transform = myRotateTransform3D;
            QuaternionAnimation fst = new QuaternionAnimation(
                new Quaternion(new Vector3D(0, 1, 0), -180), 
                new Quaternion(new Vector3D(0, 1, 0), 180), 
                new Duration(TimeSpan.FromSeconds(4)));
            fst.RepeatBehavior = RepeatBehavior.Forever;
            fst.UseShortestPath = false;
            myRotateTransform3D.Rotation.BeginAnimation(QuaternionRotation3D.QuaternionProperty, fst);
            modelGroup.Children.Add(teapotModel);
            modelGroup.Children.Add(myDirLight);

            ModelVisual3D modelsVisual = new ModelVisual3D();
            modelsVisual.Content = modelGroup;

            // Animate brush with color 
            var animation = new ColorAnimationUsingKeyFrames();
            animation.KeyFrames.Add(new DiscreteColorKeyFrame(Colors.Blue, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(2))));
            animation.KeyFrames.Add(new DiscreteColorKeyFrame(Colors.Blue, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(5))));
            animation.KeyFrames.Add(new LinearColorKeyFrame(Colors.Red, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(7))));
            brush.BeginAnimation(SolidColorBrush.ColorProperty, animation);

            //Add the visual and camera to the Viewport3D.
            myViewport.Camera = myPCamera;
            myViewport.Children.Add(modelsVisual);
            myViewport.Children.Add(new ModelVisual3D() { Content = new DirectionalLight() });

            this.Content = myViewport;

        }
    }

}
