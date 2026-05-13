using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{

    public void jogo()
    {
        SceneManager.LoadSceneAsync("jogo");
    }

}
