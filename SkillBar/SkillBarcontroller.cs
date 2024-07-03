using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillBarcontroller : MonoBehaviour
{
    [SerializeField] private Image ImageCoolDown;
    [SerializeField] private float CoolDown;
    private bool isCoolDown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.ImageSkillBar();
    }
    public void ImageSkillBar()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1)) 
        {
            isCoolDown = true;
        }
        if(isCoolDown)
        {
            ImageCoolDown.fillAmount += 1 / CoolDown * Time.deltaTime;

            if (ImageCoolDown.fillAmount >= 1)
            {
                ImageCoolDown.fillAmount = 0;
                isCoolDown = false;
            }
        }
       
    }
}
