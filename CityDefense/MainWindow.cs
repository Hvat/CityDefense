using System;
using System.Windows.Forms;
using CityDefense.Game;
using CityDefense.Engine;

/**
namespace CityDefense
@brief Пространство имен CityDefense
*/
namespace CityDefense
{
    /**
@brief Класс для работы с главным окном программы. 
*/
    public partial class MainWindow : Form
    {
        private readonly Scene scene;

    /**
@brief Инициализация компонентов главного окна. 
*/
        public MainWindow()
        {
            InitializeComponent();

            Render.SetResolution(renderBox.Width, renderBox.Height); 
            Render.SetScene(scene = new Scene());                    

            Time.SetInterval(Frame.Interval);                        
            Frame.Tick += new System.EventHandler(Time.Frame_Tick);
        }

        private void Frame_Tick(object sender, EventArgs e)
        {
            renderBox.BackgroundImage = Render.DrawFrame();
            Frame.Enabled = !GameOver.isGameOver;
        }
 
        private void renderBox_MouseDown(object sender, MouseEventArgs e)
        {
            scene.BreakBomb(e.X, e.Y);
        }
    }
}
