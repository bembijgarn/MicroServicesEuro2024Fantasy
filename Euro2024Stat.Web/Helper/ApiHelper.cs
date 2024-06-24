using Euro2024Stat.Web.Models;
using Newtonsoft.Json;
namespace Euro2024Stat.Web.Helper
{
    public class ApiHelper
    {
        public static string CountryAPIBase { get; set; }
        public static string PlayerAPIBase { get; set; }
        public static string AuthAPIBase { get; set; }
        public static string MatchAPIBase { get; set; }
        public static string WalletAPIBase { get; set; }
        public static string FantasyAPIBase { get; set; }

        public const string RoleAdmin = "ADMIN";
        public const string RoleCustomer = "CUSTOMER";
        public const string TokenCookie = "JWTToken";
        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }

        public const string Status_Pending = "Pending";
        public const string Status_Approved = "Approved";
        public const string Status_ReadyForPickup = "ReadyForPickup";
        public const string Status_Completed = "Completed";
        public const string Status_Refunded = "Refunded";
        public const string Status_Cancelled = "Cancelled";

        public enum ContentType
        {
            Json,
            MultipartFormData,
        }

        public static void APIGetDeserializedList<T>(ResponseDto response, out List<T> obj)
        {
            if (response != null && response.IsSuccess)
            {
                obj = JsonConvert.DeserializeObject<List<T>>(Convert.ToString(response.Result));
            }
            else
            {               
                obj = null;
            }
            return;
        }

        public static void APIGetDeserializedobject<T>(ResponseDto response, out T obj)
        {
            if (response != null && response.IsSuccess)
            {
                obj = JsonConvert.DeserializeObject<T>(Convert.ToString(response.Result));
            }
            else
            {                
                obj = default(T);
            }
            return;
        }
    }
}
