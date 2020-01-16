using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private LayerMask _ground;
    [SerializeField] private Transform _bottomPoint;
    [SerializeField] private float _checkDistance = 0.02f;

    public bool IsOnGround() => Physics2D.OverlapCircle(_bottomPoint.position, _checkDistance, _ground) != null;
}
