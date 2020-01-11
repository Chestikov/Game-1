using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] private Transform _target;
    private Vector3 _offset;

    private void Start()
    {
        _offset = _target.position - transform.position;
    }

    private void Update()
    {
        FollowTargetHorizontally();
    }

    private void FollowTargetHorizontally()
    {
        Vector3 newPosition = _target.position - _offset;

        transform.position = new Vector3(newPosition.x, transform.position.y, newPosition.z);
    }
}
