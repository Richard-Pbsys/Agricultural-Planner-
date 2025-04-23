using VHS.Services.Common;

namespace VHS.Services.Farming.Constants
{
    public static class RackConstant
    {
        // 1st floor (SK1)
        public const string SK1aName = "SK1a";
        public const int SK1aLayers = 75;
        public const int SK1aDepth = 27;
        public const int SK1aCount = 3;
        public const string SK1aTypeName = "Germination";
        public static readonly Guid SK1aTypeId = GlobalConstants.RACKTYPE_GERMINATION;
        public static readonly string[] SK1aCrops = { "Petite Greens", "Micro Greens" };

        // 2nd floor (SK2)
        public const string SK2aName = "SK2a";
        public const int SK2aLayers = 9;
        public const int SK2aDepth = 54;
        public const int SK2aCount = 2;
        public const string SK2aTypeName = "Propagation";
        public static readonly Guid SK2aTypeId = GlobalConstants.RACKTYPE_PROPAGATION;
        public static readonly string[] SK2aCrops = { "Lettuce Heads" };

        public const string SK2bName = "SK2b";
        public const int SK2bLayers = 9;
        public const int SK2bDepth = 54;
        public const int SK2bCount = 1;
        public const string SK2bTypeName = "Growing";
        public static readonly Guid SK2bTypeId = GlobalConstants.RACKTYPE_GROWING;
        public static readonly string[] SK2bCrops = { "Lettuce Heads", "Petite Greens", "Micro Greens" };

        public const string SK2cName = "SK2c";
        public const int SK2cLayers = 9;
        public const int SK2cDepth = 88;
        public const int SK2cCount = 1;
        public const string SK2cTypeName = "Growing";
        public static readonly Guid SK2cTypeId = GlobalConstants.RACKTYPE_GROWING;
        public static readonly string[] SK2cCrops = { "Lettuce Heads", "Petite Greens", "Micro Greens" };

        public const string SK2dName = "SK2d";
        public const int SK2dLayers = 9;
        public const int SK2dDepth = 131;
        public const int SK2dCount = 8;
        public const string SK2dTypeName = "Growing";
        public static readonly Guid SK2dTypeId = GlobalConstants.RACKTYPE_GROWING;
        public static readonly string[] SK2dCrops = { "Lettuce Heads", "Petite Greens", "Micro Greens" };

        // 3rd floor (SK3)
        public const string SK3aName = "SK3a";
        public const int SK3aLayers = 18;
        public const int SK3aDepth = 79;
        public const int SK3aCount = 2;
        public const string SK3aTypeName = "Growing";
        public static readonly Guid SK3aTypeId = GlobalConstants.RACKTYPE_GROWING;
        public static readonly string[] SK3aCrops = { "Lettuce Heads", "Petite Greens", "Micro Greens" };

        public const string SK3bName = "SK3b";
        public const int SK3bLayers = 18;
        public const int SK3bDepth = 113;
        public const int SK3bCount = 2;
        public const string SK3bTypeName = "Growing";
        public static readonly Guid SK3bTypeId = GlobalConstants.RACKTYPE_GROWING;
        public static readonly string[] SK3bCrops = { "Lettuce Heads", "Petite Greens", "Micro Greens" };

        public const string SK3cName = "SK3c";
        public const int SK3cLayers = 18;
        public const int SK3cDepth = 131;
        public const int SK3cCount = 10;
        public const string SK3cTypeName = "Growing";
        public static readonly Guid SK3cTypeId = GlobalConstants.RACKTYPE_GROWING;
        public static readonly string[] SK3cCrops = { "Lettuce Heads", "Petite Greens", "Micro Greens" };
    }
}
