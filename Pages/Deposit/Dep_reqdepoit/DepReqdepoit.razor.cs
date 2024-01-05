using Newtonsoft.Json;
using FinanceApp.Models;
using System.Net;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using System.Text;
using Newtonsoft.Json.Linq;
using Radzen;
using System.IO;
using Microsoft.AspNetCore.Components.Web;


namespace FinanceApp.Pages.Deposit.Dep_reqdepoit
{
    public partial class DepReqdepoit
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
        public string? operate_code { get; set; }
        public DateTime? calint_from { get; set; }
        public int? sign_flag { get; set; }
        public string? laststmseq_no { get; set; }
        public string? nobook_flag { get; set; }
        public string? prnc_no { get; set; }
        public decimal? deptslip_amt { get; set; }
        public decimal? deptslip_netamt { get; set; }
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
        public int? deptclose_status { get; set; }

        // public string? membcat_code { get; set; }
        public string? salary_id { get; set; }
        public string? fullgroup { get; set; }
        public List<GetBank>? getBank { get; set; }
        public List<GetOfBookNo>? getOfBookNo { get; set; }
        public List<GetBookNo>? getBookNo { get; set; }
        public List<BankBranch>? bankBranch { get; set; }
        private string BankBranchValues { get; set; }
        private string BankValues { get; set; }
        void ShowNotification(NotificationMessage message)
        {
            NotificationService.Notify(message);
        }
        public List<Models.DepReqdepoit> repReqdepoit;
        public List<DepReqdepoitDeails> depReqdepoitDeails;
        public List<DeptSlip> deptSlipOpe;
        private List<ReqAccDetails> depOfGetAccDetails;

