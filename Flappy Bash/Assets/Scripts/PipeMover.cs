using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PipeMover : MonoBehaviour
{
    [SerializeField] Transform topTube;
    [SerializeField] Transform bottomTube;

    [SerializeField] float offset = 2;

    bool ready = true;

    [SerializeField] ParticleSystem bashVFX;
    Pipe pipeInfo;
    CrushZone cz;
    // Start is called before the first frame update
    void Start()
    {
        pipeInfo = GetComponent<Pipe>();
        cz = GetComponentInChildren<CrushZone>();
    }

    public void Crush()
    {
        if (!ready) return;
        ready = false;
        StartCoroutine(CrushCoroutine());
    }

    IEnumerator CrushCoroutine()
    {
        cz.CrushAll(pipeInfo.animTime);
        float topY = topTube.position.y - offset;
        float botY = bottomTube.position.y + offset;
        topTube.DOLocalMoveY(topY, pipeInfo.animTime)
            .SetLoops(2, LoopType.Yoyo).SetEase(Ease.InQuad);
        bottomTube.DOLocalMoveY(botY, pipeInfo.animTime)
            .SetLoops(2, LoopType.Yoyo).SetEase(Ease.InQuad);
        yield return new WaitForSeconds(pipeInfo.animTime);
        GetComponent<AudioSource>().Play();
        bashVFX.Play();
        // трубы сомкнуты
        yield return new WaitForSeconds(pipeInfo.animTime);
        ready = true;
    }


}
