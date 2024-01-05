public static class ApiClient
{
    public static class API
    {
        public static string ApibaseUrl { get; } = " https://localhost:7000/api/";
    }
    public static class Paths
    {
        //login
        public const string UserLogin = "Login";
        //deposit
        public const string DepOfInitDataOffline = "Deposit/DepOfInitDataOffline";
        public const string DepOfGetAccountSaving = "Deposit/DepOfGetAccountSaving";
        public const string DepOfPostDeptSaving = "Deposit/DepOfPostDeptSaving";
        public const string DepOfPostWithSaving = "Deposit/DepOfPostWithSaving";
        public const string DepOfInitOpenAccount = "Deposit/DepOfInitOpenAccount";
        public const string DepOfPostOpenAccount = "Deposit/DepOfPostOpenAccount";
        public const string DepOfGetMemberOpenAccount = "Deposit/DepOfGetMemberOpenAccount";
        public const string DepOfGetBank = "Deposit/DepOfGetBank";
        public const string DepOfGetBankBranch = "Deposit/DepOfGetBankBranch";
        public const string DepOfInitDeptPassbook = "Deposit/DepOfInitDeptPassbook";

    }
}