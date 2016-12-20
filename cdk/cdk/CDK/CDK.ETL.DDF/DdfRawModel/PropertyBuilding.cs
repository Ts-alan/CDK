namespace CDK.ETL.DDF.DdfRawModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class PropertyBuilding
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PropertyBuilding()
        {
            this.PropertyBuildingRoom = new HashSet<PropertyBuildingRoom>();
        }
    
        public long PropertyId { get; set; }
        public string BathroomTotal { get; set; }
        public string BedroomsAboveGround { get; set; }
        public string BedroomsBelowGround { get; set; }
        public string BedroomsTotal { get; set; }
        public string Age { get; set; }
        public string Amenities { get; set; }
        public string Amperage { get; set; }
        public string Anchor { get; set; }
        public string Appliances { get; set; }
        public string ArchitecturalStyle { get; set; }
        public string BasementDevelopment { get; set; }
        public string BasementFeatures { get; set; }
        public string BasementType { get; set; }
        public string BomaRating { get; set; }
        public string CeilingHeight { get; set; }
        public string CeilingType { get; set; }
        public string ClearCeilingHeight { get; set; }
        public string ConstructedDate { get; set; }
        public string ConstructionMaterial { get; set; }
        public string ConstructionStatus { get; set; }
        public string ConstructionStyleAttachment { get; set; }
        public string ConstructionStyleOther { get; set; }
        public string ConstructionStyleSplitLevel { get; set; }
        public string CoolingType { get; set; }
        public string EnerguideRating { get; set; }
        public string ExteriorFinish { get; set; }
        public string FireProtection { get; set; }
        public string FireplaceFuel { get; set; }
        public string FireplacePresent { get; set; }
        public string FireplaceTotal { get; set; }
        public string FireplaceType { get; set; }
        public string Fixture { get; set; }
        public string FlooringType { get; set; }
        public string FoundationType { get; set; }
        public string HalfBathTotal { get; set; }
        public string HeatingFuel { get; set; }
        public string HeatingType { get; set; }
        public string LeedsCategory { get; set; }
        public string LeedsRating { get; set; }
        public string RenovatedDate { get; set; }
        public string RoofMaterial { get; set; }
        public string RoofStyle { get; set; }
        public string StoriesTotal { get; set; }
        public string SizeExterior { get; set; }
        public string SizeInterior { get; set; }
        public string SizeInteriorFinished { get; set; }
        public string StoreFront { get; set; }
        public string TotalFinishedArea { get; set; }
        public string Type { get; set; }
        public string Uffi { get; set; }
        public string UnitType { get; set; }
        public string UtilityPower { get; set; }
        public string UtilityWater { get; set; }
        public string VacancyRate { get; set; }
        public System.DateTime LastUpdate { get; set; }
    
        public virtual Property Property { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PropertyBuildingRoom> PropertyBuildingRoom { get; set; }
    }
}
