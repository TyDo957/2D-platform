using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flasl : MonoBehaviour
{
    public float flashDuration = 1f; // Thời gian flash
    public Color flashColor = Color.white; // Màu flash

    public CanvasGroup canvasGroup;
    private Shader shader;
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>(); // Lấy CanvasGroup component
        shader = GetComponent<Shader>();
    }

    public void FlashScreen()
    {
        StartCoroutine(FlashCoroutine());
    }

    IEnumerator FlashCoroutine()
    {
        canvasGroup.alpha = 1; // Hiển thị image

        yield return new WaitForSeconds(flashDuration); // Đợi thời gian flash

        canvasGroup.alpha = 0; // Ẩn image
    }
}



