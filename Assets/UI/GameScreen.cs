using TMPro;
using UnityEngine;

public class GameScreen : Screen {
    [SerializeField] private TextMeshProUGUI _positionLabel;
    [SerializeField] private TextMeshProUGUI _angleLabel;
    [SerializeField] private TextMeshProUGUI _speedLabel;
    [SerializeField] private TextMeshProUGUI _lasersCountLabel;
    [SerializeField] private TextMeshProUGUI _laserReloadTimeLabel;

    public TextMeshProUGUI PositionLabel => _positionLabel;
    public TextMeshProUGUI AngleLabel => _angleLabel;
    public TextMeshProUGUI SpeedLabel => _speedLabel;
    public TextMeshProUGUI LaserCountLadbel => _lasersCountLabel;
    public TextMeshProUGUI LaserReloadTimeLabel => _laserReloadTimeLabel;
}