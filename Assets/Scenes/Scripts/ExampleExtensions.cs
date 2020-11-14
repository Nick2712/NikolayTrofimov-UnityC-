using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace NikolayTrofimov_Game
{
    public static class ExampleExtensions
    {
        public static int StringSimbolsCount(this string someString)
        {
            string tempString = someString.Replace(" ", "");
            return tempString.Length;
        }
    }
}