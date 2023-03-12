using TMPro;
using UnityEngine;

public class GameScreen : Screen {
    [SerializeField] private TextMeshProUGUI _positionLabel;

    public TextMeshProUGUI PositionLabel => _positionLabel;
}