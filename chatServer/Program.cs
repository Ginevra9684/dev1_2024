
using System.Net;
using System.Net.Sockets;
using System.Text;

public class Server
{
    private TcpListener _listener;  // Oggetto che rappresenta un server TCP

    public void StartServer(int port)
    {
        _listener = new TcpListener(IPAddress.Any, port);   // IPAddress.Any indica che il server accetta connessioni su tutte le interfacce di rete
        _listener.Start();
        Console.WriteLine("Server avviato su porta {port}");    // Stampa un messaggio a console per indicare che il server è stato avviato

        while(true)
        {
            TcpClient client = _listener.AcceptTcpClient(); // Accetta una connessione da un client e restituisce un oggetto TcpClient che rappresenta il client connesso
            Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClient));   // Crea un uovo thread per gestire il cliente connesso
            //ParameterizedThreadStart è un delegato che consente di passare un parametro in un thread separato
            clientThread.Start(client); // Avvia il thread per gestire il client connesso in questo caso thread significa un flusso di esecuzione separato che può eseguire codice in parallelo
        }
    }

    // Si occupa di leggere i messaggi inviati dal client e di inviarli a tutti i client connessi
    private void HandleClient(object obj)
    {
        TcpClient client = (TcpClient)obj;  // Converte l'oggetto passato come argomento in un oggetto TcpClient
        NetworkStream stream = client.GetStream();  // Ottiene il flusso di dati tra il client ed il server
        byte[] buffer = new byte[1024]; // Crea un buffer di byte per leggere i dati dal flusso
        int byteCount; // Variabile per memorizzare il numero di byte letti

        while((byteCount = stream.Read(buffer, 0, buffer.Length)) != 0)
        {
            string message = Encoding.ASCII.GetString(buffer, 0, byteCount);    // Converte i byte ricevuti in una stringa
            Console.WriteLine("Ricevuto:" + message);
            Broadcast(message);
        }

        client.Close();
    }
    private void Broadcast(string message)
    {
        // Aggiungi qui la logica per inviare il messaggio a tutti i client connessi
    }
    public static void Main(String[] args)
    {
        Server server = new Server();   // Crea un'istanza della classe server
        server.StartServer(3000);   // Avvia il server sulla porta 3000
    }
}