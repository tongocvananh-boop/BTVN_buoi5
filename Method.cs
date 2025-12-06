namespace BaiTapList;

public class BaiTapList_Method
{
    public static int TinhTongLonHon50 (int[] a, int b)
    {
        if (b == a.Length) 
        {
            return 0;
        }
        return a[b] + TinhTongLonHon50 (a, b + 1);
    }

    public static int DuyetDanhSach (int [] a, int b)
    {
        if (b == a.Length)
        {
            return 0;
        }
        return DuyetDanhSach (a,b+1);
    }










}