using Pets.Context;
using Pets.Domains;
using Pets.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Pets.Repositories
{
    public class TipoDePetRepository : ITipoDePet
    {
        //chamando a classe de conexao com o banco 
        PetRaca conexao = new PetRaca();

        //chamando o objeto que irá receber e executar as linhas de comando do banco
        SqlCommand cmd = new SqlCommand();


        public TipoDePet Alterar(int id, TipoDePet b)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "UPDATE TipoDeAluno SET " +
                "TipoDePet = @tipodepet WHERE IdTipoDePet = @id " +
                "Descricao = @descricao, ";
            cmd.Parameters.AddWithValue("@tipodepet", b.IdTipoPet);
            cmd.Parameters.AddWithValue("@descricao", b.Descricao);

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            conexao.Desconectar();
            return b;
        }

        public TipoDePet BuscarPorId(int id)
        {
            cmd.Connection = conexao.Conectar();


            cmd.CommandText = "SELECT * FROM TipoDePet WHERE IdTipoDePet = @id";

            // atribuimos as variaveis que vem como argumento
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader dados = cmd.ExecuteReader();

            TipoDePet b = new TipoDePet();

            while(dados.Read())
            {
                b.IdTipoPet = Convert.ToInt32(dados.GetValue(0));
                b.Descricao = dados.GetValue(1).ToString();
            }

            conexao.Desconectar();

            return b;
        }

        public TipoDePet Cadastrar(TipoDePet b)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText =
                "INSERT INTO TipoDePet (IdTipoDePet, Descricao) " +
                "VALUES " +
                "(@idtipodepet, @descricao)";
            cmd.Parameters.AddWithValue("@idtipopet", b.IdTipoPet);
            cmd.Parameters.AddWithValue("@descricao", b.Descricao);

            cmd.ExecuteNonQuery();

            conexao.Desconectar();

            return b;
        }

        public void Excluir(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "DELETE FROM TipoDePet WHERE IdTipoDePet = @id ";
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            conexao.Desconectar();
        }

        public List<TipoDePet> LerTodos()
        {
            //abrir conexao
            cmd.Connection = conexao.Conectar();

            //Preparar  a query (consulta)
            cmd.CommandText = "SELECT * FROM TipoDePet";

            SqlDataReader dados = cmd.ExecuteReader();

            //Criamos a lista para guardar os tipos de pet 
            List<TipoDePet> petzinhos = new List<TipoDePet>();

            while (dados.Read())
            {
                petzinhos.Add(
                    new TipoDePet()
                    {
                        IdTipoPet = Convert.ToInt32(dados.GetValue(0)),
                        Descricao = dados.GetValue(1).ToString()
                    }
                    ); 
            }


            //fechar conexao
            conexao.Desconectar();  

            return petzinhos;
        }
    }
}
