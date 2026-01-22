using UnityEngine;

public class InfinityBackground : MonoBehaviour
{
    [SerializeField] private Sprite _bgSprite;
    [SerializeField] private float _moveSpeed = 2.0f;

    private InfinityBackgroundItem Current { get; set; } = new InfinityBackgroundItem();
    private InfinityBackgroundItem Next { get; set; } = new InfinityBackgroundItem();


    private void Start()
    {
        if (this._bgSprite == false)
        {
            return;
        }

        Current.Parent = this.transform;
        Next.Parent = this.transform;
    
        Current.Create(this._bgSprite);
        Next.Create(this._bgSprite);
    }

    private void Update()
    {
        if (this._bgSprite == false)
        {
            return;
        }

        Current.PosX -= this._moveSpeed * Time.deltaTime * (GameParams.Instance.IsPause ? 0 : 1) * GameParams.Instance.GameSpeed;
        Next.PosX = Current.RightSideX;

        float rightSideX = Current.GetRightScreenX(Camera.main);
        if (rightSideX <= 0) this.Swap();
    }

    private void Swap()
    {
        InfinityBackgroundItem temp = Current;
        Current = Next;
        Next = temp;
    }
}
