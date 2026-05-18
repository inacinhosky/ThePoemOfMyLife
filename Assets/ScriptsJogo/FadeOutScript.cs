using UnityEngine;

public class FadeOutScript : MonoBehaviour
{
    public GameObject fadeOutAnimacao;
    public GameObject background;

    void Start()
    {
        fadeOutAnimacao.SetActive(false);
        background.SetActive(true);
    }

    void Update()
    {
        if (Input.anyKey)
        {
            background.SetActive(false);
            fadeOutAnimacao.SetActive(true);
        }
    }
}