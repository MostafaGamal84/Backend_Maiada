using System.ComponentModel;

namespace Orbits.GeneralProject.BLL.Constants
{
    #region DbSchemas

    public class DXConstants
    {
        public static class DbSchemas
        {
            public const string GeneralSetting = "GeneralSetting";
            public const string StaticData = "StaticData";
            public const string Security = "Security";
            public const string Lang = "Lang";
            public static string ReferenceTableName = "[{0}].[{1}]";
        }

        #endregion DbSchemas
        #region Languages & Localization
        public static class SupportedLanguage
        {
            public const string RequestHeader = "Accept-Language";
            public const string EN = "en";
            public const string AR = "ar";
            public const int DefaultLangId = 1;
        }
        #endregion

        public static class Constanties
        {
            public const string ORDERASC = "ASC";
            public const string ORDERDESC = "DESC";


            public const string HAJJ_START_DAY = "10";
            public const string HAJJ_START_MONTH = "11";

            public const string HAJJ_END_DAY = "20";
            public const string HAJJ_END_MONTH = "12";

            public const string HIJRI_TYPE = "H";
            public const string GREGORIAN_TYPE = "G";
        }
    }
    #region BLL Responses MessageCodes

    public enum MessageCodes

    {

        [Description("Success")]
        Success = 1000,

        [Description("Internal Server Error")]
        Failed = 2000,

        [Description("Failed To Fetch Data")]
        FailedToFetchData = 2001,

        [Description("There is NoPermission to Perform this Action")]
        UnAuthorizedAccess = 4000,

        //Exception
        [Description("Some Error Occurred")]
        Exception = 5000,

        //InputValidation
        [Description("Failed : Input Validation Error")]
        InputValidationError = 6000,

        [Description("Failed : {0} Is Required")]
        Required = 6001,

        [Description("Failed: {0}  Must Be Greater Than Zero")]
        GreaterThanZero = 6002,

        [Description("Length Validation Error")]
        LengthValidationError = 6003,

        [Description("Failed : {2} Must Be Between {0} And {1}")]
        InbetweenValue = 6004,

        [Description("Failed : {1} Must Be GreaterThan {0}")]
        InvalidMinLength = 6005,

        [Description("Failed : {1} Must Be LessThan {0}")]
        InvalidMaxLength = 6006,

        [Description("Failed : Invalid Email")]
        InvalidEmail = 6007,

        [Description("Failed :Invalid Items Count")]
        InvalidItemsCount = 6008,

        [Description("Failed :Invalid Logo")]
        InvalidLogo = 6009,

        [Description("Failed :Invalid Json")]
        InvalidJson = 6010,

        [Description("Failed :Invalid Json Empty Value")]
        InvalidJsonEmptyValue = 6011,

        [Description("Failed :Failed To Deserialize")]
        FailedToDeserialize = 6012,

        [Description("Failed :Missing Default Value")]
        MissingDefaultValue = 6013,

        [Description("Failed :Missing Arabic Value")]
        MissingArabicValue = 6014,

        [Description("Failed :Password should contain at least 1 digit")]
        MissingPasswordDigits = 6015,

        [Description("Failed :Password should contain at least one alphabetic character")]
        MissingPasswordAlphabetic = 6016,

        [Description("Failed :Password should contain at least one special characters Like { ., $, ~ ,&}")]
        MissingPasswordSpecialCharacters = 6017,

        [Description("Failed :Invalid Https Url")]
        InvalidHttpsUrl = 6018,

        [Description("Failed :Invalid File Type")]
        InvalidFileType = 6019,

        [Description("Failed :Invalid File Content Type")]
        InvalidFileContentType = 6020,

        [Description("Failed :Invalid File Size,, Must be less than 2 MB")]
        InvalidFileSize = 6021,

        [Description("Failed :Invalid Rate, Must be within 1 to 5")]
        InvalidRate = 6022,

        [Description("Failed :You Must select one at least")]
        InvalidItemsSelect = 6023,

        //Business Validation
        [Description("Failed : Business Validation Error")]
        BusinessValidationError = 7000,

        [Description("Failed : {0} Already Exists")]
        AlreadyExists = 7001,

        [Description("Failed : {0} Not Found")]
        NotFound = 7002,

        [Description("Failed : {0} Is DefaultForOther")]
        DefaultForOther = 7003,

        [Description("There're related data to this item")]
        RelatedDataExist = 7004,

        [Description("File type Is Not supported")]
        FileTypeNotSupported = 7005,

        [Description("Failed : Name Already Exists")]
        NameAlreadyExists = 7006,

        [Description("Failed : UserName Already Exists")]
        UserNameAlreadyExists = 7007,

        [Description("Failed : Email Already Exists")]
        EmailAlreadyExists = 7008,

        [Description("Failed : Can't Delete Admin User ")]
        CanNotDeleteAdminUser = 7009,

        [Description("Failed : {0}  Already Exists")]
        AlreadyExistsEn = 7010,

        [Description("Failed : {0}  Already Exists")]
        AlreadyExistsAr = 7011,

        //InputValidation
        [Description("Failed : error on row number {0}")]
        FailedToImport = 7012,


    }

    #endregion BLL Responses MessageCodes


}