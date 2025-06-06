using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1473B
{
    public class VG1473B_CPROPVA : QueryBasis<VG1473B_CPROPVA>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VG1473B_CPROPVA() { IsCursor = true; }

        public VG1473B_CPROPVA(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string PROPOVA_NUM_CERTIFICADO { get; set; }
        public string PROPOVA_NUM_APOLICE { get; set; }
        public string PROPOVA_COD_SUBGRUPO { get; set; }
        public string PROPOVA_COD_CLIENTE { get; set; }
        public string PROPOVA_DATA_QUITACAO { get; set; }
        public string PROPVA_DTQIT10A { get; set; }
        public string PROPOVA_SIT_REGISTRO { get; set; }
        public string PRODUVG_COD_PRODUTO_EA { get; set; }
        public string PRODVG_ICODPRODEA { get; set; }
        public string PRODUVG_OPCAO_PAGAMENTO { get; set; }
        public string SEGURVGA_NUM_ITEM { get; set; }
        public string PROPOVA_ESTADO_CIVIL { get; set; }
        public string PROPOVA_IDE_SEXO { get; set; }
        public string SEGURVGA_OCORR_ENDERECO { get; set; }

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


        public override VG1473B_CPROPVA OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VG1473B_CPROPVA();
            var i = 0;

            dta.PROPOVA_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.PROPOVA_NUM_APOLICE = result[i++].Value?.ToString();
            dta.PROPOVA_COD_SUBGRUPO = result[i++].Value?.ToString();
            dta.PROPOVA_COD_CLIENTE = result[i++].Value?.ToString();
            dta.PROPOVA_DATA_QUITACAO = result[i++].Value?.ToString();
            dta.PROPVA_DTQIT10A = result[i++].Value?.ToString();
            dta.PROPOVA_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.PRODUVG_COD_PRODUTO_EA = result[i++].Value?.ToString();
            dta.PRODVG_ICODPRODEA = string.IsNullOrWhiteSpace(dta.PRODUVG_COD_PRODUTO_EA) ? "-1" : "0";
            dta.PRODUVG_OPCAO_PAGAMENTO = result[i++].Value?.ToString();
            dta.SEGURVGA_NUM_ITEM = result[i++].Value?.ToString();
            dta.PROPOVA_ESTADO_CIVIL = result[i++].Value?.ToString();
            dta.PROPOVA_IDE_SEXO = result[i++].Value?.ToString();
            dta.SEGURVGA_OCORR_ENDERECO = result[i++].Value?.ToString();

            return dta;
        }

    }
}