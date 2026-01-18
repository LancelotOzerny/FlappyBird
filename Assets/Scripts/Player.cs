using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _jumpPower = 5.0f;
    [SerializeField] private float _gravityScale = 1f;
    private Rigidbody2D _rigidBody2D;

    private float _savedVelocityY;
    private bool _isPausedMode = false;

    private void Start()
    {
        SetPauseMode();
        _savedVelocityY = _jumpPower;
    }

    private void Awake()
    {
        this._rigidBody2D = this.gameObject.AddComponent<Rigidbody2D>();
        this._rigidBody2D.gravityScale = this._gravityScale;
    }

    public void Jump()
    {
        if (GameParams.Instance.IsPause || GameParams.Instance.IsGameOver)
        {
            return;
        }
        
        this._rigidBody2D.linearVelocityY = this._jumpPower;
    }

    public void SetPauseMode()
    {
        if (_isPausedMode) return;

        this._rigidBody2D.constraints = RigidbodyConstraints2D.FreezeAll;
        _savedVelocityY = this._rigidBody2D.linearVelocityY;
        _isPausedMode = true;
    }

    public void SetPlayMode()
    {
        if (_isPausedMode == false) return;

        this._rigidBody2D.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
        this._rigidBody2D.linearVelocityY = this._savedVelocityY;
        this._rigidBody2D.WakeUp();

        _isPausedMode = false;
    }
}
