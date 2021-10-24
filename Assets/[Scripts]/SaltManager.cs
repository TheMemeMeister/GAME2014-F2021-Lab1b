using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaltManager : MonoBehaviour
{
    public SaltFactory saltFactory;
    public int MaxSalt;

    private Queue<GameObject> m_saltpool;


    // Start is called before the first frame update
    void Start()
    {
        _BuildSaltPool();
    }

    private void _BuildSaltPool()
    {
        // create empty Queue structure
        m_saltpool = new Queue<GameObject>();

        for (int count = 0; count < MaxSalt; count++)
        {
            var tempSalt = saltFactory.createSalt();
            m_saltpool.Enqueue(tempSalt);
        }
    }

    public GameObject GetSalt(Vector3 position)
    {
        var newSalt = m_saltpool.Dequeue();
        newSalt.SetActive(true);
        newSalt.transform.position = position;
        return newSalt;
    }

    public bool HasSalt()
    {
        return m_saltpool.Count > 0;
    }

    public void ReturnSalt(GameObject returnedBullet)
    {
        returnedBullet.SetActive(false);
        m_saltpool.Enqueue(returnedBullet);
    }
}