using System.Collections;
using UnityEngine;

public class MeltingIce : MonoBehaviour
{
    
    private bool isFlameActive = false;
    public GameObject stemObject;
    public Material iceMat;
    public GameObject waterPrefab;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == stemObject && GameObject.FindWithTag("Flame") != null)
        {
            
            isFlameActive = true;
            StartCoroutine(FondreGlacon());
            
        }
    }

    IEnumerator FondreGlacon()
    {
        float tempsDeFondre = 10.0f;
        float tempsTotal = 0f;

        float meltingInitialValue = 0.0f;
        float meltingFinalValue = 2.0f;

        while (tempsTotal < tempsDeFondre)
        {
            float proportion = tempsTotal / tempsDeFondre;

            // Interpolation linéaire pour ajuster progressivement les valeurs
            float newMeltingValue = Mathf.Lerp(meltingInitialValue, meltingFinalValue, proportion);

            // Appliquer les nouvelles valeurs au matériau du glaçon
            iceMat.SetFloat("_Melting", newMeltingValue);

            yield return null;
            tempsTotal += Time.deltaTime;
        }

        // Remettre la propriété de fonte à 0 après la fonte complète
        iceMat.SetFloat("_Melting", 0.0f);

        // Détruire l'objet Ice si la flamme est toujours active
        if (isFlameActive)
        {
            // enlever le son du feu
            stemObject.GetComponent<StemInteraction>().ExtinguishFire();
            Destroy(gameObject);
            // Augmenter l'échelle de l'objet "Flaque d'eau"
            if (waterPrefab != null)
            {
                Vector3 newScale = waterPrefab.transform.localScale * 1.25f; // Ajustez la valeur 1.5f selon vos besoins
                waterPrefab.transform.localScale = newScale;
            }
        }
    }
}
