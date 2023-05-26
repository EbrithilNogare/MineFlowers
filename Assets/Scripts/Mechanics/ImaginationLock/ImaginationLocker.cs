using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ImaginationLocker : MonoBehaviour
{
    #region [SerializeField] public GameObject lockedVariant { get; }

    [SerializeField]
    [Tooltip("Set unlocked variant.")]
    private GameObject _lockedVariant;

    /// <summary>
    /// Set unlocked variant.
    /// </summary>
    public GameObject lockedVariant => _lockedVariant;

    #endregion

    #region [SerializeField] public GameObject imaginationLevel { get; }

    [SerializeField]
    private GameObject _imaginationLevel;

    /// <summary>
    /// TODO
    /// </summary>
    public GameObject imaginationLevel => _imaginationLevel;

    #endregion

    private float imagination;

    private void OnTriggerStay(Collider other)
    {
        imagination = imaginationLevel.GetComponent<RealityAwareness>().awareness;
        if (imagination < lockedVariant.GetComponent<ImaginationUnlocker>().imaginationUnlockedAt)
        {
            gameObject.SetActive(false);
            lockedVariant.SetActive(true);
        }
    }
}
