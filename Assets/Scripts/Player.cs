using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private const float VerticalSpeed = 0f;
    [SerializeField] private float _horizontalSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private GroundChecker _groundChecker;
    private int _coins;
    public event Action CoinsAmountChanged;

    public int Coins
    {
        get
        {
            return _coins;
        }
        private set
        {
            _coins = value;

            CoinsAmountChanged?.Invoke();
        }
    }

    private void Start() => SetSpeed();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _groundChecker.CanJump())
        {
            Jump();
        }
    }

    private void SetSpeed() => _rigidbody.velocity = new Vector2(_horizontalSpeed, VerticalSpeed);

    private void Jump() => _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var coin = collision.GetComponent<Coin>();

        if (coin)
        {
            CollectCoin(coin);
        }
    }

    private void CollectCoin(Coin coin)
    {
        Coins += coin.Value;

        coin.RespawnRequest();
    }
}
