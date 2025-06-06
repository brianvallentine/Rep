using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG5001B
{
    public class VG5001B_RELATORIO : QueryBasis<VG5001B_RELATORIO>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VG5001B_RELATORIO() { IsCursor = true; }

        public VG5001B_RELATORIO(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string R_NUM_APOLICE { get; set; }
        public string R_NRPARCEL { get; set; }
        public string R_CODSUBES { get; set; }
        public string R_OPERACAO { get; set; }
        public string R_CODUSU { get; set; }
        public string R_CORRECAO { get; set; }

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


        public override VG5001B_RELATORIO OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VG5001B_RELATORIO();
            var i = 0;

            dta.R_NUM_APOLICE = result[i++].Value?.ToString();
            dta.R_NRPARCEL = result[i++].Value?.ToString();
            dta.R_CODSUBES = result[i++].Value?.ToString();
            dta.R_OPERACAO = result[i++].Value?.ToString();
            dta.R_CODUSU = result[i++].Value?.ToString();
            dta.R_CORRECAO = result[i++].Value?.ToString();

            return dta;
        }

    }
}