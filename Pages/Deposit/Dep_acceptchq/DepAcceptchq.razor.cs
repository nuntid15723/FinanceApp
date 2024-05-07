using Newtonsoft.Json;
using FinanceApp.Models;
using System.Net;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using System.Text;
using Newtonsoft.Json.Linq;
using Radzen;
using System.IO;


namespace FinanceApp.Pages.Deposit.Dep_acceptchq
{
    public partial class DepAcceptchq
    {

        public string? coop_id = "065001";
        public int? reqappl_flag = 0;
        public string? deptcoop_id { get; set; }
        public string? deptslip_no { get; set; }
        public string? member_no { get; set; }
        public string? membcat_code { get; set; }
        public string? deptno_format { get; set; }
        public string? deptaccount_no { get; set; }
        public string? depttype_code { get; set; }
        public string? deptgroup_code { get; set; }
        public string? recppaytype_code { get; set; }
        public string? moneytype_code { get; set; }
        public string? bank_code { get; set; }
        public string? bankbranch_code { get; set; }
        public string? entry_id { get; set; }
        public string? machine_id { get; set; }
        public string? tofrom_accid { get; set; }
        public DateTime? operate_date { get; set; }
        public DateTime? entry_date { get; set; }
        public string? calint_from { get; set; }
        public int? sign_flag { get; set; }
        public string? laststmseq_no { get; set; }
        public string? nobook_flag { get; set; }
        public string? prnc_no { get; set; }
        public string? deptslip_amt { get; set; }
        public int? deptslip_netamt { get; set; }
        public decimal? fee_amt { get; set; }
        public decimal? oth_amt { get; set; }
        public decimal? prncbal { get; set; }
        public decimal? withdrawable_amt { get; set; }
        public string? prncbal_bf { get; set; }
        public decimal? tax_amt { get; set; }
        public decimal? int_amt { get; set; }
        public int? slipnetprncbal_amt { get; set; }
        public int? posttovc_flag { get; set; }
        public string? refer_slipno { get; set; }
        public string? deptaccount_name { get; set; }
        public string? depttype_desc { get; set; }
        public string? dept_objective { get; set; }
        public int? prncbal_retire { get; set; }
        public string? remark { get; set; }
        public string? bank { get; set; }
        public string? branch { get; set; }
        public string? due_date { get; set; }
        public string? deptpassbook_no { get; set; }
        public string? condforwithdraw { get; set; }
        public string? passbook_flag { get; set; }
        public string? deptrequest_docno { get; set; }
        public int? upint_time { get; set; }
        public string? deptaccount_ename { get; set; }
        public string? account_type { get; set; }
        public int? monthintpay_meth { get; set; }
        public string? traninttype_code { get; set; }
        public string? tran_deptacc_no { get; set; }
        public string? dept_tranacc_name { get; set; }
        public int? deptmonth_status { get; set; }
        public string? deptmonth_amt { get; set; }
        public string? dept_status { get; set; }
        public int? monthint_status { get; set; }
        public int? f_tax_rate { get; set; }
        public int? adjdate_status { get; set; }
        public string? membcat_desc { get; set; }
        public string? spcint_rate_status { get; set; }
        public string? spcint_rate { get; set; }

        public List<Recppaytype> recppaytype { get; set; }
        public List<Depttype> depttype { get; set; }
        public List<Tofromacc> tofromacc { get; set; }
        public List<Acctype> acctype { get; set; }

        private bool isLoading;
        bool isCurrentOptionSelected = false;
        private bool isUpdateExecuted = false;
        private bool isLoadingModals;

        /// <summary> 
        public string memcoop_id = "065001";
        public string? member_No_fild { get; set; }
        public string? member_name { get; set; }
        public string? member_surname { get; set; }
        public string? memb_name { get; set; }
        public string? memb_surname { get; set; }
        public string? card_person { get; set; }
        public string? mem_telmobile { get; set; }
        public string? full_name { get; set; }
        public string? membgroup_code { get; set; }
        public string? membgroup_desc { get; set; }
        public string? deptitem_group { get; set; }

        // public string? membcat_code { get; set; }

        public string? salary_id { get; set; }
        public string? fullgroup { get; set; }
        public List<GetBank>? getBank { get; set; }
        public List<BankBranch>? bankBranch { get; set; }
        private string BankBranchValues { get; set; }
        private string BankValues { get; set; }
        void ShowNotification(NotificationMessage message)
        {
            NotificationService.Notify(message);
        }
        private List<DepReqdepoit> repReqdepoit;

