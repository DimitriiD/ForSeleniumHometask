using System;
using System.Collections.Generic;
using System.Text;

namespace Selenium_Basic.business_object
{
    class ProductForTest
    {
                   
        public string productName { get; set; }
        
        public string categoryValue { get; set; }
        
        public string supplierValue { get; set; }
        
        public string unitPrice { get; set; }
        
        public string quantityPerUnit { get; set; }
        
        public string unitsInStock { get; set; }
        
        public string unitsOnOrder { get; set; }
        
        public string reorderLevel { get; set; }
        
        public string discontinued { get; set; } 
        
        public ProductForTest(string productName, string categoryValue, string supplierValue, string unitPrice, string quantityPerUnit, 
            string unitsInStock, string unitsOnOrder, string reorderLevel, string discontinued)
        {
            this.productName = productName;
            this.categoryValue = categoryValue;
            this.supplierValue = supplierValue;
            this.unitPrice = unitPrice;
            this.quantityPerUnit = quantityPerUnit;
            this.unitsInStock = unitsInStock;
            this.unitsOnOrder = unitsOnOrder;
            this.reorderLevel = reorderLevel;
            this.discontinued = discontinued;
        }
    }
}
