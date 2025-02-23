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

            if (draggableItem.image != null)
            {
                if (draggableItem.item != null)
                {
                    draggableItem.image.sprite = draggableItem.item.image;
                }
                else
                {
                    draggableItem.image.sprite = null;
                }

                EditorUtility.SetDirty(draggableItem.image);
            }
        }
    }
}