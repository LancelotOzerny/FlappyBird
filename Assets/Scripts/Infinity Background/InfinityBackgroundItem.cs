using UnityEngine;

public class InfinityBackgroundItem
{
    public Transform Parent { get; set; }
    private GameObject CurrentObj { get; set; }
    private SpriteRenderer SpriteRenderer { get; set; }

    public float RightSideX
    {
        get => SpriteRenderer.bounds.max.x + SpriteRenderer.bounds.size.x / 2;
    }

    public float PosX
    {
        get
        {
            return CurrentObj.transform.position.x;
        }
        set
        {
            CurrentObj.transform.position = new Vector2(
                value,
                CurrentObj.transform.position.y
            );
        }
    }

    public void Create(Sprite sprite)
    {
        CurrentObj = new GameObject();
        CurrentObj.transform.parent = Parent;
        SpriteRenderer sr = CurrentObj.AddComponent<SpriteRenderer>();
        this.SpriteRenderer = sr;
        sr.sprite = sprite;
    }

    public float GetRightScreenX(Camera camera)
    {
        float rightWorldX = SpriteRenderer.bounds.max.x;

        Vector3 objCoords = new Vector3(
            rightWorldX,
            CurrentObj.transform.position.y,
            CurrentObj.transform.position.z
        );

        return camera.WorldToScreenPoint(objCoords).x;
    }

}
