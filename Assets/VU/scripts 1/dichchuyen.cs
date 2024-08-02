//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class DichChuyen : MonoBehaviour
//{
//    [SerializeField]  GameObject Cong;

//    // Start is called before the first frame update
//    void Start()
//    {
//        // Không có gì cần khởi tạo trong Start
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        // Kiểm tra nếu Cong không null trước khi thay đổi vị trí
//        if (Cong != null)
//        {
//            Transform diemDichChuyen = Cong.GetComponent<CongDichChuyen>().GetDiemDichChuyen();
//            if (diemDichChuyen != null)
//            {
//                transform.position = diemDichChuyen.position;
//            }
//        }
//    }

//    private void OnTriggerEnter2D(Collider2D collision)
//    {
//        // Kiểm tra nếu đối tượng va chạm có tag là "CongDichChuyen"
//        if (collision.CompareTag("CongDichChuyen"))
//        {
//            Cong = collision.gameObject;
//        }
//    }

//    private void OnTriggerExit2D(Collider2D collision)
//    {
//        // Kiểm tra nếu đối tượng va chạm có tag là "CongDichChuyen"
//        if (collision.CompareTag("CongDichChuyen"))
//        {
//            Cong = null;
//        }
//    }
//}
