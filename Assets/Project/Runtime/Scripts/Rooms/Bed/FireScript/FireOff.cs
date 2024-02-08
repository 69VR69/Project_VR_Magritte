using System.Collections;

using UnityEngine;

public class FireOff : MonoBehaviour
{
    public Material fireMat;
    public GameObject spawnerFire;

    /// <summary>
    /// Lorsque le feu entre en collision avec la glace, le feu s'éteint progressivement
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ice"))
        {
            StartCoroutine(DesactiverFeuProgressif());
        }
    }
    /// <summary>
    /// Désactive progressivement le feu
    /// </summary>
    IEnumerator DesactiverFeuProgressif()
    {
        float tempsDeFading = 10.0f;
        float tempsTotal = 0f;

        float fadePowerInitial = 0.56f;
        float fadeScaleInitial = -3.9f;

        float fadePowerFinal = 5.0f;
        float fadeScaleFinal = -1.37f;
        
        // Faire varier les valeurs du matériau pour éteindre progressivement le feu
        while (tempsTotal < tempsDeFading)
        {
            float proportion = tempsTotal / tempsDeFading;
            float newFadePower = Mathf.Lerp(fadePowerInitial, fadePowerFinal, proportion);
            float newFadeScale = Mathf.Lerp(fadeScaleInitial, fadeScaleFinal, proportion);
            fireMat.SetFloat("_FadePower", newFadePower);
            fireMat.SetFloat("_FadeScale", newFadeScale);
            yield return null;
            tempsTotal += Time.deltaTime;
        }

        // Rétablir les valeurs initiales du matériau
        fireMat.SetFloat("_FadePower", fadePowerInitial);
        fireMat.SetFloat("_FadeScale", fadeScaleInitial);

        // Détruire l'objet SpawnerFire et ses enfants
        Destroy(spawnerFire);
    }
}
