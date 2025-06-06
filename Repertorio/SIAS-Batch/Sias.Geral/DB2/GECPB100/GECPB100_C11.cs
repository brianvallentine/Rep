using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GECPB100
{
    public class GECPB100_C11 : QueryBasis<GECPB100_C11>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public GECPB100_C11() { IsCursor = true; }

        public GECPB100_C11(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string GE597_NOM_EXTERNO_ARQUIVO { get; set; }
        public string GE597_NUM_NSA_SAP { get; set; }
        public string VIND_NUM_NSA_SAP { get; set; }
        public string GE597_SEQ_REGISTRO { get; set; }
        public string VIND_SEQ_REGISTRO { get; set; }
        public string GE597_DES_REJEICAO { get; set; }
        public string GE597_STA_REJEICAO { get; set; }
        public string GE597_DTH_ATUALIZACAO { get; set; }

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


        public override GECPB100_C11 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new GECPB100_C11();
            var i = 0;

            dta.GE597_NOM_EXTERNO_ARQUIVO = result[i++].Value?.ToString();
            dta.GE597_NUM_NSA_SAP = result[i++].Value?.ToString();
            dta.VIND_NUM_NSA_SAP = string.IsNullOrWhiteSpace(dta.GE597_NUM_NSA_SAP) ? "-1" : "0";
            dta.GE597_SEQ_REGISTRO = result[i++].Value?.ToString();
            dta.VIND_SEQ_REGISTRO = string.IsNullOrWhiteSpace(dta.GE597_SEQ_REGISTRO) ? "-1" : "0";
            dta.GE597_DES_REJEICAO = result[i++].Value?.ToString();
            dta.GE597_STA_REJEICAO = result[i++].Value?.ToString();
            dta.GE597_DTH_ATUALIZACAO = result[i++].Value?.ToString();

            return dta;
        }

    }
}