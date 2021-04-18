using UnityEditor;

namespace Code
{
    public class MenuItems
    {
        [MenuItem("Sunrise/Create objects on the Scene")]
        private static void MenuOption()
        {
            EditorWindow.GetWindow(typeof(CreateObjectsWindow), false, "Create objects on the Scene");
        }
    }
}