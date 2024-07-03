using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Gamemana : MonoBehaviour
{
   
   
   
    public void OnClickBackButton()
    {
        // Thực hiện hành động khi click nút "Quay lại"
        // Ví dụ: tải lại màn chơi
        SceneManager.LoadScene("MainScene"); // Thay thế "MainScene" bằng tên màn chơi bạn muốn tải
    }
}

