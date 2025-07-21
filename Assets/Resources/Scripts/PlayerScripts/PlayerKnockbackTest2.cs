using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerKnockbackTest2 : MonoBehaviour
{
    public bool knockbackinatingE = false;
    public float knockBackStrengthE;
    public float knockBackTimeE;
    public Rigidbody2D body;
    Vector2 lastDir = Vector2.zero;
    float horizontal;
    float vertical;

    //public AI_Chase AIChase;
    public void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        //print(knockbackinatingE);
    }
    void FixedUpdate()
    {
        

    }
    IEnumerator KnockBackRoutine(Vector2 dir)
    {
        /*print("knockbacking");
        if (AIChase.body.linearVelocityY > 0)
        {
            knockbackinatingE = true;
            print("doopity dooobity doo");
            body.linearVelocityY = knockBackStrengthE;
            yield return new WaitForSeconds(knockBackTimeE);
            knockbackinatingE = false;
        }
        if (AIChase.body.linearVelocityX > 0)
        {
            knockbackinatingE = true;
            print("doopity dooobity daa");

            body.linearVelocityX = knockBackStrengthE;
            yield return new WaitForSeconds(knockBackTimeE);
            knockbackinatingE = false;
        }
        if (AIChase.body.linearVelocityY < 0)
        {
            knockbackinatingE = true;
            print("doopity dooobity dee");

            body.linearVelocityY = -knockBackStrengthE;
            yield return new WaitForSeconds(knockBackTimeE);
            knockbackinatingE = false;
        }
        if (AIChase.body.linearVelocityX < 0)
        {
            knockbackinatingE = true;
            print("doopity dooobity duu");

            body.linearVelocityX = -knockBackStrengthE;
            yield return new WaitForSeconds(knockBackTimeE);
            knockbackinatingE = false;
        }
        //body.linearVelocity = dir * knockBackStrengthE;*/

        //Debug.Log("running");
        knockbackinatingE = true;
        //print(knockBackStrengthE * AIChase.lastMoveDirEnemy);
        //lastDir = AIChase.lastMoveDirEnemy;
        lastDir = dir.normalized;
        //lastDir.x = (lastDir.x) / Mathf.Abs(lastDir.x);
        //lastDir.y = (lastDir.y) / Mathf.Abs(lastDir.y);
        //print(AIChase.lastMoveDirEnemy);
        body.AddForceAtPosition(knockBackStrengthE * lastDir, this.transform.position,  ForceMode2D.Impulse);
        yield return new WaitForSeconds(knockBackTimeE);
        knockbackinatingE = false;

    }
    public void Knockback(Vector2 dir)
    {
        
        StartCoroutine(KnockBackRoutine(dir));
    }
}
