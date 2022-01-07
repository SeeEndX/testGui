using _5.Objects;

// aimCircle = new AimCircle(pbMain.Width / 2 + rand.Next(10, 100), pbMain.Height / 2 + rand.Next(10, 100), 0);


namespace _5
{
    public partial class Form1 : Form
    {
        List<BaseObject> objects = new();
        Player player;
        Marker marker;
        AimCircle aimCircle;
        AimCircle aimCircle2;
        Killzone killZone = new(0, 0);
        int points = 0;

        public Form1()
        {
            InitializeComponent();
            Random rand = new Random(); 
            lblPoints.Text = "Очки: 0";

            player = new Player(pbMain.Width / 2, pbMain.Height / 2, 0);
            marker = new Marker(pbMain.Width / 2 + 50, pbMain.Height / 2 + 50, 0);
            aimCircle = new AimCircle(rand.Next(0, 350), rand.Next(0, 250), 0);
            aimCircle2 = new AimCircle(rand.Next(0, 350), rand.Next(0, 250), 0);
            killZone = new Killzone(pbMain.Width / 3, pbMain.Height);

            player.OnOverLap += (p, obj) =>
            {
                if (!(obj is Killzone))
                    txtLog.Text = $"[{DateTime.Now:HH:mm:ss:ff}] Игрок пересекся с {obj}\n" + txtLog.Text;
            };

            player.OnMarkerOverlap += (m) =>
            {
                objects.Remove(m);
                marker = null;
            };

            player.OnAimCircleOverlap += (aim) =>
            {
                objects.Remove(aim);
                aimCircle = null;
                objects.Add(new AimCircle(rand.Next(0, 350), rand.Next(0, 250), 0));
                points++;
                
            };

            killZone.OnOverLap = (obj1, obj2) => {
                obj2.ChangeColor(true);
            };

            killZone.NotOnOverLap = (obj1, obj2) => {
                obj2.ChangeColor(false);
            };

            objects.Add(killZone);
            objects.Add(marker);
            objects.Add(player);
            objects.Add(aimCircle);
            objects.Add(aimCircle2);
        }

        private void KzMoving()
        {
                killZone.X = (killZone.X + 2) % (pbMain.Width * 2);
        }

        private void pbMain_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.Clear(Color.White);

            lblPoints.Text = "Очки: " + points;

            KzMoving();
            updatePlayer();

            foreach (var obj in objects.ToList())
            {
                if (obj != player && player.Overlaps(obj, g))
                {
                    player.Overlap(obj);
                    obj.Overlap(player);
                }

                if (!(obj is Killzone))
                {
                    if (killZone.Overlaps(obj, g))
                        killZone.Overlap(obj);
                    else killZone.NotOverLap(obj);
                }
            }

            foreach (var obj in objects)
            {
                g.Transform = obj.GetTransform();
                obj.Render(g);
            }
        }

        private void updatePlayer()
        {
            if (marker != null)
            {
                float dx = marker.X - player.X;
                float dy = marker.Y - player.Y;
                float length = MathF.Sqrt(dx * dx + dy * dy);
                dx /= length;
                dy /= length;

                player.vX += dx * 0.5f;
                player.vY += dy * 0.5f;

                player.Angle = 90 - MathF.Atan2(player.vX, player.vY) * 180 / MathF.PI;
            }

            //торм. момент для постепенного замедления
            player.vX += -player.vX * 0.1f;
            player.vY += -player.vY * 0.1f;

            player.X += player.vX;
            player.Y += player.vY;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // запрашиваем обновление pbMain
            pbMain.Invalidate();
        }

        private void pbMain_MouseClick(object sender, MouseEventArgs e)
        {
            if (marker == null)
            {
                marker = new Marker(0, 0, 0);
                objects.Add(marker);
            }

            marker.X = e.X;
            marker.Y = e.Y;
        }

    }
}