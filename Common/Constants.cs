public static class Constants
{
    //public const string UniqueId = "b82d21f9badad90";
    public const string UniqueId = "aCq2mUEEPMauY0OW";
    public static string authToken { get; set; } = "";


    public static class API
    {
        public static string ApiKey { get; } = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJjaGFubmVsIjoibW9iaWxlX2FwcCIsInJlc291cmNlX2FwcF9pZCI6ImNvbS5lZ2F0c2F2aW5nLm1vYmlsZSIsImRldmljZV9uYW1lIjoiZ29vZ2xlIHNka19ncGhvbmU2NF9hcm02NCIsImlwX2FkZHJlc3MiOiI1OC4xMS4xODguMzMiLCJleHAiOjE2OTk5OTQ1MDh9.9VevRbCfrKWDyeTvTsrEeD2Pr885EYH6pXiPsIDIUkE";
        public static string ApiEndpoint { get; } = "http://43.229.79.117/mobile/service-igat-test/core-control/";
        public static string ApiEndpointPro { get; } = "https://mobilecore.gensoft.co.th/EGATCOOP/core-control/";
    }

    public static class Paths
    {
        public const string UserLogin = "authorization/login";

        public const string fetchsystemsms = "sms/dashboard/fetch_system_mesage";
        public const string fetchsms = "sms/dashboard/fetch_send_sms";

        //Log
        public const string fetchloglogin = "log/log_system_access/log_login/fetch_log_login";
        public const string fetchlogApp = "log/log_system_access/log_application_use/fetch_log_application_use";
        public const string fetchlogAdmin = "log/log_system_access/log_addmin_usage/fetch_log_admin_uage";
        public const string fetchlogLock = "log/log_system_access/log_lock_account/fetch_log_lock_account";
        public const string fetchlogWithdraw = "log/log_online_transaction/fetch_log_withdraw_online";
        public const string fetchlogDeposit = "log/log_online_transaction/fetch_log_deposit_online";
        public const string fetchlogTransfer = "log/log_online_transaction/fetch_log_transfer";
        public const string fetchlogBind = "log/log_online_transaction/fetch_log_bind_account";
        public const string fetchlogUnbind = "log/log_online_transaction/fetch_log_unbind_account";
        public const string fetchlogAllow = "log/log_online_transaction/fetch_log_allow_account_transaction";
        public const string fetchlogScReq = "";
        public const string fetchlogScRes = "";
        public const string fetchlogScTranc = "";
        public const string fetchlogAdminUse = "log/log_system_access/log_addmin_usage/fetch_log_admin_uage";
        public const string fetchlogAppUse = "log/log_system_access/log_application_use/fetch_log_application_use";
        public const string fetchlogAdminControl = "log/log_editdata/fetch_log_edit_admin_control";
        public const string fetchlogMobileAdmin = "log/log_editdata/fetch_log_edit_mobile_admin";
        public const string fetchlogBindErr = "log/log_usage_error/fetch_log_bind_account_error";
        public const string fetchlogDepositErr = "log/log_usage_error/fetch_log_deposit_error";
        public const string fetchlogDeptErr = "log/log_usage_error/fetch_log_dept_transbank_error";
        public const string fetchlogUsageErr = "log/log_usage_error/fetch_log_error_usage";
        public const string fetchlogTransferErr = "log/log_usage_error/fetch_log_transfer_inside_error";
        public const string fetchlogWithdrawErr = "log/log_usage_error/fetch_log_withdraw_error";

        //Send noti
        public const string fetchPreviewBeforeSend = "sms/manual/preview_message_before_send";
        public const string sendMessageNotify = "sms/manual/send_message_notify";
        public const string sendMessageAhead = "sms/settings/sendahead/insert_sendahead";

        //ConstSms
        public const string fecthConstDeptSms = "sms/constantsms/constantsmsdeposit/fetch_constdeptsms";
        public const string UpdateConstDeptSms = "sms/constantsms/constantsmsdeposit/update_constdeptsms";
        public const string fecthConstLoanSms = "sms/constantsms/constantsmsloan/fetch_constloansms";
        public const string UpdateConstLoanSms = "sms/constantsms/constantsmsloan/update_constloansms";
        public const string fecthConstShareSms = "sms/constantsms/constantsmsshare/fetch_constsharesms";
        public const string UpdateConstShareSms = "sms/constantsms/constantsmsshare/update_constsharesms";

        //Report
        public const string ReportSendSms = "sms/report/report_smstranwassent";
        public const string ReportNotSendSms = "sms/report/report_smswasnotsent";
        public const string ReportNoti = "sms/report/report_notifywassent";

        //Setting
        public const string SettingTemplateDelete = "sms/settings/template/delete_template";
        public const string SettingTemplateEdit = "sms/settings/template/edit_template";
        public const string SettingTemplateFetch = "sms/settings/template/fetch_template";
        public const string SettingTemplateInsert = "sms/settings/template/insert_template";
        public const string SettingTemplateQuery = "sms/settings/template/query_data_form";
        public const string SettingTemplateSystemEdit = "sms/settings/systemtemplate/edit_system_template";
        public const string SettingTemplateSystemFetch = "sms/settings/systemtemplate/fetch_system_template";
        public const string SettingGroupDelete = "sms/settings/group/delete_group";
        public const string SettingGroupEdit = "sms/settings/group/edit_group";
        public const string SettingGroupFetch = "sms/settings/group/fetch_group";
        public const string SettingGroupInsert = "sms/settings/group/insert_group";
        public const string SettingTopicInsert = "sms/settings/topic/insert_topic";
        public const string SettingTopicEdit = "sms/settings/topic/edit_topic";
        public const string SettingTopicFetch = "sms/settings/topic/fetch_topic";
        public const string SettingTopicDelete = "sms/settings/topic/delete_topic";

        //Dashboard
        public const string FetchSumUserNow = "mobile_admin/dashboard/fetch_sum_user_data_now";
        public const string FetchLoginMonth = "mobile_admin/dashboard/fetch_user_login_data_month";
        public const string FetchLogoutMonth = "mobile_admin/dashboard/fetch_user_logout_date_month";

        //ManageUser
        public const string SearchUser = "mobile_admin/manageuser/searchmember/fetch_search_member";
        public const string InitProvinceList = "mobile_admin/manageuser/searchmember/init_province_list";
        public const string FetchUserLogin = "mobile_admin/manageuser/userlogin/fetch_user_login";
        public const string UpdateUserLogout = "mobile_admin/manageuser/userlogin/update_userlogout";
        public const string FetchUserNotRegis = "mobile_admin/manageuser/usernotregistered/fetch_user_not_register";
        public const string FetchEditMemberLabel = "mobile_admin/manageuser/reportmembereditdata/fetch_editmember_label";
        public const string FetchEditMemberData = "mobile_admin/manageuser/reportmembereditdatafetch_member_editdata";
        public const string FetchEditMemberDataUpdate = "mobile_admin/manageuser/reportmembereditdata/fetch_member_editdata_updated";
        public const string UpdateEditMemberData = "mobile_admin/manageuser/reportmembereditdata/update_member_editdata";
        public const string DeleteEmail = "mobile_admin/manageuser/manageuseraccount/delete_email";
        public const string FetchUserAccount = "mobile_admin/manageuser/manageuseraccount/fetch_user_account";
        public const string UpdateEmail = "mobile_admin/manageuser/manageuseraccount/update_email";
        public const string UpdatePassword = "mobile_admin/manageuser/manageuseraccount/update_password_account";
        public const string UpdatePin = "mobile_admin/manageuser/manageuseraccount/update_pin_account";
        public const string UpdateResign = "mobile_admin/manageuser/manageuseraccount/update_resign_account";
        public const string UpdateTel = "mobile_admin/manageuser/manageuseraccount/update_tel";
        public const string UpdateUserStatus = "mobile_admin/manageuser/manageuseraccount/update_user_status";
        public const string FetchBlacklist = "mobile_admin/manageuser/blacklistdevice/fetch_device_blacklist";
        public const string UpdateBlacklist = "mobile_admin/manageuser/blacklistdevice/update_device_blacklist";

        //ManageAplication
        public const string ChangeStatusLive = "mobile_admin/manageapplication/managelive/change_status_live";
        public const string FetchStatusLive = "mobile_admin/manageapplication/managelive/fetch_live";
        public const string InsertStatusLive = "mobile_admin/manageapplication/managelive/insert_update_live";
        public const string FetchAssignAdmin = "mobile_admin/manageapplication/assignadmin/fetch_assign_admin";
        public const string FetchNotAssignAdmin = "mobile_admin/manageapplication/assignadmin/fetch_notassign_admin";
        public const string UpdaeAssignAdmin = "mobile_admin/manageapplication/assignadmin/update_assign_admin";
        public const string FetchBindAccount = "mobile_admin/manageapplication/manageaccbeenbind/fetch_bindaccount";
        public const string SearchBindAccount = "mobile_admin/manageapplication/manageaccbeenbind/search_bindaccount";
        public const string UnbindBindAccount = "mobile_admin/manageapplication/manageaccbeenbind/unbind_account";
        public const string UpdateindAccount = "mobile_admin/manageapplication/manageaccbeenbind/update_bindaccount";
        public const string FetchAllMenu = "mobile_admin/manageapplication/managemenu/fetch_all_menu";
        public const string UpdateAllMenu = "mobile_admin/manageapplication/managemenu/update_menu_mobile";
        public const string UpdateAllMenuName = "mobile_admin/manageapplication/managemenu/update_menu_name";
        public const string UpdateAllMenuOrder = "mobile_admin/manageapplication/managemenu/update_menu_order";
        public const string DeletePaletteColor = "mobile_admin/manageapplication/managepalette/delete_palettecolor";
        public const string FetchPaletteColor = "mobile_admin/manageapplication/managepalette/fetch_palettecolor";
        public const string InsertPaletteColor = "mobile_admin/manageapplication/managepalette/insert_palettecolor";
        public const string PreviousPaletteColor = "mobile_admin/manageapplication/managepalette/previous_palette";
        public const string UpdatePaletteColor = "mobile_admin/manageapplication/managepalette/update_palettecolor";
        public const string FetchCalendar = "mobile_admin/activitiesandnews/calendarcoop/fetch_calendarcoop";
        public const string DeleteTaskEvent = "mobile_admin/activitiesandnews/calendarcoop/delete_taskevent";
        public const string InsertTaskEvent = "mobile_admin/activitiesandnews/calendarcoop/insert_taskevent";
        public const string UpdateTaskEvent = "mobile_admin/activitiesandnews/calendarcoop/update_taskevent";
        public const string FetchNews = "mobile_admin/activitiesandnews/managenews/fetch_news";
        public const string FetchNewsImage = "mobile_admin/activitiesandnews/managenews/fetch_img_news";
        public const string DeleteNews = "mobile_admin/activitiesandnews/managenews/delete_news";
        public const string InsertNews = "mobile_admin/activitiesandnews/managenews/insert_news";
        public const string UpdateNews = "mobile_admin/activitiesandnews/managenews/update_news";
        public const string FetchAnnounce = "mobile_admin/activitiesandnews/announce/fetch_announce";
        public const string CancelAnnounce = "mobile_admin/activitiesandnews/announce/cancel_announce";
        public const string InsertAnnounce = "mobile_admin/activitiesandnews/announce/insert_announce";
        public const string UpdateAnnounce = "mobile_admin/activitiesandnews/announce/update_announce";

        //More 
        public const string CheckLoanCredit = "mobile_admin/moremobileadmin/checkcreditmember/check_loan_credit_member";
        public const string FetchDeptTransaction = "mobile_admin/moremobileadmin/dept_transaction/fetch_dept_transaction";
        public const string FetchQrList = "moremobileadmin/qrgeneratelist/fetch_qrgenerate_list";
        public const string FetchQrListReport = "moremobileadmin/qrgeneratelist/fetch_qrgenerate_list_report";
        public const string CheckReconKTB = "mobile_admin/moremobileadmin/reconcile/check_reconcile_ktb";
        public const string FetchRecon = "mobile_admin/moremobileadmin/reconcile/fetch_reconcile";
        public const string InitRecon = "mobile_admin/moremobileadmin/reconcile/init_reconcile";
        public const string ChangeStatusReqloan = "mobile_admin/moremobileadmin/reqloanform/chage_status_reqloan_online";
        public const string FetchStatusReqloan = "mobile_admin/moremobileadmin/reqloanform/fetch_reqloan_form_online";
        public const string SummaryStatusReqloan = "mobile_admin/moremobileadmin/reqloanform/summary_reqloan_form_online";
        public const string FetchActiveAllowMember = "mobile_admin/moremobileadmin/reqloanformmember/fetch_active_allow_member";
        public const string FetchAllowLoadReqMember = "mobile_admin/moremobileadmin/reqloanformmember/fetch_allow_loanreq_member";
        public const string UpdateAllowLoanReq = "mobile_admin/moremobileadmin/reqloanformmember/update_allow_loanreq_member";

        //Const mobile admin
        public const string FetchConstBank = "mobile_admin/constmobileadmin/constantbankaccount/fetch_bankconstant";
        public const string FetchConstBankAccount = "mobile_admin/constmobileadmin/constantbankaccount/fetch_constbankaccount";
        public const string DeleteConstBank = "mobile_admin/constmobileadmin/constantbankaccount/delete_bankconstantmapping";
        public const string InsertConstBank = "mobile_admin/constmobileadmin/constantbankaccount/insert_bankconstant";
        public const string InsertConstBankMapping = "mobile_admin/constmobileadmin/constantbankaccount/insert_bankconstantmapping";
        public const string UpdateConstBank = "mobile_admin/constmobileadmin/constantbankaccount/update_bankconstant";
        public const string UpdateConstBankMapping = "mobile_admin/constmobileadmin/constantbankaccount/update_const_bank_account";
        public const string FetchConstDeptAccount = "mobile_admin/constmobileadmin/constantdeptaccount/fetch_constdeptaccount";
        public const string UpdateConstDeptAccount = "mobile_admin/constmobileadmin/constantdeptaccount/update_constdeptaccount";
        public const string FetchLoanType = "mobile_admin/constmobileadmin/constantloantype/fetch_loantype";
        public const string UpdateLoanType = "mobile_admin/constmobileadmin/constantloantype/update_loantype";
        public const string FetchConstantqrcode = "mobile_admin/constmobileadmin/constantqrcode/fetch_constantqrcode";
        public const string DeleteConstantqrcode = "mobile_admin/constmobileadmin/constantqrcode/delete_constantqrcode";
        public const string InsertConstantqrcode = "mobile_admin/constmobileadmin/constantqrcode/insert_constantqrcode";
        public const string UpdateConstantqrcode = "mobile_admin/constmobileadmin/constantqrcode/update_constantqrcode";
        public const string FetchConstantSystem= "mobile_admin/constmobileadmin/constantsystem/fetch_constant";
        public const string UpdateConstantSystem= "mobile_admin/constmobileadmin/constantsystem/update_constant";
        public const string FetchConstantMenu = "mobile_admin/constmobileadmin/constanttransactionmenu/fetch_consttransmenu";
        public const string InsertConstantMenu = "mobile_admin/constmobileadmin/constanttransactionmenu/insert_constantmapping";
        public const string DeleteConstantMenu = "mobile_admin/constmobileadmin/constanttransactionmenu/delete_constantmapping";
        public const string ChangeConstInfo = "mobile_admin/constmobileadmin/constchangeinfo/fetch_const_change_info";
        public const string UpdateConstInfo = "mobile_admin/constmobileadmin/constchangeinfo/update_const_change_info";
        public const string FetchReqLoan = "mobile_admin/constmobileadmin/reqloanremark/fetch_reqloan_remark";
        public const string CancelReqLoan = "mobile_admin/constmobileadmin/reqloanremark/cancel_reqloan_remark";
        public const string InsertReqLoan = "mobile_admin/constmobileadmin/reqloanremark/insert_reqloan_remark";
        public const string UpdateReqLoan = "mobile_admin/constmobileadmin/reqloanremark/update_reqloan_remark";

        //Document
        public const string FetchDocUpload = "document/constdocument/manageuploadconst/delete_docupload_const";
        public const string DeleteDocUpload = "document/constdocument/manageuploadconst/delete_docupload_const";
        public const string InsertDocUpload = "document/constdocument/manageuploadconst/insert_docupload_const";
        public const string UpdateDocUpload = "document/constdocument/manageuploadconst/update_docupload_const";
        public const string FetchAllDocument = "document/documents/viewdocuments/fetch_alldocument";
        public const string FetchSearchFile = "document/documents/viewdocuments/fetch_search_files";
        public const string FetchDocControl = "document/settingsdocument/managedoccontrolid/fetch_doccontrolid";
        public const string InsertDocControl = "document/settingsdocument/managedoccontrolid/insert_doccontrolid";
        public const string DeleteDocControl = "document/settingsdocument/managedoccontrolid/delete_doccontrolid";
        public const string UpdateDocControl = "document/settingsdocument/managedoccontrolid/update_doccontrolid";
        public const string DeleteDocuments = "document/settingsdocument/managedocuments/delete_documents";
        public const string FetchDocControlData = "document/settingsdocument/managedocuments/fetch_doccontrol_data";
        public const string FetchDocControlid = "document/settingsdocument/managedocuments/fetch_doccontrolid";
        public const string FetchDocData = "document/settingsdocument/managedocuments/fetch_docdata";
        public const string FetchDocUploadConst = "document/settingsdocument/managedocuments/fetch_docupload_const";
        public const string InsertFolder = "document/settingsdocument/managedocuments/insert_folder";

        //

     }
}