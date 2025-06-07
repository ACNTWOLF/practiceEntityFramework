using System.Data;

namespace practiceEntityFramework.Interface
{
    public interface IProductSpRepository
    {
        //Recuerda amador, las interfaces son lo mismo que contratos y definen que deben 
        //hacer ciertas clases sin importar como lo hacen 
        Task PutProductByAsync(DataTable product);
    }
}
