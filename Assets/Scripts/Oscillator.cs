using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPos;
    [SerializeField] Vector3 movementVector;
    [SerializeField] [Range(0,1)] float movementFactor;
    [SerializeField] float period = 2f;
    void Start()
    {
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon) return;
        float cycles = Time.time / period; //gittikce buyuyen bir deger, periyot buyurse cycles kuculuyor

        const float tau = Mathf.PI * 2; //2pi yani 360 dereceyi kapsýyor
        float rawSinWave = Mathf.Sin(cycles * tau);

        movementFactor = (rawSinWave + 1) / 2; // 0 ile 1 arasi oldu simdi
        

        Debug.Log(rawSinWave);

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPos + offset;
    }
}
