using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelManagerScript : MonoBehaviour
{
    [SerializeField] int thingsToFind;
    [SerializeField] int thingsFound;

    [SerializeField] TextMeshProUGUI text;

    [SerializeField] int level;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (thingsFound >= thingsToFind)
        {
            Debug.Log("COMPLETED LEVEL");
        }
    }
    
    public void ThingFound()
    {
        thingsFound++;
        text.text = (thingsToFind - thingsFound).ToString();
    }
}
