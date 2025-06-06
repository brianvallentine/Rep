using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.SPBGE053
{
    public class SPBGE053_CSR_NOM_SOCIAL : QueryBasis<SPBGE053_CSR_NOM_SOCIAL>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SPBGE053_CSR_NOM_SOCIAL() { IsCursor = true; }

        public SPBGE053_CSR_NOM_SOCIAL(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string NUM_CPF { get; set; }
        public string DTH_OPERACAO { get; set; }
        public string CASE_IND_USA_NOME_SOCIAL { get; set; }
        public string IND_TIPO_ACAO { get; set; }
        public string IND_USA_NOME_SOCIAL { get; set; }
        public string IFNULL_ { get; set; }
        public string COD_TP_PES_NEGOCIO { get; set; }
        public string NUM_PROPOSTA { get; set; }
        public string COD_CANAL_ORIGEM { get; set; }
        public string NUM_MATRICULA { get; set; }
        public string NOM_PROGRAMA { get; set; }
        public string DTH_CADASTRAMENTO { get; set; }

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


        public override SPBGE053_CSR_NOM_SOCIAL OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SPBGE053_CSR_NOM_SOCIAL();
            var i = 0;

            dta.NUM_CPF = result[i++].Value?.ToString();
            dta.DTH_OPERACAO = result[i++].Value?.ToString();
            dta.CASE_IND_USA_NOME_SOCIAL = result[i++].Value?.ToString();
            dta.IND_TIPO_ACAO = result[i++].Value?.ToString();
            dta.IND_USA_NOME_SOCIAL = result[i++].Value?.ToString();
            dta.IFNULL_ = result[i++].Value?.ToString();
            dta.COD_TP_PES_NEGOCIO = string.IsNullOrWhiteSpace(dta.IFNULL_) ? "-1" : "0";
            dta.IFNULL_ = result[i++].Value?.ToString();
            dta.COD_CANAL_ORIGEM = result[i++].Value?.ToString();
            dta.NUM_MATRICULA = result[i++].Value?.ToString();
            dta.NOM_PROGRAMA = result[i++].Value?.ToString();
            dta.DTH_CADASTRAMENTO = result[i++].Value?.ToString();

            return dta;
        }

    }
}