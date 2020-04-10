using System.IO;

namespace MasterChef.Infra.Data.Factory
{
    public sealed class Conexao
    {
        private static Conexao instance = null;

        private static readonly object padlock = new object();

        public static Conexao Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                        instance = new Conexao();

                    return instance;
                }
            }
        }

        public string GetConection()
        {
            string connectionString = string.Empty;

            connectionString = CheckDatabase();

            if (string.IsNullOrEmpty(connectionString))
                throw new System.ArgumentException("Falha ao conectar com banco de dados");

            return connectionString;
        }

        private string ObterNomeDatabase()
        {
            return "MasterChef.db";
        }

        private string CheckDatabase()
        {
            string result = string.Empty;

            string path = CheckPathDatabase();

            if (!string.IsNullOrEmpty(path))
            {
                path += "\\" + ObterNomeDatabase();

                if (File.Exists(path))
                {
                    path = path.Insert(0, "Data Source=");
                    result = path;
                }
            }
            return result;
        }

        private string CheckPathDatabase()
        {
            string result = string.Empty;

            // D:\TFS\Repos\FCC.Autentica\FCC.Autentica\bin\Debug\netcoreapp2.2\data
            string path = $"{System.AppDomain.CurrentDomain.BaseDirectory}data";

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            result = path;

            return result;
        }
    }
}