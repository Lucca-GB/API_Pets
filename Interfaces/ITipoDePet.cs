using Pets.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pets.Interfaces
{
    interface ITipoDePet
    {
        TipoDePet Cadastrar(TipoDePet b);
        List<TipoDePet> LerTodos();
        TipoDePet BuscarPorId(int id);
        TipoDePet Alterar(int id, TipoDePet b);
        void Excluir(int id );

    }
}
