using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Validation : MonoBehaviour
{
    public GameObject _validationUI;
    public Maison _maison;
    public FermeBouton _ferme;
    public Chateau _chateau;
    public TMP_Text textMeshPro;    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CliqueValidation()
    {
        _validationUI.SetActive(false);
    }
    public void PhraseValidationMaison()
    {
        textMeshPro.text="Bravo vous venez d'acheter "+_maison._nbMaisonsAchete+" Maison";
    }
    public void PhraseValidationFerme()
    {
        textMeshPro.text="Bravo vous venez d'acheter "+_ferme._nbFermeAchete+" Ferme";
    }
    public void PhraseValidationChateau()
    {
        textMeshPro.text="Bravo vous venez d'acheter "+_chateau._nbChateauAchete+" Chateau";
    }
}
