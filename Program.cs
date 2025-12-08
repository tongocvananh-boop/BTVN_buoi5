using System.Data;
using System.Runtime.InteropServices;
using System.Xml.Serialization;
using BaiTapList;
List<int> lstNumber = new List<int> { 20, 81, 97, 63, 72, 11, 20, 15, 33, 15, 41, 20 };
Console.WriteLine($@"Danh sách ban đầu: {string.Join(" - ", lstNumber)}");

/* Tính tổng các số lớn hơn 50 trong danh sách
 Yêu cầu: Viết chương trình tính tổng các số trong lstNumber mà lớn hơn 50.*/

#region Cách tui làm (dùng class-lớp đối tượng)
 int index = lstNumber.FindIndex(lonHon50 => lonHon50 > 50);
 int kq1 = 0; // gán mặc định để tránh lỗi "Use of unassigned local variable"
 if (index != -1) // nếu có ít nhất 1 số > 50
    {
    // Tạo 1 list mới chỉ chứa các số > 50
    List<int> lstLonHon50 = new List<int>();
    foreach (int n in lstNumber)
        {
        if (n > 50)
            {
            lstLonHon50.Add(n);
            }
        }
    kq1 = BaiTapList_Method.TinhTongLonHon50(lstLonHon50.ToArray(),0);
    }

Console.WriteLine($@"Tổng các số lớn hơn 50 trong danh sách: {kq1}"); 
#endregion

#region Cách trên lớp
Func<int> tinhTongCacSoLonHon50 = () => //dùng Lambda để khai báo hàm mà không cần thông qua lớp đối tượng, hàm này không có tham số để nhập vào nên trình bày vậy đó
{
int tong = 0;
//process:
foreach (int n in lstNumber)
{
    if (n > 50)
    {
      tong += n;  
    }   
}
return tong;
};
//output
Console.WriteLine($@"Tổng các số lớn hơn 50 trong danh sách: {tinhTongCacSoLonHon50()}");

#endregion


/* Tìm vị trí đầu tiên của số 20 trong danh sách
 Yêu cầu: Viết chương trình để tìm vị trí đầu tiên của số 20 trong danh sách lstNumber.*/

#region 
Func<string> timViTriNguoiDungNhapVao = () =>
{
//input:
Console.WriteLine($@"Nhập vào số cần tìm trong lstNumber: ");
int soNDN = Convert.ToInt32(Console.ReadLine());
//process: dùng FindIndex + lambda để tìm vị trí đầu tiên
int index = lstNumber.FindIndex(x => x == soNDN);
string kq = "";
if (index == -1)
    {
      kq = $@"Không tìm thấy giá trị {soNDN} trong lstNumber";
    }
else
    {
      kq = $@"Vị trí đẩu tiên của {soNDN} trong lstNumber là {index}";   
    }    
return kq;
//output:
};
Console.WriteLine($@" {timViTriNguoiDungNhapVao()}");
#endregion


/*Đếm số phần tử lớn hơn 30
 Yêu cầu: Viết chương trình đếm số phần tử trong danh sách lstNumber mà lớn hơn 30.*/

#region 
//tìm số >30 rồi đếm => duyet list, so >30 cho vao list moi => dem lst.Count
Func<int> demSoLonHon30 = () =>
{
  int ketQuaDemSoLonHon30 = 0;
  int indexLonHon30 = lstNumber.FindIndex(lonHon30 => lonHon30 >30);
  if (indexLonHon30 != -1)
    {
        List<int> lstLonHon30 = new List<int>();
        foreach (int n in lstNumber)
        {
            if (n>30)
            {
                lstLonHon30.Add(n);
                ketQuaDemSoLonHon30 = lstLonHon30.Count(); 
            }
        }
    }
  return ketQuaDemSoLonHon30;
};
Console.WriteLine($@"Kết quả đếm số lớn hơn 30 là {demSoLonHon30()}");
#endregion


/*Tìm số lớn nhất trong danh sách
 Yêu cầu: Viết chương trình để tìm số lớn nhất trong lstNumber*/

