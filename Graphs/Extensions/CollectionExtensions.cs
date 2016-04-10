﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Extensions
{
    public static class CollectionExtensions
    {

        public static T SelectRandom<T>(this ICollection<T> collection)
        {
            Random rand = new Random();
            return collection.ElementAt(rand.Next(0, collection.Count));
        }
    }
}
