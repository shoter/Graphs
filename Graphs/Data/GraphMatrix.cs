﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Graphs.Data
{
    public class GraphMatrix
    {
        public GraphMatrix(int nodes)
        {
            nodesNr = nodes;

            connect = new int[nodesNr, nodesNr];
        }

        public GraphMatrix(int nodes, int[,] connections)
        {
            NodesNr = nodes;
            connect = connections;
        }
        public void MakeConnection(int node1, int node2)
        {
            connect[node1, node2] = connect[node2, node1] = 1;
        }

        public bool GetConnection(int node1, int node2)
        {
            return connect[node1, node2] >= 1;
        }

        public void generatorGER(int nodes, int branches)//generator Erdoesa-Renyiego
        {
            nodesNr = nodes;
            connect = new int[nodesNr, nodesNr];//default =0
            int max = (nodesNr * nodesNr - nodesNr) / 2;
            int[] ar = new int[branches];
            Random r = new Random();
            for (int i = 0; i < nodesNr; i++)//losowanie wezlow
                while (true)//sprawdzanie czy sie nie powtarzaja
                {
                    ar[i] = r.Next(max);
                    bool q = false;
                    for (int k = 0; k < i; k++)
                        if (ar[k] == ar[i])
                            q = true;
                    if (!q)
                        break;
                }
            int counter = 0;
            for (int i = 1; i < nodesNr; i++)//wpisywanie wylosowanych liczb
                for (int j = 1; j < i; j++)
                {
                    for (int k = 0; k < branches; k++)
                        if (ar[k] == counter)
                            MakeConnection(i, j);
                    counter++;
                }
        }
        public void generatorGnp(int nodes, double prob)//generator G(n,p)
        {
            if (0 <= prob || prob <= 1 || nodes < 2)
                return;
            nodesNr = nodes;
            connect = new int[nodes, nodes];//default =0
            Random r = new Random();
            for (int i = 1; i < nodesNr; i++)
                for (int j = 1; j < i; j++)
                    if (r.NextDouble() < prob)
                        MakeConnection(i, j);
        }
        public int[,] Connect { get; set; }
        public int NodesNr { get; set; }
        private int[,] connect;
        private int nodesNr;
    }
}
