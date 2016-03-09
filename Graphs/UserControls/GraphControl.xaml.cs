﻿using Graphs.ViewModels;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Graphs.UserControls
{
    /// <summary>
    /// Interaction logic for GraphControl.xaml
    /// </summary>
    public partial class GraphControl : UserControl
    {
        public GraphViewModel _vm;
        private const int NewCanvasPer = 150;
        public GraphViewModel VM
        {
            set
            {
                _vm = value;
                Draw();
            }
            protected get
            {
                return _vm;
            }
        }
        public GraphControl()
        {
            InitializeComponent();

        }

        public void DrawNodes()
        {
            int i = 0;
            Canvas canvas = MyCanvas;
            bool add = false;
            foreach (var node in VM.Nodes)
            {
                Circle circle = new Circle();
                circle.DataContext = node;
                canvas.Children.Add(circle);

                if (i >= NewCanvasPer)
                {
                    if (add)
                        MyCanvas.Children.Add(canvas);

                    canvas = new Canvas();
                    i = 0;
                    add = true;
                }
                i++;
            }

            if (add)
                MyCanvas.Children.Add(canvas);
        }

        public void DrawConnections()
        {
            foreach (var connection in VM.Connections)
            {
                Line line = new Line();
                line.DataContext = connection;
                MyCanvas.Children.Add(line);
            }
        }

        private void Draw()
        {
            Clear();
            DrawConnections();
            DrawNodes();

            //Image test = new Image();
            //DrawingGroup tmpDrawing = new DrawingGroup();
            //GeometryGroup lineGroup = new GeometryGroup();
            //GeometryGroup circleGroup = new GeometryGroup();
            //circleGroup.FillRule = FillRule.Nonzero;

            //LineGeometry[] lines = new LineGeometry[VM.Connections.Count];
            //EllipseGeometry[] circles = new EllipseGeometry[VM.Nodes.Count];
            //int i = 0;
            //foreach (var c in VM.Connections)
            //{
            //    lines[i] = new LineGeometry
            //        (
            //        new Point(c.X1, c.Y1),
            //        new Point(c.X2, c.Y2)
            //        );
            //    lineGroup.Children.Add(lines[i]);
            //     ++ i;
            //}
            //i = 0;
            //foreach (var n in VM.Nodes)
            //{
            //    circles[i] = new EllipseGeometry
            //        (
            //         new Point(n.X, n.Y),
            //         n.Radius,
            //         n.Radius
            //        );
                
            //    circleGroup.Children.Add(circles[i]);
            //    ++i;
            //}

            //tmpDrawing.Children.Add(new GeometryDrawing(new SolidColorBrush(Colors.Black), new Pen(new SolidColorBrush(Colors.Black), 1), lineGroup));
            //tmpDrawing.Children.Add(new GeometryDrawing(new SolidColorBrush(Colors.Black), new Pen(new SolidColorBrush(Colors.Black), 1), circleGroup));
            //LineImage.Source = new DrawingImage(tmpDrawing);


           
            //// MyCanvas.Drawing = tmpDrawing;

        }

        private void Clear()
        {
            MyCanvas.Children.Clear();
        }
    }
}
