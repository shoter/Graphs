﻿using Graphs.Data;
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
using System.Windows.Shapes;

namespace Graphs.Windows.Generators
{
    /// <summary>
    /// Interaction logic for ErdosGenerator.xaml
    /// </summary>
    public partial class ErdosGenerator : Window
    {

        public ErdosGenerator()
        {
            InitializeComponent();
        }

        private void Generate(object sender, RoutedEventArgs e)
        {
            Close();
        }

        

        private GraphMatrix Generate()
        {
            int nodesCount,
                connectionCount;



            nodesCount = Int32.Parse(NodeCount.Text);
            connectionCount = Int32.Parse(ConnectionCount.Text);

            GraphMatrix graph = new GraphMatrix(nodesCount);
            graph.generatorGER(nodesCount, connectionCount);

            return graph;
        }

        private void OnClose(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DataContext = Generate();
        }
    }
}
