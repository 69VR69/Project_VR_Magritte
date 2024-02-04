using System.Collections;
using UnityEngine;

public class FireOff : MonoBehaviour
{
    public Material fireMat;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ice"))
        {
            StartCoroutine(DesactiverFeuProgressif());
        }
    }

    IEnumerator DesactiverFeuProgressif()
    {
        float tempsDeFading = 3.0f;
        float tempsTotal = 0f;

        float fadePowerFinal = 5.0f;
        float fadeScaleFinal = -1.37f;

        while (tempsTotal < tempsDeFading)
        {
            float proportion = tempsTotal / tempsDeFading;

            // Interpolation linéaire pour ajuster progressivement les valeurs
            float newFadePower = Mathf.Lerp(0.38f, fadePowerFinal, proportion);
            float newFadeScale = Mathf.Lerp(3.0f, fadeScaleFinal, proportion);

            // Appliquer les nouvelles valeurs au matériau
            fireMat.SetFloat("_FadePower", newFadePower);
            fireMat.SetFloat("_FadeScale", newFadeScale);

            yield return null;
            tempsTotal += Time.deltaTime;
        }

        // Désactiver le GameObject une fois la boucle terminée
        gameObject.SetActive(false);
    }
}
