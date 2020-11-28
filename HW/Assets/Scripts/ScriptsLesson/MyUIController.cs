using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MyUIController : MonoBehaviour
{

    #region Fields

    public static MyUIController instance;
    [SerializeField] private GameObject informationPanel;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private Text informationText;


    #endregion


    #region UnityMethod

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    #endregion


    #region Method

    public void ShowInformationpannel(string text)
    {
        informationPanel.SetActive(true);
        informationText.text = text;
    }

    public void LoadLevelButton(int indexScene)
    {
        SceneManager.LoadScene(indexScene);
    }

    public void PauseAndPause(int timescale)
    {
        Time.timeScale = timescale;

        if (timescale == 0)
        {
            pausePanel.SetActive(true);
        }
        else if (timescale == 1)
        {
            pausePanel.SetActive(false);
        }
    }

    #endregion
}
