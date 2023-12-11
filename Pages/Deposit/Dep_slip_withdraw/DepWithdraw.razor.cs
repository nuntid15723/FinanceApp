using Microsoft.JSInterop;
using Newtonsoft.Json;
using FinanceApp.Models;
using Radzen;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Net.Http.Json;
using System.Text.Json;
using FinanceApp.Services;
using System.Text;
using Microsoft.AspNetCore.Components;
using System.Globalization;
using System.Net;
using Newtonsoft.Json.Linq;
using System.ComponentModel;

namespace FinanceApp.Pages.Deposit.Dep_slip_withdraw
{
    public partial class DepWithdraw
    {
        private readonly IApiProvider _apiProvider;
        // private async Task CallAlert(string message)
        // {
        //     await jsRuntime.InvokeVoidAsync("alert", message);
        // }
        private List<Models.Deposit> datadetail;
        private List<Recppaytype> recppaytype;
        private List<Tofromacc> tofromacc;
        private Deptslip? deptSlip;
        private DeptSlipdet? deptSlipdet;
        // private DeptSlipCheque? deptSlipCheque;
        private DepOfGetAccount? depOfGetAccount;
        private List<AccountDetails> depOfGetAccDetails;

        /// <deptSlip>
        private string coop_id = "065001";
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
        public DateTime? calint_from { get; set; }
        public int? operate_code { get; set; }
        public int? sign_flag { get; set; }
        public int? laststmseq_no { get; set; }
        public int? nobook_flag { get; set; }
        public int? prnc_no { get; set; }
        public decimal? deptslip_amt { get; set; }
        public decimal? deptslip_netamt { get; set; }
        public decimal? fee_amt { get; set; }
        public decimal? oth_amt { get; set; }
        public decimal? prncbal { get; set; }
        public decimal? withdrawable_amt { get; set; }
        public decimal? prncbal_bf { get; set; }
        public decimal? tax_amt { get; set; }
        public decimal? int_amt { get; set; }
        public decimal? slipnetprncbal_amt { get; set; }
        public int? posttovc_flag { get; set; }
        public string? refer_slipno { get; set; }
        public string? deptaccount_name { get; set; }
        public string? depttype_desc { get; set; }
        public string? dept_objective { get; set; }
        public int? prncbal_retire { get; set; }
        public string? remark { get; set; }
        public DateTime? due_date { get; set; }
        public string? deptpassbook_no { get; set; }
        public string? condforwithdraw { get; set; }
        public int? upint_time { get; set; }
        public string? deptaccount_ename { get; set; }
        public string? account_type { get; set; }
        public int? monthintpay_meth { get; set; }
        public string? traninttype_code { get; set; }
        public string? tran_deptacc_no { get; set; }
        public string? dept_tranacc_name { get; set; }
        public int? deptmonth_status { get; set; }
        public decimal? deptmonth_amt { get; set; }
        public int? dept_status { get; set; }
        public int? monthint_status { get; set; }
        public decimal? f_tax_rate { get; set; }
        public int? adjdate_status { get; set; }
        public int? membcat_desc { get; set; }
        public int? sequest_amont { get; set; }
        public int? checkpend_amt { get; set; }
        public decimal? intbonus_amt { get; set; }
        // public int? int_return { get; set; }
        // public int? tax_return { get; set; }
        public decimal? int_netamt { get; set; }





