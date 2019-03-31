using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProductSearch
/// </summary>
public class ProductSearch
{
    private int _Id;   
    private string _Product;
    private string _Image;
    private double _NewPrice;
    private string _Size;
    private double _OldPrice;
    private string _Discount;
    public ProductSearch()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int Id
    {
        get { return _Id; }
        set { _Id = value; }
    }
  
    public string Product
    {
        get { return _Product; }
        set { _Product = value; }
    }

    public string Image
    {
        get { return _Image; }
        set { _Image = value; }
    }
    public string Size
    {
        get { return _Size; }
        set { _Size = value; }
    }
    public string Discount
    {
        get { return _Discount; }
        set { _Discount = value; }
    }
    public double NewPrice
    {
        get { return _NewPrice; }
        set { _NewPrice = value; }
    }
    public double OldPrice
    {
        get { return _OldPrice; }
        set { _OldPrice = value; }
    }
}