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
