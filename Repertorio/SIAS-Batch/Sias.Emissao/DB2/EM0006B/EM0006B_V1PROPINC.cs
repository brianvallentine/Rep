using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0006B
{
    public class EM0006B_V1PROPINC : QueryBasis<EM0006B_V1PROPINC>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public EM0006B_V1PROPINC() { IsCursor = true; }

        public EM0006B_V1PROPINC(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V1PRIN_COD_EMPRESA { get; set; }
        public string V1PRIN_FONTE { get; set; }
        public string V1PRIN_NRPROPOS { get; set; }
        public string V1PRIN_NUM_RISCO { get; set; }
        public string V1PRIN_CODCOBINC { get; set; }
        public string V1PRIN_SUBRIS { get; set; }
        public string V1PRIN_NRITEM { get; set; }
        public string V1PRIN_COD_PLANTA { get; set; }
        public string V1PRIN_COD_RUBRICA { get; set; }
        public string V1PRIN_CLASOCUPA { get; set; }
        public string V1PRIN_CLASCONST { get; set; }
        public string V1PRIN_DTINIVIG { get; set; }
        public string V1PRIN_DTTERVIG { get; set; }
        public string V1PRIN_IMP_SEG_IX { get; set; }
        public string V1PRIN_PRM_TAR_IX { get; set; }
        public string V1PRIN_TIPCOND { get; set; }
        public string V1PRIN_TAXA_PRM { get; set; }
        public string V1PRIN_TIPO_TAXA { get; set; }
        public string V1PRIN_PCDESCON { get; set; }
        public string V1PRIN_TPDESCON { get; set; }
        public string V1PRIN_PCADICIO { get; set; }
        public string V1PRIN_PCVALRISC { get; set; }
        public string V1PRIN_COEFAGRAV { get; set; }
        public string V1PRIN_TIPRAZO { get; set; }
        public string V1PRIN_SITUACAO { get; set; }
        public string V1PRIN_TPMOVTO { get; set; }
        public string V1PRIN_TPOCUP { get; set; }
        public string V1PRIN_SPOCUP { get; set; }
        public string V1PRIN_QTPAVTO { get; set; }

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


        public override EM0006B_V1PROPINC OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new EM0006B_V1PROPINC();
            var i = 0;

            dta.V1PRIN_COD_EMPRESA = result[i++].Value?.ToString();
            dta.V1PRIN_FONTE = result[i++].Value?.ToString();
            dta.V1PRIN_NRPROPOS = result[i++].Value?.ToString();
            dta.V1PRIN_NUM_RISCO = result[i++].Value?.ToString();
            dta.V1PRIN_CODCOBINC = result[i++].Value?.ToString();
            dta.V1PRIN_SUBRIS = result[i++].Value?.ToString();
            dta.V1PRIN_NRITEM = result[i++].Value?.ToString();
            dta.V1PRIN_COD_PLANTA = result[i++].Value?.ToString();
            dta.V1PRIN_COD_RUBRICA = result[i++].Value?.ToString();
            dta.V1PRIN_CLASOCUPA = result[i++].Value?.ToString();
            dta.V1PRIN_CLASCONST = result[i++].Value?.ToString();
            dta.V1PRIN_DTINIVIG = result[i++].Value?.ToString();
            dta.V1PRIN_DTTERVIG = result[i++].Value?.ToString();
            dta.V1PRIN_IMP_SEG_IX = result[i++].Value?.ToString();
            dta.V1PRIN_PRM_TAR_IX = result[i++].Value?.ToString();
            dta.V1PRIN_TIPCOND = result[i++].Value?.ToString();
            dta.V1PRIN_TAXA_PRM = result[i++].Value?.ToString();
            dta.V1PRIN_TIPO_TAXA = result[i++].Value?.ToString();
            dta.V1PRIN_PCDESCON = result[i++].Value?.ToString();
            dta.V1PRIN_TPDESCON = result[i++].Value?.ToString();
            dta.V1PRIN_PCADICIO = result[i++].Value?.ToString();
            dta.V1PRIN_PCVALRISC = result[i++].Value?.ToString();
            dta.V1PRIN_COEFAGRAV = result[i++].Value?.ToString();
            dta.V1PRIN_TIPRAZO = result[i++].Value?.ToString();
            dta.V1PRIN_SITUACAO = result[i++].Value?.ToString();
            dta.V1PRIN_TPMOVTO = result[i++].Value?.ToString();
            dta.V1PRIN_TPOCUP = result[i++].Value?.ToString();
            dta.V1PRIN_SPOCUP = result[i++].Value?.ToString();
            dta.V1PRIN_QTPAVTO = result[i++].Value?.ToString();

            return dta;
        }

    }
}