
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScript : MonoBehaviour
{

   
    //　パーティクルシステム
    private ParticleSystem ps;
    //　ScaleUp用の経過時間
    private float elapsedScaleUpTime = 0f;
    //　Scaleを大きくする間隔時間
    [SerializeField]
    private float scaleUpTime = 0.03f;
    //　ScaleUpする割合
    [SerializeField]
    private float scaleUpParam = 0.3f;
    //　パーティクル削除用の経過時間
    private float elapsedDeleteTime = 0f;
    //　パーティクルを削除するまでの時間
    [SerializeField]
    private float deleteTime = 5f;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        
    }

    // Update is called once per frame
    void Update()
    {
        elapsedScaleUpTime += Time.deltaTime;
        elapsedDeleteTime += Time.deltaTime;

        if (elapsedDeleteTime >= deleteTime)
        {
            Destroy(gameObject);
        }

        if (elapsedScaleUpTime > scaleUpTime)
        {
            transform.localScale += new Vector3(scaleUpParam, scaleUpParam, scaleUpParam);
            elapsedScaleUpTime = 0f;
        }
    }

    public void OnParticleTrigger()
    {

        if (ps != null)
        {

            //　Particle型のインスタンス生成
            List<ParticleSystem.Particle> inside = new List<ParticleSystem.Particle>();
            List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();

            //　Inside、Enterのパーティクルを取得
            int numInside = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Inside, inside);
            int numEnter = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
            //　データがあればキャラクターに接触した
            

            //　わかりやすくキャラクターと接触したパーティクルの色を赤に変更
            for (int i = 0; i < numInside; i++)
            {
                ParticleSystem.Particle p = inside[i];
                p.startColor = new Color32(255, 0, 0, 255);
                inside[i] = p;
            }

            for (int i = 0; i < numEnter; i++)
            {
                ParticleSystem.Particle p = enter[i];
                p.startColor = new Color32(255, 0, 0, 255);
                enter[i] = p;
            }

            //　パーティクルデータの設定
            ps.SetTriggerParticles(ParticleSystemTriggerEventType.Inside, inside);
            ps.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
        }
    }
}
