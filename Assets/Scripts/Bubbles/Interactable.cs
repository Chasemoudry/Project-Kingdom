using UnityEngine;

[RequireComponent(typeof(Collider)), DisallowMultipleComponent]
public class Interactable : MonoBehaviour
{
    [SerializeField]
    private BubbleObject _bubbleObject;

    private Collider _collider;

    private void Awake()
    {
        this._collider = this.GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Move bubble
        if (this._bubbleObject.IsThoughtBubble)
        {
            BubbleRenderer.SetPosition(other.transform.position + this._bubbleObject.Offset);
        }
        else
        {
            BubbleRenderer.SetPosition(this.transform.position
                + new Vector3(0, this._collider.bounds.extents.y, 0)
                + this._bubbleObject.Offset);
        }
        BubbleRenderer.SetSprite(this._bubbleObject.BubbleSprite);
        // Enable bubble
        BubbleRenderer.SetVisibility(true);
    }

    private void OnTriggerStay(Collider other)
    {
        if (this._bubbleObject.IsThoughtBubble)
        {
            BubbleRenderer.SetPosition(other.transform.position + this._bubbleObject.Offset);
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        // Disable bubble 
        BubbleRenderer.SetVisibility(false);
    }
}
