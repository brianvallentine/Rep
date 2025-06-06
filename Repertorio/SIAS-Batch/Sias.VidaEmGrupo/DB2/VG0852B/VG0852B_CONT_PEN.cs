using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0852B
{
    public class VG0852B_CONT_PEN : QueryBasis<VG0852B_CONT_PEN>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VG0852B_CONT_PEN() { IsCursor = true; }

        public VG0852B_CONT_PEN(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string COBHISVI_NUM_PARCELA { get; set; }
        public string COBHISVI_OPCAO_PAGAMENTO { get; set; }
        public string COBHISVI_SIT_REGISTRO { get; set; }
        public string COBHISVI_DATA_VENCIMENTO { get; set; }

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


        public override VG0852B_CONT_PEN OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VG0852B_CONT_PEN();
            var i = 0;

            dta.COBHISVI_NUM_PARCELA = result[i++].Value?.ToString();
            dta.COBHISVI_OPCAO_PAGAMENTO = result[i++].Value?.ToString();
            dta.COBHISVI_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.COBHISVI_DATA_VENCIMENTO = result[i++].Value?.ToString();

            return dta;
        }

    }
}