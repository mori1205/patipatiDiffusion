using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartParticle : MonoBehaviour
{
  [SerializeField]
  [Tooltip("whiteBall")]
  private ParticleSystem particle1;

  [SerializeField]
  [Tooltip("yellowBall")]
  private ParticleSystem particle2;

  [SerializeField]
  float sec = 0f;

  private void OnCollisionEnter(Collision collision)
  {
    
    // 当たった相手が"Player"タグを持っていたら
    if (collision.gameObject.tag == "Player")
    { 
      //音を再生
      
      // パーティクルシステムのインスタンスを生成する。
      ParticleSystem newParticle1 = Instantiate(particle1);
      ParticleSystem newParticle2 = Instantiate(particle2);
      // パーティクルの発生場所をこのスクリプトをアタッチしているGameObjectの場所にする。
      newParticle1.transform.position = this.transform.position;
      newParticle2.transform.position = this.transform.position;
      // パーティクルを発生させる。
      newParticle1.Play();
      newParticle2.Play();
      // インスタンス化したパーティクルシステムのGameObjectを5秒後に削除する。(任意)
      // ※第一引数をnewParticleだけにするとコンポーネントしか削除されない。
      Destroy(newParticle1.gameObject, sec);
      Destroy(newParticle2.gameObject, sec);


    }
  }
}