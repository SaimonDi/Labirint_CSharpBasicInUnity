using UnityEditor;

namespace LabirintSpace
    {
    public class MenuItems
        {
        [MenuItem("My Windows/First")]
        private static void MenuOption()
            {
            EditorWindow.GetWindow(typeof(MyWindow), false, "My Window");
            }
        }
    }