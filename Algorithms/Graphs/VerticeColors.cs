﻿namespace Algorithms.Graphs
{
    internal class VerticeColors
    {
        private readonly VerticeColor[] colors;

        public int Length => colors.Length;

        public VerticeColors(int verticesCount)
        {
            colors = new VerticeColor[verticesCount];
        }

        public VerticeColor this[int vertice]
        {
            get { return colors[vertice]; }
            set { colors[vertice] = value; }
        }
    }
}