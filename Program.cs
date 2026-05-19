using System;
using System.Collections.Generic;
List<Chamado> listaChamados = new List<Chamado>();
bool sistemaAtivo = true;
int numeroId = 1;

string opcao;

while (sistemaAtivo)
{
    Console.WriteLine("--MENU--");
    Console.WriteLine("1.Abrir Chamado");
    Console.WriteLine("2.Listar Chamados");
    Console.WriteLine("3.Alterar status");
    Console.WriteLine("4.Remover Chamado");
    Console.WriteLine("0.SAIR");
    opcao = Console.ReadLine();


    switch (opcao)
    {
        case "1":
            AbrirChamado(listaChamados, numeroId);
            Console.WriteLine("Chamado criado com sucesso!");
            numeroId++;

            break;

        case "2":
            ListarChamados(listaChamados);
            break;

        case "3":

            AlterarStatus(listaChamados);
            break;

        case "4":
            RemoverChamado(listaChamados);
            break;

        case "0":
            sistemaAtivo = false;
            break;


    }

}

static void ListarChamados(List<Chamado> listaChamados)
{
    if (listaChamados.Count == 0)
            {
                Console.WriteLine("Não há nenhum chamado no momento");
            }
            else
            {
                foreach (Chamado chamado in listaChamados)
                {
                    Console.WriteLine($"ID: {chamado.Id} \nTítulo: {chamado.Titulo} \nDescrição: {chamado.Descricao} \nPrioridade: {chamado.Prioridade} \nStatus: {chamado.Status}");
                }
            }
}


static void AlterarStatus(List<Chamado> listaChamados)
{

    Console.WriteLine("Digite o Id do Chamado");
    string idDigitado = Console.ReadLine();
    int respostaId = int.Parse(idDigitado);



    foreach (Chamado chamado in listaChamados)
    {
        if (chamado.Id == respostaId)
        {

            Console.WriteLine("Atualize o status");
            string atualizacaoStatus = Console.ReadLine();
            chamado.Status = atualizacaoStatus;
            Console.WriteLine("Status atualizado!");
            return;
        }

    }
    Console.WriteLine("Erro. ID inválido");
}   


static void AbrirChamado(List<Chamado> listaChamados, int numeroId)
    {
    Console.WriteLine("Título: ");
    string titulo = Console.ReadLine();
    Console.WriteLine("Descrição: ");
    string descricao = Console.ReadLine();
    Console.WriteLine("Prioridade: ");
    string prioridade = Console.ReadLine();

    Chamado chamado = new Chamado();
    chamado.Titulo = titulo;
    chamado.Descricao = descricao;
    chamado.Prioridade = prioridade;
    chamado.Status = "Aberto";
    chamado.Id = numeroId;
    

    listaChamados.Add(chamado);
    }


static void RemoverChamado(List<Chamado> listaChamados)
{
     Console.WriteLine("Digite o Id do Chamado");
    string idDigitado = Console.ReadLine();
    int respostaId = int.Parse(idDigitado);
    Chamado chamadoEncontrado = null;
   
    foreach (Chamado chamado in listaChamados)
    {
        if (chamado.Id == respostaId)
        {
            chamadoEncontrado = chamado;
            break;
        }
    }
    if (chamadoEncontrado != null)
    {
        listaChamados.Remove(chamadoEncontrado);
        Console.WriteLine("Chamado removido!");
    }
    if(chamadoEncontrado == null)
    {
        Console.WriteLine("Chamado inválido.Tente novamente!");
    }
}
class Chamado
{





    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public string Prioridade { get; set; }
    public string Status { get; set; }

}