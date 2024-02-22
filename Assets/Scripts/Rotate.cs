using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 200.0f;
    [SerializeField] private Vector3 _rotateAxis = Vector3.zero;

    void Update()
    {
        float angle = _rotationSpeed * Time.deltaTime;
        transform.Rotate(_rotateAxis.x * angle, _rotateAxis.y * angle, _rotateAxis.z * angle);
    }
}
