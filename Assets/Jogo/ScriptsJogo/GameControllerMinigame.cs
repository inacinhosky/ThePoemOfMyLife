using UnityEngine;

public class GameControllerMinigame : MonoBehaviour
{
    public Dialogo dialogo;
    public int pessoasTotal;
    public int pessoasFrutas;
    public GameObject gameController;
    public GameObject Timer;
    private bool jaFoi = false;
    void Start()
    {
        pessoasTotal = transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void clicouNaPessoa()
    {
        pessoasFrutas++;
        if (pessoasFrutas == pessoasTotal && !jaFoi)
        {
            jaFoi = true;
            Debug.Log("Ganhou");
            dialogo.continuarDialogo();
            gameController.SetActive(false);
            Timer.SetActive(false);
        }    
    }
}
