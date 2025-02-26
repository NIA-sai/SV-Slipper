using UnityEngine;

public class Letterboxing : MonoBehaviour
{
    private float targetAspect = 128f / 72f;
    private Camera mainCamera;
    private int lastWidth, lastHeight;

    void Start()
    {
        mainCamera = Camera.main;
        lastWidth = Screen.width;
        lastHeight = Screen.height;
        AdjustViewport();
    }

    void Update()
    {
        // 如果屏幕尺寸发生变化，重新调整视口
        if (Screen.width != lastWidth || Screen.height != lastHeight)
        {
            lastWidth = Screen.width;
            lastHeight = Screen.height;
            AdjustViewport();
        }
    }

    void AdjustViewport()
    {
        // 获取当前屏幕的宽高比
        float currentAspect = (float)Screen.width / Screen.height;

        // 计算缩放因子
        float scaleHeight = currentAspect / targetAspect;
        float scaleWidth = targetAspect / currentAspect;

        if (scaleHeight <= 1.0f)
        {
            // 如果高度需要缩放，添加水平黑边
            mainCamera.rect = new Rect(0, (1.0f - scaleHeight) / 2.0f, 1.0f, scaleHeight);
        }
        else
        {
            // 如果宽度需要缩放，添加垂直黑边
            mainCamera.rect = new Rect((1.0f - scaleWidth) / 2.0f, 0, scaleWidth, 1.0f);
        }
    }
}
