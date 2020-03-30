using Projeto.Data.Contracts;
using Projeto.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Dapper;
using System.Linq;

namespace Projeto.Data.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Exercicio01;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public void Alterar(Funcionario funcionario)
        {
            var query = "update Funcionario set Nome = @Nome, Salario = @Salario, DataAdmissao = @DataAdmissao, Cargo = @Cargo where IdFuncionario = @IdFuncionario";

            using(var connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, funcionario);
            }
        }

        public List<Funcionario> Consultar()
        {
            var query = "select * from Funcionario";

            using(var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Funcionario>(query).ToList();
            }
        }

        public void Excluir(Funcionario funcionario)
        {
            var query = "delete from Funcionario where IdFuncionario = @IdFuncionario";

            using(var connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, funcionario);
            }
        }

        public void Inserir(Funcionario funcionario)
        {
            var query = "insert into Funcionario(Nome, Salario, DataAdmissao, Cargo) values (@Nome, @Salario, @DataAdmissao, @Cargo)";

            using(var connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, funcionario);
            }
        }

        public Funcionario ObterPorId(int idFuncionario)
        {
            var query = "select * from Funcionario where IdFuncionario = @IdFuncionario";

            using(var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Funcionario>(query, new { idFuncionario }).FirstOrDefault();
            }
        }
    }
}
