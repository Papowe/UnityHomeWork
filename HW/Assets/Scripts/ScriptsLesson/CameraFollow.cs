using UnityEngine;


public class CameraFollow : MonoBehaviour
{
    #region Fields

    [SerializeField] private Transform targetFollow;
    [SerializeField] private float speedCamera;
    [SerializeField] private Vector3 positionOffset;
    [SerializeField] private Vector3 rotationOffset;

    private Vector3 position;
   
    #endregion


    #region UnityMethods

    private void Start()
    {
        position = targetFollow.InverseTransformPoint(transform.position);
    }

    private void Update()
    {
        if (targetFollow)
        {
            var currentPosition = targetFollow.TransformPoint(position) + positionOffset;
            transform.position = Vector3.Lerp(transform.position, currentPosition, speedCamera * Time.deltaTime);
            var currentRotation = Quaternion.LookRotation(targetFollow.position - transform.position + rotationOffset);
            transform.rotation = Quaternion.Lerp(transform.rotation, currentRotation, speedCamera * Time.deltaTime);
        }

    }

    #endregion
}
