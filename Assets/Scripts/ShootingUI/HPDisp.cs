using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HPDisp : MonoBehaviour
{
    public HPComponent hpComponent;
    TextMeshProUGUI tmpro;
    // Start is called before the first frame update
    void Start()
    {
        tmpro=GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        tmpro.text = $"HP:{hpComponent.HP}";
    }
}
