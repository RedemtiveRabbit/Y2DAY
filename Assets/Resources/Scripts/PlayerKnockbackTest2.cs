using System.Collections;
using UnityEngine;

public class PlayerKnockbackTest2 : MonoBehaviour
{
    public float knockbackTime = 0.2f;
    public float hitDirectionForce = 10f;
    public float constantForce = 5f;
    public float inputForce = 7.5f;

    private Rigidbody2D rb2d;

    private Coroutine knockbackCoroutine;

    public bool isBeingKnockedBack { get; private set; }

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    public IEnumerator KnockbackAction(Vector2 hitDirection, Vector2 constantForceDirection, float inputdirection)
    {
        isBeingKnockedBack = true;

        Vector2 _hitForce;
        Vector2 _constantForce;
        Vector2 _knockbackForce;
        Vector2 _combinedForce;

        _hitForce = hitDirection * hitDirectionForce;
        _constantForce = constantForceDirection * constantForce;

        float _elapsedTime = 0f;
        while (_elapsedTime < knockbackTime)
        {
            //iterate the timer
            _elapsedTime += Time.fixedDeltaTime;

            // combine _hitForce and _constantForce
            _knockbackForce = _hitForce + _constantForce;

            //combine knockbackForce with inputForce
            if (inputdirection != 0)
            {
                _combinedForce = _knockbackForce + new Vector2 (inputdirection, 0f);
            }
            else
            {
                _combinedForce = _knockbackForce;
            }

            //Apply knockback
            rb2d.linearVelocity = _combinedForce;

                yield return new WaitForFixedUpdate();
        }

        isBeingKnockedBack = false;
    }
    public void Callknockback(Vector2 hitDirection, Vector2 constantForceDirection, float inputdirection)
    {
        knockbackCoroutine = StartCoroutine(KnockbackAction(hitDirection, constantForceDirection, inputdirection));
    }
}
