using System;
using System.Net.Sockets;
using System.Text;
public class Client
{
    void StartClient(string serverIP, int port)
    {
        // digito ipconfig nel cmd e prendo l'indirizzo ipv4
        using (var client = new TcpClient(serverIP, port))  // TcpClient è la classe che rappresenta un client TCP cioè un client che si connette a un server
        using (var stream = client.GetStream()) // Restituisce un oggetto NetworkStream che rappresenta il flusso di dati tra il client e il server
        {
            Console.WriteLine("Connessione al server");
            string messageToSend = Console.ReadLine();

            while (!string.IsNullOrEmpty(messageToSend))
            {
                byte[] buffer = Encoding.ASCII.GetBytes(messageToSend); // Converte la stringa in un array di byte
                stream.Write(buffer, 0, buffer.Length); // Invia il messaggio al server
                messageToSend = Console.ReadLine(); // Legge il messaggio da inviare
            }
        }
    }
    public static void Main(string[] args)
    {
        Client client = new Client();   // Crea un'istanza della classe Client
        Console.WriteLine("Inserisci l'IP del server:");   
        string serverIP = Console.ReadLine();
        client.StartClient(serverIP, 3000); // Avvia il client con l'IP del server e la porta 3000
                                            // StartClient è il metodo che si occupa di stabilire la connessione con il server
                                            // 3000 è la porta su cui il server è in ascolto
    }
}

