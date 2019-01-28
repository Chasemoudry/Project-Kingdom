using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class BeginButton : MonoBehaviour
{
    private void Start()
    {
        this.gameObject.SetActive(PlayerPrefs.GetInt("Complete?") == 0);
    }
}
