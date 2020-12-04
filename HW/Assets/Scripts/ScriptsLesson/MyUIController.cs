using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MyUIController : MonoBehaviour
{

    #region Fields

    public static MyUIController instance;
    [Header("SetForLevel 1")]
    [SerializeField] private GameObject informationPanel;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private Text informationText;
    [SerializeField] private AudioMixerGroup Mixer;

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

    public void GameStatus(string text)
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
            Mixer.audioMixer.SetFloat("EffectSound", -80f);
        }
        else if (timescale == 1)
        {
            pausePanel.SetActive(false);
            Mixer.audioMixer.SetFloat("EffectSound", 0f);
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
    }

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }



    #endregion
}
