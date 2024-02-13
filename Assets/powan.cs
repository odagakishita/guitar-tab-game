using DG.Tweening;
using UnityEngine;

// 波紋作成クラス
public class powan : MonoBehaviour
{
    // 波紋のSpriteRenderer
    // Unityエディタで設定
    [SerializeField]
    SpriteRenderer sr;

    // スタートメソッド    
    void Start()
    {
        // シーケンス作成
        var sequence = DOTween.Sequence();
        /*
         * ・2秒間で大きさを2倍にする
         * transform.DOScale(new Vector3(2f, 2f, 2f), 2f)
         * ・1秒間で透明度を50/100にする(半透明にする)
         * sr.DOFade(0.5f, 1f)
         * ・1秒間で透明度を0/100にする(透明にする)
         * sr.DOFade(0f, 1f)
         */
        
        sequence.Append(transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 1f))
            .Join(sr.DOFade(0.5f, 1f).OnComplete(() => { sr.DOFade(0f, 1f); }));

        //Tween t = sequence.Append(transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 1f))
        //    .Join(sr.DOFade(0.5f, 1f).OnComplete(() => { sr.DOFade(0f, 1f); }));
        //SpriteRenderer hamon = Instantiate(sr, new Vector3(50, 2, 10), Quaternion.identity);
    }
    
}
