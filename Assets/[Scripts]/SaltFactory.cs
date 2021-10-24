using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class SaltFactory : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Salt Types")]
    public GameObject normalSalt;
    public GameObject BigSalt;
    public GameObject NoseSalt; //speedy gonzalas

    public GameObject createSalt(saltType type = saltType.normalSalt)
    {
        if (type == saltType.normalSalt)
        {
            var randomSalt = Random.Range(0, 3);
            type = (saltType)randomSalt;
        }

        GameObject tempSalt = null;
        switch (type)
        {
            case saltType.normalSalt:
                tempSalt = Instantiate(normalSalt);
                tempSalt.GetComponent<SaltController>().damage = 10;
                break;
            case saltType.BigSalt:
                tempSalt = Instantiate(BigSalt);
                tempSalt.GetComponent<SaltController>().damage = 20;
                break;
            case saltType.NoseSalt:
                tempSalt = Instantiate(NoseSalt);
                tempSalt.GetComponent<SaltController>().damage = 30;
                break;
        }

        tempSalt.transform.parent = transform;
        tempSalt.SetActive(false);

        return tempSalt;
    }
}
