using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ImaginationUnlocker : MonoBehaviour
{
    #region [SerializeField] public float imaginationUnlockedAt

    /// <summary>
    /// TODO
    /// </summary>
    [Tooltip("TODO")]
    [Range(0, 1f)]
    public float imaginationUnlockedAt;

    #endregion

    #region [SerializeField] public GameObject unlockedVariant { get; }

    [SerializeField]
    [Tooltip("Set unlocked variant.")]
    private GameObject _unlockedVariant;

    /// <summary>
    /// Set unlocked variant.
    /// </summary>
    public GameObject unlockedVariant => _unlockedVariant;

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
        if (imagination >= imaginationUnlockedAt)
        {
            gameObject.SetActive(false);
            unlockedVariant.SetActive(true);
        }
    }


}
