using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebApi.DeflateCompression.Attributes;

namespace WebApi.DeflateCompression.Controllers
{
    [RoutePrefix("api")]
    public class ContatoController : ApiController
    {
        readonly string[] _contatos = null;

        public ContatoController()
        {
            _contatos = new string[] { "Ana", "Maria", "Pedro", "João", "Carlos", "Bruno", "Viviane", "Letícia" };
        }

        [HttpGet]
        [Route("obterContatos")]
        public Task<HttpResponseMessage> ObterContatos()
        {
            return CriarResponse();
        }

        [HttpGet]
        [DeflateCompression]
        [Route("obterContatos2")]
        public Task<HttpResponseMessage> ObterContatosComDeflateCompression()
        {
            return CriarResponse();
        }

        private Task<HttpResponseMessage> CriarResponse()
        {
            var response = new HttpResponseMessage();
            response = Request.CreateResponse(HttpStatusCode.OK, _contatos);
            return Task.FromResult<HttpResponseMessage>(response);
        }
    }
}
