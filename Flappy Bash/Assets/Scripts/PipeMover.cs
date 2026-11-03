using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PipeMover : MonoBehaviour
{
    [SerializeField] Transform topTube;
    [SerializeField] Transform bottomTube;

    [SerializeField] float animTime = 0.4f;
    [SerializeField] float offset = 2;
    [SerializeField] int hp = 2;

    bool ready = true;

    [SerializeField] ParticleSystem bashVFX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public int GetHP() { return hp; }

    public void Crush()
    {
        if (!ready) return;
        ready = false;
        StartCoroutine(CrushCoroutine());
    }

    IEnumerator CrushCoroutine()
    {
        float topY = topTube.position.y - offset;
        float botY = bottomTube.position.y + offset;
        topTube.DOLocalMoveY(topY, animTime)
            .SetLoops(2, LoopType.Yoyo).SetEase(Ease.InQuad);
        bottomTube.DOLocalMoveY(botY, animTime)
            .SetLoops(2, LoopType.Yoyo).SetEase(Ease.InQuad);
        yield return new WaitForSeconds(animTime);
        GetComponent<AudioSource>().Play();
        bashVFX.Play();
        // трубы сомкнуты
        yield return new WaitForSeconds(animTime);
        ready = true;
    }


}
