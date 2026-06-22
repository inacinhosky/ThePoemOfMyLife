using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Audio;


public class BotõesMenu : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
public AudioSource audioSource;
public AudioClip hoverSound;

public void OnPointerEnter(PointerEventData eventData)
{
    transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
    audioSource.PlayOneShot(hoverSound);
}
    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
    }
}
