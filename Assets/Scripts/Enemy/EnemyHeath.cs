using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyHeath : MonoBehaviour
{
    //Máu max
    public int MaxHeath;
    //Máu hiện tại
    int HealthCurrent;
    //Tham chiếu thanh máu
    public Slider HeathSlider;
    // Start is called before the first frame update
    void Start()
    {
        HealthCurrent = MaxHeath;
        HeathSlider.maxValue = MaxHeath;
        HeathSlider.value = MaxHeath;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Bị tấn công
    public void addDame(int Damage)
    {
        HealthCurrent -= Damage;
        HeathSlider.value = HealthCurrent;
        if(HealthCurrent<=0)
        {
            makeDead();
        }    
    }    
    // Khi enemy chết
    void makeDead()
    {
        Destroy(gameObject);
    }    
}
