using UnityEngine;
using UnityEngine.SceneManagement;
public class IrParaOJogo : MonoBehaviour
{

    public void jogo()
    {
        SceneManager.LoadSceneAsync("jogo");
    }

}
