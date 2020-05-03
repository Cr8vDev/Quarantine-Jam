using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStack : MonoBehaviour
{
    private List<Transform> stackPositions = new List<Transform>();
    private int nextBlockToStackOn = 0;

    private List<Transform> stackedObjects = new List<Transform>();

    [SerializeField]
    private Transform resetPosition;



    private void Awake()
    {
        stackPositions.Add(transform);

        for(int i = 0; i < transform.childCount; ++i)
        {
            stackPositions.Add(transform.GetChild(i));
        }
    }



    public Transform GetPeakItem()
    {
        return stackedObjects[stackedObjects.Count - 1].GetChild(1);
    }



    public int GetStackObjectsCount()
    {
        return stackedObjects.Count;
    }



    public void Stack(Transform addObject)
    {
        stackedObjects.Add(addObject);

        addObject.position = stackPositions[nextBlockToStackOn].position;

        nextBlockToStackOn++;
    }



    public void Pop()
    {
        if (stackedObjects.Count > 0)
        {
            stackedObjects[GetStackObjectsCount() - 1].GetComponent<StackItem>().RemoveFromStack();

            stackedObjects[GetStackObjectsCount() - 1].position = resetPosition.position;

            stackedObjects.RemoveAt(GetStackObjectsCount() - 1);

            nextBlockToStackOn--;
        }
    }
}
