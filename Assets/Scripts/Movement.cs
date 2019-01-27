using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour
{
    public List<BubbleObject> Objects { get { return this._objects; } }

    [SerializeField]
    private bool _canBeControlled = true;

    private CharacterController _controller;
    private List<BubbleObject> _objects = new List<BubbleObject>(0);
    [SerializeField]
    private Interactable _nearbyInteractable;

    private void Awake()
    {
        this._controller = this.GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F12))
        {
            //Hard reset game state
        }

        if (this._canBeControlled == false)
        {
            return;
        }

        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");
        var absH = Mathf.Abs(h);
        var absV = Mathf.Abs(v);
        var moveSpeed = 0f;

        //if: Horizontal movement is greater, moveSpeed equals horizontal movement scalar
        //else if: Vertical movement is greater, moveSpeed equals vertical movement scalar
        moveSpeed = (absH > absV) ? absH : absV;

        //Switches movement to worldSpace from localSpace
        this._controller.SimpleMove(Vector3.ClampMagnitude(
            this.transform.InverseTransformDirection(new Vector3(h, 0, v)), 1) * (moveSpeed * 2f));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (this._nearbyInteractable)
            {
                this._nearbyInteractable.Interact(this);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var otherInt = other.GetComponent<Interactable>();
        if (otherInt)
        {
            this._nearbyInteractable = otherInt;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var otherInt = other.GetComponent<Interactable>();
        if (otherInt)
        {
            this._nearbyInteractable = otherInt;
        }
    }

    public void AddObjectToInventory(BubbleObject newObject)
    {
        this._objects.Add(newObject);
        // Update UI
    }

    public void RemoveObjectFromInventory(BubbleObject targetObject)
    {
        this.Objects.Remove(targetObject);
    }
}
