using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardFlip : MonoBehaviour
{
    private SpriteRenderer rend;

    [SerializeField]
    private Sprite faceSprite, backSprite;

    private bool coroutineAllowed, facedUp;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        rend.sprite = backSprite;
        coroutineAllowed = true;
        facedUp = false;
    }

    private void OnMouseDown()
    {
        if (coroutineAllowed)
        {
            StartCoroutine(RotateCard());
        }
    }

    private IEnumerator RotateCard()
    {
        yield return null;
    }
}
