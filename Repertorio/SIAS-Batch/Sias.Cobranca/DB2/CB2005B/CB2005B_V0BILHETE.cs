using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB2005B
{
    public class CB2005B_V0BILHETE : QueryBasis<CB2005B_V0BILHETE>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public CB2005B_V0BILHETE() { IsCursor = true; }

        public CB2005B_V0BILHETE(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0BILH_NUMBIL { get; set; }
        public string V0BILH_FONTE { get; set; }
        public string V0BILH_AGECOBR { get; set; }
        public string V0BILH_NUM_MATR { get; set; }
        public string V0BILH_AGENCIA { get; set; }
        public string V0BILH_OPE_CONTA { get; set; }
        public string V0BILH_NUM_CONTA { get; set; }
        public string V0BILH_DIG_CONTA { get; set; }
        public string V0BILH_CODCLIEN { get; set; }
        public string V0BILH_PROFISSAO { get; set; }
        public string V0BILH_AGENCIA_DEB { get; set; }
        public string V0BILH_OPERACAO_DEB { get; set; }
        public string V0BILH_NUMCTA_DEB { get; set; }
        public string V0BILH_DIGCTA_DEB { get; set; }
        public string V0BILH_OPCAO_COBER { get; set; }
        public string V0BILH_DTA_VENDA { get; set; }
        public string V0BILH_DTQITBCO { get; set; }
        public string V0BILH_VLRCAP { get; set; }
        public string V0BILH_RAMO { get; set; }
        public string V0BILH_CODUSU { get; set; }
        public string V0BILH_SITUACAO { get; set; }
        public string V0BILH_NUM_APO_ANT { get; set; }

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


        public override CB2005B_V0BILHETE OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new CB2005B_V0BILHETE();
            var i = 0;

            dta.V0BILH_NUMBIL = result[i++].Value?.ToString();
            dta.V0BILH_FONTE = result[i++].Value?.ToString();
            dta.V0BILH_AGECOBR = result[i++].Value?.ToString();
            dta.V0BILH_NUM_MATR = result[i++].Value?.ToString();
            dta.V0BILH_AGENCIA = result[i++].Value?.ToString();
            dta.V0BILH_OPE_CONTA = result[i++].Value?.ToString();
            dta.V0BILH_NUM_CONTA = result[i++].Value?.ToString();
            dta.V0BILH_DIG_CONTA = result[i++].Value?.ToString();
            dta.V0BILH_CODCLIEN = result[i++].Value?.ToString();
            dta.V0BILH_PROFISSAO = result[i++].Value?.ToString();
            dta.V0BILH_AGENCIA_DEB = result[i++].Value?.ToString();
            dta.V0BILH_OPERACAO_DEB = result[i++].Value?.ToString();
            dta.V0BILH_NUMCTA_DEB = result[i++].Value?.ToString();
            dta.V0BILH_DIGCTA_DEB = result[i++].Value?.ToString();
            dta.V0BILH_OPCAO_COBER = result[i++].Value?.ToString();
            dta.V0BILH_DTA_VENDA = result[i++].Value?.ToString();
            dta.V0BILH_DTQITBCO = result[i++].Value?.ToString();
            dta.V0BILH_VLRCAP = result[i++].Value?.ToString();
            dta.V0BILH_RAMO = result[i++].Value?.ToString();
            dta.V0BILH_CODUSU = result[i++].Value?.ToString();
            dta.V0BILH_SITUACAO = result[i++].Value?.ToString();
            dta.V0BILH_NUM_APO_ANT = result[i++].Value?.ToString();

            return dta;
        }

    }
}