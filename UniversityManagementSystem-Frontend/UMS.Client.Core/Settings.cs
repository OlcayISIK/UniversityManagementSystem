namespace Mesero.Web.Core
{
    public static class Settings
    {
        public static class ServerRoutes
        {
            public static class Admin
            {
                private const string ServerPrefix = "api/admin";

                public static class Authentication
                {
                    private const string ControllerPrefix = "/Auth";

                    public const string AuthenticateWithPassword = ServerPrefix + ControllerPrefix + "/pass";
                    public const string AuthenticateWithToken = ServerPrefix + ControllerPrefix + "/token";
                    public const string Logout = ServerPrefix + ControllerPrefix + "/logout";
                    public const string LoginCompany = ServerPrefix + ControllerPrefix + "/loginCompany";
                }

                public static class Company
                {
                    private const string ControllerPrefix = "/Company";

                    public const string GetAll = ServerPrefix + ControllerPrefix + "/getAll";

                    public const string Get = ServerPrefix + ControllerPrefix + "/get";

                    public const string AddCompany = ServerPrefix + ControllerPrefix + "/add";

                    public const string UpdateCompany = ServerPrefix + ControllerPrefix + "/update";

                    public const string RemoveCompany = ServerPrefix + ControllerPrefix + "/remove";

                    public const string GetWorkingHours = ServerPrefix + ControllerPrefix + "/getWorkingHours";
                    public const string Get2 = ServerPrefix + ControllerPrefix + "/get2";
                    public const string UpdateCompany2 = ServerPrefix + ControllerPrefix + "/update2";
                    public const string AddCompany2 = ServerPrefix + ControllerPrefix + "/add2";
                }

                public static class CompanyDebt
                {
                    private const string ControllerPrefix = "/CompanyDebt";


                    public const string Get = ServerPrefix + ControllerPrefix + "/get";

                    public const string CollectCompanyDebts = ServerPrefix + ControllerPrefix + "/collectCompanyDebts";
                }

                public static class Features
                {
                    private const string ControllerPrefix = "/Features";

                    public const string SetMobileFeatures = ServerPrefix + ControllerPrefix + "/setMobileFeatures";

                    public const string GetMobileFeatures = ServerPrefix + ControllerPrefix + "/getMobileFeatures";

                    public const string SetWebFeatures = ServerPrefix + ControllerPrefix + "/setWebFeatures";

                    public const string GetWebFeatures = ServerPrefix + ControllerPrefix + "/getWebFeatures";
                }
                
                public static class Log
                {
                    private const string ControllerPrefix = "/Log";

                    public const string GetAll = ServerPrefix + ControllerPrefix + "/getAll";

                    public const string remove = ServerPrefix + ControllerPrefix + "/remove";

                    public const string clear = ServerPrefix + ControllerPrefix + "/clear";

                    public const string getAllMobile = ServerPrefix + ControllerPrefix + "/getAllMobile";

                    public const string removeMobile = ServerPrefix + ControllerPrefix + "/removeMobile";

                    public const string clearMobile = ServerPrefix + ControllerPrefix + "/clearMobile";

                    public const string getAllConnector = ServerPrefix + ControllerPrefix + "/getAllConnector";

                    public const string setMobileFeatures = ServerPrefix + ControllerPrefix + "/setMobileFeatures";

                    public const string getMobileFeatures = ServerPrefix + ControllerPrefix + "/getMobileFeatures";
                }

                public static class User
                {
                    private const string ControllerPrefix = "/User";

                    public const string GetAll = ServerPrefix + ControllerPrefix + "/GetAll";

                    public const string AddUser = ServerPrefix + ControllerPrefix + "/Add";

                    public const string RemoveUser = ServerPrefix + ControllerPrefix + "/Remove";

                    public const string UpdateUser = ServerPrefix + ControllerPrefix + "/update";
                }

                public static class Customer
                {
                    private const string ControllerPrefix = "/Customer";

                    public const string GetAll = ServerPrefix + ControllerPrefix + "/GetAll";

                    public const string UpdateCustomerVisibilityPermission = ServerPrefix + ControllerPrefix + "/UpdateCustomerVisibilityPermission";
                }
            }
            public static class User
            {
                private const string ServerPrefix = "api/user";
                public static class Authentication
                {
                    private const string ControllerPrefix = "/Auth";

                    public const string AuthenticateWithPassword = ServerPrefix + ControllerPrefix + "/pass";
                    
                    public const string AuthenticateWithToken = ServerPrefix + ControllerPrefix + "/token";
                    
                    public const string Logout = ServerPrefix + ControllerPrefix + "/logout";
                    
                    public const string ForgotPassword = ServerPrefix + ControllerPrefix + "/ForgotPassword";
                    
                    public const string ResetPassword = ServerPrefix + ControllerPrefix + "/ResetPassword";
                }
                public static class Category
                {
                    private const string ControllerPrefix = "/Category";

                    public const string GetCategory = ServerPrefix + ControllerPrefix + "/Get";

                    public const string GetAll = ServerPrefix + ControllerPrefix + "/GetAll";

                    public const string AddCategory = ServerPrefix + ControllerPrefix + "/Add";

                    public const string UpdateCategory = ServerPrefix + ControllerPrefix + "/Update";

                    public const string RemoveCategory = ServerPrefix + ControllerPrefix + "/Remove";
                }
                public static class Customer
                {
                    private const string ControllerPrefix = "/Customer";

                    public const string GetDetails = ServerPrefix + ControllerPrefix + "/GetDetails";
                }

                public static class Station
                {
                    private const string ControllerPrefix = "/Station";

                    public const string GetAll = ServerPrefix + ControllerPrefix + "/GetAll";

                    public const string AddStation = ServerPrefix + ControllerPrefix + "/Add";

                    public const string UpdateStation = ServerPrefix + ControllerPrefix + "/Update";

                    public const string RemoveStation = ServerPrefix + ControllerPrefix + "/Remove";
                }
                public static class Tag
                {
                    private const string ControllerPrefix = "/Tag";

                    public const string GetAll = ServerPrefix + ControllerPrefix + "/GetAll";

                    public const string AddTag = ServerPrefix + ControllerPrefix + "/Add";

                    public const string UpdateTag = ServerPrefix + ControllerPrefix + "/Update";

                    public const string RemoveTag = ServerPrefix + ControllerPrefix + "/Remove";
                }
                public static class Table
                {
                    private const string ControllerPrefix = "/Table";

                    public const string GetAll = ServerPrefix + ControllerPrefix + "/GetAll";

                    public const string GetAllWithDetails = ServerPrefix + ControllerPrefix + "/GetAllWithDetails";

                    public const string AddTable = ServerPrefix + ControllerPrefix + "/Add";

                    public const string UpdateTable = ServerPrefix + ControllerPrefix + "/Update";

                    public const string RemoveTable = ServerPrefix + ControllerPrefix + "/Remove";

                    public const string SendWaiter = ServerPrefix + ControllerPrefix + "/SendWaiter";

                    public const string GetQrCodeForApple = ServerPrefix + ControllerPrefix + "/GetQrCodeForApple";

                    public const string GetQrCodeForAndroid = ServerPrefix + ControllerPrefix + "/GetQrCodeForAndroid";

                    public const string Clear = ServerPrefix + ControllerPrefix + "/Clear";

                    public const string HasInvisibleCustomer = ServerPrefix + ControllerPrefix + "/HasInvisibleCustomer";

                }
                public static class Reservation
                {
                    private const string ControllerPrefix = "/Reservation";

                    public const string GetAll = ServerPrefix + ControllerPrefix + "/GetAll";

                    public const string Confirm = ServerPrefix + ControllerPrefix + "/Confirm";

                    public const string Reject = ServerPrefix + ControllerPrefix + "/Reject";
                }
                public static class Order
                {
                    private const string ControllerPrefix = "/Order";

                    public const string Add = ServerPrefix + ControllerPrefix + "/Add";

                    public const string GetAll = ServerPrefix + ControllerPrefix + "/GetAll";

                    public const string GetDetails = ServerPrefix + ControllerPrefix + "/GetDetails";

                    public const string GetAllForTable = ServerPrefix + ControllerPrefix + "/GetAllForTable";

                    public const string AddOrder = ServerPrefix + ControllerPrefix + "/AddOrder";

                    public const string UpdateOrderItem = ServerPrefix + ControllerPrefix + "/UpdateOrderItem";

                    public const string CloseOrder = ServerPrefix + ControllerPrefix + "/CloseOrder";

                    public const string CloseAllOrdersForTable = ServerPrefix + ControllerPrefix + "/CloseAllOrdersForTable";

                    public const string PayWithCash = ServerPrefix + ControllerPrefix + "/PayWithCash";

                    public const string PrepareOrderItem = ServerPrefix + ControllerPrefix + "/PrepareOrderItem";

                    public const string DeliverOrderItem = ServerPrefix + ControllerPrefix + "/DeliverOrderItem";

                    public const string CancelOrderItem = ServerPrefix + ControllerPrefix + "/CancelOrderItem";

                    public const string GetReceivedOrderDetails = ServerPrefix + ControllerPrefix + "/GetReceivedOrderDetails";

                    public const string TransferTable = ServerPrefix + ControllerPrefix + "/TransferTable";

                    public const string PayWithCashAsBulk = ServerPrefix + ControllerPrefix + "/PayWithCashAsBulk";

                    public const string GetTakeawayOrders = ServerPrefix + ControllerPrefix + "/GetTakeawayOrders";

                    public const string CloseTakeawayOrder = ServerPrefix + ControllerPrefix + "/CloseTakeawayOrder";
                }

                public static class Profile
                {
                    private const string ControllerPrefix = "/Profile";

                    public const string UpdateProfile = ServerPrefix + ControllerPrefix + "/UpdateProfile";

                    public const string ChangePassword = ServerPrefix + ControllerPrefix + "/ChangePassword";

                    public const string Get = ServerPrefix + ControllerPrefix + "/Get";
                }

                public static class Temp
                {
                    private const string ControllerPrefix = "/temp";

                    public const string Get = ServerPrefix + ControllerPrefix + "/get";

                    public const string UpdateViewOrder = ServerPrefix + ControllerPrefix + "/UpdateViewOrder";

                    public const string GetTime = ServerPrefix + ControllerPrefix + "/GetTime";

                    public const string GetPromotions = ServerPrefix + ControllerPrefix + "/getPromotions";

                    public const string Ping = ServerPrefix + ControllerPrefix + "/ping";
                }
                public static class Item
                {
                    private const string ControllerPrefix = "/Item";

                    public const string Get = ServerPrefix + ControllerPrefix + "/Get";

                    public const string Add = ServerPrefix + ControllerPrefix + "/Add";

                    public const string Update = ServerPrefix + ControllerPrefix + "/Update";

                    public const string Remove = ServerPrefix + ControllerPrefix + "/Remove";

                    public const string ChangeStockStatus = ServerPrefix + ControllerPrefix + "/ChangeStockStatus";

                    public const string GetItemDetailOptions = ServerPrefix + ControllerPrefix + "/GetItemDetailOptions";

                    public const string GetTimes = ServerPrefix + ControllerPrefix + "/GetTimes";
                }
                public static class Promotion
                {
                    private const string ControllerPrefix = "/Promotion";

                    public const string Add = ServerPrefix + ControllerPrefix + "/Add";

                    public const string Update = ServerPrefix + ControllerPrefix + "/Update";

                    public const string Remove = ServerPrefix + ControllerPrefix + "/Remove";

                    public const string GetAll = ServerPrefix + ControllerPrefix + "/GetAll";

                    public const string GetTimes = ServerPrefix + ControllerPrefix + "/GetTimes";

                    public const string GetDetails = ServerPrefix + ControllerPrefix + "/GetDetails";

                    public const string Get = ServerPrefix + ControllerPrefix + "/Get";
                }
                public static class CompanySetting
                {
                    private const string ControllerPrefix = "/Company";

                    public const string Get = ServerPrefix + ControllerPrefix + "/getPaymentAccount";

                    public const string Create = ServerPrefix + ControllerPrefix + "/CreatePaymentAccount";
                }
                public static class Company
                {
                    private const string ControllerPrefix = "/Company";

                    public const string Get = ServerPrefix + ControllerPrefix + "/get";

                    public const string Set = ServerPrefix + ControllerPrefix + "/set";

                    public const string GetPaymentAccount = ServerPrefix + ControllerPrefix + "/getPaymentAccount";

                    public const string CreatePaymentAccount = ServerPrefix + ControllerPrefix + "/createPaymentAccount";

                    public const string GetStripeDashboardLink = ServerPrefix + ControllerPrefix + "/getStripeDashboardLink";

                    public const string CompletePaymentAccount = ServerPrefix + ControllerPrefix + "/completePaymentAccount";

                    public const string GetWorkingHours = ServerPrefix + ControllerPrefix + "/getWorkingHours";
                    public const string Get2 = ServerPrefix + ControllerPrefix + "/get2";
                    public const string Set2 = ServerPrefix + ControllerPrefix + "/set2";

                }
                public static class CompanyUser
                {
                    private const string ControllerPrefix = "/User";

                    public const string GetAll = ServerPrefix + ControllerPrefix + "/getAll";

                    public const string Add = ServerPrefix + ControllerPrefix + "/add";

                    public const string Remove = ServerPrefix + ControllerPrefix + "/remove";

                    public const string Get = ServerPrefix + ControllerPrefix + "/get";

                    public const string Update = ServerPrefix + ControllerPrefix + "/update";
                }
                public static class SuggestedItem
                {
                    private const string ControllerPrefix = "/SuggestedItems";

                    public const string GetAll = ServerPrefix + ControllerPrefix + "/GetSuggestedItems";

                    public const string Save = ServerPrefix + ControllerPrefix + "/SaveSuggestedItems";
                }
                public static class Dashboard
                {
                    private const string ControllerPrefix = "/Dashboard";

                    public const string GetDailySalesSummary = ServerPrefix + ControllerPrefix + "/getDailySalesSummary";

                    public const string GetWeeklySalesSummary = ServerPrefix + ControllerPrefix + "/getWeeklySalesSummary";

                    public const string GetMonthlySalesSummary = ServerPrefix + ControllerPrefix + "/getMonthlySalesSummary";

                    public const string GetAnnualSalesSummary = ServerPrefix + ControllerPrefix + "/getAnnualSalesSummary";

                    public const string GetTopSellingProducts = ServerPrefix + ControllerPrefix + "/getTopSellingProducts";

                }
                public static class ItemPackage
                {
                    private const string ControllerPrefix = "/ItemPackage";

                    public const string GetAll = ServerPrefix + ControllerPrefix + "/GetAll";

                    public const string Add = ServerPrefix + ControllerPrefix + "/Add";

                    public const string Update = ServerPrefix + ControllerPrefix + "/Update";

                    public const string Remove = ServerPrefix + ControllerPrefix + "/Remove";

                    public const string GetDetails = ServerPrefix + ControllerPrefix + "/GetDetails";
                }
            }

            public static class Customer
            {
                private const string ServerPrefix = "api/customer";

                public static class Authentication
                {
                    private const string ControllerPrefix = "/Auth";

                    public const string ForgotPassword = ServerPrefix + ControllerPrefix + "/ForgotPassword";

                    public const string ResetPassword = ServerPrefix + ControllerPrefix + "/ResetPassword";

                    public const string Approve = ServerPrefix + ControllerPrefix + "/Approve";
                }
            }

            public static class Socket
            {
                private const string ServerPrefix = "api";
                private const string ControllerPrefix = "/Socket";

                public const string JoinGroup = ServerPrefix + ControllerPrefix + "/JoinGroup";
            }
        }
    }
}
