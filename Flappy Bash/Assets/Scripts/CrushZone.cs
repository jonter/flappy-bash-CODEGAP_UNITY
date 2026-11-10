using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrushZone : MonoBehaviour
{
    List<IDamagable> zoneObjects = new List<IDamagable>();

    bool action = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (action == true) return;
        IDamagable obj = collision.GetComponent<IDamagable>();
        if (obj == null) return;
        zoneObjects.Add(obj);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (action == true) return;
        IDamagable obj = collision.GetComponent<IDamagable>();
        if (obj == null) return;
        zoneObjects.Remove(obj);
    }

    public void CrushAll(float t)
    {
        action = true;
        foreach(IDamagable el in zoneObjects)
            el.Grab(t);

        StartCoroutine(KillAllCoroutine(t));
    }

    IEnumerator KillAllCoroutine(float t)
    {
        yield return new WaitForSeconds(t);
        foreach (IDamagable el in zoneObjects)
            el.Kill();
        zoneObjects.Clear();
        action = false;
        // вызвать событие, сколько птичек мы убили
    }

}
