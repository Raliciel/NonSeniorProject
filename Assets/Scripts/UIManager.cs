using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class UIManager : MonoBehaviour
{

    public void Open() { gameObject.SetActive(true); }

    public void Close() { gameObject.SetActive(false);}

}
