public class Studente : Persona
{
    public string Matricola { get; set; }
    public string CorsoDiStudi { get; set; }

                // Costruttore
    public Studente(string nome, string cognome, int eta, string matricola, string corsoDiStudi)
    {
        Nome = nome;
        Cognome = cognome;
        Eta = eta;
        Matricola = matricola;
        CorsoDiStudi = corso;
    }
}