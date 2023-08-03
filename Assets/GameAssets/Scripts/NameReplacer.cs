using UnityEngine;

namespace GameAssets.Scripts
{
    public class NameReplacer : MonoBehaviour
    {
        [SerializeField] private string newName;
        [SerializeField] private string oldName;

        [ContextMenu("Replace")]
        public void Replace()
        {
            ReplaceRecursive(transform);
        }

        public void ReplaceRecursive(Transform tr)
        {
            if (tr.childCount == 0)
                return;
            for (int i = 0; i < tr.childCount; i++)
            {
                tr.GetChild(i).name = tr.GetChild(i).name.Replace(oldName, newName);
                ReplaceRecursive(tr.GetChild(i));
            }
        }
    }
}