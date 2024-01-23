using FinanceApp.Services;

public class StateContainer
{
    public List<AmsecUseappss> AmsecUseappss { get; private set; }

    public void SetAmsecUseappss(List<AmsecUseappss> amsecUseappss)
    {
        AmsecUseappss = amsecUseappss;
    }
}
