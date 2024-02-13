using DG.Tweening;
using UnityEngine;

public class HamonScript : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer sr;

    private bool animationPlaying = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!animationPlaying)
            {
                StartAnimation();
            }
            else
            {
                ResetAnimation();
            }
        }
    }

    private void StartAnimation()
    {
        animationPlaying = true;
        transform.localScale = Vector3.zero;
        sr.color = Color.clear;

        var sequence = DOTween.Sequence();
        sequence.Append(transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 1f))
            .Join(sr.DOFade(0.5f, 1f))
            .Append(sr.DOFade(0f, 1f))
            .OnComplete(() =>
            {
                ResetAnimation();
            });
    }

    private void ResetAnimation()
    {
        animationPlaying = false;
        transform.localScale = Vector3.one;
        sr.color = Color.white;
    }
}
