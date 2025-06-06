using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0071B
{
    public class R0123_00_LE_APOLCOBR_DB_SELECT_1_Query1 : QueryBasis<R0123_00_LE_APOLCOBR_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_AGENCIA,
            COD_PRODUTO,
            COD_AGENCIA_DEB,
            OPER_CONTA_DEB,
            NUM_CONTA_DEB,
            DIG_CONTA_DEB,
            NUM_CARTAO
            INTO :APOLCOBR-COD-AGENCIA,
            :APOLCOBR-COD-PRODUTO,
            :APOLCOBR-COD-AGENCIA-DEB:VIND-NULL01,
            :APOLCOBR-OPER-CONTA-DEB:VIND-NULL02,
            :APOLCOBR-NUM-CONTA-DEB:VIND-NULL03,
            :APOLCOBR-DIG-CONTA-DEB:VIND-NULL04,
            :APOLCOBR-NUM-CARTAO:VIND-NULL05
            FROM SEGUROS.APOLICE_COBRANCA
            WHERE NUM_APOLICE = :V1BILH-NUMAPOL
            FETCH FIRST 1 ROW ONLY
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_AGENCIA
							,
											COD_PRODUTO
							,
											COD_AGENCIA_DEB
							,
											OPER_CONTA_DEB
							,
											NUM_CONTA_DEB
							,
											DIG_CONTA_DEB
							,
											NUM_CARTAO
											FROM SEGUROS.APOLICE_COBRANCA
											WHERE NUM_APOLICE = '{this.V1BILH_NUMAPOL}'
											FETCH FIRST 1 ROW ONLY";

            return query;
        }
        public string APOLCOBR_COD_AGENCIA { get; set; }
        public string APOLCOBR_COD_PRODUTO { get; set; }
        public string APOLCOBR_COD_AGENCIA_DEB { get; set; }
        public string VIND_NULL01 { get; set; }
        public string APOLCOBR_OPER_CONTA_DEB { get; set; }
        public string VIND_NULL02 { get; set; }
        public string APOLCOBR_NUM_CONTA_DEB { get; set; }
        public string VIND_NULL03 { get; set; }
        public string APOLCOBR_DIG_CONTA_DEB { get; set; }
        public string VIND_NULL04 { get; set; }
        public string APOLCOBR_NUM_CARTAO { get; set; }
        public string VIND_NULL05 { get; set; }
        public string V1BILH_NUMAPOL { get; set; }

        public static R0123_00_LE_APOLCOBR_DB_SELECT_1_Query1 Execute(R0123_00_LE_APOLCOBR_DB_SELECT_1_Query1 r0123_00_LE_APOLCOBR_DB_SELECT_1_Query1)
        {
            var ths = r0123_00_LE_APOLCOBR_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0123_00_LE_APOLCOBR_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0123_00_LE_APOLCOBR_DB_SELECT_1_Query1();
            var i = 0;
            dta.APOLCOBR_COD_AGENCIA = result[i++].Value?.ToString();
            dta.APOLCOBR_COD_PRODUTO = result[i++].Value?.ToString();
            dta.APOLCOBR_COD_AGENCIA_DEB = result[i++].Value?.ToString();
            dta.VIND_NULL01 = string.IsNullOrWhiteSpace(dta.APOLCOBR_COD_AGENCIA_DEB) ? "-1" : "0";
            dta.APOLCOBR_OPER_CONTA_DEB = result[i++].Value?.ToString();
            dta.VIND_NULL02 = string.IsNullOrWhiteSpace(dta.APOLCOBR_OPER_CONTA_DEB) ? "-1" : "0";
            dta.APOLCOBR_NUM_CONTA_DEB = result[i++].Value?.ToString();
            dta.VIND_NULL03 = string.IsNullOrWhiteSpace(dta.APOLCOBR_NUM_CONTA_DEB) ? "-1" : "0";
            dta.APOLCOBR_DIG_CONTA_DEB = result[i++].Value?.ToString();
            dta.VIND_NULL04 = string.IsNullOrWhiteSpace(dta.APOLCOBR_DIG_CONTA_DEB) ? "-1" : "0";
            dta.APOLCOBR_NUM_CARTAO = result[i++].Value?.ToString();
            dta.VIND_NULL05 = string.IsNullOrWhiteSpace(dta.APOLCOBR_NUM_CARTAO) ? "-1" : "0";
            return dta;
        }

    }
}