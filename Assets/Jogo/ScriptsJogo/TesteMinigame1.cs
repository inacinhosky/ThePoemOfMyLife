using UnityEngine;

public class TesteMinigame1 : MonoBehaviour
{
    private bool jaVirouFruta = false;
    public GameControllerMinigame gameControllerMinigame;
    public SpriteRenderer frutaSpriteRenderer;
    public Sprite[] frutas;
    void Start()
    {
        gameControllerMinigame = GetComponentInParent<GameControllerMinigame>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        if (jaVirouFruta)
        {
            return;
        }
        jaVirouFruta = true;
        gameControllerMinigame.clicouNaPessoa();
        frutaSpriteRenderer.sprite = frutas[Random.Range(0, frutas.Length)];
    }
}