        private string DepttypeValue;
        private string Valueselecte;
        private async Task GetBank()
        {
            try
            {
                var response = await httpClient.GetAsync($"{ApiClient.API.ApibaseUrl}{Paths.DepOfGetBank}?coop_control={coop_id}");
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var GetBank = JsonConvert.DeserializeObject<List<GetBank>>(json);
                getBank = new List<GetBank>();
                getBank.AddRange(GetBank);
                // foreach (var item in GetBank)
                // {
                //     Console.WriteLine($"bank_code: {item.bank_code},bank_desc: {item.bank_desc},bank_name_e: {item.bank_name_e},bank_shortname_t: {item.bank_shortname_t},");
                // }

            }
            catch (Exception ex)
            {
                ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = ex.Message, Duration = 5000 });
                Console.WriteLine(ex.Message.ToString());
            }
            finally
            {
                isLoading = false;
            }
        }
        private string bank_code_fild;
        private async Task BankBranch()
        {
            try
            {
                var response = await httpClient.GetAsync($"{ApiClient.API.ApibaseUrl}{Paths.DepOfGetBankBranch}?coop_control={coop_id}&bank_code=006");
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var BankBranch = JsonConvert.DeserializeObject<List<BankBranch>>(json);
                bankBranch = new List<BankBranch>();
                bankBranch.AddRange(BankBranch);
                // foreach (var item in BankBranch)
                // {
                //     Console.WriteLine($"bank_code: {item.bank_code},branch_id: {item.branch_id},branch_name: {item.branch_name}");
                // }
            }
            catch (Exception ex)
            {
                ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = ex.Message, Duration = 5000 });
                Console.WriteLine(ex.Message.ToString());
            }
            finally
            {
                isLoading = false;
            }
        }

        private async Task DepttypeChanged(ChangeEventArgs e)
        {
            string[] values = e.Value.ToString().Split('|');
            DepttypeValue = e.Value.ToString();
            depttype_code = values[1];
            Console.WriteLine($"Recp Pay Type Code: {DepttypeValue},Depttype Code: {depttype_code}");
        }
        private async Task Search()
        {
            GetBank();
            BankBranch();
            if (member_no == null || member_no == "")
            {
                ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = "กรุณากรอกเลขทะเบียนสมาชิก", Duration = 1500 });
            }
            // else
            // {
            //     try
            //     {
            //         isLoading = true;
            //         var response = await
            //         httpClient.GetAsync($"{ApiClient.API.ApibaseUrl}{Paths.DepOfInitOpenAccount}?coop_control={coop_id}&member_no={member_no}&reqappl_flag={reqappl_flag}");
            //         response.EnsureSuccessStatusCode();
            //         var json = await response.Content.ReadAsStringAsync();
            //         var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(json);
            //         Console.WriteLine(apiResponse.status == true);
            //         if (apiResponse.status == true)
            //         {
            //             repReqdepoit = new List<Models.DepReqdepoit> { apiResponse.data };
            //             Console.WriteLine($"API request failed: {repReqdepoit}");
            //         }
            //         else
            //         {
            //             ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = "ตรวจสอบเลขที่กรอกให้ถูกต้อง", Duration = 2500 });
            //             Console.WriteLine($"API request failed: {apiResponse.message}");
            //         }
            //     }
            //     catch (Exception ex)
            //     {
            //         ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = ex.Message, Duration = 5000 });
            //         Console.WriteLine(ex.Message.ToString());
            //     }
            //     finally
            //     {
            //         isLoading = false;
            //     }
            // }
            // string memberNo_fild = null;

            // if (member_no != null)
            // {
            //     string[] memberNoDtails = member_no.ToString().Split('-');
            //     string firstPart = memberNoDtails[0];
            //     string secondPart = memberNoDtails[1];
            //     member_no = firstPart + secondPart;
            // }
            else
            {
                try
                {
                    isLoading = true;
                    var depOfGetAccount = new ReqAccDetails
                    {
                        coop_id = "065001",
                        memcoop_id = "065001",
                        deptaccount_no = deptaccount_no,
                        member_no = member_no,
                        depttype_code = depttype_code,
                        salary_id = salary_id,
                        deptclose_status = 0,
                        memb_name = memb_name,
                        memb_surname = memb_surname,
                        card_person = card_person,
                        mem_telmobile = mem_telmobile,
                        full_name = full_name,
                        membgroup_code = membgroup_code,
                        membgroup_desc = membgroup_desc,
                        entry_date = entry_date,
                        deptitem_group = deptitem_group,
                        reqappl_flag = reqappl_flag,
                    };
                    var json = JsonConvert.SerializeObject(depOfGetAccount);
                    // Console.WriteLine(json);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var apiUrl = $"{ApiClient.API.ApibaseUrl}{Paths.DepOfInitOpenAccount}";
                    var response = await httpClient.PostAsync(apiUrl, content);

                    Console.WriteLine(response.IsSuccessStatusCode);
                    if (response.IsSuccessStatusCode)
                    {
                        // อ่าน response string
                        var jsonResponse = await response.Content.ReadAsStringAsync();
                        var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(jsonResponse);
                        // Console.WriteLine(apiResponse.status == true);
                        if (apiResponse.status == true)
                        {
                            repReqdepoit = new List<Models.DepReqdepoit> { apiResponse.data };
                            Console.WriteLine($"API request failed: {repReqdepoit}");
                        }
                    }
                }
                // var repReqdepoitDetails = new List<Models.DepReqdepoit>();

                catch (Exception ex)
                {
                    ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = ex.Message, Duration = 5000 });
                    Console.WriteLine(ex.Message.ToString());
                }
                finally
                {
                    isLoading = false;
                }
            }
        }
        private async Task SearchOfGetAcc()
        {
            string memberNo_fild = null;

            if (member_No_fild != null)
            {
                string[] memberNoDtails = member_No_fild.ToString().Split('-');
                string firstPart = memberNoDtails[0];
                string secondPart = memberNoDtails[1];
                memberNo_fild = firstPart + secondPart;
            }

            try
            {
                isLoadingModals = true;
                var depOfGetAccount = new AccountDetails
                {
                    coop_id = "065001",
                    memcoop_id = "065001",
                    deptaccount_no = memberNo_fild,
                    member_no = member_no,
                    depttype_code = depttype_code,
                    salary_id = salary_id,
                };
                var json = JsonConvert.SerializeObject(depOfGetAccount);
                // Console.WriteLine(json);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var apiUrl = $"{ApiClient.API.ApibaseUrl}{Paths.DepOfGetAccountSaving}";
                var response = await httpClient.PostAsync(apiUrl, content);

                Console.WriteLine(response.IsSuccessStatusCode);
                if (response.IsSuccessStatusCode)
                {
                    // อ่าน response string
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var jsonResponse1 = JObject.Parse(jsonResponse);
                }
                var accountDetailsList = new List<Models.AccountDetails>();
            }
            catch (Exception ex)
            {
                // ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = ex.Message, Duration = 5000 });
                Console.WriteLine(ex.Message.ToString());
            }
            finally
            {
                isLoadingModals = false;
            }

        }
        // private async Task SaveData()
        // {
        //     try
        //     {
        //         // ทำการบันทึกข้อมูลลงในฐานข้อมูล
        //         await SaveDataAsync();

        //         // บันทึก log
        //         Console.WriteLine("บันทึกข้อมูลลงในฐานข้อมูลสำเร็จ");
        //     }
        //     catch (Exception ex)
        //     {
        //         // กรณีเกิด error ในขณะที่บันทึกข้อมูล
        //         Console.WriteLine($"เกิดข้อผิดพลาด: {ex.Message}");
        //     }
        // }
        public async Task SaveDataAsync()
        {
            try
            {

                string hostName = Dns.GetHostName();
                var hostEntry = Dns.GetHostEntry(hostName);
                isLoading = true;
                foreach (var item in repReqdepoit)
                {
                    // var ItemdeptSlip = item.deptSlip;
                    // var ItemdeptSlipdet = item.deptSlipdet;
                    // var ItemdeptSlipCheque = item.deptSlipCheque;
                    var DepReqdepoit = new DepReqdepoit
                    {
                        coop_id = item.coop_id,
                        deptcoop_id = item.deptcoop_id,
                        deptslip_no = item.deptslip_no,
                        member_no = item.member_no,
                        deptno_format = item.deptno_format,
                        deptaccount_no = item.deptaccount_no,
                        membcat_code = item.membcat_code,
                        depttype_code = item.depttype_code,
                        deptgroup_code = item.deptgroup_code,
                        recppaytype_code = item.recppaytype_code,
                        moneytype_code = item.moneytype_code,
                        bank_code = (BankValues == null) ? item.bank_code : BankValues,
                        bankbranch_code = (BankBranchValues == null) ? item.bankbranch_code : BankBranchValues,
                        entry_id = item.entry_id,
                        machine_id = item.machine_id,
                        tofrom_accid = item.tofrom_accid,
                        operate_date = item.operate_date,
                        entry_date = item.entry_date,
                        calint_from = item.calint_from,
                        sign_flag = item.sign_flag,
                        laststmseq_no = item.laststmseq_no,
                        nobook_flag = item.nobook_flag,
                        prnc_no = item.prnc_no,
                        deptslip_amt = item.deptslip_amt,
                        deptslip_netamt = item.deptslip_netamt ?? 0,
                        fee_amt = item.fee_amt ?? 0,
                        oth_amt = item.oth_amt ?? 0,
                        prncbal = item.prncbal ?? 0,
                        withdrawable_amt = item.withdrawable_amt ?? 0,
                        prncbal_bf = item.prncbal_bf,
                        tax_amt = item.tax_amt ?? 0,
                        int_amt = item.int_amt ?? 0,
                        slipnetprncbal_amt = item.slipnetprncbal_amt ?? 0,
                        posttovc_flag = item.posttovc_flag ?? 0,
                        refer_slipno = item.refer_slipno,
                        deptaccount_name = item.deptaccount_name,
                        depttype_desc = item.depttype_desc,
                        dept_objective = item.dept_objective,
                        prncbal_retire = item.prncbal_retire ?? 0,
                        remark = item.remark,
                        bank = item.bank,
                        branch = item.branch,
                        due_date = item.due_date,
                        deptpassbook_no = item.deptpassbook_no,
                        condforwithdraw = item.condforwithdraw,
                        passbook_flag = item.passbook_flag,
                        upint_time = item.upint_time ?? 0,
                        deptaccount_ename = item.deptaccount_ename,
                        deptrequest_docno = item.deptrequest_docno,
                        account_type = item.account_type,
                        monthintpay_meth = item.monthintpay_meth ?? 0,
                        traninttype_code = item.traninttype_code,
                        tran_deptacc_no = item.tran_deptacc_no,
                        dept_tranacc_name = item.dept_tranacc_name,
                        deptmonth_status = item.deptmonth_status,
                        deptmonth_amt = item.deptmonth_amt,
                        dept_status = item.dept_status,
                        monthint_status = item.monthint_status,
                        f_tax_rate = item.f_tax_rate,
                        adjdate_status = item.adjdate_status,
                        membcat_desc = item.membcat_desc,
                        reqappl_flag = item.reqappl_flag,
                        spcint_rate_status = item.spcint_rate_status,
                        spcint_rate = item.spcint_rate,
                    };
                    var json = JsonConvert.SerializeObject(DepReqdepoit);
                    // Console.WriteLine("JsonData:" + json);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync($"{ApiClient.API.ApibaseUrl}DepOfPostDeptSaving", content);
                    var responseData = await response.Content.ReadAsStringAsync();
                    var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(responseData);
                    Console.WriteLine("JsonData:" + json);

                    if (apiResponse.status)
                    {
                        // var responseData = await response.Content.ReadAsStringAsync();
                        // var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(responseData);

                        Console.WriteLine($"apiResponse.status: {apiResponse.status}");
                        var notificationDetail = apiResponse != null ? apiResponse.message : responseData;
                        ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Success, Summary = "Success", Detail = notificationDetail, Duration = 2500 });
                    }
                    else
                    {
                        // Console.WriteLine(responseData);
                        var jsonResponse = JObject.Parse(responseData);
                        var errorsProperty = jsonResponse["errors"];
                        Console.WriteLine(errorsProperty);
                        ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = errorsProperty + "ตรวจสอบข้อมูลให้ครบถ้วน", Duration = 2500 });
                    }
                }
            }
            catch (Exception ex)
            {
                ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = ex.Message, Duration = 2500 });
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                isLoading = false;
            }
        }

        public class ApiResponse
        {
            public bool status { get; set; }
            public Models.DepReqdepoit data { get; set; }
            public string message { get; set; }
        }
    }
}