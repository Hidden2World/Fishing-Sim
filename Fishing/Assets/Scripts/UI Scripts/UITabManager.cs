using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Call _ChangeTab() to switch to the selected UI Page.
/// This is done by setting all pageContainers as Inactive, then set the selected pageContainer as Active.
/// (Functions that are meant to be called by a UI element (e.g. a button) are preceded with "_" to make them stand out when selected in Unity Inspector.)
/// </summary>
public class UITabManager : MonoBehaviour
    //naomi
{
    [Tooltip("Select any number of UI GameObjects containing the page UI elements.")]
    public GameObject[] pageContainers;

    public void _ChangeTab(GameObject pageContainerToSwitchTo)
    {
        foreach (GameObject pageContainer in pageContainers)
        {
            pageContainer.SetActive(false);
        }

        pageContainerToSwitchTo.SetActive(true);
    }
}
