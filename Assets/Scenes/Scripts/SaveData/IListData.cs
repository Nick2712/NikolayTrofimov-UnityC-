using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace NikolayTrofimov_Game
{
    public interface IListData<T>
    {
        void Save(List<T> data, string path = null);
        List<T> Load(string path = null);
    }
}