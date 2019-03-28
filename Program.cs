using System;
using static System.Console;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace consoleWebApi
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Acessando a WebAPI, aguarde um momento...");

            var repositorio = new UsuarioRepositorio();

            Task<List<Usuario>> usuariosTask = repositorio.GetUsuariosAsync();

            usuariosTask.ContinueWith(task =>
            {
                var usuarios = task.Result;
                foreach (var u in usuarios)
                    WriteLine(u.ToString());

                //Environment.Exit(0);
            },
            TaskContinuationOptions.OnlyOnRanToCompletion
            );

            ReadLine();
        }
    }
}
