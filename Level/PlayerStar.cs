using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

using UnityEngine.UI;

public class PlayerStar : MonoBehaviour
{
    public float xp;
    public float LvlUpRequireement;
    public int level;
    public float xpmutiler;
    public float requimentIncrease;
    public Slider sliderr;
    public Text  texl;
    public void gainxp(float gainexp)
    {
        xp += gainexp * (1 + xpmutiler);    
        if(xp >= LvlUpRequireement)
        {
            levelup();
        }
    }
   public void levelup()
    {
        level += 1;
        LvlUpRequireement += requimentIncrease;

        requimentIncrease += 50;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

      if(sliderr != null)
        {
            sliderr.maxValue = xp;
            sliderr.value = LvlUpRequireement;
            
        }

        texl.text = LvlUpRequireement.ToString();
    }
}
