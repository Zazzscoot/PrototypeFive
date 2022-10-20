using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float xRange = 4;
    private float ySpawnPos = -6;
    private float maxTorque = 10;
    private GameManager gameManager;
    public int pointValue;
    public ParticleSystem explosionParticle;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(randomVelocity() , ForceMode.Impulse);
        targetRb.AddTorque(randomTorque(), randomTorque(), randomTorque(), ForceMode.Impulse);
        transform.position = randomPosition();

    }
    void OnMouseDown()
    {
        Destroy(gameObject);
        gameManager.UpdateScore(pointValue);
        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    Vector3 randomVelocity()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    float randomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }
    Vector3 randomPosition()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos, 0);
    }
}
