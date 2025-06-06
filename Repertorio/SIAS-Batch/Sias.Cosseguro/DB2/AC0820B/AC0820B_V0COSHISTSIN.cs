using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0820B
{
    public class AC0820B_V0COSHISTSIN : QueryBasis<AC0820B_V0COSHISTSIN>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public AC0820B_V0COSHISTSIN() { IsCursor = true; }

        public AC0820B_V0COSHISTSIN(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0CHIS_NUM_SINI { get; set; }
        public string V0CHIS_OCORHIST { get; set; }
        public string V0CHIS_OPERACAO { get; set; }
        public string V0CHIS_DTMOVTO { get; set; }
        public string V0CHIS_VAL_OPER { get; set; }
        public string GESISFUO_IDE_SISTEMA { get; set; }
        public string GESISFUO_COD_FUNCAO { get; set; }
        public string GESISFUO_IDE_SISTEMA_OPER { get; set; }
        public string GESISFUO_NUM_FATOR { get; set; }
        public string GEOPERAC_IND_TIPO_FUNCAO { get; set; }

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


        public override AC0820B_V0COSHISTSIN OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new AC0820B_V0COSHISTSIN();
            var i = 0;

            dta.V0CHIS_NUM_SINI = result[i++].Value?.ToString();
            dta.V0CHIS_OCORHIST = result[i++].Value?.ToString();
            dta.V0CHIS_OPERACAO = result[i++].Value?.ToString();
            dta.V0CHIS_DTMOVTO = result[i++].Value?.ToString();
            dta.V0CHIS_VAL_OPER = result[i++].Value?.ToString();
            dta.GESISFUO_IDE_SISTEMA = result[i++].Value?.ToString();
            dta.GESISFUO_COD_FUNCAO = result[i++].Value?.ToString();
            dta.GESISFUO_IDE_SISTEMA_OPER = result[i++].Value?.ToString();
            dta.GESISFUO_NUM_FATOR = result[i++].Value?.ToString();
            dta.GEOPERAC_IND_TIPO_FUNCAO = result[i++].Value?.ToString();

            return dta;
        }

    }
}