using Pets.Context;
using Pets.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Pets.Repositories
{
    public class RacaRepository : IRaca
    {
        //Chamando a classe de conexao do banco
        PetRaca conexao = new PetRaca();

        //chamando o objeto responsavel por receber e executar os comandos de banco 
        SqlCommand cmd = new SqlCommand();

        public Raca Alterar(int id, Raca a)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "UPDATE Raca SET " +
                "IdRaca     = @idraca " +
                "Descricao  = @descricao " +
                "IdTipoPet  = @idtipopet WHERE IdRaca = @id ";

            cmd.Parameters.AddWithValue("@idraca", a.IdRaca);
            cmd.Parameters.AddWithValue("@descricao", a.Descricao);
            cmd.Parameters.AddWithValue("@idtipopet", a.IdTipoPet);

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            conexao.Desconectar();
            return a;
        }

        public Raca BuscarPorId(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT * FROM Raca WHERE IdRaca = @id";

            //atribuimos as variaveis que vem como argumento 
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader dados = cmd.ExecuteReader();

            Raca a = new Raca();

            while(dados.Read())
            {
                a.IdRaca = Convert.ToInt32(dados.GetValue(0));
                a.Descricao = dados.GetValue(1).ToString();
                a.IdTipoPet = Convert.ToInt32(dados.GetValue(2));
            }
            conexao.Desconectar();

            return a;

        }

        public Raca Cadastrar(Raca a)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText =
                "INSERT INTO Raca (IdRaca, Descricao, IdTipoPet) " +
                "VALUES " +
                "(@idraca, @descricao, @idtipopet)";
            cmd.Parameters.AddWithValue("@idraca", a.IdRaca);
            cmd.Parameters.AddWithValue("@descricao", a.Descricao);
            cmd.Parameters.AddWithValue("@idtipopet", a.IdTipoPet);

            cmd.ExecuteNonQuery();

            conexao.Desconectar();

            return a;
        }

        public void Excluir(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "DELETE FROM Raca WHERE IdRaca = @id";
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            conexao.Desconectar();
        }

        public List<Raca> LerTodos()
        {
            //Abrir conexao
            cmd.Connection = conexao.Conectar();

            //Preparar a Query(consulta)
            cmd.CommandText = "SELECT * FROM Raca";

            SqlDataReader dados = cmd.ExecuteReader();

            //criamos a lista para guardarr os alunos 
            List<Raca> racas = new List<Raca>();

            while(dados.Read())
            {
                racas.Add(
                    new Raca()
                    {
                        IdRaca      = Convert.ToInt32(dados.GetValue(0)),
                        Descricao   = dados.GetValue(1).ToString(),
                        IdTipoPet   = Convert.ToInt32(dados.GetValue(2))
                    }
                    );
            }

            //Fehcar conexao
            conexao.Desconectar();

            return racas;
        }
    }
}
