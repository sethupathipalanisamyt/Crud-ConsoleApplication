// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using ProjectDataAccessLayer;
namespace program;
public class Program
{
    public static void Main(string[] args)
    {
        ProductService productser = new ProductService();
        productser.MenuDriven();
    }
}
