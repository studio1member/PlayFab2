using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombo : MonoBehaviour
{
    private PlayerStatus playerStatus;
    private float hitChange = 1, timerDelay, rangeHit = 1f;
    private Transform hitPoint;
    private bool displayRangeHit = false;
    private void Awake()
    {
        this.playerStatus = transform.root.GetComponent<PlayerStatus>();
        foreach (Transform t in playerStatus.transform) if (t.name == "Hit Point") hitPoint = t.transform;
        displayRangeHit = true;
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.J) && timerDelay <= 0) Hits();
        if (timerDelay > 0) timerDelay -= Time.deltaTime;
    }
    private void Hits()
    {
        if(this.hitChange == 1)
        {
            StartCoroutine(_Hit1());
            this.playerStatus.Anim.SetTrigger("HitTr");
            this.playerStatus.Anim.SetFloat("Hit", hitChange);
            this.hitChange = 2;
            timerDelay = 0.25f;
        }
        else if(this.hitChange == 2)
        {
            StartCoroutine(_Hit2());
            this.playerStatus.Anim.SetTrigger("HitTr");
            this.playerStatus.Anim.SetFloat("Hit", hitChange);
            this.hitChange = 3;
            timerDelay = 0.2f;
        }
        else if(this.hitChange == 3)
        {
            StartCoroutine(_Hit3());
            this.playerStatus.Anim.SetTrigger("HitTr");
            this.playerStatus.Anim.SetFloat("Hit", hitChange);
            this.hitChange = 1;
            timerDelay = 0.25f;
        }
    }
    private IEnumerator _Hit1()
    {
        yield return new WaitForSeconds(0.1f);
        Collider2D[] hits = Physics2D.OverlapCircleAll(this.hitPoint.position, this.rangeHit, this.playerStatus.enemy);
        foreach (Collider2D hit in hits) { if (hit.gameObject != this.playerStatus.gameObject) { hit.GetComponent<Status>()._Damage_Recived(10f); } }
    }
    private IEnumerator _Hit2()
    {
        yield return new WaitForSeconds(0.1f);
        Collider2D[] hits = Physics2D.OverlapCircleAll(this.hitPoint.position, this.rangeHit, this.playerStatus.enemy);
        foreach (Collider2D hit in hits) { if (hit.gameObject != this.playerStatus.gameObject) { hit.GetComponent<Status>()._Damage_Recived(10f); } }
    }
    private IEnumerator _Hit3()
    {
        yield return new WaitForSeconds(0.1f);
        Collider2D[] hits = Physics2D.OverlapCircleAll(this.hitPoint.position, this.rangeHit, this.playerStatus.enemy);
        foreach (Collider2D hit in hits) { if (hit.gameObject != this.playerStatus.gameObject) { hit.GetComponent<Status>()._Damage_Recived(10f); } }
    }
    private void OnDrawGizmos()
    {
        if (!displayRangeHit) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(hitPoint.position, this.rangeHit);

    }
}
