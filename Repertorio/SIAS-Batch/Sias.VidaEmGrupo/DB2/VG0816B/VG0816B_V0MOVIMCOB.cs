using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0816B
{
    public class VG0816B_V0MOVIMCOB : QueryBasis<VG0816B_V0MOVIMCOB>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VG0816B_V0MOVIMCOB() { IsCursor = true; }

        public VG0816B_V0MOVIMCOB(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0MOVC_COD_EMPRESA { get; set; }
        public string V0MOVC_CODMOV { get; set; }
        public string V0MOVC_BCOAVISO { get; set; }
        public string V0MOVC_AGEAVISO { get; set; }
        public string V0MOVC_NRAVISO { get; set; }
        public string V0MOVC_NUMFITA { get; set; }
        public string V0MOVC_DTMOVTO { get; set; }
        public string V0MOVC_DTQITBCO { get; set; }
        public string V0MOVC_NRTIT { get; set; }
        public string V0MOVC_NUM_APOLICE { get; set; }
        public string V0MOVC_NRENDOS { get; set; }
        public string V0MOVC_NRPARCEL { get; set; }
        public string V0MOVC_VALTIT { get; set; }
        public string V0MOVC_VLIOCC { get; set; }
        public string V0MOVC_VALCDT { get; set; }
        public string V0MOVC_SITUACAO { get; set; }
        public string V0MOVC_NOME { get; set; }
        public string V0MOVC_TIPO_MOVIMENTO { get; set; }
        public string V0MOVC_NOSSO_TITULO { get; set; }

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


        public override VG0816B_V0MOVIMCOB OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VG0816B_V0MOVIMCOB();
            var i = 0;

            dta.V0MOVC_COD_EMPRESA = result[i++].Value?.ToString();
            dta.V0MOVC_CODMOV = result[i++].Value?.ToString();
            dta.V0MOVC_BCOAVISO = result[i++].Value?.ToString();
            dta.V0MOVC_AGEAVISO = result[i++].Value?.ToString();
            dta.V0MOVC_NRAVISO = result[i++].Value?.ToString();
            dta.V0MOVC_NUMFITA = result[i++].Value?.ToString();
            dta.V0MOVC_DTMOVTO = result[i++].Value?.ToString();
            dta.V0MOVC_DTQITBCO = result[i++].Value?.ToString();
            dta.V0MOVC_NRTIT = result[i++].Value?.ToString();
            dta.V0MOVC_NUM_APOLICE = result[i++].Value?.ToString();
            dta.V0MOVC_NRENDOS = result[i++].Value?.ToString();
            dta.V0MOVC_NRPARCEL = result[i++].Value?.ToString();
            dta.V0MOVC_VALTIT = result[i++].Value?.ToString();
            dta.V0MOVC_VLIOCC = result[i++].Value?.ToString();
            dta.V0MOVC_VALCDT = result[i++].Value?.ToString();
            dta.V0MOVC_SITUACAO = result[i++].Value?.ToString();
            dta.V0MOVC_NOME = result[i++].Value?.ToString();
            dta.V0MOVC_TIPO_MOVIMENTO = result[i++].Value?.ToString();
            dta.V0MOVC_NOSSO_TITULO = result[i++].Value?.ToString();

            return dta;
        }

    }
}