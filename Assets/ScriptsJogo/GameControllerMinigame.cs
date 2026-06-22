using UnityEngine;

public class GameControllerMinigame : MonoBehaviour
{
    public int pessoasTotal;
    public int pessoasFrutas;
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
        if (pessoasFrutas == pessoasTotal)
        {
            Debug.Log("Ganhou");
        }    
    }
}
