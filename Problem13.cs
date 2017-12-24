using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode
{
    public class Problem13Part1
    {
        public class Layer
        {
            public int Index { get; set; }
            public int Depth { get; set; }
            public int ScanLocation { get; set; }
            public bool ScanUp { get; set; }
        }

        public static void Run()
        {
            var layers = File.ReadAllLines("Problem13.txt").Select(l => new Layer
            {
                Index = int.Parse(l.Split(": ")[0]),
                Depth = int.Parse(l.Split(": ")[1])
            }).ToList();

            var caughts = new List<int>();
            for (var layerIndex = 0; layerIndex <= layers.Max(l => l.Index); layerIndex++)
            {
                var currentLayer = layers.FirstOrDefault(l => l.Index == layerIndex);
                if (currentLayer != null)
                {
                    if (currentLayer.ScanLocation == 0)
                    {
                        caughts.Add(currentLayer.Depth * currentLayer.Index);
                    }
                }

                foreach (var layer in layers)
                {
                    if (layer.ScanUp && layer.ScanLocation == 0)
                        layer.ScanUp = false;
                    if (!layer.ScanUp && layer.ScanLocation == layer.Depth - 1)
                        layer.ScanUp = true;

                    layer.ScanLocation += layer.ScanUp ? -1 : 1;
                }
            }
        }
    }

    public class Problem13Part2
    {
        public class Layer
        {
            public int Index { get; set; }
            public int Depth { get; set; }
        }

        public static List<Layer> layers;

        public static void Run()
        {
            layers = File.ReadAllLines("Problem13.txt").Select(l => new Layer
            {
                Index = int.Parse(l.Split(": ")[0]),
                Depth = int.Parse(l.Split(": ")[1])
            }).ToList();


            for (var delay = 0; delay < int.MaxValue; delay++)
            {
                if(layers.All((layer) => 
                {
                    var location = (delay + layer.Index) % (2 * (layer.Depth - 1));
                    return location != 0;
                }))
                {
                    // Winning    
                }
            }
        }
    }
}
