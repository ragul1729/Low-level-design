using System.Collections.Generic;
using System.Collections;

public class InventorySystem
{
    private Dictionary<string, Product> productList;
    private Dictionary<string, List<Unit>> unitList;
    private Dictionary<string, User> userList;

    public InventorySystem()
    {
        productList = new Dictionary<string, Product>();
        unitList = new Dictionary<string, List<Unit>>();
        userList = new Dictionary<string, User>();

    }

    public Dictionary<string, Product> ProductList { get{ return productList; }}
    public Dictionary<string, List<Unit>> UnitList { get { return unitList; } }

    public Dictionary<string, User> UserList { get { return userList; }}

    
}

public class Unit
{
}

public class Product
{
    private string productID;
    private string description;
    private double price;
    private pSize size;

    public Product(string pID, pSize size)
    {
        this.productID = pID;
        this.size = size;
    }

    public string ProductID { get { return productID; } }
    public string Description { get { return description; } set { description = value}; }
    public double Price { get { return price; } set { price = value; } }
    public pSize Size { get { return size; } };
}

enum pSize { Small, Medium, Large }

public class User
{
    private string userID;
    private string name;
}