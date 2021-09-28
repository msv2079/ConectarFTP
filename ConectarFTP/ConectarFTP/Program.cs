using Renci.SshNet;
using System;
using System.IO;

namespace ConectarFTP
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				var nomeArquivoFTP = "caminho_completo_arquivo_ftp";
				var nomeArquivoLocal = "caminho_completo_arquivo_local";


				string host = "";
				string username = "";
				string password = "";

				using (SftpClient sftp = new SftpClient(host,username, password))
				{
					sftp.Connect();

					using (Stream fileStream = File.OpenWrite(nomeArquivoLocal))
					{
						sftp.DownloadFile(nomeArquivoFTP, fileStream);
					}

					sftp.Disconnect();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			Console.ReadKey();
		}
	}
}
