using UnityEngine;
using UnityEngine.EventSystems;


public class BotõesMenu : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{


    void Start()
    {
         
    }


    void Update()
    {
        
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
       transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
    }
}
