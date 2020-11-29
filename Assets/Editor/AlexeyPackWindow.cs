using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


namespace NikolayTrofimov_Game
{
    public sealed class AlexeyPackWindow : EditorWindow
    {
        public int Number;
        public string Name;
        public bool IsPressed;

        public void OnGUI()
        {
            GUILayout.Label("Моё первое кастомное окно");
            EditorGUILayout.HelpBox("Warning!!", MessageType.Warning);
            
            if(GUILayout.Button("не нажимайте на кнопку"))
            {
                IsPressed = true;
            }
            //IsPressed = GUILayout.Button("не нажимайте на кнопку");
            if(IsPressed)
            {
                EditorGUILayout.HelpBox("Вы нажали на кнопку", MessageType.Warning);
                EditorGUILayout.TextField("Колличество префабов");
                Number = EditorGUILayout.IntSlider(Number, 1, 10);

            }

        }
    }
}