using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0077B
{
    public class SI0077B_V0SINIHABIT4 : QueryBasis<SI0077B_V0SINIHABIT4>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0077B_V0SINIHABIT4() { IsCursor = true; }

        public SI0077B_V0SINIHABIT4(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0HABIT4_NUM_APOL_SINISTRO { get; set; }
        public string V0HABIT4_NUM_FIAP { get; set; }
        public string V0HABIT4_DATA_CONTRATO { get; set; }
        public string V0HABIT4_DATA_SINISTRO { get; set; }
        public string V0HABIT4_DATA_INDENIZACAO { get; set; }
        public string V0HABIT4_DATA_SALDO_DEVEDOR { get; set; }
        public string V0HABIT4_NOME_SEGURADO { get; set; }
        public string V0HABIT4_PERC_PARTICIPACAO { get; set; }
        public string V0HABIT4_DIAS_M { get; set; }
        public string V0HABIT4_DIAS_N { get; set; }
        public string V0HABIT4_DIAS_CORRIDOS_D { get; set; }
        public string V0HABIT4_PERC_JUROS { get; set; }
        public string V0HABIT4_VAL_SDO_DEVEDOR { get; set; }
        public string V0HABIT4_VAL_SDO_CORRIGIDO { get; set; }
        public string V0HABIT4_VAL_INDENIZACAO { get; set; }
        public string V0HABIT4_PRI_INPC { get; set; }
        public string V0HABIT4_PRI_INPC_MMAA { get; set; }
        public string V0HABIT4_ULT_INPC { get; set; }
        public string V0HABIT4_ULT_INPC_MMAA { get; set; }
        public string V0HABIT4_INPC_INDENI { get; set; }
        public string V0HABIT4_INPC_INDENI_MMAA { get; set; }
        public string V0HABIT4_INPC_PRO_RATA { get; set; }
        public string V0HABIT4_TIMESTAMP { get; set; }

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


        public override SI0077B_V0SINIHABIT4 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0077B_V0SINIHABIT4();
            var i = 0;

            dta.V0HABIT4_NUM_APOL_SINISTRO = result[i++].Value?.ToString();
            dta.V0HABIT4_NUM_FIAP = result[i++].Value?.ToString();
            dta.V0HABIT4_DATA_CONTRATO = result[i++].Value?.ToString();
            dta.V0HABIT4_DATA_SINISTRO = result[i++].Value?.ToString();
            dta.V0HABIT4_DATA_INDENIZACAO = result[i++].Value?.ToString();
            dta.V0HABIT4_DATA_SALDO_DEVEDOR = result[i++].Value?.ToString();
            dta.V0HABIT4_NOME_SEGURADO = result[i++].Value?.ToString();
            dta.V0HABIT4_PERC_PARTICIPACAO = result[i++].Value?.ToString();
            dta.V0HABIT4_DIAS_M = result[i++].Value?.ToString();
            dta.V0HABIT4_DIAS_N = result[i++].Value?.ToString();
            dta.V0HABIT4_DIAS_CORRIDOS_D = result[i++].Value?.ToString();
            dta.V0HABIT4_PERC_JUROS = result[i++].Value?.ToString();
            dta.V0HABIT4_VAL_SDO_DEVEDOR = result[i++].Value?.ToString();
            dta.V0HABIT4_VAL_SDO_CORRIGIDO = result[i++].Value?.ToString();
            dta.V0HABIT4_VAL_INDENIZACAO = result[i++].Value?.ToString();
            dta.V0HABIT4_PRI_INPC = result[i++].Value?.ToString();
            dta.V0HABIT4_PRI_INPC_MMAA = result[i++].Value?.ToString();
            dta.V0HABIT4_ULT_INPC = result[i++].Value?.ToString();
            dta.V0HABIT4_ULT_INPC_MMAA = result[i++].Value?.ToString();
            dta.V0HABIT4_INPC_INDENI = result[i++].Value?.ToString();
            dta.V0HABIT4_INPC_INDENI_MMAA = result[i++].Value?.ToString();
            dta.V0HABIT4_INPC_PRO_RATA = result[i++].Value?.ToString();
            dta.V0HABIT4_TIMESTAMP = result[i++].Value?.ToString();

            return dta;
        }

    }
}