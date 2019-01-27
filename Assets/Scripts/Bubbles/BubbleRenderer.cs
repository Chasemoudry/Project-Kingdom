using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image), typeof(RectTransform)), DisallowMultipleComponent]
public class BubbleRenderer : MonoBehaviour
{
    private static BubbleRenderer Main;
    private RectTransform _rectTransform;
    private Canvas _canvas;
    private Image _image;

    private void Awake()
    {
        if (Main)
        {
            Debug.LogWarning("Static BubbleRenderer already exists!", Main);
            Destroy(this.gameObject);
        }
        else
        {
            Main = this;
        }

        this._rectTransform = this.GetComponent<RectTransform>();
        this._canvas = this._rectTransform.GetComponentsInParent<Canvas>()[0];
        this._image = this.GetComponent<Image>();

        SetVisibility(false);
    }

    public static void SetPosition(Vector3 worldPosition)
    {
        var screenPoint = Camera.main.WorldToViewportPoint(worldPosition);
        Main._rectTransform.anchoredPosition = new Vector2(
            screenPoint.x * Main._canvas.pixelRect.width,
            screenPoint.y * Main._canvas.pixelRect.height);
    }

    public static void SetSprite(Sprite sprite)
    {
        Debug.Log("SetSprite: " + sprite.name);
        Main._image.sprite = sprite;
    }

    public static void SetVisibility(bool isVisible)
    {
        Main._image.enabled = isVisible;
    }
}
