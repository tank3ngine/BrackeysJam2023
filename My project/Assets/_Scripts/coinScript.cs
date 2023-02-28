using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinScript : MonoBehaviour
{
    [SerializeField] public int laneNum;
    [SerializeField] public float speed;
    [SerializeField] private SpriteRenderer SR;

    [SerializeField] private Sprite bronzeCoinSprite;
    [SerializeField] private Sprite silverCoinSprite;
    [SerializeField] private Sprite goldCoinSprite;


    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(0, 0, 0);

        SR = transform.GetComponent<SpriteRenderer>();
        if (gameObject.CompareTag("BronzeCoin"))
        {
            SR.sprite = bronzeCoinSprite;
            speed = -2.5f;
        }
        if (gameObject.CompareTag("SilverCoin"))
        {
            SR.sprite = silverCoinSprite;
            speed = -4f;
        }
        if (gameObject.CompareTag("GoldCoin"))
        {
            SR.sprite = goldCoinSprite;
            speed = -5.5f;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x < 1)
        {
            transform.localScale += new Vector3(0 + 0.05f, 0 + 0.05f, 0 + 0.05f);
        }

        transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime);
        if (transform.position.y < -6)
        {
            Destroy(gameObject);
        }
    }
}
