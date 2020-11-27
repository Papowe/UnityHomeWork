using UnityEngine;


public class ToDamage : MonoBehaviour
{
    #region Fields

    [SerializeField] private int damage;

    #endregion


    #region UnityMethods

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerHealth>(out PlayerHealth playerHealth))
        {
            playerHealth.GetDamage(damage);
        }
    }

    #endregion
}
