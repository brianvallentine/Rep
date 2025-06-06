using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0010B
{
    public class VG0010B_TBENEFIPROP : QueryBasis<VG0010B_TBENEFIPROP>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VG0010B_TBENEFIPROP() { IsCursor = true; }

        public VG0010B_TBENEFIPROP(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string NUM_APOLICE { get; set; }
        public string COD_SUBGRUPO { get; set; }
        public string COD_FONTE { get; set; }
        public string NUM_PROPOSTA { get; set; }
        public string NUM_BENEFICIARIO { get; set; }
        public string NOME_BENEFICIARIO { get; set; }
        public string GRAU_PARENTESCO { get; set; }
        public string PCT_PART_BENEFICIA { get; set; }
        public string COD_USUARIO { get; set; }
        public string COD_EMPRESA { get; set; }
        public string WCOD_EMPRESA { get; set; }

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


        public override VG0010B_TBENEFIPROP OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VG0010B_TBENEFIPROP();
            var i = 0;

            dta.NUM_APOLICE = result[i++].Value?.ToString();
            dta.COD_SUBGRUPO = result[i++].Value?.ToString();
            dta.COD_FONTE = result[i++].Value?.ToString();
            dta.NUM_PROPOSTA = result[i++].Value?.ToString();
            dta.NUM_BENEFICIARIO = result[i++].Value?.ToString();
            dta.NOME_BENEFICIARIO = result[i++].Value?.ToString();
            dta.GRAU_PARENTESCO = result[i++].Value?.ToString();
            dta.PCT_PART_BENEFICIA = result[i++].Value?.ToString();
            dta.COD_USUARIO = result[i++].Value?.ToString();
            dta.COD_EMPRESA = result[i++].Value?.ToString();
            dta.WCOD_EMPRESA = string.IsNullOrWhiteSpace(dta.COD_EMPRESA) ? "-1" : "0";

            return dta;
        }

    }
}