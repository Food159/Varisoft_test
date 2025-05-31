using UnityEngine;
using TMPro;

public class PlayerHP : MonoBehaviour
{
    private int maxHp = 15;
    public TMP_Text hpAmountTxt;
    public int hp;
    public GameObject bloodPrefab;
    private void Start()
    {
        hp = maxHp;
        hpAmountTxt.text = "HP : " + hp.ToString();
    }
    private void Update()
    {
        if (hp <= 0)
        {
            GameObject prefab = Instantiate(bloodPrefab);
            prefab.transform.position = this.transform.position;
            Destroy(prefab, 0.5f);
        }
        if (hp >= maxHp) 
        {
            hp = maxHp;
        }
        else if(hp <= 0)
        {
            hp = 0;
            gameObject.SetActive(false);
        }
        hpAmountTxt.text = "HP : " + hp.ToString();
    }
}
