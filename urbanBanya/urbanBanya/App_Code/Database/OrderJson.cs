using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for JsonTest
/// </summary>
public class OrderJson
{
    private int _Id;
    private int _Sku;
    private int _Categoryid;
    private int _Subcategoryid;
    private string _ProductName;
    private double _Price;
    private string _Discount;
    private double _Newprice;
    private string _Size;
    private string _Description;
    private string _Image;
    private int _Status;
    private int _Quantity;
    private int _Stock;
    public OrderJson()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int Id { get { return _Id; } set { _Id = value; } }
    public int Sku { get { return _Sku; } set { _Sku = value; } }
    public int CategoryId { get { return _Categoryid; } set { _Categoryid = value; } }
    public int SubcategoryId { get { return _Subcategoryid; } set { _Subcategoryid = value; } }
    public string ProductName { get { return _ProductName; } set { _ProductName = value; } }
    public double Price { get { return _Price; } set { _Price = value; } }
    public string Discount { get { return _Discount; } set { _Discount = value; } }
    public double Newprice { get { return _Newprice; } set { _Newprice = value; } }
    public string Size { get { return _Size; } set { _Size = value; } }
    public string Description { get { return _Description; } set { _Description = value; } }
    public string Image { get { return _Image; } set { _Image = value; } }
    public int Status { get { return _Status; } set { _Status = value; } }
    public int Quantity { get { return _Quantity; } set { _Quantity = value; } }
    public int Stock { get { return _Stock; } set { _Stock = value; } }
}