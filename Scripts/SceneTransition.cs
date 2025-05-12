using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class SceneTransition : MonoBehaviour
{
    public Image transitionImage;
    public float transitionSpeed = 1f;
    public Color transitionColor = Color.black;
    public float autoClearDelay = 2f;
    public UnityEvent onShowComplete;
    public UnityEvent onClearComplete;

    private bool isTransitioning = false;
    public bool isStartShow = true;

    private void Start()
    {
        if (transitionImage != null)
        {
            transitionImage.color = new Color(transitionColor.r, transitionColor.g, transitionColor.b, 0f);
        }
        if (isStartShow)
        {
            Show();
        }
    }

    public void Show()
    {
        if (!isTransitioning && transitionImage != null)
        {
            isTransitioning = true;
            StartCoroutine(PerformShow());
        }
    }

    public void Clear()
    {
        if (!isTransitioning && transitionImage != null)
        {
            isTransitioning = true;
            StartCoroutine(PerformClear());
        }
    }

    private System.Collections.IEnumerator PerformShow()
    {
        float alpha = 0f;
        while (alpha < 1f)
        {
            alpha += Time.deltaTime * transitionSpeed;
            alpha = Mathf.Clamp01(alpha);
            transitionImage.color = new Color(transitionColor.r, transitionColor.g, transitionColor.b, alpha);
            yield return new WaitForSeconds(Time.deltaTime * transitionSpeed);
        }
        isTransitioning = false;
        onShowComplete.Invoke();
        yield return new WaitForSeconds(autoClearDelay);
        Clear();
    }

    private System.Collections.IEnumerator PerformClear()
    {
        float alpha = 1f;
        while (alpha > 0f)
        {
            alpha -= Time.deltaTime * transitionSpeed;
            alpha = Mathf.Clamp01(alpha);
            transitionImage.color = new Color(transitionColor.r, transitionColor.g, transitionColor.b, alpha);
            yield return null;
        }
        isTransitioning = false;
        onClearComplete.Invoke();
    }
}