        /// < deptSlipdet>
        public decimal? prnc_bal { get; set; }
        public decimal? prnc_amt { get; set; }
        public DateTime? prnc_date { get; set; }
        public DateTime? calint_to { get; set; }
        public DateTime? prncdue_date { get; set; }
        public DateTime? prncmindue_date { get; set; }
        public int? prncdue_nmonth { get; set; }
        public decimal? prncslip_amt { get; set; }
        public decimal? intarr_amt { get; set; }
        public decimal? intpay_amt { get; set; }
        public decimal? taxpay_amt { get; set; }
        public decimal? intbf_accyear { get; set; }
        public int? intcur_accyear { get; set; }
        public DateTime? monthintdue_date { get; set; }
        public DateTime? prncdeptdue_date { get; set; }
        public decimal? interest_rate { get; set; }
        public decimal? int_return { get; set; }
        public decimal? tax_return { get; set; }
        public decimal? other_amt { get; set; }
        public decimal? chequepend_amt { get; set; }
        public int? refer_prnc_no { get; set; }
        /// <deptSlipCheque>
        public string? cheque_no { get; set; }
        public DateTime? cheque_date { get; set; }
        public DateTime? entry_time { get; set; }
        public DateTime? chequedue_date { get; set; }
        public string? cheque_type { get; set; }
        public decimal? cheque_amt { get; set; }
        [DefaultValue(0)]
        public int? seq_no { get; set; }
        [DefaultValue(0)]
        public int? checkclear_status { get; set; }
        /// <summary> 
        // public string coop_id { get; set; }
        // public string memcoop_id { get; set; }
        public string memcoop_id = "065001";
        public string? deptaccount_No_fild { get; set; }
        public string? deptaccountNo_fild { get; set; }
        public string? deptaccount_name_fild { get; set; }
        // public string? member_no { get; set; }
        // public string? depttype_code { get; set; }
        public int deptclose_status { get; set; }
        public string? memb_name { get; set; }
        public string? memb_surname { get; set; }
        public string? card_person { get; set; }
        public string? mem_telmobile { get; set; }
        public string? full_name { get; set; }
        public string? salary_id { get; set; }
        public string? membgroup_code { get; set; }
        public string? membgroup_desc { get; set; }
        public string? deptitem_group { get; set; }
        public int? reqappl_flag { get; set; }
        // public DateTime? entry_date { get; set; }

        /// </summary>        
        private bool isLoading;
        private bool isLoadingModals;
        bool isCurrentOptionSelected = false;
        private bool isUpdateExecuted = false;
        public List<GetBank>? getBank { get; set; }
        public List<BankBranch>? bankBranch { get; set; }

