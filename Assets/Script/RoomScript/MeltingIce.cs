using System.Collections;
using UnityEngine;

public class MeltingIce : MonoBehaviour
{
    private bool isFlameActive = false;
    private bool hasStartedMelting = false;
    private bool waterSoundPlayed = false;
    public GameObject stemObject;
    public Material iceMat;
    public GameObject waterPrefab;
    public AudioClip waterSound;
    private AudioSource waterAudioSource;

    private void Start()
    {
        waterAudioSource = gameObject.AddComponent<AudioSource>();
        waterAudioSource.clip = waterSound;  
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == stemObject && GameObject.FindWithTag("Flame") != null)
        {
            isFlameActive = true;

            if (!hasStartedMelting)
            {
                StartCoroutine(FondreGlacon());
                hasStartedMelting = true;
            }
        }
    }

    IEnumerator FondreGlacon()
    {
        Debug.Log("FondreGlacon");
        float tempsDeFondre = 12.0f;
        float tempsTotal = 0f;

        float meltingInitialValue = 0.0f;
        float meltingFinalValue = 2.0f;

        while (tempsTotal < tempsDeFondre)
        {
            float proportion = tempsTotal / tempsDeFondre;

            float newMeltingValue = Mathf.Lerp(meltingInitialValue, meltingFinalValue, proportion);

            iceMat.SetFloat("_Melting", newMeltingValue);

            yield return null;
            tempsTotal += Time.deltaTime;
        }

        

        Debug.Log("Son du feu eteint");
        stemObject.GetComponent<StemInteraction>().ExtinguishFire();

        if (waterPrefab != null && !waterSoundPlayed)
        {
            Vector3 newScale = waterPrefab.transform.localScale * 1.25f;
            waterPrefab.transform.localScale = newScale;

            if (waterAudioSource != null && waterSound != null)
            {   
                Debug.Log("Son de l'eau");
                waterAudioSource.Play();

                while (waterAudioSource.isPlaying)
                {
                    yield return null;
                }

                waterSoundPlayed = true;
            }
        }
        iceMat.SetFloat("_Melting", 0.0f);
        Destroy(gameObject);
    }
}
