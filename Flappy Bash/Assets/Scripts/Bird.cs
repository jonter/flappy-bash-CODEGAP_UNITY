using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bird : MonoBehaviour, IDamagable
{
    [SerializeField] ParticleSystem deathVFX;

    public void Grab(float t)
    {
        GetComponent<BirdMovement>().enabled = false;
        transform.DOMoveY(0, t).SetEase(Ease.InQuad).SetDelay(t / 5);
        StartCoroutine(GrabCoroutine(t));
    }

    IEnumerator GrabCoroutine(float t)
    {
        yield return new WaitForSeconds(t / 3);
        GetComponentInChildren<Animator>().speed = 2;
        yield return new WaitForSeconds(t / 3);
        transform.DOScaleY(0.3f, t / 3);
    }

    private void OnDisable()
    {
        transform.DOKill();
    }

    public void Kill()
    {
        deathVFX.transform.parent = null;
        deathVFX.transform.localScale = new Vector3(1, 1, 1);
        Color c = GetComponentInChildren<SpriteRenderer>().color;
        var main = deathVFX.main;
        main.startColor = c;
        deathVFX.Play();
        Destroy(deathVFX.gameObject, 2);
        // сыграть эффект вылета перьев и заспаунить кости
        Destroy(gameObject);
    }
}
