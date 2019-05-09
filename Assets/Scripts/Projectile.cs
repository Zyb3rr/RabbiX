using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    private float speed = 0.5f;
    private SpriteRenderer sr;
    private AudioSource audioSource;


 private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }
      


    void Update()
    {

        transform.Translate(Vector3.down * speed * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Floor")
        {
            StartCoroutine(Break());
        }

    }

    private IEnumerator Break()
    {
        audioSource.Play();
        sr.enabled = false;

        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
    }

}
