﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EncModel.NCPDP
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class UtlCompound
    {
        [Key]
        public int UtlCompoundID { get; set; }
        public int UtlDetailID { get; set; }
        public string RecordType { get; set; }
        public string Prescription_Reference_Number_Qualifier { get; set; }
        public string Prescription_Reference_Number { get; set; }
        public string Compound_Ingredient_Count { get; set; }
        public string First_Compound_ID_Qualifier { get; set; }
        public string First_Compound_ID { get; set; }
        public string First_Compound_Ingredient_Quantity { get; set; }
        public string First_Compound_Ingredient_Drug_Cost { get; set; }
        public string First_Compound_Ingredient_Basis_Of_Cost_Determination { get; set; }
        public string Second_Compound_ID_Qualifier { get; set; }
        public string Second_Compound_ID { get; set; }
        public string Second_Compound_Ingredient_Quantity { get; set; }
        public string Second_Compound_Ingredient_Drug_Cost { get; set; }
        public string Second_Compound_Ingredient_Basis_Of_Cost_Determination { get; set; }
        public string Third_Compound_ID_Qualifier { get; set; }
        public string Third_Compound_ID { get; set; }
        public string Third_Compound_Ingredient_Quantity { get; set; }
        public string Third_Compound_Ingredient_Drug_Cost { get; set; }
        public string Third_Compound_Ingredient_Basis_Of_Cost_Determination { get; set; }
        public string Fourth_Compound_ID_Qualifier { get; set; }
        public string Fourth_Compound_ID { get; set; }
        public string Fourth_Compound_Ingredient_Quantity { get; set; }
        public string Fourth_Compound_Ingredient_Drug_Cost { get; set; }
        public string Fourth_Compound_Ingredient_Basis_Of_Cost_Determination { get; set; }
        public string Fifth_Compound_ID_Qualifier { get; set; }
        public string Fifth_Compound_ID { get; set; }
        public string Fifth_Compound_Ingredient_Quantity { get; set; }
        public string Fifth_Compound_Ingredient_Drug_Cost { get; set; }
        public string Fifth_Compound_Ingredient_Basis_Of_Cost_Determination { get; set; }
        public string Sixth_Compound_ID_Qualifier { get; set; }
        public string Sixth_Compound_ID { get; set; }
        public string Sixth_Compound_Ingredient_Quantity { get; set; }
        public string Sixth_Compound_Ingredient_Drug_Cost { get; set; }
        public string Sixth_Compound_Ingredient_Basis_Of_Cost_Determination { get; set; }
        public string Seventh_Compound_ID_Qualifier { get; set; }
        public string Seventh_Compound_ID { get; set; }
        public string Seventh_Compound_Ingredient_Quantity { get; set; }
        public string Seventh_Compound_Ingredient_Drug_Cost { get; set; }
        public string Seventh_Compound_Ingredient_Basis_Of_Cost_Determination { get; set; }
        public string Eighth_Compound_ID_Qualifier { get; set; }
        public string Eighth_Compound_ID { get; set; }
        public string Eighth_Compound_Ingredient_Quantity { get; set; }
        public string Eighth_Compound_Ingredient_Drug_Cost { get; set; }
        public string Eighth_Compound_Ingredient_Basis_Of_Cost_Determination { get; set; }
        public string Ninth_Compound_ID_Qualifier { get; set; }
        public string Ninth_Compound_ID { get; set; }
        public string Ninth_Compound_Ingredient_Quantity { get; set; }
        public string Ninth_Compound_Ingredient_Drug_Cost { get; set; }
        public string Ninth_Compound_Ingredient_Basis_Of_Cost_Determination { get; set; }
        public string Tenth_Compound_ID_Qualifier { get; set; }
        public string Tenth_Compound_ID { get; set; }
        public string Tenth_Compound_Ingredient_Quantity { get; set; }
        public string Tenth_Compound_Ingredient_Drug_Cost { get; set; }
        public string Tenth_Compound_Ingredient_Basis_Of_Cost_Determination { get; set; }
        public string Eleventh_Compound_ID_Qualifier { get; set; }
        public string Eleventh_Compound_ID { get; set; }
        public string Eleventh_Compound_Ingredient_Quantity { get; set; }
        public string Eleventh_Compound_Ingredient_Drug_Cost { get; set; }
        public string Eleventh_Compound_Ingredient_Basis_Of_Cost_Determination { get; set; }
        public string Twelfth_Compound_ID_Qualifier { get; set; }
        public string Twelfth_Compound_ID { get; set; }
        public string Twelfth_Compound_Ingredient_Quantity { get; set; }
        public string Twelfth_Compound_Ingredient_Drug_Cost { get; set; }
        public string Twelfth_Compound_Ingredient_Basis_Of_Cost_Determination { get; set; }
        public string Thirteenth_Compound_ID_Qualifier { get; set; }
        public string Thirteenth_Compound_ID { get; set; }
        public string Thirteenth_Compound_Ingredient_Quantity { get; set; }
        public string Thirteenth_Compound_Ingredient_Drug_Cost { get; set; }
        public string Thirteenth_Compound_Ingredient_Basis_Of_Cost_Determination { get; set; }
        public string Fourteenth_Compound_ID_Qualifier { get; set; }
        public string Fourteenth_Compound_ID { get; set; }
        public string Fourteenth_Compound_Ingredient_Quantity { get; set; }
        public string Fourteenth_Compound_Ingredient_Drug_Cost { get; set; }
        public string Fourteenth_Compound_Ingredient_Basis_Of_Cost_Determination { get; set; }
        public string Fifteenth_Compound_ID_Qualifier { get; set; }
        public string Fifteenth_Compound_ID { get; set; }
        public string Fifteenth_Compound_Ingredient_Quantity { get; set; }
        public string Fifteenth_Compound_Ingredient_Drug_Cost { get; set; }
        public string Fifteenth_Compound_Ingredient_Basis_Of_Cost_Determination { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }

        public virtual UtlDetail UtlDetail { get; set; }
    }
}

