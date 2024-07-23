using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

public class Button : MonoBehaviour
{
    public GameObject ThongTinWeapon;
    public void OnButtonClicked()
    {
        // Khi Button được nhấn
        if (ThongTinWeapon != null)
        {
            // Ẩn Canvas ngay lập tức
            ThongTinWeapon.SetActive(false);
        }
    }
}