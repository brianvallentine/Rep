using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0029B
{
    public class SI0029B_PRINCIPAL : QueryBasis<SI0029B_PRINCIPAL>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0029B_PRINCIPAL() { IsCursor = true; }

        public SI0029B_PRINCIPAL(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0MEST_FONTE { get; set; }
        public string V0MEST_PROTSINI { get; set; }
        public string V0MEST_NUM_APOL_SINISTRO { get; set; }
        public string V0MEST_NUM_APOLICE { get; set; }
        public string V0MEST_NRCERTIF { get; set; }
        public string V0MEST_CODSUBES { get; set; }
        public string V0MEST_CODCAU { get; set; }
        public string V0MEST_DATORR { get; set; }
        public string V0MEST_DATCMD { get; set; }
        public string V0MEST_DATTEC { get; set; }
        public string V0MEST_SITUACAO { get; set; }
        public string V0PROP_IDADE { get; set; }
        public string V0SAVG_IDE_SEXO { get; set; }
        public string V0SAVG_DT_NASCM { get; set; }
        public string VIND_DTNASCM { get; set; }
        public string V0CLI_COD_CLIENTE { get; set; }
        public string V0CLI_NOME_RAZAO { get; set; }
        public string V0CLI_DATA_NASCM { get; set; }
        public string VIND_DATNASC { get; set; }
        public string V0SCAU_DESCAU { get; set; }
        public string V0CDGC_DTINIVIG { get; set; }
        public string SEGVGAPH_OCORR_HISTORICO { get; set; }
        public string SEGVGAPH_COD_OPERACAO { get; set; }
        public string CA_IND_ATIVO { get; set; }
        public string CA_MOTIV_CANCEL { get; set; }
        public string CA_MOTIV_CANCEL_NULO { get; set; }

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


        public override SI0029B_PRINCIPAL OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0029B_PRINCIPAL();
            var i = 0;

            dta.V0MEST_FONTE = result[i++].Value?.ToString();
            dta.V0MEST_PROTSINI = result[i++].Value?.ToString();
            dta.V0MEST_NUM_APOL_SINISTRO = result[i++].Value?.ToString();
            dta.V0MEST_NUM_APOLICE = result[i++].Value?.ToString();
            dta.V0MEST_NRCERTIF = result[i++].Value?.ToString();
            dta.V0MEST_CODSUBES = result[i++].Value?.ToString();
            dta.V0MEST_CODCAU = result[i++].Value?.ToString();
            dta.V0MEST_DATORR = result[i++].Value?.ToString();
            dta.V0MEST_DATCMD = result[i++].Value?.ToString();
            dta.V0MEST_DATTEC = result[i++].Value?.ToString();
            dta.V0MEST_SITUACAO = result[i++].Value?.ToString();
            dta.V0PROP_IDADE = result[i++].Value?.ToString();
            dta.V0SAVG_IDE_SEXO = result[i++].Value?.ToString();
            dta.V0SAVG_DT_NASCM = result[i++].Value?.ToString();
            dta.VIND_DTNASCM = string.IsNullOrWhiteSpace(dta.V0SAVG_DT_NASCM) ? "-1" : "0";
            dta.V0CLI_COD_CLIENTE = result[i++].Value?.ToString();
            dta.V0CLI_NOME_RAZAO = result[i++].Value?.ToString();
            dta.V0CLI_DATA_NASCM = result[i++].Value?.ToString();
            dta.VIND_DATNASC = string.IsNullOrWhiteSpace(dta.V0CLI_DATA_NASCM) ? "-1" : "0";
            dta.V0SCAU_DESCAU = result[i++].Value?.ToString();
            dta.V0CDGC_DTINIVIG = result[i++].Value?.ToString();
            dta.SEGVGAPH_OCORR_HISTORICO = result[i++].Value?.ToString();
            dta.SEGVGAPH_COD_OPERACAO = result[i++].Value?.ToString();
            dta.CA_IND_ATIVO = result[i++].Value?.ToString();
            dta.CA_MOTIV_CANCEL = result[i++].Value?.ToString();
            dta.CA_MOTIV_CANCEL_NULO = string.IsNullOrWhiteSpace(dta.CA_MOTIV_CANCEL) ? "-1" : "0";

            return dta;
        }

    }
}