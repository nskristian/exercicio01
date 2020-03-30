using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Projeto.Presentation.Models;
using Projeto.Data.Entities;
using Projeto.Data.Repositories;

namespace Projeto.Presentation.Controllers
{
    public class FuncionarioController : Controller
    {
        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(CadastrarFuncionarioModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var funcionario = new Funcionario();

                    funcionario.Nome = model.Nome;
                    funcionario.Salario = model.Salario;
                    funcionario.DataAdmissao = model.DataAdmissao;
                    funcionario.Cargo = model.Cargo;

                    var funcionarioRepository = new FuncionarioRepository();

                    funcionarioRepository.Inserir(funcionario);

                    TempData["Mensagem"] = "Funcionário cadastrado com sucesso!";

                    ModelState.Clear();
                }
                catch (Exception e)
                {
                    TempData["Mensagem"] = "Ocorreu um erro: " + e.Message;
                }
            }
            return View();
        }

        public IActionResult Consulta()
        {
            var lista = new List<Funcionario>();

            try
            {
                var funcionarioRepository = new FuncionarioRepository();

                lista = funcionarioRepository.Consultar();
            }
            catch (Exception e)
            {
                TempData["Mensagem"] = "Ocorreu um erro: " + e.Message;
            }

            return View(lista);
        }

        public IActionResult Exclusao(int id)
        {
            try
            {
                var funcionarioRepository = new FuncionarioRepository();
                var funcionario = funcionarioRepository.ObterPorId(id);

                if (funcionario != null)
                {
                    funcionarioRepository.Excluir(funcionario);

                    TempData["Mensagem"] = "Funcionario " + funcionario.Nome + " excluido com sucesso!";
                }
                else
                {
                    TempData["Mensagem"] = "Funcionário não encontrado!";
                }
            }
            catch (Exception e)
            {
                TempData["Mensagem"] = "Ocorreu um erro: " + e.Message;
            }
            return RedirectToAction("Consulta");
        }

        public IActionResult Edicao(int id)
        {

            var model = new EditarFuncionarioModel();

            try
            {

                var funcionarioRepository = new FuncionarioRepository();
                var funcionario = funcionarioRepository.ObterPorId(id);

                if(funcionario != null)
                {
                    model.IdFuncionario = funcionario.IdFuncionario;
                    model.Nome = funcionario.Nome;
                    model.Salario = funcionario.Salario;
                    model.DataAdmissao = funcionario.DataAdmissao;
                    model.Cargo = funcionario.Cargo;
                    
                }
                else
                {
                    TempData["Mensagem"] = "Funcionario não encontrado!";
                }

            }
            catch (Exception e)
            {
                TempData["Mensagem"] = "Ocorreu um erro: " + e.Message;
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Edicao(EditarFuncionarioModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var funcionario = new Funcionario();

                    funcionario.IdFuncionario = model.IdFuncionario;
                    funcionario.Nome = model.Nome;
                    funcionario.Salario = model.Salario;
                    funcionario.DataAdmissao = model.DataAdmissao;
                    funcionario.Cargo = model.Cargo;

                    var funcionarioRepository = new FuncionarioRepository();
                    funcionarioRepository.Alterar(funcionario);

                    TempData["Mensagem"] = "Funcionario editado com sucesso!";
                }
                catch (Exception e)
                {
                    TempData["Mensagem"] = "Ocorreu um erro: " + e.Message;
                }
            }

            return RedirectToAction("Consulta");
        }
    }
}