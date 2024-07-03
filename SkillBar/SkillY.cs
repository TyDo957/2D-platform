using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillY : MonoBehaviour
{
    [SerializeField] private Image ImageCoolDown;
    [SerializeField] private float CoolDown;
    private bool isCoolDown;
    // Start is called before the first frame update
    void Update()
    {
        this.ImageSkillBar();
    }
    public void ImageSkillBar()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            isCoolDown = true;
        }
        if (isCoolDown)
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