#region 
 //duyet list tim so (foreach), neu A < B thi A=B 
Func<int> timSoLonNhat = ()  =>
{
  int kqSoLonNhat = 0;
  for (int soA = 0; soA < lstNumber.Count(); soA ++) //duyet vi tri tang dan roi in value, so sanh value, soA < soB thi soA = soB 
  {
    kqSoLonNhat = lstNumber[soA];
    foreach (int soB in lstNumber)
    {
      if (kqSoLonNhat < soB)
        {
          kqSoLonNhat = soB;
        } 
    }   
  }
  return kqSoLonNhat;
};
Console.WriteLine($@"Kết quả số lớn nhất là: {timSoLonNhat()}");
#endregion


/*Tính trung bình cộng của các số lẻ
Yêu cầu: Viết chương trình để tính trung bình cộng của các số lẻ trong danh sách lstNumber*/

#region 
//số lẻ không chia hết cho 2 + count các số lẻ mà tính thương và tổng hoặc xài tên_list.Average()
Func<double> trungBinhCongCacSoLe = () =>
{
  double kqTBCCSL = 0;
  List<int> lstCacSoLe = new List<int> ();
  foreach (int a in lstNumber)
    {
       if (a%2 != 0)
        {
            lstCacSoLe.Add(a);
            kqTBCCSL = lstCacSoLe.Average();
        } 
    }
  return kqTBCCSL;
};
Console.WriteLine($@"Kết quả TB cộng các số lẻ {trungBinhCongCacSoLe():N2}");
#endregion


/* In ra các số chẵn trong danh sách
 Yêu cầu: Viết chương trình để in ra tất cả các số chẵn trong lstNumber.*/

#region 
// duyệt danh sách tìm số chẵn cho vào list mới

Func<string> inDanhSachSoChan = () =>
{
  string kqIn = " ";
  List<int> lstSoChan = new List<int> ();
  foreach (int a in lstNumber)
    {
        if (a%2 ==0)
        {
           lstSoChan.Add(a);
           kqIn = String.Join(" - ", lstSoChan);
        }
    }

  return kqIn;
};
Console.WriteLine($@"Các số chẳn trong list: {inDanhSachSoChan()}");
#endregion


/* Tìm vị trí đầu tiên của số 20 trong danh sách
 Yêu cầu: Viết chương trình để tìm vị trí đầu tiên của số 20 trong danh sách lstNumber.*/

#region 
// "tìm vị trí" => duyệt index list[index] == 20

Func<string> timSo20DauTien = () =>
{
  string kqTimSo20DauTien = "";
  int index = lstNumber.FindIndex(x => x == 20);
  if (index == -1)
  {
    kqTimSo20DauTien = "Không có số 20";
  }
  else
  {
    kqTimSo20DauTien = "Vị trí đẩu tiên của số 20 là: " + index;
  }

  return kqTimSo20DauTien;
};
Console.WriteLine($@"{timSo20DauTien()}");
#endregion


/*Tìm số lượng phần tử bằng 15 trong danh sách
 Yêu cầu: Viết chương trình để đếm số lượng phần tử bằng 15 trong lstNumber.*/

#region C1
//duyệt danh sách tìm số 15 (foreach, tìm a=15, đếm, không cần bỏ vô list mới - đc hem ta) vả count => int
Func<int> soLuongPhanTu15 = () =>
{
int kqSoLuongPhanTu = 0;
int tong15 = 0;
foreach (int a in lstNumber)
    {
     if (a == 15)
        {
           tong15 += a;
           kqSoLuongPhanTu = tong15/15;
        }   
    }

return kqSoLuongPhanTu;
};
Console.WriteLine($@"Số lượng phần tử 15 trong lstNumber là: {soLuongPhanTu15()}");
#endregion
#region C2
Func<int> soLuongPhanTu15b = () =>
{
int kqSoLuongPhanTu = 0;
List<int> phanTu15 = new List<int> ();
foreach (int a in lstNumber)
    {
     if (a == 15)
        {
           phanTu15.Add(a);
           kqSoLuongPhanTu = phanTu15.Count; // đếm từ 1, còn index đếm từ 0
        }   
    }

return kqSoLuongPhanTu;
};
Console.WriteLine($@"Số lượng phần tử 15 trong lstNumber là: {soLuongPhanTu15b()}");
#endregion


