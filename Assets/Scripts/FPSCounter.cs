using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    public generateSquad squadGenerator; // Ajouter une r�f�rence au script generateSquad
    public GameObject tmp;
    public float updateInterval = 0.5f; // Le taux de rafra�chissement de l'affichage en secondes
    private float deltaTime = 0.0f;
    private float nextUpdate = 0.0f; // Le temps auquel l'affichage sera mis � jour
    private int enemyCount = 0; // Le nombre total d'unit�s ennemies

    private void Start()
    {
        squadGenerator = tmp.GetComponent<generateSquad>();
    }

    void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;

        // Si le temps actuel est sup�rieur � nextUpdate
        if (Time.unscaledTime > nextUpdate)
        {
            // Mettre � jour nextUpdate
            nextUpdate = Time.unscaledTime + updateInterval;

            // Mettre � jour le nombre d'unit�s ennemies
            enemyCount = 0;
            foreach (var squad in squadGenerator.squads)
            {
                enemyCount += squad.Count;
            }
        }
    }

    void OnGUI()
    {
        int w = Screen.width, h = Screen.height;

        GUIStyle style = new GUIStyle();

        Rect rect = new Rect(0, 0, w, h * 2 / 100);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 2 / 100;
        style.normal.textColor = new Color(0.0f, 0.0f, 0.5f, 1.0f);
        float msec = deltaTime * 1000.0f;
        float fps = 1.0f / deltaTime;

        string text = string.Format("{0:0.0} ms ({1:0.} fps) {2} ennemies", msec, fps, enemyCount);
        GUI.Label(rect, text, style);
    }
}
