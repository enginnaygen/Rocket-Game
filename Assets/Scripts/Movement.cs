using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    AudioSource audioSource;
    [SerializeField] float thrustPower = 1000;
    [SerializeField] float rotationPower = 1000;
    [SerializeField] AudioClip thrustSFX;
    [SerializeField] ParticleSystem sideParticleRight, sideParticleLeft, mainEngineParticle;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartThrusting();

        }
        else
        {
            StopThrrusting();
        }
    }

    

    private void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * Time.deltaTime * thrustPower);

        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(thrustSFX);

        }
        if (!mainEngineParticle.isPlaying)
        {

            mainEngineParticle.Play();
        }
    }

    private void StopThrrusting()
    {
        audioSource.Stop();
        mainEngineParticle.Stop();
    }



    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.D))
        {
            TurnRight();
        }

        else if (Input.GetKey(KeyCode.A))
        {
            TurnLeft();
        }
        else
        {
            StopRotation();
        }
    }

    private void StopRotation()
    {
        sideParticleLeft.Stop();
        sideParticleRight.Stop();
    }

    private void TurnLeft()
    {
        ApplyRotation(-rotationPower);
        if (!sideParticleRight.isPlaying)
        {
            sideParticleRight.Play();

        }
    }

    private void TurnRight()
    {
        ApplyRotation(rotationPower);
        if (!sideParticleLeft.isPlaying)
        {
            sideParticleLeft.Play();

        }
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.back * Time.deltaTime * rotationThisFrame);
        rb.freezeRotation = false;
    }
}
