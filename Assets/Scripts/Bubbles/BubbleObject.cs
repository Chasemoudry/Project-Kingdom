using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyObjects/Bubble")]
public class BubbleObject : ScriptableObject
{
    [SerializeField]
    private Sprite _bubbleSprite;
    [SerializeField]
    private Vector3 _bubbleOffset;
    [SerializeField]
    private bool _isThoughtBubble;

    public Sprite BubbleSprite { get { return this._bubbleSprite; } }
    public Vector3 Offset { get { return this._bubbleOffset; } }
    public bool IsThoughtBubble { get { return this._isThoughtBubble; } }
}
