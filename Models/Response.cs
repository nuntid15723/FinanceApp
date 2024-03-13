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
      // public string? printslip_data { get; set; }
      // public string? frontbook_data { get; set; }
      // public List<Printbook_data> printbook_data { get; set; }
      public object? printbook_data { get; set; }
   }
   public class Printbook_data
   {
      public string? deptaccount_no { get; set; }
      public string? deptpassbook_no { get; set; }
      public int? lastrec_no { get; set; }
      public int? laststmseq_no { get; set; }
      public int? lastpage_no { get; set; }
      public int? lastline_no { get; set; }
      public List<Statement_list> statement_list { get; set; }

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
      public int? deposit_amt { get; set; }
      public int? withdraw_amt { get; set; }
   }
}
