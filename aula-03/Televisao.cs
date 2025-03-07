namespace aula_03;
// separação virtual 
public class Televisao
{
    // o metodo construtr possui o mesmo
    // nome da classe. ele nao possui retorno
    // nem mesmo o void
    // este metodo é executado sempre que uma 
    // instancia da classe é criada
    // por padrao, o c# cria um metodo construtor publico vazil
    // mas podemos criar metodos construtores com outras
    // visibilidades e recebendo paramentros, se necessario.
    public Televisao(float tamanho)
    {
        if (tamanho < TAMANHO_MINIMO || tamanho > TAMANHO_MAXIMO)
        {
            // uma exceção interrompe o fluxo normal do sistema.
            throw new ArgumentOutOfRangeException($"o tamanho ({tamanho})não é suportado.");
        }
        Tamanho = tamanho;
        Volume = VOLUME_PADRAO;
        Canal = Canal_Padrao;
        
        
    }
    // optamos pela utilização da constante s
    private const float TAMANHO_MINIMO = 22;
    private const float TAMANHO_MAXIMO = 80;

    private const int VOLUME_MAXIMO = 100;
    private const int VOLUME_MINIMO = 0;
    private const int VOLUME_PADRAO = 10;

    private const int Canal_Minimo = 0;
    private const int Canal_Padrao = 500;
    private const int Canal_maximo = 999;

    private  int UltimoCanal = -1;
    private int ultimoVolume = VOLUME_PADRAO;
    private bool ModoTroca = false;
    
    // Get, permite que seja executado a leitura
    // do valor atual da propriedade
    // Set, permite que seja atribuido um
    // valor para propriedade

    // classes, propriedade e metodos possuem modificadores de acesso
    // eles são public:visiveis a todo o projeto
    // internal: visivel somente no namespace
    // protected: visiveis somente na classe e nas classses que herdam
    // private: visivel somente na classe que foram criadas
    public float Tamanho { get;  }
    public int Resolucao { get; set; }
    public int Volume { get; private set; }
    public int Canal { get;  set; }
    public bool Estado { get; set; }

    
    public void AumentarVolume()
    {
        if(ModoTroca == true){
            Console.WriteLine("A TV está no modo MUTE.");
        }
        else if (Volume < VOLUME_MAXIMO){ 
        Volume++;
    }
        else
        {
            Console.WriteLine("A tv já está no volume maximo permitido");
    }
    }

    public void DiminuirVolume()
    {
        if(ModoTroca == true){
            Console.WriteLine("A TV está no modo MUTE.");
        }
        else if (Volume > VOLUME_MINIMO){ 
        Volume--;
    }
        else
        {
            Console.WriteLine("A tv já está no volume minimo permitido");
    }


    }
    public void DigitarCanal(int canal)
    {   
        
        if(canal < Canal_Minimo || canal > Canal_maximo){
            Console.WriteLine($"Não foi possivel encontrar esse canal");
        }
        else
        {
            Console.WriteLine($"canal encontrado, você esta no canal {canal}");
        }
        UltimoCanal = canal;
        Canal = UltimoCanal;
    }
    public void SubirCanal()
    {   
     
        if(Canal >= Canal_Minimo && Canal <= Canal_maximo){
            Canal++;
            Console.WriteLine($"O canal é : {Canal}.");
        }
        UltimoCanal = Canal;
    }
    public void DescerCanal()
    {  
        
        if(Canal <= Canal_maximo && Canal >= Canal_Minimo){
            Canal--;
            Console.WriteLine($"O canal é : {Canal}.");
        }
        UltimoCanal = Canal;
    }
    public void Silenciar()
        {
            ModoTroca = !ModoTroca;
            if(ModoTroca ==true){
                ultimoVolume = Volume;
                Volume = VOLUME_MINIMO;
                Console.WriteLine("Você colocou a TV está no modo MUTE.");
            }
            else{
                Volume = ultimoVolume;
                Console.WriteLine($"Você desmutou a TV, O volume da TV é : {Volume}.");

            }

        

        }
}