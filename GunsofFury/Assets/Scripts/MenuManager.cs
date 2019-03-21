using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(LoadScene);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

    public void LoadScene()
    {
        //SceneManager.LoadScene(name);
        SceneManager.LoadScene("Level1");
    }
}
