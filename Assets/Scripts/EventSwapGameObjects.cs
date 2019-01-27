using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Interactable))]
public class EventSwapGameObjects : MonoBehaviour
{
    [SerializeField]
    private GameObject _initialObject;
    [SerializeField]
    private GameObject _finalObject;

    private void Awake()
    {
        this._initialObject.SetActive(true);
        this._finalObject.SetActive(false);
    }

    public void SwapGameObjects()
    {
        Debug.Log("SWAPPING " + this._initialObject.name + " and " + this._finalObject.name);
        this._initialObject.SetActive(!this._initialObject.activeSelf);
        this._finalObject.SetActive(!this._finalObject.activeSelf);
    }
}
