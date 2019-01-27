using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour
{

    [SerializeField]
    private bool _canBeControlled = true;

    private CharacterController _controller;

    private void Awake()
    {
        this._controller = this.GetComponent<CharacterController>();
    }

    private void Update()
    {
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
        if (absH > absV)
        {
            moveSpeed = absH;
        }
        else if (absV > absH)
        {
            moveSpeed = absV;
        }

        //Switches movement to worldSpace from localSpace
        this._controller.SimpleMove(Vector3.ClampMagnitude(
            this.transform.InverseTransformDirection(new Vector3(h, 0, v)), 1) * moveSpeed);
    }
}
