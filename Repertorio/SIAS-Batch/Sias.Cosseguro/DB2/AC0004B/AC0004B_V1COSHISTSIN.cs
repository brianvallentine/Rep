using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0004B
{
    public class AC0004B_V1COSHISTSIN : QueryBasis<AC0004B_V1COSHISTSIN>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public AC0004B_V1COSHISTSIN() { IsCursor = true; }

        public AC0004B_V1COSHISTSIN(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V1CHSI_COD_EMPR { get; set; }
        public string V1CHSI_CONGENER { get; set; }
        public string V1CHSI_NUM_SINI { get; set; }
        public string V1CHSI_OCORHIST { get; set; }
        public string V1CHSI_OPERACAO { get; set; }
        public string V1CHSI_DTMOVTO { get; set; }
        public string V1CHSI_VAL_OPER { get; set; }
        public string V1CHSI_SITUACAO { get; set; }
        public string VIND_SIT_REGT { get; set; }
        public string V1CHSI_TIPSGU { get; set; }
        public string VIND_TIP_SEGR { get; set; }
        public string V1CHSI_SIT_LIBREC { get; set; }
        public string VIND_SIT_LIBR { get; set; }
        public string GESISFUO_IDE_SISTEMA { get; set; }
        public string GESISFUO_COD_FUNCAO { get; set; }
        public string GESISFUO_IDE_SISTEMA_OPER { get; set; }
        public string GESISFUO_COD_OPERACAO { get; set; }

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


        public override AC0004B_V1COSHISTSIN OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new AC0004B_V1COSHISTSIN();
            var i = 0;

            dta.V1CHSI_COD_EMPR = result[i++].Value?.ToString();
            dta.V1CHSI_CONGENER = result[i++].Value?.ToString();
            dta.V1CHSI_NUM_SINI = result[i++].Value?.ToString();
            dta.V1CHSI_OCORHIST = result[i++].Value?.ToString();
            dta.V1CHSI_OPERACAO = result[i++].Value?.ToString();
            dta.V1CHSI_DTMOVTO = result[i++].Value?.ToString();
            dta.V1CHSI_VAL_OPER = result[i++].Value?.ToString();
            dta.V1CHSI_SITUACAO = result[i++].Value?.ToString();
            dta.VIND_SIT_REGT = string.IsNullOrWhiteSpace(dta.V1CHSI_SITUACAO) ? "-1" : "0";
            dta.V1CHSI_TIPSGU = result[i++].Value?.ToString();
            dta.VIND_TIP_SEGR = string.IsNullOrWhiteSpace(dta.V1CHSI_TIPSGU) ? "-1" : "0";
            dta.V1CHSI_SIT_LIBREC = result[i++].Value?.ToString();
            dta.VIND_SIT_LIBR = string.IsNullOrWhiteSpace(dta.V1CHSI_SIT_LIBREC) ? "-1" : "0";
            dta.GESISFUO_IDE_SISTEMA = result[i++].Value?.ToString();
            dta.GESISFUO_COD_FUNCAO = result[i++].Value?.ToString();
            dta.GESISFUO_IDE_SISTEMA_OPER = result[i++].Value?.ToString();
            dta.GESISFUO_COD_OPERACAO = result[i++].Value?.ToString();

            return dta;
        }

    }
}