using UnityEditor;
using UnityEngine;

namespace NikolayTrofimov_Game
{
    public class MyWindowEditor : EditorWindow
    {
        [SerializeField] private static GameObject _goodBonus;
        [SerializeField] private static GameObject _badBonus;

        private string _goodBonusName = "GoodBonus";
        private string _badBonusName = "BadBonus";

        private readonly string[] _toolbarStrings = { "Good Bonus", "Bad Bonus" };

        private int _selectedBonus;

        //public static GameObject ObjectInstantiate;
        //public string _nameObject = "Hello World";
        //public bool _groupEnabled;
        //public bool _randomColor = true;
        //public int _countObject = 1;
        //public float _radius = 10;

        private void OnGUI()
        {
            GUILayout.Label("Расстановка бонусов", EditorStyles.boldLabel);

            _goodBonus = EditorGUILayout.ObjectField("Good Bonus", _goodBonus,
                typeof(GameObject), true) as GameObject;

            _badBonus = EditorGUILayout.ObjectField("Bad Bonus", _badBonus,
                typeof(GameObject), true) as GameObject;

            //ObjectInstantiate =
            //   EditorGUILayout.ObjectField("Объект который хотим вставить",
            //         ObjectInstantiate, typeof(GameObject), true)
            //      as GameObject;

            _goodBonusName = EditorGUILayout.TextField("Имя Good Bonus'а", _goodBonusName);
            _badBonusName = EditorGUILayout.TextField("Имя Bad Bonus'а", _badBonusName);

            GUILayout.Label("Текущий бонус", EditorStyles.boldLabel);

            _selectedBonus = GUILayout.Toolbar(_selectedBonus, _toolbarStrings);

            if (Event.current.button == 0 && Event.current.type == EventType.MouseDown)
            {
                if (_selectedBonus == 0)
                {
                    Debug.Log("Ставим гуд бонус");
                }

                if (_selectedBonus == 0)
                {
                    Debug.Log("Ставим бэд бонус");
                }
            }
            


            //_nameObject = EditorGUILayout.TextField("Имя объекта", _nameObject);
            //_groupEnabled = EditorGUILayout.BeginToggleGroup("Дополнительные настройки",
            //   _groupEnabled);
            //_randomColor = EditorGUILayout.Toggle("Случайный цвет", _randomColor);
            //_countObject = EditorGUILayout.IntSlider("Количество объектов",
            //_countObject, 1, 100);
            //_radius = EditorGUILayout.Slider("Радиус окружности", _radius, 10, 50);
            //EditorGUILayout.EndToggleGroup();
            //var button = GUILayout.Button("Создать объекты");
            //if (button)
            //{
            //    if (ObjectInstantiate)
            //    {
            //        GameObject root = new GameObject("Root");
            //        for (int i = 0; i < _countObject; i++)
            //        {
            //            float angle = i * Mathf.PI * 2 / _countObject;
            //            Vector3 pos = new Vector3(Mathf.Cos(angle), 0,
            //                             Mathf.Sin(angle)) * _radius;
            //            GameObject temp = Instantiate(ObjectInstantiate, pos,
            //               Quaternion.identity);
            //            temp.name = _nameObject + "(" + i + ")";
            //            temp.transform.parent = root.transform;
            //            var tempRenderer = temp.GetComponent<Renderer>();
            //            if (tempRenderer && _randomColor)
            //            {
            //                tempRenderer.material.color = Random.ColorHSV();
            //            }
            //        }
            //    }
            //}
        }

  
    }
}
