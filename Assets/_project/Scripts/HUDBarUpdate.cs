using System;
using NUnit.Framework;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.Linq.Expressions;
public class HUDBarUpdate : MonoBehaviour
{
    public Image fillBar;
    public TextMeshProUGUI fillBarText;
    public bool showMaxValue = false;
    
    private float maxVal;
    private float Val;
    public enum BarType { SP , MP, HP };
    public BarType TypeOfBar;


    public GameObject player;
    private SPSystem staminaSys;
    private HealthSystem healthSys;
    private ManaSystem manaSys;
    private void Awake()
    {
        staminaSys = player.GetComponent<SPSystem>();
        healthSys = player.GetComponent<HealthSystem>();
        manaSys = player.GetComponent<ManaSystem>();
        
             switch (TypeOfBar)
            {
                case (BarType.HP):
                    maxVal = healthSys.HP;
                    break;
                case (BarType.SP):
                    maxVal = staminaSys.SP;

                    break;
                case (BarType.MP):
                    maxVal = manaSys.MP;
                    break;
            }
        
       
           
    }
    private void FixedUpdate()
    {
        switch (TypeOfBar)
        {
            case (BarType.HP):
                Val = healthSys.HP;
                UpdateField();
                break;
            case (BarType.SP):
                Val = staminaSys.SP;
                UpdateField();
                break;
            case (BarType.MP):
                Val = manaSys.MP;
                UpdateField();
                break;

        }

        
    }

    private void UpdateField()
    {
        
        fillBar.fillAmount = Mathf.Clamp(Val / maxVal, 0f, 1f);
        if (showMaxValue)
            fillBarText.text = TypeOfBar.ToString() + $" {(int)Val}/{(int)maxVal}";
        else fillBarText.text = TypeOfBar.ToString() + $" {(int)Val}";
    }
  /*  [CustomEditor(typeof(HUDBarUpdate))]
    public class Player_Editor : Editor
    {
        public override void OnInspectorGUI()
        {
            var script = (HUDBarUpdate)target;
            script.fillBar = EditorGUILayout.ObjectField(script.fillBar, typeof(Image), true) as Image;
            script.fillBarText = EditorGUILayout.ObjectField(script.fillBarText, typeof(TextMeshProUGUI), true) as TextMeshProUGUI;
            script.TypeOfBar = (BarType)EditorGUILayout.EnumPopup(script.TypeOfBar) ;
            switch (script.TypeOfBar)
            {     
                case (BarType.HP):
                    script.healthSys = EditorGUILayout.ObjectField(script.healthSys, typeof(HealthSystem), true) as HealthSystem;
                    script.staminaSys = null;
                    script.manaSys = null;
                    break ;
                    
                case (BarType.SP):
                    script.staminaSys = EditorGUILayout.ObjectField(script.staminaSys, typeof(SPSystem), true) as SPSystem;
                    script.manaSys = null;
                    script.healthSys = null;
                    break ;
                
                case (BarType.MP):
                    script. manaSys = EditorGUILayout.ObjectField(script. manaSys, typeof(ManaSystem), true) as ManaSystem;
                    script.staminaSys = null;
                    script.healthSys = null;
                    break;
            }
        }
    }*/
}
