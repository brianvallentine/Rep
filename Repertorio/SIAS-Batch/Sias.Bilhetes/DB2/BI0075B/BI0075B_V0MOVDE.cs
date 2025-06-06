using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0075B
{
    public class BI0075B_V0MOVDE : QueryBasis<BI0075B_V0MOVDE>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public BI0075B_V0MOVDE() { IsCursor = true; }

        public BI0075B_V0MOVDE(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V1MVDB_COD_CONVENIO { get; set; }
        public string V1MVDB_DTVENCTO { get; set; }
        public string V1MVDB_DTCREDITO { get; set; }
        public string V1MVDB_VLR_DEBITO { get; set; }
        public string V1MVDB_VLR_CREDITO { get; set; }
        public string V1MVDB_NUM_APOLICE { get; set; }
        public string V1MVDB_NRENDOS { get; set; }
        public string V1MVDB_SEQUENCIA { get; set; }
        public string V1MVDB_NUM_LOTE { get; set; }

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


        public override BI0075B_V0MOVDE OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new BI0075B_V0MOVDE();
            var i = 0;

            dta.V1MVDB_COD_CONVENIO = result[i++].Value?.ToString();
            dta.V1MVDB_DTVENCTO = result[i++].Value?.ToString();
            dta.V1MVDB_DTCREDITO = result[i++].Value?.ToString();
            dta.V1MVDB_VLR_DEBITO = result[i++].Value?.ToString();
            dta.V1MVDB_VLR_CREDITO = result[i++].Value?.ToString();
            dta.V1MVDB_NUM_APOLICE = result[i++].Value?.ToString();
            dta.V1MVDB_NRENDOS = result[i++].Value?.ToString();
            dta.V1MVDB_SEQUENCIA = result[i++].Value?.ToString();
            dta.V1MVDB_NUM_LOTE = result[i++].Value?.ToString();

            return dta;
        }

    }
}