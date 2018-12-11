using UnityEngine;
using System.Collections.Generic;


public class ObjectPool : MonoBehaviour
{
    public GameObject prefab;
    private Stack<GameObject> inactiveInstances = new Stack<GameObject>();

    // Returns an instance of the prefab
    public GameObject GetObject()
    {
        GameObject spawnedGameObject;

        if (inactiveInstances.Count > 0){
            spawnedGameObject = inactiveInstances.Pop();
        }  
       else{
            spawnedGameObject = (GameObject)GameObject.Instantiate(prefab);

            // add the PooledObject component to the prefab so we know it came from this pool
            PooledObject pooledObject = spawnedGameObject.AddComponent<PooledObject>();
            pooledObject.pool = this;
        }

        spawnedGameObject.transform.SetParent(null);
        spawnedGameObject.SetActive(true);

        return spawnedGameObject;
    }

    // Return an instance of the prefab to the pool
    public void ReturnObject(GameObject toReturn)
    {
        PooledObject pooledObject = toReturn.GetComponent<PooledObject>();

        // if the instance came from this pool, return it to the pool
        if (pooledObject != null && pooledObject.pool == this){
           
            toReturn.transform.SetParent(transform);
            toReturn.SetActive(false);

            inactiveInstances.Push(toReturn);
        }else{
            Debug.LogWarning(toReturn.name + " was returned to a pool it wasn't spawned from! Destroying.");
            Destroy(toReturn);
        }
    }
}

// a component that simply identifies the pool that a GameObject came from
public class PooledObject : MonoBehaviour
{
    public ObjectPool pool;
}