        private async Task GetBank()
        {
            try
            {
                var response = await httpClient.GetAsync($"{Apiurl.ApibaseUrl}{Paths.DepOfGetBank}?coop_control={coop_id}");
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
                var response = await httpClient.GetAsync($"{Apiurl.ApibaseUrl}{Paths.DepOfGetBankBranch}?coop_control={coop_id}&bank_code=006");
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
        void ShowNotification(NotificationMessage message)
        {
            NotificationService.Notify(message);
        }
        //RetriveDataFromDeptNo
        private async void UpdateAccountDetails(Models.AccountDetails data)
        {
            try
            {
                deptaccount_no = data.deptaccount_no?.Trim();

				Console.WriteLine($"Clicked on coop_id: {coop_id}");
                Console.WriteLine($"Clicked on deptaccount_no: {data.deptaccount_no}");
                await jsRuntime.InvokeVoidAsync("alert", $"เลือก {data.deptaccount_no}, {data.deptaccount_name}");
				var depOfGetAccount = new DepOfInitDataOffline
				{
					coop_id = coop_id,
					memcoop_id = coop_id,
					deptno_format = data.deptaccount_no,
					entry_date = null,
					deptitem_group ="WID",
				};
				var jsonReq = JsonConvert.SerializeObject(depOfGetAccount);
				Console.WriteLine(jsonReq);
				var content = new StringContent(jsonReq, Encoding.UTF8, "application/json");
				var apiUrl = $"{Apiurl.ApibaseUrl}{Paths.DepOfInitDataOffline}";
				var response = await httpClient.PostAsync(apiUrl, content);
                //var response = await httpClient.GetAsync($"{Apiurl.ApibaseUrl}DepOfInitDataOffline?coop_control={coop_id}&deptaccount_no={data.deptaccount_no}");

                response.EnsureSuccessStatusCode();
                var jsonRes = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(jsonRes);
                if (apiResponse.status == true)
                {
                    datadetail = new List<Models.Deposit> { apiResponse.data };
                    StateHasChanged();
                    Console.WriteLine($"API request failed: {datadetail}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        private void AnotherFunction()
        {
            GetBank();
            BankBranch();
        }
        //ค้นหา
        private async Task Search()
        {
            AnotherFunction();
            deptno_format = deptno_format?.Trim().Replace("-", "");
            if (deptno_format == null || deptno_format == "")
            {

                ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = "กรุณากรอกเลขที่บัญชี", Duration = 1500 });
            }
            else
            {
                try
                {
                    isLoading = true;                    
                    var depOfGetAccount = new DepOfInitDataOffline
                    {
                        coop_id = "065001",
                        memcoop_id = "065001",
						deptno_format = deptno_format,
                        entry_date = entry_date,
                        deptitem_group = deptitem_group ?? "WID",
                        reqappl_flag = reqappl_flag ?? 0,
                    };
                    var json = JsonConvert.SerializeObject(depOfGetAccount);
                    Console.WriteLine(json);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var apiUrl = $"{Apiurl.ApibaseUrl}{Paths.DepOfInitDataOffline}";
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
                            datadetail = new List<Models.Deposit> { apiResponse.data };
                            Console.WriteLine($"API request failed: {datadetail}");
                            AnotherFunction();
                        }
                    }
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

        }
        //ค้นหาใน dlg
        private async Task SearchOfGetAcc()
        {
            try
            {
                isLoadingModals = true;
                var depOfGetAccount = new AccountDetails
                {
                    coop_id = "065001",
                    memcoop_id = "065001",
                    deptaccount_no = deptaccount_No_fild,

					deptaccount_name = deptaccount_name_fild,
					member_no = member_no,
                    depttype_code = depttype_code,
                    deptclose_status = deptclose_status,
                    memb_name = memb_name,
                    memb_surname = memb_surname,
                    card_person = card_person,
                    mem_telmobile = mem_telmobile,
                    full_name = full_name,
                    salary_id = salary_id,
                    entry_date = entry_date ?? null
                };
                var json = JsonConvert.SerializeObject(depOfGetAccount);
                // Console.WriteLine(json);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var apiUrl = $"{Apiurl.ApibaseUrl}{Paths.DepOfGetAccountSaving}";
                var response = await httpClient.PostAsync(apiUrl, content);

                Console.WriteLine(response.IsSuccessStatusCode);
                if (response.IsSuccessStatusCode)
                {
                    // อ่าน response string
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var jsonResponse1 = JObject.Parse(jsonResponse);
                    depOfGetAccDetails = jsonResponse1["data"].ToObject<List<AccountDetails>>();
                    //Console.WriteLine("depOfGetAccDetails:" + depOfGetAccDetails);
                }
                // dataaccDetails = accountDetailsList;
                var accountDetailsList = new List<Models.AccountDetails>();
                if (depOfGetAccDetails != null)
                {
                    foreach (var accDetails in depOfGetAccDetails)
                    {
                        var accountDetails = new Models.AccountDetails
                        {
                            deptaccount_no = accDetails.deptaccount_no,
                            deptaccount_name = accDetails.deptaccount_name,
                            member_no = accDetails.member_no,
                            full_name = accDetails.full_name
                        };

                        // Optional: You might want to add this to the list
                        accountDetailsList.Add(accountDetails);

                        Console.WriteLine($"Coop ID: {accDetails.coop_id}, Member Name: {accDetails.memb_name}");
                        // Add other properties as needed
                    }
                }
                // Assign the list to dataaccDetails
                dataaccDetails = accountDetailsList;
            }
            catch (Exception ex)
            {
                ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = ex.Message, Duration = 5000 });
                Console.WriteLine(ex.Message.ToString());
            }
            finally
            {
                isLoadingModals = false;
            }

        }
        public class ApiResponse
        {
            public bool status { get; set; }
            public Models.Deposit data { get; set; }
            public string message { get; set; }
        }
        private string selectedValue;
        private string moneytypeCode;

        private string cashTypeValue;
        private string Valueselecte;
        private string Recppaytype_code;
        private string recpPayTypeCode { get; set; }
        private string bankaccount_name { get; set; }
        private string check_no { get; set; }
        private string valuetoFromaccId { get; set; }
        private string toFromaccId2 { get; set; }
        private string bookCode { get; set; }
        private string deptslipNetamt { get; set; }
        private async Task RecpPayTypeChanged(ChangeEventArgs e)
        {
            string[] values = e.Value.ToString().Split('_');
            string[] valuestoFo = e.Value.ToString().Split('|');
            selectedValue = values[0];
            recpPayTypeCode = values[1];
            cashTypeValue = values[2];
            bookCode = selectedValue;
            string[] toFromaccId1 = bookCode.Split('|');
            valuetoFromaccId = toFromaccId1[1];
            Console.WriteLine($"Cash Type: {cashTypeValue}, Recp Pay Type Code: {recpPayTypeCode},toFromaccId:{valuetoFromaccId}");
            if (recpPayTypeCode == "DEN")
            {
                GetBank();
                BankBranch();
            }
        }
        private async Task OnToFromAccChanged(ChangeEventArgs e)
        {
            string[] values = e.Value.ToString().Split('|');
            Valueselecte = values[0];
            toFromaccId2 = values[1];
            Console.WriteLine($"Cash Typee: {bookCode}, Recp Pay Type Code: {Valueselecte},toFromaccId:{valuetoFromaccId}");

        }
        private async Task CheckNumber()
        {
            deptslipNetamt = "50";
            Console.WriteLine($"input: {deptslipNetamt}");
        }
        private async Task SaveDataAsync()
        {
            try
            {

                string hostName = Dns.GetHostName();
                var hostEntry = Dns.GetHostEntry(hostName);
                isLoading = true;
                foreach (var item in datadetail)
                {
                    var ItemdeptSlip = item.deptSlip;
                    var ItemdeptSlipdet = item.deptSlipdet;
                    var ItemdeptSlipCheque = item.deptSlipCheque;
                    var Deptslip = new Deptslip
                    {
                        coop_id = ItemdeptSlip.coop_id,
                        deptcoop_id = ItemdeptSlip.deptcoop_id,
                        deptslip_no = ItemdeptSlip.deptslip_no,
                        member_no = ItemdeptSlip.member_no,
                        deptno_format = ItemdeptSlip.deptno_format,
                        deptaccount_no = ItemdeptSlip.deptaccount_no,
                        membcat_code = ItemdeptSlip.membcat_code,
                        depttype_code = ItemdeptSlip.depttype_code,
                        deptgroup_code = ItemdeptSlip.deptgroup_code,
                        recppaytype_code = recpPayTypeCode ?? ItemdeptSlip.recppaytype_code,
                        moneytype_code = ItemdeptSlip.moneytype_code,
                        bank_code = ItemdeptSlip.bank_code,
                        bankbranch_code = ItemdeptSlip.bankbranch_code,
                        entry_id = "entry_id",
                        machine_id = ItemdeptSlip.machine_id,
                        tofrom_accid = ItemdeptSlip.tofrom_accid,
                        operate_date = DateTime.Today,
                        entry_date = DateTime.Today,
                        calint_from = DateTime.Today,
                        sign_flag = ItemdeptSlip.sign_flag,
                        laststmseq_no = ItemdeptSlip.laststmseq_no,
                        nobook_flag = ItemdeptSlip.nobook_flag,
                        prnc_no = ItemdeptSlip.prnc_no,
                        deptslip_amt = ItemdeptSlip.deptslip_amt,
                        deptslip_netamt = ItemdeptSlip.deptslip_netamt,
                        fee_amt = ItemdeptSlip.fee_amt,
                        oth_amt = ItemdeptSlip.oth_amt,
                        prncbal = ItemdeptSlip.prncbal,
                        withdrawable_amt = ItemdeptSlip.withdrawable_amt,
                        prncbal_bf = ItemdeptSlip.prncbal_bf,
                        tax_amt = ItemdeptSlip.tax_amt,
                        int_amt = ItemdeptSlip.int_amt,
                        slipnetprncbal_amt = ItemdeptSlip.slipnetprncbal_amt,
                        posttovc_flag = ItemdeptSlip.posttovc_flag,
                        refer_slipno = ItemdeptSlip.refer_slipno,
                        deptaccount_name = ItemdeptSlip.deptaccount_name,
                        depttype_desc = ItemdeptSlip.depttype_desc,
                        dept_objective = ItemdeptSlip.dept_objective,
                        prncbal_retire = ItemdeptSlip.prncbal_retire,
                        remark = ItemdeptSlip.remark,
                        due_date = DateTime.Today,
                        deptpassbook_no = ItemdeptSlip.deptpassbook_no,
                        condforwithdraw = ItemdeptSlip.condforwithdraw,
                        passbook_flag = ItemdeptSlip.passbook_flag,
                        upint_time = ItemdeptSlip.upint_time,
                        deptaccount_ename = ItemdeptSlip.deptaccount_ename,
                        deptrequest_docno = ItemdeptSlip.deptrequest_docno,
                        account_type = ItemdeptSlip.account_type,
                        monthintpay_meth = ItemdeptSlip.monthintpay_meth,
                        traninttype_code = ItemdeptSlip.traninttype_code,
                        tran_deptacc_no = ItemdeptSlip.tran_deptacc_no,
                        dept_tranacc_name = ItemdeptSlip.dept_tranacc_name,
                        deptmonth_status = ItemdeptSlip.deptmonth_status,
                        deptmonth_amt = ItemdeptSlip.deptmonth_amt,
                        dept_status = ItemdeptSlip.dept_status,
                        monthint_status = ItemdeptSlip.monthint_status,
                        f_tax_rate = ItemdeptSlip.f_tax_rate,
                        adjdate_status = ItemdeptSlip.adjdate_status,
                        membcat_desc = ItemdeptSlip.membcat_desc,
                        reqappl_flag = ItemdeptSlip.reqappl_flag,
                        spcint_rate_status = ItemdeptSlip.spcint_rate_status,
                        spcint_rate = ItemdeptSlip.spcint_rate,
                    };
                    var DeptSlipdet = new DeptSlipdet();
                    //{
                    //    coop_id = (coop_id == null) ? ItemdeptSlipdet.coop_id : null,
                    //    deptslip_no = (deptslip_no == null) ? ItemdeptSlipdet.deptslip_no : null,

                    //    deptaccount_no = (deptaccount_no == null) ? ItemdeptSlipdet.deptaccount_no : null,
                    //    prnc_no = (prnc_no == null) ? ItemdeptSlipdet.prnc_no : null,

                    //    prnc_bal = (prnc_bal == null) ? ItemdeptSlipdet.prnc_bal : null,
                    //    prnc_amt = (prnc_amt == null) ? ItemdeptSlipdet.prnc_amt : null,
                    //    prnc_date = (prnc_date == null) ? ItemdeptSlipdet.prnc_date : null,
                    //    calint_from = (calint_from == null) ? ItemdeptSlipdet.calint_from : null,
                    //    calint_to = (calint_to == null) ? ItemdeptSlipdet.calint_to : null,
                    //    prncdue_date = (prncdue_date == null) ? ItemdeptSlipdet.prncdue_date : null,
                    //    prncmindue_date = (prncmindue_date == null) ? ItemdeptSlipdet.prncmindue_date : null,
                    //    prncdue_nmonth = (prncdue_nmonth == null) ? ItemdeptSlipdet.prncdue_nmonth : null,
                    //    prncslip_amt = (prncslip_amt == null) ? ItemdeptSlipdet.prncslip_amt : null,

                    //    intarr_amt = (intarr_amt == null) ? ItemdeptSlipdet.intarr_amt : null,
                    //    intpay_amt = (intpay_amt == null) ? ItemdeptSlipdet.intpay_amt : null,
                    //    taxpay_amt = (taxpay_amt == null) ? ItemdeptSlipdet.taxpay_amt : null,
                    //    intbf_accyear = (intbf_accyear == null) ? ItemdeptSlipdet.intbf_accyear : null,
                    //    intcur_accyear = (intcur_accyear == null) ? ItemdeptSlipdet.intcur_accyear : null,

                    //    monthintdue_date = (monthintdue_date == null) ? ItemdeptSlipdet.monthintdue_date : null,
                    //    prncdeptdue_date = (prncdeptdue_date == null) ? ItemdeptSlipdet.prncdeptdue_date : null,

                    //    interest_rate = (interest_rate == null) ? ItemdeptSlipdet.interest_rate : null,
                    //    int_return = (int_return == null) ? ItemdeptSlipdet.int_return : null,
                    //    tax_return = (tax_return == null) ? ItemdeptSlipdet.tax_return : null,
                    //    fee_amt = (fee_amt == null) ? ItemdeptSlipdet.fee_amt : null,
                    //    other_amt = (other_amt == null) ? ItemdeptSlipdet.other_amt : null,
                    //    chequepend_amt = (chequepend_amt == null) ? ItemdeptSlipdet.chequepend_amt : null,
                    //    refer_prnc_no = (refer_prnc_no == null) ? ItemdeptSlipdet.refer_prnc_no : null,
                    //    upint_time = (upint_time == null) ? ItemdeptSlipdet.upint_time : null,
                    //};
                    var DeptSlipCheque = new DeptSlipCheque();
                    // {
                    // coop_id = (coop_id == null) ? ItemdeptSlipCheque.coop_id : null,
                    // deptslip_no = (deptslip_no == null) ? ItemdeptSlipCheque.deptslip_no : null,
                    // deptaccount_no = (deptaccount_no == null) ? ItemdeptSlipCheque.deptaccount_no : null,
                    // cheque_no = (cheque_no == null) ? ItemdeptSlipCheque.cheque_no : null,
                    // bank_code = (bank_code == null) ? ItemdeptSlipCheque.bank_code : null,
                    // bankbranch_code = (bankbranch_code == null) ? ItemdeptSlipCheque.bankbranch_code : null,
                    // cheque_date = (cheque_date == null) ? ItemdeptSlipCheque.cheque_date : null,
                    // entry_date = (entry_date == null) ? ItemdeptSlipCheque.entry_date : null,
                    // entry_time = (entry_time == null) ? ItemdeptSlipCheque.entry_time : null,
                    // chequedue_date = (chequedue_date == null) ? ItemdeptSlipCheque.chequedue_date : null,
                    // cheque_type = (cheque_type == null) ? ItemdeptSlipCheque.cheque_type : null,
                    // cheque_amt = (cheque_amt == null) ? ItemdeptSlipCheque.cheque_amt : null,
                    // seq_no = (seq_no == null) ? ItemdeptSlipCheque.seq_no : null,
                    // checkclear_status = (checkclear_status == null) ? ItemdeptSlipCheque.checkclear_status : null,
                    // entry_id = (entry_id == null) ? ItemdeptSlipCheque.entry_id : null,
                    // depttype_code = (depttype_code == null) ? ItemdeptSlipCheque.depttype_code : null,
                    // };
                    // foreach (var rowsItem in rows)
                    // {
                    //     DeptSlipCheque = new DeptSlipCheque
                    //     {
                    //         coop_id = coop_id,
                    //         deptslip_no = deptslip_no,

                    //         deptaccount_no = deptaccount_no,
                    //         cheque_no = rowsItem.cheque_no,

                    //         bank_code = rowsItem.bank_code,
                    //         bankbranch_code = rowsItem.branch_id,
                    //         cheque_date = DateTime.Now,
                    //         entry_date = DateTime.Now,
                    //         entry_time = DateTime.Now,
                    //         chequedue_date = chequedue_date,

                    //         cheque_type = rowsItem.cheque_type,

                    //         cheque_amt = rowsItem.cheque_amt ?? 0,
                    //         seq_no = rowsItem.seq_no ?? 0,
                    //         checkclear_status = rowsItem.checkclear_status,
                    //         entry_id = "Admin_id",
                    //         depttype_code = ItemdeptSlip.depttype_code,
                    //     };
                    // };
                    var Deposit = new Models.Deposit
                    {
                        deptSlip = Deptslip,
                        deptSlipdet = null,
                        deptSlipCheque = null,

                    };
                    var json = JsonConvert.SerializeObject(Deposit);
                    Console.WriteLine("JsonData:" + json);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync($"{Apiurl.ApibaseUrl}DepOfPostWithSaving", content);
                    var responseData = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("JsonData:" + responseData);

                    if (response.IsSuccessStatusCode)
                    {
                        // var responseData = await response.Content.ReadAsStringAsync();
                        var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(responseData);

                        Console.WriteLine($"IsSuccessStatusCode: {response.IsSuccessStatusCode}");
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
        public class ErrorResponse
        {
            public string? Type { get; set; }
            public string? Title { get; set; }
            public bool? Status { get; set; }
            public string? TraceId { get; set; }
            public Errors Errors { get; set; }
        }
        public class Errors
        {
            // public string errors { get; set; }
            public Dictionary<string, List<string>> errors { get; set; }
        }
        public async Task<HttpResponseMessage> PostAsync<T>(string uri, T item)
        {
            uri = Apiurl.ApibaseUrl + uri;
            var json = JsonConvert.SerializeObject(item);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            return await httpClient.PostAsync(uri, content);
        }
    }
}