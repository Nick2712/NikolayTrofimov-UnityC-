
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace NikolayTrofimov_Game
{
    public class Test : MonoBehaviour
    {
        private Transform _root;
        
        void Start()
        {
            _root = new GameObject("Root").transform;
        }
    }
}