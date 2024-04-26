public static class ApiClient
{
    public const string UniqueId = "aCq2mUEEPMauY0OW";
    public static string authToken { get; set; } = "";
    public static class API
    {
        // public static string ApiKey { get; } = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiJhZG1pbl9hcGkiLCJuYW1lIjoiYWRtaW5fYXBpIiwiZW1haWwiOiJhZG1pbl9hcGkiLCJuYmYiOjE3MDQ0NDI2NDYsImV4cCI6MTcwNDQ0NjI0NiwiaWF0IjoxNzA0NDQyNjQ2LCJpc3MiOiJTZWN1cmVBcGkiLCJhdWQiOiJTZWN1cmVBcGlVc2VyIn0.ZgklhLaCQmXIAy3BfZZsl-bWy-jCwdo5sN0kL8WjUnw";
        public static string ApibaseUrl { get; } = " https://localhost:7090/api/";
        public static string ApibaseUrl2 { get; } = " https://localhost:7214/api/";
    }
    public static class App
    {
        public const string Deposit = "Deposit/";
        public const string Finance = "Finance/";
        public const string Loan = "Loan/";

    }
    public static class Paths
    {
        //login
        public const string OfGetConnection = "Login/OfGetConnection"; 
        public const string UserLogin = "Login/OfAuthLogin"; 
        public const string UseOfAuthPagePermiss= "Login/OfAuthPagePermiss";
        public const string OfGetCoopid = "Login/OfGetCoopid";

        //deposit
        public const string DepOfInitDataOffline = "DepOfInitDataOffline";
        public const string DepOfGetAccountSaving = "Deposit/DepOfGetAccountSaving";
        public const string DepOfPostDeptSaving = "Deposit/DepOfPostDeptSaving";
        public const string DepOfPostWithSaving = "Deposit/DepOfPostWithSaving";
        public const string DepOfInitOpenAccount = "Deposit/DepOfInitOpenAccount";
        public const string DepOfPostOpenAccount = "Deposit/DepOfPostOpenAccount";
        public const string DepOfGetMemberOpenAccount = "Deposit/DepOfGetMemberOpenAccount";
        public const string DepOfGetBank = "Deposit/DepOfGetBank"; 
        public const string DepOfGetBankBranch = "Deposit/DepOfGetBankBranch";
        public const string DepOfGetDeptMaintype = "Deposit/DepOfGetDeptMaintype";
        public const string DepOfInitDeptPassbook = "Deposit/DepOfInitDeptPassbook";
        public const string DeptOfGetPrintSlip = "DeptOfGetPrintSlip?deptslip_no"; 
        public const string DepOfDataStatement = "DepOfDataStatement?deptaccount_no"; 
        public const string DepOfCalIntPrncfix = "DepOfCalIntPrncfix"; 
        public const string DepOfGetBookNew = "DepOfGetBookNew"; 
        public const string DepOfPutBookNew = "DepOfPutBookNew"; 

        //Loan
        public const string PostMemeber = "PostMemeber";
        

    }
    public static class Print
    {
        public const string DepOfPrintSlip = "Print/DepOfPrintSlip";
        public const string DeptOfGetPrintSlip = "Print/DeptOfGetPrintSlip"; 
        public const string DepOfPostPrintBook = "Print/DepOfPostPrintBook";
        public const string DepOfGetFrontbook = "Print/DepOfGetFrontbook"; 
        public const string DepOfGetInitPrintBook = "Print/DepOfGetInitPrintBook"; 
    }
   
}