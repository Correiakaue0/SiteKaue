using Back.Models;
using Back.ViewModel;

namespace Back.Services.Interfaces
{
    public interface IProdutoServices : IBaseServices<Produto>
    {
        Produto Create(ProdutoViewModel prod);
        Produto Delete(int id);
    }
}
