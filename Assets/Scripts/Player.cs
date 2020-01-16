using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private const float VerticalSpeed = 0f;
    [SerializeField] private float _horizontalSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private KeyCode _jumpKey;

    public event Action CoinsAmountChanged;
    public event Action PlayerDied;

    public int Coins { get; private set; }

    public void Die()
    {
        gameObject.SetActive(false);

        PlayerDied?.Invoke();
    }

    private void Start() => ApplySpeed();

    private void Update()
    {
        if (Input.GetKeyDown(_jumpKey) && _groundChecker.IsOnGround())
        {
            Jump(_jumpForce);
        }
    }

    private void ApplySpeed() => _rigidbody.velocity = new Vector2(_horizontalSpeed, VerticalSpeed);

    private void Jump(float jumpForce) => _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var coin = collision.GetComponent<Coin>();

        if (coin)
        {
            AddCoin(coin);
        }
    }

    private void AddCoin(Coin coin)
    {
        ChangeCoinsAmount(coin.Value);

        coin.RespawnRequest();
    }

    private void ChangeCoinsAmount (int value)
    {
        Coins += value;

        CoinsAmountChanged?.Invoke();
    }
}
