namespace FinanceApp.Models
{
   public class Response
   {
      public Content content { get; set; }

   }
   public class Content
   {
      public string? process_status { get; set; }
      public string? deptslip_no { get; set; }
      public string? deptslip_no_fee { get; set; }
      public string? deptslip_no_oth { get; set; }
      public string? message { get; set; }
      public object? book_data { get; set; }
      public List<Slip_data>? slip_data { get; set; }
      // public object? slip_data1 { get; set; }
   }
   public class Book_data
   {
      public string? deptaccount_no { get; set; }
      public string? deptpassbook_no { get; set; }
      public int? lastrec_no { get; set; }
      public int? laststmseq_no { get; set; }
      public int? lastpage_no { get; set; }
      public int? lastline_no { get; set; }
      public List<Statement_list> statement_list { get; set; }

   }
   // public class Slip_data
   // {
   //    public string? deptaccount_no { get; set; }
   //    public string? deptaccount_name { get; set; }
   //    public string? coop_name { get; set; }
   //    public string? recppaytype_code { get; set; }
   //    public string? entry_id { get; set; }
   //    public DateTime? deptslip_date { get; set; }
   //    public DateTime? entry_date { get; set; }
   //    public string? time_date { get; set; }
   //    public decimal? deptslip_amt { get; set; }
   //    public decimal? deptslip_netamt { get; set; }
   //    public decimal? fee_amt { get; set; }
   //    public decimal? oth_amt { get; set; }
   //    public decimal? prncbal { get; set; }
   //    public string? readtihaibath { get; set; }
   //    public int? int_amt { get; set; }
   //    public int? t_net { get; set; }

   // }

   public class Slip_data
   {
      public string? column_name { get; set; }
      public string? column_value { get; set; }
      public decimal? point_top { get; set; }
      public decimal? point_left { get; set; }
      public decimal? point_width { get; set; }
      public decimal? point_height { get; set; }
      public string? align { get; set; }
      public string? valign { get; set; }
      public string? font_name { get; set; }
      public int? font_size { get; set; }

   }
   public class Statement_list
   {
      public string? coop_id { get; set; }
      public string? deptaccount_no { get; set; }
      public int? seq_no { get; set; }
      public string? deptitemtype_code { get; set; }
      public DateTime? operate_date { get; set; }
      public DateTime? entry_date { get; set; }
      public decimal? prncbal { get; set; }
      public string? entry_id { get; set; }
      public int? item_status { get; set; }
      public int? sign_flag { get; set; }
      public string? print_code { get; set; }
      public int? prnc_no { get; set; }
      public int? tax_amt { get; set; }
      public int? accuint_amt { get; set; }
      public int? int_amt { get; set; }
      public int? printbook_status { get; set; }
      public string? deptslip_no { get; set; }
      public int? deptitem_amt { get; set; }
      public int? deptint_amt { get; set; }
      public decimal deposit_amt { get; set; }
      public decimal? withdraw_amt { get; set; }
   }
}
