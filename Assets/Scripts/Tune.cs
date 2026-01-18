using UnityEngine;

public class Tune : MonoBehaviourExt
{
    [SerializeField] private float _moveSpeed = 1.0f;

    private void Update()
    {
        TransformPosX -= Time.deltaTime * _moveSpeed * (GameParams.Instance.IsPause ? 0 : 1);
        if (TransformPosX < -16f)
        {
            this.Destroy();
        }
    }
}
