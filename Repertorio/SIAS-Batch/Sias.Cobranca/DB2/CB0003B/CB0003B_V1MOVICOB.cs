using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0003B
{
    public class CB0003B_V1MOVICOB : QueryBasis<CB0003B_V1MOVICOB>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public CB0003B_V1MOVICOB() { IsCursor = true; }

        public CB0003B_V1MOVICOB(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V1MCOB_CODMOV { get; set; }
        public string V1MCOB_BANCO { get; set; }
        public string V1MCOB_AGENCIA { get; set; }
        public string V1MCOB_NRAVISO { get; set; }
        public string V1MCOB_NUMFITA { get; set; }
        public string V1MCOB_DTMOVTO { get; set; }
        public string V1MCOB_DTQITBCO { get; set; }
        public string V1MCOB_NRTIT { get; set; }
        public string V1MCOB_NUM_APOL { get; set; }
        public string V1MCOB_NRENDOS { get; set; }
        public string V1MCOB_NRPARCEL { get; set; }
        public string V1MCOB_VALTIT { get; set; }
        public string V1MCOB_VLIOCC { get; set; }
        public string V1MCOB_VALCDT { get; set; }
        public string V1MCOB_SITUACAO { get; set; }
        public string V1MCOB_NOME { get; set; }
        public string V1MCOB_NUM_NOSSO { get; set; }

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


        public override CB0003B_V1MOVICOB OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new CB0003B_V1MOVICOB();
            var i = 0;

            dta.V1MCOB_CODMOV = result[i++].Value?.ToString();
            dta.V1MCOB_BANCO = result[i++].Value?.ToString();
            dta.V1MCOB_AGENCIA = result[i++].Value?.ToString();
            dta.V1MCOB_NRAVISO = result[i++].Value?.ToString();
            dta.V1MCOB_NUMFITA = result[i++].Value?.ToString();
            dta.V1MCOB_DTMOVTO = result[i++].Value?.ToString();
            dta.V1MCOB_DTQITBCO = result[i++].Value?.ToString();
            dta.V1MCOB_NRTIT = result[i++].Value?.ToString();
            dta.V1MCOB_NUM_APOL = result[i++].Value?.ToString();
            dta.V1MCOB_NRENDOS = result[i++].Value?.ToString();
            dta.V1MCOB_NRPARCEL = result[i++].Value?.ToString();
            dta.V1MCOB_VALTIT = result[i++].Value?.ToString();
            dta.V1MCOB_VLIOCC = result[i++].Value?.ToString();
            dta.V1MCOB_VALCDT = result[i++].Value?.ToString();
            dta.V1MCOB_SITUACAO = result[i++].Value?.ToString();
            dta.V1MCOB_NOME = result[i++].Value?.ToString();
            dta.V1MCOB_NUM_NOSSO = result[i++].Value?.ToString();

            return dta;
        }

    }
}