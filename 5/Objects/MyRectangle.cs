﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Objects
{
    class MyRectangle : BaseObject
    {
        // создаем конструктор с тем же набором параметров что и в BaseObject
        // base(x, y, angle) -- вызывает конструктор родительского класса
        public MyRectangle(float x, float y, float angle) : base(x, y, angle)
        {
        }

        public override void Render(Graphics g)
        {
            g.FillRectangle(new SolidBrush(Color.Yellow), -25, -15, 50, 30);
            g.DrawRectangle(new Pen(Color.Red, 2), -25, -15, 50, 30);
        }
    }
}
