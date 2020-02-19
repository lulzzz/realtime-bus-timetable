﻿using System;
using System.IO;
using System.Reflection;
using System.Text.Json;
using BusTimetable.Generator.Generators;
using BusTimetable.Generator.Models;

namespace BusTimetable.Generator
{
    class Program
    {
        private const int Width = 1000;
        private const int Height = 800;
        private const int BustStopsNumber = 10;
        private const int RoutesNumber = 10;

        static void Main()
        {
            var busStops = BusStopGenerator.Generate(Width, Height, BustStopsNumber);
            var routes = RouteGenerator.Generate(busStops, Width, Height, RoutesNumber);

            var json = JsonSerializer.Serialize(new Root {BusStops = busStops, Routes = routes});
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"metadata-{Guid.NewGuid()}.json");
            File.AppendAllText(path, json);
        }
    }
}