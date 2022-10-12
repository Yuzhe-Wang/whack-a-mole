using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game : MonoBehaviour
{
    public AudioClip bunkSound;
    public AudioClip thudSound;
    public TextMeshProUGUI m_text;

    AudioSource m_audio;
    int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        m_audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // for mouse
            Vector2 inputMouse = Input.mousePosition;
            Ray mouseRay = Camera.main.ScreenPointToRay(inputMouse);
            RaycastHit2D hitMouse = Physics2D.Raycast(mouseRay.origin, mouseRay.direction);
            if (hitMouse)
            {
                GameObject hitObj = hitMouse.collider.gameObject;
                bool found = false;
                for (int i = 0; i < 9; ++i)
                {
                    Transform curr = transform.GetChild(i);
                    if (curr.gameObject == hitObj)
                    {
                        Mole m = curr.gameObject.GetComponent<Mole>();
                        if (m.Hit())
                        {
                            found = true;
                            counter += 1;
                            string temp = "Score: " + counter.ToString();
                            m_text.SetText(temp);
                            m_audio.PlayOneShot(bunkSound);
                        }
                    }
                }
                if (!found)
                {
                    m_audio.PlayOneShot(thudSound);
                }
            }
            else
            {
                m_audio.PlayOneShot(thudSound);
            }
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            // for touch
            Vector2 inputTouch = Input.GetTouch(0).position;
            Ray touchRay = Camera.main.ScreenPointToRay(inputTouch);
            RaycastHit2D hitTouch = Physics2D.Raycast(touchRay.origin, touchRay.direction);
            if (hitTouch)
            {
                GameObject hitObj = hitTouch.collider.gameObject;
                for (int i = 0; i < 9; ++i)
                {
                    Transform curr = transform.GetChild(i);
                    if (curr.gameObject == hitObj)
                    {
                        Mole m = curr.gameObject.GetComponent<Mole>();
                        if (m.Hit())
                        {
                            counter += 1;
                            string temp = "Score: " + counter.ToString();
                            m_text.SetText(temp);
                            m_audio.PlayOneShot(bunkSound);
                        }
                    }
                }
                m_audio.PlayOneShot(thudSound);
            }
            else
            {
                m_audio.PlayOneShot(thudSound);
            }
        }
    }
}
