using UnityEngine;

public class sondManager : MonoBehaviour
{
    public AudioClip[] sound;
    public AudioSource a;
    public void pudgeDis()
    {
        a.clip = sound[0];
            a.Play();
         }
    public void sfTaunt()
    {
        a.clip = sound[1];
                a.Play();
             }
     public void sfReq()
     {
         a.clip = sound[2];
                 a.Play();
              }
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    // Update is called once per frame
    void Update()
    {
        
    }
}
