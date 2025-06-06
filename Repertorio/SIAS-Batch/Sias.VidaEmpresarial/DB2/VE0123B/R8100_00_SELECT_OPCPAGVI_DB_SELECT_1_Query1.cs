using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE0123B
{
    public class R8100_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1 : QueryBasis<R8100_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_CERTIFICADO
            , DATA_INIVIGENCIA
            , DATA_TERVIGENCIA
            , OPCAO_PAGAMENTO
            , PERI_PAGAMENTO
            , DIA_DEBITO
            , COD_USUARIO
            , TIMESTAMP
            , COD_AGENCIA_DEBITO
            , OPE_CONTA_DEBITO
            , NUM_CONTA_DEBITO
            , DIG_CONTA_DEBITO
            , NUM_CARTAO_CREDITO
            INTO :OPCPAGVI-NUM-CERTIFICADO
            ,:OPCPAGVI-DATA-INIVIGENCIA
            ,:OPCPAGVI-DATA-TERVIGENCIA
            ,:OPCPAGVI-OPCAO-PAGAMENTO
            ,:OPCPAGVI-PERI-PAGAMENTO
            ,:OPCPAGVI-DIA-DEBITO
            ,:OPCPAGVI-COD-USUARIO
            ,:OPCPAGVI-TIMESTAMP
            ,:OPCPAGVI-COD-AGENCIA-DEBITO :VIND-AGEDEB
            ,:OPCPAGVI-OPE-CONTA-DEBITO :VIND-OPEDEB
            ,:OPCPAGVI-NUM-CONTA-DEBITO :VIND-CTADEB
            ,:OPCPAGVI-DIG-CONTA-DEBITO :VIND-DIGDEB
            ,:OPCPAGVI-NUM-CARTAO-CREDITO :VIND-NUMCAR
            FROM SEGUROS.OPCAO_PAG_VIDAZUL
            WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO
            AND DATA_TERVIGENCIA = '9999-12-31'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_CERTIFICADO
											, DATA_INIVIGENCIA
											, DATA_TERVIGENCIA
											, OPCAO_PAGAMENTO
											, PERI_PAGAMENTO
											, DIA_DEBITO
											, COD_USUARIO
											, TIMESTAMP
											, COD_AGENCIA_DEBITO
											, OPE_CONTA_DEBITO
											, NUM_CONTA_DEBITO
											, DIG_CONTA_DEBITO
											, NUM_CARTAO_CREDITO
											FROM SEGUROS.OPCAO_PAG_VIDAZUL
											WHERE NUM_CERTIFICADO = '{this.PROPOVA_NUM_CERTIFICADO}'
											AND DATA_TERVIGENCIA = '9999-12-31'
											WITH UR";

            return query;
        }
        public string OPCPAGVI_NUM_CERTIFICADO { get; set; }
        public string OPCPAGVI_DATA_INIVIGENCIA { get; set; }
        public string OPCPAGVI_DATA_TERVIGENCIA { get; set; }
        public string OPCPAGVI_OPCAO_PAGAMENTO { get; set; }
        public string OPCPAGVI_PERI_PAGAMENTO { get; set; }
        public string OPCPAGVI_DIA_DEBITO { get; set; }
        public string OPCPAGVI_COD_USUARIO { get; set; }
        public string OPCPAGVI_TIMESTAMP { get; set; }
        public string OPCPAGVI_COD_AGENCIA_DEBITO { get; set; }
        public string VIND_AGEDEB { get; set; }
        public string OPCPAGVI_OPE_CONTA_DEBITO { get; set; }
        public string VIND_OPEDEB { get; set; }
        public string OPCPAGVI_NUM_CONTA_DEBITO { get; set; }
        public string VIND_CTADEB { get; set; }
        public string OPCPAGVI_DIG_CONTA_DEBITO { get; set; }
        public string VIND_DIGDEB { get; set; }
        public string OPCPAGVI_NUM_CARTAO_CREDITO { get; set; }
        public string VIND_NUMCAR { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }

        public static R8100_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1 Execute(R8100_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1 r8100_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1)
        {
            var ths = r8100_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R8100_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R8100_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1();
            var i = 0;
            dta.OPCPAGVI_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.OPCPAGVI_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.OPCPAGVI_DATA_TERVIGENCIA = result[i++].Value?.ToString();
            dta.OPCPAGVI_OPCAO_PAGAMENTO = result[i++].Value?.ToString();
            dta.OPCPAGVI_PERI_PAGAMENTO = result[i++].Value?.ToString();
            dta.OPCPAGVI_DIA_DEBITO = result[i++].Value?.ToString();
            dta.OPCPAGVI_COD_USUARIO = result[i++].Value?.ToString();
            dta.OPCPAGVI_TIMESTAMP = result[i++].Value?.ToString();
            dta.OPCPAGVI_COD_AGENCIA_DEBITO = result[i++].Value?.ToString();
            dta.VIND_AGEDEB = string.IsNullOrWhiteSpace(dta.OPCPAGVI_COD_AGENCIA_DEBITO) ? "-1" : "0";
            dta.OPCPAGVI_OPE_CONTA_DEBITO = result[i++].Value?.ToString();
            dta.VIND_OPEDEB = string.IsNullOrWhiteSpace(dta.OPCPAGVI_OPE_CONTA_DEBITO) ? "-1" : "0";
            dta.OPCPAGVI_NUM_CONTA_DEBITO = result[i++].Value?.ToString();
            dta.VIND_CTADEB = string.IsNullOrWhiteSpace(dta.OPCPAGVI_NUM_CONTA_DEBITO) ? "-1" : "0";
            dta.OPCPAGVI_DIG_CONTA_DEBITO = result[i++].Value?.ToString();
            dta.VIND_DIGDEB = string.IsNullOrWhiteSpace(dta.OPCPAGVI_DIG_CONTA_DEBITO) ? "-1" : "0";
            dta.OPCPAGVI_NUM_CARTAO_CREDITO = result[i++].Value?.ToString();
            dta.VIND_NUMCAR = string.IsNullOrWhiteSpace(dta.OPCPAGVI_NUM_CARTAO_CREDITO) ? "-1" : "0";
            return dta;
        }

    }
}