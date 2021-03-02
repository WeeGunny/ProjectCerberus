using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopkeeperController : MonoBehaviour
{
    public Animator anim;
    private float animationDelay = 5f;

    private int randInt;
    private bool isAnimating;

    void start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        animationDelay -= Time.deltaTime;

        if (animationDelay <= 0f && !isAnimating)
        {
            isAnimating = true;
            randInt = Random.Range(0, 3);
            switch (randInt)
            {
                case 0:
                    Animation1();
                    break;
                case 1:
                    Animation2();
                    break;
                case 2:
                    Animation3();
                    break;
                default: break;
            }
        }

        if (anim.GetBool("isTalking"))
        {
            isAnimating = true;
        }

        if (!anim.GetBool("isTalking"))
        {
            isAnimating = false;
        }
    }

    void Animation1()
    {
        animationDelay = 10f;
        anim.SetTrigger("Foot");
        isAnimating = false;
    }

    void Animation2()
    {
        animationDelay = 8f;
        anim.SetTrigger("Happy");
        isAnimating = false;
    }

    void Animation3()
    {
        animationDelay = 6f;
        anim.SetTrigger("Head");
        isAnimating = false;
    }
}
