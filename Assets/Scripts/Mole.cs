using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : MonoBehaviour
{
    public float HoleToUpTime;
    public float IdleToDownTime;

    Animator m_anim;
    bool HoleToUpStarted = false;
    bool IdleToDownStarted = false;

    public bool Hit()
    {
        if (m_anim.GetCurrentAnimatorStateInfo(0).IsName("Up") || m_anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            m_anim.SetTrigger("isHit");
            return true;
        }
        else
        {
            return false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // get the animator component
        m_anim = GetComponent<Animator>();
        StartCoroutine(waitForUp());
    }

    // Update is called once per frame
    void Update()
    {
        //if (m_anim.GetCurrentAnimatorStateInfo(0).IsName("Hole") && !HoleToUpStarted)
        //{
        //    HoleToUpStarted = true;
        //    StartCoroutine(waitForUp());
        //}
        //if (m_anim.GetCurrentAnimatorStateInfo(0).IsName("Up"))
        //{
        //    HoleToUpStarted = false;
        //}
        //if (m_anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") && !IdleToDownStarted)
        //{
        //    IdleToDownStarted = true;
        //    StartCoroutine(waitForDown());
        //}
        //if (m_anim.GetCurrentAnimatorStateInfo(0).IsName("Down"))
        //{
        //    IdleToDownStarted = false;
        //}

    }

    IEnumerator waitForUp()
    {
        while(true)
        {
            yield return new WaitForSeconds(HoleToUpTime);
            m_anim.SetTrigger("getUp");
            m_anim.ResetTrigger("getDown");
            yield return new WaitForSeconds(IdleToDownTime);
            m_anim.SetTrigger("getDown");
        }
    }
        

    IEnumerator waitForDown()
    {
        yield return new WaitForSeconds(IdleToDownTime);
        m_anim.SetTrigger("getDown");
    }
}