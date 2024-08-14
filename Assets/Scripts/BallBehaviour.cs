using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
   [SerializeField] private Transform respawnPoint;

   [SerializeField] private Transform ballPrefab;

   private AudioSource audioSource;

   [SerializeField] private AudioClip racketBounceAudioClip;
   [SerializeField] private AudioClip tableBounceAudioClip;
   private NewControls inputControls;


   private void Start()
   {
      audioSource = GetComponent<AudioSource>();

      inputControls = new NewControls();
      inputControls.Newactionmap.BallRespawn.Enable();
   }



   private void Update()
   {
      if (inputControls.Newactionmap.BallRespawn.ReadValue<float>() > 0.5f)
      {
         Instantiate(ballPrefab, respawnPoint.position, Quaternion.identity);
         Destroy(gameObject);
      }
   }


   private void OnCollisionEnter(Collision collision)
   {
      if (collision.gameObject.CompareTag("Table"))
      {
         PlayBouncingAudio(collision, tableBounceAudioClip);
      }
      else if (collision.gameObject.CompareTag("Racket"))
      {
         PlayBouncingAudio(collision, racketBounceAudioClip);
      }
   }

   private void PlayBouncingAudio(Collision collision, AudioClip audioClip)
   {
      float relativeVelocitySqrMagnitude = collision.relativeVelocity.sqrMagnitude;

      float volumeMultiplier = 0.025f;
      float audioSourceVolume = Mathf.Clamp01(relativeVelocitySqrMagnitude * volumeMultiplier);
      audioSource.volume = audioSourceVolume;

      float pitchMultiplier = 0.0025f;
      float audioSourcePitch = 0.90f + (relativeVelocitySqrMagnitude * pitchMultiplier);
      audioSource.pitch = audioSourcePitch;

      audioSource.clip = audioClip;
      audioSource.Play();

      // Debug.Log("relativeVelocitySqrMagnitude = " + relativeVelocitySqrMagnitude);
      // Debug.Log("audioSourceVolume = " + audioSourceVolume);
      // Debug.Log("audioSourcePitch = " + audioSourcePitch);
      // Debug.Log("-------------------------");
   }
}
