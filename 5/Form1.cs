using _5.Objects;

namespace _5
{
    public partial class Form1 : Form
    {
        List<BaseObject> objects = new();
        Player player;
        Marker marker;
        public Form1()
        {
            InitializeComponent();

            player = new Player(pbMain.Width / 2, pbMain.Height / 2, 0);
            marker = new Marker(pbMain.Width / 2 + 50, pbMain.Height / 2 + 50, 0);

            objects.Add(marker);

            objects.Add(player);
            objects.Add(new MyRectangle(50, 50, 0));
            objects.Add(new MyRectangle(100, 100, 45));
        }

        private void pbMain_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.Clear(Color.White);

            foreach (var obj in objects)
            {
                g.Transform = obj.GetTransform();
                obj.Render(g);
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            float dx = marker.X - player.X;
            float dy = marker.Y - player.Y;

            float length = MathF.Sqrt(dx*dx + dy*dy);
            dx /= length;
            dy /= length;

            player.X += dx * 2;
            player.Y += dy * 2;
            
            pbMain.Invalidate();
        }

        private void pbMain_MouseClick(object sender, MouseEventArgs e)
        {
            marker.X = e.X;
            marker.Y = e.Y;
        }
    }
}