using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public static Sound instance;
    [SerializeField] private AudioClip attackPlayer, enemybullet, dash, skill1, skil2, skill0 , attackEnemy;
    // Start is called before the first frame update

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

    }
    public void PlayerBullet()
    {
        AudioSource.PlayClipAtPoint(attackPlayer, transform.position);
    }
    public void PlayerSkill0()
    {
        AudioSource.PlayClipAtPoint(skill0, transform.position);
    }
    public void EneemyBullet()
    {
        AudioSource.PlayClipAtPoint(enemybullet, transform.position);
    }
    public void SkillPlayer1()
    {
        AudioSource.PlayClipAtPoint(skill1, transform.position);
    }
    public void dashh()
    {
        AudioSource.PlayClipAtPoint(dash, transform.position);
    }
    public void Skillplayer2()
    {
        AudioSource.PlayClipAtPoint(skil2, transform.position);
    }
   
}
