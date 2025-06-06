using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA2601B
{
    public class VA2601B_CPESENDER : QueryBasis<VA2601B_CPESENDER>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VA2601B_CPESENDER() { IsCursor = true; }

        public VA2601B_CPESENDER(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string DCLPESSOA_ENDERECO_OCORR_ENDERECO { get; set; }
        public string DCLPESSOA_ENDERECO_ENDERECO { get; set; }
        public string DCLPESSOA_ENDERECO_BAIRRO { get; set; }
        public string DCLPESSOA_ENDERECO_CIDADE { get; set; }
        public string DCLPESSOA_ENDERECO_CEP { get; set; }
        public string DCLPESSOA_ENDERECO_SIGLA_UF { get; set; }

        public new void Open()
        {
            if (!IsProcedure)
                SetQuery(GetQueryEvent());
            base.Open();
        }


        public new bool Fetch()
        {
            if (!JustACursor)
            {
                var idx = CurrentIndex;
                Open();
                CurrentIndex = idx > -1 ? idx : 0;
            }

            return base.Fetch();
        }


        public override VA2601B_CPESENDER OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VA2601B_CPESENDER();
            var i = 0;

            dta.DCLPESSOA_ENDERECO_OCORR_ENDERECO = result[i++].Value?.ToString();
            dta.DCLPESSOA_ENDERECO_ENDERECO = result[i++].Value?.ToString();
            dta.DCLPESSOA_ENDERECO_BAIRRO = result[i++].Value?.ToString();
            dta.DCLPESSOA_ENDERECO_CIDADE = result[i++].Value?.ToString();
            dta.DCLPESSOA_ENDERECO_CEP = result[i++].Value?.ToString();
            dta.DCLPESSOA_ENDERECO_SIGLA_UF = result[i++].Value?.ToString();

            return dta;
        }

    }
}