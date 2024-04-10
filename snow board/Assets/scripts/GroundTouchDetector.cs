using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTouchDetector : MonoBehaviour
{
    [SerializeField] ParticleSystem snowParticle;

    Rigidbody2D rb;
    ParticleSystem.EmissionModule emissionModule;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        emissionModule = snowParticle.emission;
    }
    // Start is called before the first frame update
    void Update()
    {
        Vector3 velocity = rb.velocity;
        float speed = velocity.magnitude;
        emissionModule.rateOverTime = speed*5;

    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            snowParticle.Play();
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            snowParticle.Stop();
        }
    }
}
