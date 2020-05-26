using System;
using System.Collections.Generic;
using System.Text;

namespace Selenium_Basic.service.ui
{
    class GetProductForTest
    {

        public string getProductName { get; set; }

        public string getCategoryValue { get; set; }

        public string getSupplierValue { get; set; }

        public string getUnitPrice { get; set; }

        public string getQuantityPerUnit { get; set; }

        public string getUnitsInStock { get; set; }

        public string getUnitsOnOrder { get; set; }

        public string getReorderLevel { get; set; }

        public string getDiscontinued { get; set; }

        public GetProductForTest(string getProductName, string getCategoryValue, string getSupplierValue, string getUnitPrice, string getQuantityPerUnit,
            string getUnitsInStock, string getUnitsOnOrder, string getReorderLevel, string getDiscontinued)
        {
            this.getProductName = getProductName;
            this.getCategoryValue = getCategoryValue;
            this.getSupplierValue = getSupplierValue;
            this.getUnitPrice = getUnitPrice;
            this.getQuantityPerUnit = getQuantityPerUnit;
            this.getUnitsInStock = getUnitsInStock;
            this.getUnitsOnOrder = getUnitsOnOrder;
            this.getReorderLevel = getReorderLevel;
            this.getDiscontinued = getDiscontinued;
        }
    }
}
