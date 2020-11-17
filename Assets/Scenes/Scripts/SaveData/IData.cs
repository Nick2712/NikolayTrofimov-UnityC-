using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace NikolayTrofimov_Game
{
    public interface IData<T>
    {
        void Save(T data, string path = null);
        T Load(string path = null);
    }
}