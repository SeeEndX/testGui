using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;

namespace _5.Objects
{
    internal class AimCircle : BaseObject
    {
        public AimCircle(float x, float y, float angle) : base(x, y, angle)
        {
        }

        public override void Render(Graphics g)
        {
            if (!IsColorChanged)
            {
                g.FillEllipse(
                new SolidBrush(Color.Green),
                -15, -15,
                30, 30
                );
                g.DrawEllipse(
                    new Pen(Color.Black, 2),
                    -15, -15,
                    30, 30
                    );
            }
            else
            {
                g.FillEllipse(
                new SolidBrush(Color.Gray),
                -15, -15,
                30, 30
                );
                g.DrawEllipse(
                    new Pen(Color.White, 2),
                    -15, -15,
                    30, 30
                    );
            }
        }

        public override GraphicsPath GetGraphicsPath()
        {
            var path = base.GetGraphicsPath();
            path.AddEllipse(-10, -10, 30, 30);
            return path;
        }
        
    }
}
