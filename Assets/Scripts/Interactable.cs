using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider)), DisallowMultipleComponent]
public sealed class Interactable : MonoBehaviour
{
    public bool IsInteractable { get { return _isInteractable; } }

    public BubbleObject BubbleObject;

    [Header("Interaction Event")]
    [SerializeField]
    private bool _alwaysShow = false;
    [SerializeField]
    private bool _isInteractable = true;
    [SerializeField]
    private BubbleObject _interactRequirement;
    [SerializeField]
    private BubbleObject _objectToGive;
    [SerializeField]
    private UnityEvent _onInteract;

    private Collider _collider;

    private void Awake()
    {
        this._collider = this.GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (this._isInteractable == false && this._alwaysShow == false)
        {
            BubbleRenderer.SetVisibility(false);
            return;
        }

        // Move bubble
        if (this.BubbleObject.IsThoughtBubble)
        {
            BubbleRenderer.SetPosition(other.transform.position + this.BubbleObject.Offset);
        }
        else
        {
            BubbleRenderer.SetPosition(this.transform.position
                + new Vector3(0, this._collider.bounds.extents.y, 0)
                + this.BubbleObject.Offset);
        }
        BubbleRenderer.SetSprite(this.BubbleObject.BubbleSprite);
        // Enable bubble
        BubbleRenderer.SetVisibility(true);
    }

    private void OnTriggerStay(Collider other)
    {
        if (this._isInteractable == false && this._alwaysShow == false)
        {
            BubbleRenderer.SetVisibility(false);
            return;
        }

        if (this.BubbleObject.IsThoughtBubble)
        {
            BubbleRenderer.SetPosition(other.transform.position + this.BubbleObject.Offset);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (this._isInteractable == false && this._alwaysShow == false)
        {
            BubbleRenderer.SetVisibility(false);
            return;
        }

        // Disable bubble 
        BubbleRenderer.SetVisibility(false);
    }

    public void SetIsInteractable(bool isInteractable)
    {
        this._isInteractable = isInteractable;
    }

    public void Interact(Movement player)
    {
        if (this._interactRequirement != null && !player.Objects.Contains(this._interactRequirement))
        {
            return;
        }
        else
        {
            player.RemoveObjectFromInventory(this._interactRequirement);
        }

        player.AddObjectToInventory(this._objectToGive);
        this.SetIsInteractable(false);
        this._onInteract.Invoke();
    }
}
