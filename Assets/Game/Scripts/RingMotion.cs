using UnityEngine;

public class RingMotion : MonoBehaviour
{
    public Transform[] rings;
    private float[] offset;
    private Vector3[] ringScale;
    private float[] timeSenceFlip;
    private void Start()
    {
        // Initialize the arrays
        ringScale = new Vector3[rings.Length];
        timeSenceFlip = new float[rings.Length];
        offset = new float[rings.Length];

        // set initial values to all that need it
        for (int i = 0; i < rings.Length; i++)
        {
            ringScale[i] = rings[i].localScale;

            //Sets the offset to be equal for each ring
            offset[i] = (Mathf.PI / rings.Length) * i;

            //Offsets each ring's time
            timeSenceFlip[i] = offset[i];
        }
    }

    void Update()
    {
        //Sets the ring's highest point to the top of the orb
        float stretch = transform.localScale.x / 2;
        for (int i = 0; i < rings.Length; i++)
        {
            //Resets the time after reaching the bottom peak
            // This prevents the rings from bouncing back up
            timeSenceFlip[i] += Time.deltaTime;
            if (timeSenceFlip[i] >= Mathf.PI)
            {
                timeSenceFlip[i] -= Mathf.PI;
            }

            //Move the ring
            float height = Mathf.Cos(timeSenceFlip[i]) * stretch;
            Vector3 shift = new Vector3(0, height, 0);
            rings[i].position = this.transform.position + shift;

            //Scale the ring
            float scale = Mathf.Sin(timeSenceFlip[i]);
            rings[i].localScale = ringScale[i] * scale;
        }
    }
}
