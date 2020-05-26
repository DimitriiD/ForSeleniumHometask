using System;
using System.Collections.Generic;
using System.Text;

namespace Selenium_Basic.business_object
{
    class ProductForTest
    {
                   
        public string prName { get; set; }
        
        public string catVal { get; set; }
        
        public string supVal { get; set; }
        
        public string unPrice { get; set; }
        
        public string quPerUnit { get; set; }
        
        public string unInStock { get; set; }
        
        public string unOnOrder { get; set; }
        
        public string reLevel { get; set; }
        
        public string discont { get; set; } 
        
        public ProductForTest(string prName, string catVal,string supVal, string unPrice, string quPerUnit, 
            string unInStock, string unOnOrder, string reLevel, string discont)
        {
            this.prName = prName;
            this.catVal = catVal;
            this.supVal = supVal;
            this.unPrice = unPrice;
            this.quPerUnit = quPerUnit;
            this.unInStock = unInStock;
            this.unOnOrder = unOnOrder;
            this.reLevel = reLevel;
            this.discont = discont;
        }
    }
}
