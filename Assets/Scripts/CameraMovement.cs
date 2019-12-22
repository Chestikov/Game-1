using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _targetTransform;
    private Vector3 _offset;

    private void Start()
    {
        _offset = _targetTransform.position - transform.position;
    }

    private void Update()
    {
        FollowTargetHorizontally();
    }

    private void FollowTargetHorizontally()
    {
        Vector3 newPosition = _targetTransform.position - _offset;

        transform.position = new Vector3(newPosition.x, transform.position.y, newPosition.z);
    }
}