/* Tính tổng các số nhỏ hơn 40
 Yêu cầu: Viết chương trình tính tổng các số trong danh sách lstNumber nhỏ hơn 40.*/

#region C1
//duyệt danh sách-foreach-, tìm phần tử <40, bỏ vô list mới, cộng lại.Total hay .Sum =)))
Func<int> tongCacSoNhoHon40 = () =>
{
  int kqTongCacSoNhoHon40 = 0;
  List<int> dsCacSoNhoHon40 = new List<int> ();
  foreach (int a in lstNumber)
    {
        if (a < 40)
        {
          dsCacSoNhoHon40.Add(a);
        }
    }
  foreach(int b in dsCacSoNhoHon40)
    {
        kqTongCacSoNhoHon40 += b;
    }

  return kqTongCacSoNhoHon40;  
};
Console.WriteLine($@"Tổng các số trong danh sách lstNumber nhỏ hơn 40
{tongCacSoNhoHon40()}");
#endregion
#region C2
Func<int> tongCacSoNhoHon40b = () =>
{
  int kqTongCacSoNhoHon40 = 0;
  List<int> dsCacSoNhoHon40 = new List<int> ();
  foreach (int a in lstNumber)
    {
        if (a < 40)
        {
          dsCacSoNhoHon40.Add(a);
          kqTongCacSoNhoHon40 += a;
        }
    }
  return kqTongCacSoNhoHon40;  
};
Console.WriteLine($@"Tổng các số trong danh sách lstNumber nhỏ hơn 40b
{tongCacSoNhoHon40b()}");
#endregion


/*Đếm số lượng các số chia hết cho 5
 Yêu cầu: Viết chương trình để đếm bao nhiêu số trong danh sách chia hết cho 5*/

#region 
//duyệt ds-foreach, tìm các số a % 5 == 0, count
Func<int> demCacSoChiaHetCho5 = () =>
{
  List<int> cacSoChiaHetCho5 = new List<int> ();
  foreach (int a in lstNumber)
    {
      if (a%5==0)
        {
          cacSoChiaHetCho5.Add(a);
        }
    }
return cacSoChiaHetCho5.Count; //miễn sao return lại đúng kiểu dữ liệu đã khai báo ở đầu
};
Console.WriteLine($@"Số trong danh sách chia hết cho 5 là: {demCacSoChiaHetCho5()}");
#endregion


/* Tạo danh sách mới chỉ chứa các số nhỏ hơn 50
 Yêu cầu: Viết chương trình để tạo một danh sách mới chỉ chứa các số nhỏ hơn 50 từ danh sách lstNumber.*/

#region C1
//duyệt ds lớn, tạo ds chỉ chứa các số nhỏ hơn 50, in ra
Func<string> dsCacSoNhoHon50 = () =>
{
  string kqdsCacSoNhoHon50 = "";
  List<int> cacSoNhoHon50 = new List<int> ();
  foreach (int a in lstNumber)
    {
        if (a < 50)
        {
          cacSoNhoHon50.Add(a);
        }
    }
  kqdsCacSoNhoHon50 = string.Join(" - ", cacSoNhoHon50);
  return kqdsCacSoNhoHon50;
};
Console.WriteLine($@"Danh sách mới chỉ chứa các số nhỏ hơn 50:
{dsCacSoNhoHon50()}");
#endregion
#region C2
Func<string> dsCacSoNhoHon50b = () =>
{
  List<int> cacSoNhoHon50 = new List<int> ();
  foreach (int a in lstNumber)
    {
        if (a < 50)
        {
          cacSoNhoHon50.Add(a);
        }
    }
  return string.Join(" - ", cacSoNhoHon50);

};
Console.WriteLine($@"Danh sách mới chỉ chứa các số nhỏ hơn 50b:
{dsCacSoNhoHon50b()}");
#endregion


//------------------------------------------------------------------------------------------------------------------------------------------------
/* lstStrings = ["apple", "banana", "orange", "kiwi", "mango", "pineapple", "grape", "melon"]*/
List<string> lstStrings = new List<string> { "apple", "banana", "orange", "kiwi", "mango", "pineapple", "grape", "melon" };

/*Tính độ dài của mảng
 Yêu cầu: Viết chương trình để đếm số phần tử trong mảng lstStrings.*/

//lstStrings.count thui
Console.WriteLine($@"Số phần tử trong mảng lstStrings là {lstStrings.Count()}");

/* In ra các chuỗi dài hơn 5 ký tự
 Yêu cầu: Viết chương trình để in ra các chuỗi trong lstStrings có độ dài lớn hơn 5 ký tự.*/

#region 
//tạo ds mới chứa các chuỗi có a.Length >5, duyệt foreach để đưa vào chuỗi mới, in ra chuỗi mới => string

Func<string> dsCacChuoiCoLengthHon5KyTu = () =>
{
  List<string> cacChuoiCoLengthHon5KyTu = new List<string> ();
  foreach (string a in lstStrings)
     {
         if (a.Length > 5)
         {
          cacChuoiCoLengthHon5KyTu.Add(a);
         }
     }
  Console.Write($@"Các chuỗi trong lstStrings có độ dài lớn hơn 5 ký tự là {cacChuoiCoLengthHon5KyTu.Count()}, cụ thể là: ");   
  return string.Join(" ~ ", cacChuoiCoLengthHon5KyTu); 
};
Console.WriteLine($@"{dsCacChuoiCoLengthHon5KyTu()}");
#endregion


/*Tìm chuỗi dài nhất trong mảng
 Yêu cầu: Viết chương trình để tìm chuỗi có độ dài lớn nhất trong mảng lstStrings.*/

#region 
//duyệt list từng index a, cho lstString[a] so sánh với b.Length, cái nào dài hơn thỉ cho nó bằng kqChuoiDaiNhat
Func<string> timChuoiDaiNhat = () =>
{
  string kqChuoiDaiNhat = "";
  for (int a = 0; a < lstStrings.Count; a++)
    {
      kqChuoiDaiNhat = lstStrings[a];
      foreach (string b in lstStrings)
        {
           if (b.Length > kqChuoiDaiNhat.Length)
            {
                kqChuoiDaiNhat=b;
            }
        }
    }
Console.WriteLine($@"Độ dài chuỗi dài nhất trong mảng lstStrings là: {kqChuoiDaiNhat.Count()}");    
return kqChuoiDaiNhat;
};
Console.WriteLine($@"Cụ thể lả phần tử: {timChuoiDaiNhat()}");
#endregion


/* In ra các chuỗi có chứa chữ 'a'
 Yêu cầu: Viết chương trình để in ra tất cả các chuỗi trong lstStrings có chứa chữ cái 'a'.*/

#region 
//duyệt ds, tạo list mới, xải List.Contains("a")
Func<string> cacChuoiCoChua_a = () =>
{
    List<string> chuoiCoChua_a = new List<string> ();
    foreach (string a in lstStrings)
    {
        if (a.Contains("a"))
        chuoiCoChua_a.Add(a); 
    }
    return string.Join(" ~ ", chuoiCoChua_a);
};
Console.WriteLine($@"Chuỗi có chứa 'a' bao gồm: {cacChuoiCoChua_a()}");
#endregion


/*Tìm chuỗi bắt đầu bằng chữ 'm'
 Yêu cầu: Viết chương trình để tìm tất cả các chuỗi trong lstStrings bắt đầu bằng chữ 'm'*/

#region 
//Duyệt value (foreach) - tạo list chứa 'm' - duyệt lại tại vị trí item[0] có là 'm' khom - in => string
// Func<string> timChuoiChua_m = () =>
// {
//     List<string> chuoiChua_m = new List<string> ();
//     foreach (string a in lstStrings)
//     {
//         if (a[0] == 'm')
//         {
//             chuoiChua_m.Add(a);
//         }
//     }
//     return string.Join(" ~ ", chuoiChua_m);
// };
// Console.WriteLine($@"Các chuỗi bắt đầu bằng chữ 'm': {timChuoiChua_m()}");
#endregion


/* Đếm số chuỗi có độ dài nhỏ hơn 6 ký tự
 Yêu cầu: Viết chương trình để đếm số chuỗi có độ dài nhỏ hơn 6 ký tự trong lstStrings*/

#region 
// duyệt ds tìm chuỗi có độ dài nhỏ hơn 6 ký tự - tạo ds mới - in => string
Func<string> timChuoiDaiNhoHon6KyTu = () =>
{
    List<string> chuoiDaiNhoHon6KyTu = new List<string> ();
    foreach (string a in lstStrings)
    {
        if (a.Length<6)
        chuoiDaiNhoHon6KyTu.Add(a);
    }

    return string.Join(" ~ ", chuoiDaiNhoHon6KyTu);
};
Console.WriteLine($@"Chuỗi có độ dài nhỏ hơn 6 ký tự: {timChuoiDaiNhoHon6KyTu()}");
#endregion


/* In ra chuỗi dài thứ hai trong mảng
 Yêu cầu: Viết chương trình để tìm và in ra chuỗi dài thứ hai trong mảng lstStrings*/

#region 
//duyet - a.length < b.length => = a dài nhất - loại a ra khỏi ds, tìm tương tự trong ds thứ 2 => ra dài thứ 2
Func<string> timChuoiDaiThuHai = () =>
{
int doDai1 = 0;
int doDai2 = 0;
foreach (string a in lstStrings)
    {
        int doDai = a.Length;
        if (doDai > doDai1)
        {
            doDai2 = doDai1;
            doDai1 = doDai;
        }
        else if (doDai > doDai2 && doDai < doDai1)      //trường hợp loại trừ theo điều kiện, xét từ trên xuống
        {
            doDai2 = doDai;
        }
    }
List<string> chuoiDaiThuHai = new List<string> ();
foreach (string b in lstStrings)
{
    if (b.Length == doDai2)
        {
            chuoiDaiThuHai.Add(b);
        }
}

return string.Join(" ~ ", chuoiDaiThuHai);
};
Console.WriteLine($@"Chuỗi dài thứ hai: {timChuoiDaiThuHai()}");
#endregion


/* Sắp xếp mảng theo thứ tự bảng chữ cái
 Yêu cầu: Viết chương trình để sắp xếp mảng lstStrings theo thứ tự bảng chữ cái (A-Z)*/

#region 
//list.Sort()
lstStrings.Sort();
Console.WriteLine($@"Mảng lstStrings theo thứ tự bảng chữ cái: {string.Join(" ~ ", lstStrings)}"); //nếu không ép kiểu string.Join thì sẻ không in ra được
#endregion


/*Chuyển tất cả các chuỗi thành chữ hoa
 Yêu cầu: Viết chương trình để chuyển tất cả các chuỗi trong lstStrings thành chữ in hoa.*/

#region 
//.ToUpper() hẻ
Func<string> chuyenThanhInHoa = () =>
{
    List<string> chuoiInHoa = new List<string> ();
    foreach (string a in lstStrings)
    {
      chuoiInHoa.Add(a.ToUpper());  
    }
return string.Join(" ~ ", chuoiInHoa);
};
Console.WriteLine($@"Các chuỗi in hoa: {chuyenThanhInHoa()}");
#endregion


/*Thay thế chuỗi "banana" bằng "pear"
 Yêu cầu: Viết chương trình để thay thế chuỗi "banana" bằng "pear" trong lstStrings.*/

#region 
//duyệt ds - tìm "banana" thay bằng "pear" - in lại ds
Func<string> thayTheChuoi = () =>
{
  int a = lstStrings.FindIndex(b => b == "banana");
  if (a != -1)
  lstStrings[a] = "pear";

  return string.Join(" ~ ", lstStrings);  
};
Console.WriteLine($@"lstStrings mới 'banana' thay bằng 'pear': {thayTheChuoi()}");
#endregion
