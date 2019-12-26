using UnityEngine;
using TMPro;

public class CoinsAmountRenderer : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TextMeshProUGUI _coinsText;
    [SerializeField] private string _template = "Coins: {0}";

    private void Start() => _player.CoinsAmountChanged += () => _coinsText.text = string.Format(_template, _player.Coins);
}
