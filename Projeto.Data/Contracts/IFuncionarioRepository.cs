using System;
using System.Collections.Generic;
using System.Text;
using Projeto.Data.Entities;

namespace Projeto.Data.Contracts
{
    public interface IFuncionarioRepository
    {
        void Inserir(Funcionario funcionario);
        void Excluir(Funcionario funcionario);
        void Alterar(Funcionario funcionario);
        List<Funcionario> Consultar();
        Funcionario ObterPorId(int idFuncionario);
    }
}
