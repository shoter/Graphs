﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Extensions
{
    public static class CollectionExtensions
    {
        static Random rand = new Random();
        public static T SelectRandom<T>(this ICollection<T> collection)
        {
           
            return collection.ElementAt(rand.Next(0, collection.Count));
        }

        /// <param name="min">Inclusive</param>
        /// <param name="max">Not inclusive</param>
        /// <returns></returns>
        public static T SelectRandom<T>(this ICollection<T> collection, int min, int max)
        {

            return collection.ElementAt(rand.Next(min, max));
        }
    }
}