        private string DepttypeValue;
        private string Valueselecte;
        private string recpPayTypeCode;
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
            DepttypeValue = e.Value.ToString();
            depttype_code = DepttypeValue;
            Console.WriteLine($"Depttype Code: {DepttypeValue}");
        }
        private void AnotherFunction()
        {
            GetBank();
            BankBranch();
            GetBookNo();
        }
        private decimal deptslipAmt { get; set; }
        private string deptslipNetamt { get; set; }
        private string DeptslipAmt { get; set; }
        private void FormatNumber()
        {

            if (decimal.TryParse(DeptslipAmt, out decimal result))
            {
                // DeptslipAmt = result.ToString("0.00");
                // result = Math.Round(result, 2);
                // deptslipAmt = result;
                // Console.WriteLine(deptslipAmt);

                DeptslipAmt = result.ToString("N2");

                // นำค่าที่ได้มา round และกำหนดให้กับตัวแปร result
                result = Math.Round(result, 2);

                // นำค่าที่ได้มากำหนดให้กับตัวแปร deptslipAmt (หาก deptslipAmt เป็นตัวแปรที่ถูกประกาศแล้ว)
                deptslipAmt = result;

                // แสดงค่าใน Console
                Console.WriteLine(deptslipAmt);


            }
        }
        private async void UpdateAccountDetails(Models.ReqAccDetails data)
        {
            AnotherFunction();
            try
            {
                member_no = data.member_no;
                Console.WriteLine($"Clicked on coop_id: {coop_id}");
                Console.WriteLine($"Clicked on member_no: {data.member_no}");
                await jsRuntime.InvokeVoidAsync("alert", $"เลือก {data.member_no}, {data.memb_name}  {data.memb_surname}");

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
                Console.WriteLine(json);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var apiUrl = $"{ApiClient.API.ApibaseUrl}{Paths.DepOfInitOpenAccount}";
                var response = await httpClient.PostAsync(apiUrl, content);
                response.EnsureSuccessStatusCode();
                Console.WriteLine(response.IsSuccessStatusCode);
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(jsonResponse);
                if (apiResponse.status == true)
                {
                    repReqdepoit = new List<Models.DepReqdepoit> { apiResponse.data };

                    StateHasChanged();
                    Console.WriteLine($"API request failed: {repReqdepoit}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private async Task Search()
        {
            AnotherFunction();
            if (member_no == null || member_no == "")
            {
                ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = "กรุณากรอกเลขทะเบียนสมาชิก", Duration = 1500 });
            }
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
                        entry_date = DateTime.Today,
                        deptitem_group = deptitem_group,
                        reqappl_flag = reqappl_flag,
                        membcat_code = "10"
                    };
                    var json = JsonConvert.SerializeObject(depOfGetAccount);
                    Console.WriteLine(json);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var apiUrl = $"{ApiClient.API.ApibaseUrl}{Paths.DepOfInitOpenAccount}";
                    var response = await httpClient.PostAsync(apiUrl, content);

                    Console.WriteLine(response.IsSuccessStatusCode);
                    if (response.IsSuccessStatusCode)
                    {
                        // อ่าน response string
                        var jsonResponse = await response.Content.ReadAsStringAsync();
                        var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(jsonResponse);
                        Console.WriteLine(apiResponse.status == true);
                        if (apiResponse.status == true)
                        {
                            repReqdepoit = new List<Models.DepReqdepoit> { apiResponse.data };
                            Console.WriteLine($"API request failed: {repReqdepoit}");
                        }
                        else
                        {

                            var Error = JsonConvert.SerializeObject(apiResponse.message);
                            // Console.WriteLine(Error);
                            ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = Error, Duration = 5000 });
                        }
                    }
                }
                // var repReqdepoitDetails = new List<Models.DepReqdepoit>();

                catch (Exception ex)
                {
                    ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = ex.Message, Duration = 5000 });
                    Console.WriteLine(ex.Message.ToString());
                    isLoading = false;
                }
                finally
                {
                    isLoading = false;
                }
            }
        }
        private async Task SearchOfGetAcc()
        {
            try
            {
                isLoadingModals = true;
                var depOfGetAccount = new ReqAccDetails
                {
                    coop_id = "065001",
                    memcoop_id = "065001",
                    deptaccount_no = null,
                    deptaccount_name = null,
                    member_no = member_No_fild,
                    depttype_code = null,
                    deptclose_status = 0,
                    memb_name = null,
                    memb_surname = null,
                    card_person = null,
                    mem_telmobile = null,
                    full_name = null,
                    salary_id = null,
                    membgroup_code = null,
                    membgroup_desc = null,
                    entry_date = null,
                    deptitem_group = null,
                    reqappl_flag = 0,
                    membcat_code = null
                };
                var json = JsonConvert.SerializeObject(depOfGetAccount);
                Console.WriteLine(json);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var apiUrl = $"{ApiClient.API.ApibaseUrl}{Paths.DepOfGetMemberOpenAccount}";
                var response = await httpClient.PostAsync(apiUrl, content);

                Console.WriteLine(response.IsSuccessStatusCode);
                if (response.IsSuccessStatusCode)
                {
                    // อ่าน response string
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var jsonResponse1 = JObject.Parse(jsonResponse);
                    depOfGetAccDetails = jsonResponse1["data"].ToObject<List<ReqAccDetails>>();
                }
                var accountDetailsList = new List<Models.ReqAccDetails>();
                if (depOfGetAccDetails != null)
                {
                    foreach (var accDetails in depOfGetAccDetails)
                    {
                        var accountDetails = new Models.ReqAccDetails
                        {
                            coop_id = accDetails.coop_id,
                            memcoop_id = accDetails.memcoop_id,
                            deptaccount_no = accDetails.deptaccount_no,
                            deptaccount_name = accDetails.deptaccount_name,
                            member_no = accDetails.member_no,
                            depttype_code = accDetails.depttype_code,
                            deptclose_status = accDetails.deptclose_status,
                            memb_name = accDetails.memb_name,
                            memb_surname = accDetails.memb_surname,
                            card_person = accDetails.card_person,
                            mem_telmobile = accDetails.mem_telmobile,
                            full_name = accDetails.full_name,
                            salary_id = accDetails.salary_id,
                            membgroup_code = accDetails.membgroup_code,
                            membgroup_desc = accDetails.membgroup_desc,
                            entry_date = DateTime.Today,
                            deptitem_group = accDetails.deptitem_group,
                            reqappl_flag = accDetails.reqappl_flag,
                            membcat_code = accDetails.membcat_code,
                            membcat_desc = accDetails.membcat_desc

                        };

                        // Optional: You might want to add this to the list
                        accountDetailsList.Add(accountDetails);

                        // Console.WriteLine($"Coop ID: {accDetails.coop_id}, Member Name: {accDetails.memb_name}, membcat_desc: {accDetails.membcat_desc}");
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
        private async Task HandleEnterKeyPress(KeyboardEventArgs e)
        {
            if (e.Code == "Enter")
            {
                await PerformSearch();
            }
        }
        private async Task PerformSearch()
        {
            isLoading = true;

            AnotherFunction();

            if (string.IsNullOrEmpty(member_no))
            {
                ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = "กรุณากรอกเลขทะเบียนสมาชิก", Duration = 1500 });
            }
            else
            {
                await CallApi();
            }

            isLoading = false;
        }

        private async Task CallApi()
        {
            try
            {
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
                    entry_date = DateTime.Today,
                    deptitem_group = deptitem_group,
                    reqappl_flag = reqappl_flag,
                    membcat_code = "10"
                };
                var json = JsonConvert.SerializeObject(depOfGetAccount);
                Console.WriteLine(json);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var apiUrl = $"{ApiClient.API.ApibaseUrl}{Paths.DepOfInitOpenAccount}";
                var response = await httpClient.PostAsync(apiUrl, content);

                Console.WriteLine(response.IsSuccessStatusCode);
                if (response.IsSuccessStatusCode)
                {
                    // อ่าน response string
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(jsonResponse);
                    Console.WriteLine(apiResponse.status == true);
                    if (apiResponse.status == true)
                    {
                        repReqdepoit = new List<Models.DepReqdepoit> { apiResponse.data };
                        Console.WriteLine($"API request failed: {repReqdepoit}");
                    }
                    else
                    {

                        var Error = JsonConvert.SerializeObject(apiResponse.message);
                        // Console.WriteLine(Error);
                        ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = Error, Duration = 5000 });
                    }
                }
                // โค้ดเกี่ยวกับการเรียก API ที่เหมือนเดิม
            }
            catch (Exception ex)
            {
                ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = ex.Message, Duration = 5000 });
                Console.WriteLine(ex.Message.ToString());
            }
        }
        private async Task RecpPayTypeChanged(ChangeEventArgs e)
        {
            recpPayTypeCode = e.Value.ToString();
            Console.WriteLine($" Recp Pay Type Code: {recpPayTypeCode}");
            // if (recpPayTypeCode == "DEN")
            // {
            //     GetBabk();
            //     BankBranch();
            // }
        }
        private async Task GetBookNo()
        {
            try
            {
                string book_no;
                var depOfGetBookNo = new GetBookNo
                {
                    coop_id = "065001",
                    depttype_code = "10",
                    membcat_code = "10",
                };
                var json = JsonConvert.SerializeObject(depOfGetBookNo);
                Console.WriteLine(json);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var apiUrl = $"{ApiClient.API.ApibaseUrl}{Paths.DepOfInitDeptPassbook}";
                var response = await httpClient.PostAsync(apiUrl, content);
                response.EnsureSuccessStatusCode();
                Console.WriteLine(response.IsSuccessStatusCode);
                if (response.IsSuccessStatusCode)
                {
                    // อ่าน response string
                    var OfBookNoJson = await response.Content.ReadAsStringAsync();
                    var OfBookNoList = JsonConvert.DeserializeObject<List<GetOfBookNo>>(OfBookNoJson);
                    getOfBookNo = new List<GetOfBookNo>();
                    getOfBookNo.AddRange(OfBookNoList);
                    // foreach (var item in OfBookNoList)
                    // {
                    //     Console.WriteLine($"book_no: {item.book_no}");
                    // }

                    // var jsonResponse = await response.Content.ReadAsStringAsync();
                    // Console.WriteLine(jsonResponse);
                    // var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(jsonResponse);
                    // Console.WriteLine(apiResponse.status == true);
                    // if (apiResponse.status == true)
                    // {
                    //     // repReqdepoit = new List<Models.DepReqdepoit> { apiResponse.data };
                    //     // Console.WriteLine($"API request failed: {repReqdepoit}");
                    // }
                    // else
                    // {

                    //     var Error = JsonConvert.SerializeObject(apiResponse.message);
                    //     Console.WriteLine(Error);
                    //     ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = Error, Duration = 5000 });
                    // }
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
        private int type_monthintpay;
        // private async Task BookNo(ChangeEventArgs e)
        // {
        //     var type_Value = e.Value.ToString();
        //     type_monthintpay = int.Parse(type_Value);
        //     Console.WriteLine($"type_monthintpay: {type_monthintpay}");
        //     if (type_monthintpay == 1)
        //     {
        //         await GetBookNo();
        //         // await LoadData();


        //         foreach (var item in getOfBookNo)
        //         {
        //             Console.WriteLine($"book_no: {item.book_no}");
        //         }
        //     }
        // }
        private async Task BookNo(ChangeEventArgs e)
        {
            var type_Value = e.Value.ToString();
            type_monthintpay = int.Parse(type_Value);
            Console.WriteLine($"type_monthintpay: {type_monthintpay}");
            if (type_monthintpay == 1)
            {
                await GetBookNo();
                foreach (var item in getOfBookNo)
                {
                    Console.WriteLine($"book_no: {item.book_no}");
                }
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
                    var SlipOpen = item.deptSlip;
                    var ItemdeptSlipdet = item.deptSlipdet;
                    var ItemdeptSlipCheque = item.deptSlipCheque;
                    var DeptSlip = new DeptSlip
                    {
                        coop_id = item.coop_id,
                        deptcoop_id = "065001",
                        deptslip_no = item.deptslip_no,
                        member_no = item.member_no,
                        depttype_code = DepttypeValue ?? item.depttype_code,
                        membcat_code = item.membcat_code,
                        deptgroup_code = item.deptgroup_code,
                        recppaytype_code = recpPayTypeCode ?? item.recppaytype_code,
                        deptno_format = item.deptno_format ?? "null",
                        deptaccount_no = item.deptaccount_no ?? "null",

                        moneytype_code = item.moneytype_code,
                        bank_code = item.bank_code,
                        bankbranch_code = item.bankbranch_code,
                        entry_id = "item.entry_id",
                        machine_id = machine_id,
                        tofrom_accid = item.tofrom_accid,
                        operate_date = DateTime.Today,
                        entry_date = DateTime.Today,
                        operate_code = item.operate_code,
                        sign_flag = 1,

                        nobook_flag = item.nobook_flag,
                        deptslip_amt = deptslipAmt,
                        deptslip_netamt = deptslipAmt,
                        fee_amt = item.fee_amt,
                        oth_amt = item.oth_amt,
                        deptaccount_name = item.deptaccount_name,
                        depttype_desc = DepttypeValue ?? item.depttype_desc,
                        dept_objective = item.dept_objective,
                        prncbal_retire = item.prncbal_retire,
                        remark = item.remark,

                        deptpassbook_no = item.deptpassbook_no,
                        condforwithdraw = item.condforwithdraw,
                        upint_time = item.upint_time,
                        deptaccount_ename = item.deptaccount_ename,
                        account_type = item.account_type,
                        monthintpay_meth = item.monthintpay_meth,
                        traninttype_code = item.traninttype_code,
                        tran_deptacc_no = tran_deptacc_no,
                        dept_tranacc_name = item.dept_tranacc_name,
                        deptmonth_status = item.deptmonth_status,

                        deptmonth_amt = item.deptmonth_amt,
                        dept_status = item.dept_status,
                        monthint_status = item.monthint_status,
                        f_tax_rate = item.f_tax_rate,
                        adjdate_status = item.adjdate_status,
                        membcat_desc = item.membcat_desc,

                        prncbal = item.prncbal,
                        withdrawable_amt = item.withdrawable_amt,
                        tax_amt = item.tax_amt,
                        int_amt = item.int_amt,
                        slipnetprncbal_amt = item.slipnetprncbal_amt,
                        prnc_no = item.prnc_no,


                        calint_from = DateTime.Today,
                        laststmseq_no = item.laststmseq_no,
                        prncbal_bf = item.prncbal_bf,
                        posttovc_flag = item.posttovc_flag,
                        refer_slipno = item.refer_slipno,
                        due_date = item.due_date,
                        passbook_flag = item.passbook_flag,
                        deptrequest_docno = item.deptrequest_docno,
                        reqappl_flag = item.reqappl_flag,
                        spcint_rate_status = item.spcint_rate_status,
                        spcint_rate = item.spcint_rate



                    };
                    var DeptSlipdet = new DeptSlipdet();
                    var DeptSlipCheque = new DeptSlipCheque();
                    var Reqdepoit = new Models.DepReqdepoit
                    {
                        deptSlip = DeptSlip,
                        deptSlipdet = null,
                        deptSlipCheque = null,

                    };
                    var json = JsonConvert.SerializeObject(Reqdepoit);
                    Console.WriteLine("JsonData:" + json);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync($"{ApiClient.API.ApibaseUrl}{Paths.DepOfPostOpenAccount}", content);
                    var responseData = await response.Content.ReadAsStringAsync();
                    // Console.WriteLine("JsonData:" + responseData);

                    if (response.IsSuccessStatusCode)
                    {
                        // var responseData = await response.Content.ReadAsStringAsync();
                        var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(responseData);
                        // Console.WriteLine("JsonData:" + apiResponse);

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

        public class ApiResponse
        {
            public bool status { get; set; }
            public Models.DepReqdepoit data { get; set; }
            public string message { get; set; }
        }
    }
}