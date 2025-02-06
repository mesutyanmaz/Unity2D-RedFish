using DG.Tweening;
using UnityEngine;
using System;

public class Fish : MonoBehaviour
{
    private Fish.FishType type;
    private CircleCollider2D coll;
    private SpriteRenderer rend;
    private float screenLeft;
    private Tweener tweener;

    public Fish.FishType Type
    {
        get { return type; }
        set
        {
            type = value;
            coll.radius = type.colliderRadius;
            rend.sprite = type.sprite;
        }
    }

    private void Awake()
    {
        coll = GetComponent<CircleCollider2D>();
        rend = GetComponentInChildren<SpriteRenderer>();
        screenLeft = Camera.main.ScreenToWorldPoint(Vector3.zero).x;

    }

    public void ResetFish()
    {
        if (tweener != null)   //wait for past animation
            tweener.Kill(false);

        float num1 = UnityEngine.Random.Range(type.minLength, type.maxLength);
        coll.enabled = true;

        Vector3 position = transform.position; //make position
        position.x = screenLeft;
        position.y = num1;
        transform.position = position;

        float num2 = 1f;  // target location
        float y = UnityEngine.Random.Range(num1 - num2, num1 + num2);
        Vector2 vTarget = new Vector2(-position.x, y);

        float num3 = 3f;
        float delay = UnityEngine.Random.Range(0, 2 * num3);
        // yoyo move up-down ,in num3second, at constant speed, with delay 
        tweener = transform.DOMove(vTarget, num3, false).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear).SetDelay(delay).OnStepComplete(delegate
        {
            Vector3 localScale = transform.localScale; //come back
            localScale.x = -localScale.x;
            transform.localScale = localScale;
        });
    }

    public void Hooked()
    {
        coll.enabled = false;
        tweener.Kill(false);
    }

    [Serializable]
    public class FishType //fishtype object's attribute
    {
        public int price;
        public float fishCount;
        public float minLength;
        public float maxLength;
        public float colliderRadius;
        public Sprite sprite;
    }
}
