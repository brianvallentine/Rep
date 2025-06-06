using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GEJVS002
{
    public class GEJVS002_GE074_CURSOR : QueryBasis<GEJVS002_GE074_CURSOR>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public GEJVS002_GE074_CURSOR() { IsCursor = true; }

        public GEJVS002_GE074_CURSOR(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string PARAMGER_DATA_INIVIGENCIA { get; set; }
        public string PARAMGER_DATA_TERVIGENCIA { get; set; }
        public string PARAMGER_COD_MOEDA { get; set; }
        public string PARAMGER_COD_BANCO { get; set; }
        public string PARAMGER_COD_AGENCIA { get; set; }
        public string PARAMGER_OPCAO_BANCO { get; set; }
        public string PARAMGER_DIF_PREMIOS { get; set; }
        public string PARAMGER_FAIXA_APOL_MANUAL { get; set; }
        public string PARAMGER_FAIXA_ENDOSCOB_MAN { get; set; }
        public string PARAMGER_DATA_FATURAVG_AUT { get; set; }
        public string PARAMGER_CAPITAL_SOCIAL { get; set; }
        public string PARAMGER_CAPITAL_REALIZADO { get; set; }
        public string PARAMGER_CAPITAL_VINCULADO { get; set; }
        public string PARAMGER_ULT_AVISO_CREDITO { get; set; }
        public string PARAMGER_CODIGO_LIDER { get; set; }
        public string PARAMGER_NUM_RELACAO { get; set; }
        public string PARAMGER_COD_EMPRESA { get; set; }
        public string PARAMGER_COD_CGCCPF { get; set; }
        public string PARAMGER_COD_EMPRESA_CAP { get; set; }

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


        public override GEJVS002_GE074_CURSOR OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new GEJVS002_GE074_CURSOR();
            var i = 0;

            dta.PARAMGER_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.PARAMGER_DATA_TERVIGENCIA = result[i++].Value?.ToString();
            dta.PARAMGER_COD_MOEDA = result[i++].Value?.ToString();
            dta.PARAMGER_COD_BANCO = result[i++].Value?.ToString();
            dta.PARAMGER_COD_AGENCIA = result[i++].Value?.ToString();
            dta.PARAMGER_OPCAO_BANCO = result[i++].Value?.ToString();
            dta.PARAMGER_DIF_PREMIOS = result[i++].Value?.ToString();
            dta.PARAMGER_FAIXA_APOL_MANUAL = result[i++].Value?.ToString();
            dta.PARAMGER_FAIXA_ENDOSCOB_MAN = result[i++].Value?.ToString();
            dta.PARAMGER_DATA_FATURAVG_AUT = result[i++].Value?.ToString();
            dta.PARAMGER_CAPITAL_SOCIAL = result[i++].Value?.ToString();
            dta.PARAMGER_CAPITAL_REALIZADO = result[i++].Value?.ToString();
            dta.PARAMGER_CAPITAL_VINCULADO = result[i++].Value?.ToString();
            dta.PARAMGER_ULT_AVISO_CREDITO = result[i++].Value?.ToString();
            dta.PARAMGER_CODIGO_LIDER = result[i++].Value?.ToString();
            dta.PARAMGER_NUM_RELACAO = result[i++].Value?.ToString();
            dta.PARAMGER_COD_EMPRESA = result[i++].Value?.ToString();
            dta.PARAMGER_COD_CGCCPF = result[i++].Value?.ToString();
            dta.PARAMGER_COD_EMPRESA_CAP = result[i++].Value?.ToString();

            return dta;
        }

    }
}