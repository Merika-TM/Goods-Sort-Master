using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(DraggableItem))]
    public class DraggableItemEditor : UnityEditor.Editor
    {
        public Sprite warningSprite;
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI(); 

            DraggableItem draggableItem = (DraggableItem)target;

            if (draggableItem.Image != null)
            {
                if (draggableItem.item != null)
                {
                    draggableItem.Image.sprite = draggableItem.item.image;
                }
                else
                {
                    draggableItem.Image.sprite = null;
                }

                EditorUtility.SetDirty(draggableItem.Image);
            }
        }
    }
}