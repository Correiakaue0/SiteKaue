using Back.ViewModel;
using Store.Model;

namespace Back.Services.Interfaces
{
    public interface IProdutoServices : IBaseServices<Produto>
    {
        Produto Create(ProdutoViewModel prod);
    }
}
