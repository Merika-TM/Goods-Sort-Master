using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeItem : MonoBehaviour
{
    private const float FadeDuration = 0.7f;
    
    private Image _image;
    private Color _originalColor;

    void Start()
    {
        _image = GetComponent<Image>();
        _originalColor = _image.color;
    }

    public void StartFade()
    {
        StartCoroutine(FadeOut());
    }
    
    private IEnumerator FadeOut()
    {
        float currentTime = 0.0f;

        while (currentTime < FadeDuration)
        {
            float alpha = Mathf.Lerp(1.0f, 0.0f, currentTime / FadeDuration);
            _image.color = new Color(_originalColor.r, _originalColor.g, _originalColor.b, alpha);

            currentTime += Time.deltaTime;
            yield return null;
        }

        _image.color = new Color(_originalColor.r, _originalColor.g, _originalColor.b, 0.0f);
        Destroy(gameObject);  // Optional: نابود کردن گیم آبجکت بعد از محو شدن کامل
    }
}
