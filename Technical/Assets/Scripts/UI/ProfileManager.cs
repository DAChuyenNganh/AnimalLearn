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

[System.Serializable]
public class ProfileData
{
    public string TenTiengAnh;
    public string ThucAn;
    public string KhuVucSong;
    public string KichThuoc;
    public string TrongLuong;
    public string TuoiTho;
    public string ThongTinKhac;
}
public class ProfileManager : MonoBehaviour {
    public TextGroupShow groupTextProfile;

    private Dictionary<string, ProfileData> dicData = new Dictionary<string, ProfileData>();
    [SerializeField]
    private ProfileData currProfileData;
	// Use this for initialization
	void Start () {
        ShowProfile();
	}

    /// <summary>
    /// Show thong tin cua con vat
    /// tham so:
    /// </summary>
    public void ShowProfile()
    {
        if(currProfileData == null)
        {
            return;
        }
        groupTextProfile.txtTenTiengAnh.text = "Tên Tiếng Anh:"+currProfileData.TenTiengAnh;
        groupTextProfile.txtThucAn.text = "Loại:" + currProfileData.ThucAn;
        groupTextProfile.txtKhuVucSong.text = "Khu Vực Sống:" + currProfileData.KhuVucSong;
        groupTextProfile.txtKichThuoc.text = "Kích thước:" + currProfileData.KichThuoc;
        groupTextProfile.txtTrongLuong.text = "Trọng Lượng:" + currProfileData.TrongLuong;
        groupTextProfile.txtTuoiTho.text = "Tuổi Thọ:" + currProfileData.TuoiTho;
        groupTextProfile.txtThongTinKhac.text = "Thông Tin Khác:" + currProfileData.ThongTinKhac;
    }
	
    public ProfileData GetDatafromName(string name)
    {
        if(dicData.ContainsKey(name))
        {
            return dicData[name];
        }
#if UNITY_EDITOR
        Debug.Log("KHONG CO TEN NAY TRONG DICTIONARY");
#endif
        return null;
    }
	// Update is called once per frame
	void Update () {
	
	}
}
