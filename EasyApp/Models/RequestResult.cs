namespace EasyApp.Models
{
    public class RequestResult<T> where T : class
    {
        public bool Status { get; set; } = false;
        public string Mensagem { get; set; } = "Erro ao realizar requisão.";
        public T Data { get; set; } = null;

        public RequestResult<T> Erro(string erro)
        {
            Mensagem = erro;
            return this;
        }


        public void TestarClass1()
        {
            var classTemp = Class1.CriarNovaIdade(25, 1);

            lblDescricaoIdade.Text = classTemp.descricaoIdade;
            if(classTemp.FreteGratis)
            {

            }
        }
    }
}
