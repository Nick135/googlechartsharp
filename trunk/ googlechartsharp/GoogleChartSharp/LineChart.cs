using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleChartSharp
{
    public class LineChart : Chart
    {
        private bool isXY;

        public LineChart(int width, int height) 
            : base(width, height)
        {
            
        }

        public LineChart(int width, int height, bool isXY)
            : base(width, height)
        {
            this.isXY = isXY;
        }

        public override string chartType()
        {
            if (this.isXY)
            {
                return "lxy";
            }
            return "lc";
        }
    }
}