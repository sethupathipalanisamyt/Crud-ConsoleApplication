// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using ProjectDataAccessLayer;
namespace Crud_ConsoleApplication;
public class Program
{
    public static void Main(string[] args)
    {
        ProductService productser = new ProductService();
        productser.MenuDriven();
    }
}
