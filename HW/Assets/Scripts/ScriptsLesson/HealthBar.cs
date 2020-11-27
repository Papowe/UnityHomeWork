using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    #region Fields

    [SerializeField] PlayerHealth player;
    private Slider slider;

    #endregion


    #region UnityMethod

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    private void Start()
    {
        slider.maxValue = player.Health;
        ViewHealts();
    }

    private void Update()
    {
        //ViewHealts();
    }

    #endregion


    #region Method

    public void ViewHealts()
    {
        slider.value = player.Health;
    }

    #endregion
}
