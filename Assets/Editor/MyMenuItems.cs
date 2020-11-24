using UnityEditor;

namespace NikolayTrofimov_Game
{
    public class MyMenuItems
    {
        [MenuItem("Window/NikolayTrofimovGame окно редактора")]
        private static void MenuOption()
        {
            EditorWindow.GetWindow(typeof(MyWindowEditor), false, "Редактор бонусов");
        }
    }
}
