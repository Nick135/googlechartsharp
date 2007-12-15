using System;
using System.Collections.Generic;
using System.Text;
using GoogleChartSharp;
using System.Diagnostics;
using System.Drawing;
using System.IO;

namespace Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            using (TextWriter tw = new StreamWriter(("test.html")))
            {
                int[] data;
                float[] fdata;
                List<int[]> intDataList = new List<int[]>();
                List<float[]> fDataList = new List<float[]>();

                tw.WriteLine("<h3>Line Charts</h3>");

                # region Line Charts
                // Test Line Chart
                data = new int[] { 40, 30, 20, 10, 0 };
                LineChart chart = new LineChart(150, 150);
                chart.SetData(data);
                tw.WriteLine(getImageTag(chart.GetUrl()));

                // Test XY Line Chart
                fDataList.Clear();
                fdata = new float[] { 0, 30, 60, 70, 90, 95, 100 };
                fDataList.Add(fdata);
                fdata = new float[] { 20, 30, 40, 50, 60, 70, 80 };
                fDataList.Add(fdata);
                fdata = new float[] { 10, 30, 40, 45, 52 };
                fDataList.Add(fdata);
                fdata = new float[] { 100, 90, 40, 20, 10 };
                fDataList.Add(fdata);
                LineChart xyLineChart = new LineChart(150, 150, true);
                xyLineChart.SetData(fDataList);
                tw.WriteLine(getImageTag(xyLineChart.GetUrl()));
                #endregion

                #region Bar Charts
                // Horizontal Stacked Bar Chart
                tw.WriteLine("<h3>Bar Charts</h3>");
                data = new int[] { 0, 10, 20, 30, -1, 40 };
                BarChart barChart = new BarChart(150, 150, BarChartOrientation.Horizontal, BarChartStyle.Stacked);
                barChart.SetData(data);
                tw.WriteLine(getImageTag(barChart.GetUrl()));

                // Vertical Stacked Bar Chart
                data = new int[] { 0, 10, 20, 30, -1, 40 };
                barChart = new BarChart(200, 150, BarChartOrientation.Vertical, BarChartStyle.Stacked);
                barChart.SetBarWidth(10);
                barChart.SetData(data);
                tw.WriteLine(getImageTag(barChart.GetUrl()));
                #endregion

                #region Pie Charts
                // 2D Pie Chart
                tw.WriteLine("<h3>Pie Charts</h3>");
                data = new int[] { 10, 20, 30, 40 };
                PieChart pieChart = new PieChart(300, 200);
                pieChart.SetData(data);
                tw.WriteLine(getImageTag(pieChart.GetUrl()));

                // 3D Pie Chart
                data = new int[] { 10, 20, 30, 40 };
                pieChart = new PieChart(300, 200, true);
                pieChart.SetData(data);
                tw.WriteLine(getImageTag(pieChart.GetUrl()));
                #endregion

                # region Venn Diagrams
                tw.WriteLine("<h3>Venn Diagrams</h3>");
                VennDiagram venn = new VennDiagram(150, 150);
                data = new int[] { 100, 80, 60, 30, 30, 30, 10 };
                venn.SetData(data);
                tw.WriteLine(getImageTag(venn.GetUrl()));
                #endregion

                # region Scatter Plots
                tw.WriteLine("<h3>Scatter Plots</h3>");
                ScatterPlot scatter = new ScatterPlot(150, 150);
                data = new int[] { 10, 20, 30, 40, 50 };
                intDataList.Add(data);
                data = new int[] { 10, 20, 30, 40, 50 };
                intDataList.Add(data);
                data = new int[] { 1, 2, 3, 4, 5 };
                intDataList.Add(data);
                scatter.SetData(intDataList);
                tw.WriteLine(getImageTag(scatter.GetUrl()));
                #endregion
            }

            Process.Start(new FileInfo("test.html").FullName);
        }

        static string getImageTag(string url)
        {
            return "<img src=\"" + url + "\" />";
        }
    }
}