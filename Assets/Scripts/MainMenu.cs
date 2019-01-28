using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private static MainMenu Main;
    [SerializeField]
    private Image _introImage;
    [SerializeField]
    private Sprite _introSprite;
    [SerializeField]
    private Sprite _completionSprite;

    private void Awake()
    {
        if (Main)
        {
            Debug.LogWarning("Static MainMenu already exists!", Main);
            Destroy(this.gameObject);
        }
        else
        {
            Main = this;
        }
    }

    private void Start()
    {
        if (PlayerPrefs.GetInt("Complete?") == 0)
        {
            SetIntro();
        }
        else
        {
            SetCompletion();
        }
    }

    public static void BigReset()
    {
        PlayerPrefs.SetInt("Complete?", 0);
        SetIntro();
    }

    public static void SetCompletion()
    {
		Main.gameObject.SetActive(true);
        Main._introImage.sprite = Main._completionSprite;
    }

    public static void SetIntro()
    {
        Main._introImage.sprite = Main._introSprite;
    }
}
