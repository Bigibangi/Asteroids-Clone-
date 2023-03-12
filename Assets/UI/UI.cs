using UnityEngine;

public class UI : MonoBehaviour {
    [SerializeField] private GameScreen _gameScreen;

    public GameScreen GameScreen => _gameScreen;
}