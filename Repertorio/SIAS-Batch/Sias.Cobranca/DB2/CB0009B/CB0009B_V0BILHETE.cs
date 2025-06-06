using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0009B
{
    public class CB0009B_V0BILHETE : QueryBasis<CB0009B_V0BILHETE>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public CB0009B_V0BILHETE() { IsCursor = true; }

        public CB0009B_V0BILHETE(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0BILH_NUMBIL { get; set; }
        public string V0BILH_NUMAPOL { get; set; }
        public string V0BILH_FONTE { get; set; }
        public string V0BILH_AGECOBR { get; set; }
        public string V0BILH_MATRICULA { get; set; }
        public string V0BILH_AGECONTA { get; set; }
        public string V0BILH_OPECONTA { get; set; }
        public string V0BILH_NUMCONTA { get; set; }
        public string V0BILH_DIGCONTA { get; set; }
        public string V0BILH_CODCLIEN { get; set; }
        public string V0BILH_PROFISSAO { get; set; }
        public string V0BILH_SEXO { get; set; }
        public string V0BILH_ESTCIV { get; set; }
        public string V0BILH_OPCOBER { get; set; }
        public string V0BILH_DTQITBCO { get; set; }
        public string V0BILH_VLRCAP { get; set; }
        public string V0BILH_RAMO { get; set; }
        public string V0BILH_DTVENDA { get; set; }
        public string V0BILH_DTMOVTO { get; set; }
        public string V0BILH_SITUACAO { get; set; }
        public string V0BILH_CODUSU { get; set; }
        public string V0BILH_FX_RENDA_IND { get; set; }
        public string V0BILH_FX_RENDA_FAM { get; set; }
        public string V0BILH_COD_PRODUTO { get; set; }

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


        public override CB0009B_V0BILHETE OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new CB0009B_V0BILHETE();
            var i = 0;

            dta.V0BILH_NUMBIL = result[i++].Value?.ToString();
            dta.V0BILH_NUMAPOL = result[i++].Value?.ToString();
            dta.V0BILH_FONTE = result[i++].Value?.ToString();
            dta.V0BILH_AGECOBR = result[i++].Value?.ToString();
            dta.V0BILH_MATRICULA = result[i++].Value?.ToString();
            dta.V0BILH_AGECONTA = result[i++].Value?.ToString();
            dta.V0BILH_OPECONTA = result[i++].Value?.ToString();
            dta.V0BILH_NUMCONTA = result[i++].Value?.ToString();
            dta.V0BILH_DIGCONTA = result[i++].Value?.ToString();
            dta.V0BILH_CODCLIEN = result[i++].Value?.ToString();
            dta.V0BILH_PROFISSAO = result[i++].Value?.ToString();
            dta.V0BILH_SEXO = result[i++].Value?.ToString();
            dta.V0BILH_ESTCIV = result[i++].Value?.ToString();
            dta.V0BILH_OPCOBER = result[i++].Value?.ToString();
            dta.V0BILH_DTQITBCO = result[i++].Value?.ToString();
            dta.V0BILH_VLRCAP = result[i++].Value?.ToString();
            dta.V0BILH_RAMO = result[i++].Value?.ToString();
            dta.V0BILH_DTVENDA = result[i++].Value?.ToString();
            dta.V0BILH_DTMOVTO = result[i++].Value?.ToString();
            dta.V0BILH_SITUACAO = result[i++].Value?.ToString();
            dta.V0BILH_CODUSU = result[i++].Value?.ToString();
            dta.V0BILH_FX_RENDA_IND = result[i++].Value?.ToString();
            dta.V0BILH_FX_RENDA_FAM = result[i++].Value?.ToString();
            dta.V0BILH_COD_PRODUTO = result[i++].Value?.ToString();

            return dta;
        }

    }
}