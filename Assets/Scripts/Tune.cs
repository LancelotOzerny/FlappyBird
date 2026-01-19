using UnityEngine;

public class Tune : MonoBehaviourExt
{
    [SerializeField] private float _moveSpeed = 1.0f;
    [SerializeField] private float _yPosRandInterval = 2.0f;

    private void Start()
    {
        TransformPosY = Random.Range(TransformPosY - _yPosRandInterval, TransformPosY + _yPosRandInterval);
    }

    private void Update()
    {
        TransformPosX -= Time.deltaTime * _moveSpeed * (GameParams.Instance.IsPause ? 0 : 1);
        if (TransformPosX < -16f)
        {
            this.Destroy();
        }
    }
}
