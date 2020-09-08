using Pets.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pets.Interfaces
{
    interface IRaca
    {
        Raca Cadastrar(Raca a);
        List<Raca> LerTodos();
        Raca BuscarPorId(int a);
        Raca Alterar(int id, Raca a);
        void Excluir(int id);
    }
}
