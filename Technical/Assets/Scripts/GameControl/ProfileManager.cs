using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

[System.Serializable]
public class TextGroupShow
{
    public Text txtTenTiengAnh;
    public Text txtThucAn;
    public Text txtKhuVucSong;
    public Text txtKichThuoc;
    public Text txtTrongLuong;
    public Text txtTuoiTho;
    public Text txtThongTinKhac;
}

//[System.Serializable]
//public class ProfileData
//{
//    public string TenTiengAnh;
//    public string ThucAn;
//    public string KhuVucSong;
//    public string KichThuoc;
//    public string TrongLuong;
//    public string TuoiTho;
//    public string ThongTinKhac;
//}
public class ProfileManager : MonoBehaviour {

    public TextGroupShow groupTextProfile;

    //[SerializeField]
    private AnimalInfo currProfileData;

    public Transform content;
    public Transform txtNoTrackable;

	// Use this for initialization
	void Start () {
        
	}

    /// <summary>
    /// Show thong tin cua con vat
    /// tham so:
    /// </summary>
    public void ShowProfile()
    {
        string currAnimalName = GameController.Instance.GetNameAnimalCurrent();
        Debug.Log(".................."+currAnimalName);
        if (currAnimalName == "" && txtNoTrackable)
        {
            txtNoTrackable.gameObject.SetActive(true);
            content.gameObject.SetActive(false);
            return;
        }
        else
        {
            content.gameObject.SetActive(true);
            txtNoTrackable.gameObject.SetActive(false);
            currProfileData = GameData.Instance.GetAnimalInfo(currAnimalName);
        }
        if(currProfileData == null)
        {
            return;
        }

        groupTextProfile.txtTenTiengAnh.text = "Tên Tiếng Anh:"+currProfileData.nameEng;
        groupTextProfile.txtThucAn.text = "Loại:" + currProfileData.loai;
        groupTextProfile.txtKhuVucSong.text = "Khu Vực Sống:" + currProfileData.khuVucSong;
        groupTextProfile.txtKichThuoc.text = "Kích thước:" + currProfileData.kichThuoc;
        groupTextProfile.txtTrongLuong.text = "Trọng Lượng:" + currProfileData.trongLuong;
        groupTextProfile.txtTuoiTho.text = "Tuổi Thọ:" + currProfileData.tuoiTho;
        groupTextProfile.txtThongTinKhac.text = "Thông Tin Khác:" + currProfileData.thongTin;
    }
	
}
