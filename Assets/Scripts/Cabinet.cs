using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class Cabinet : MonoBehaviour
{
    private RectTransform cabinetSize;
    private GridLayoutGroup placeHolder;

    private void Awake()
    {
        cabinetSize= gameObject.GetComponent<RectTransform>();
        placeHolder = gameObject.GetComponent<GridLayoutGroup>();
        placeHolder.cellSize = new Vector2(cabinetSize.rect.width / 3,cabinetSize.rect.height);
    }

}
