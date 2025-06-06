using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0540S
{
    public class R0210_00_SELECT_APOLCOBR_DB_SELECT_1_Query1 : QueryBasis<R0210_00_SELECT_APOLCOBR_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_AGENCIA_DEB ,
            OPER_CONTA_DEB ,
            NUM_CONTA_DEB ,
            DIG_CONTA_DEB
            INTO :APOLCOBR-COD-AGENCIA-DEB:VIND-NULL01 ,
            :APOLCOBR-OPER-CONTA-DEB:VIND-NULL02 ,
            :APOLCOBR-NUM-CONTA-DEB:VIND-NULL03 ,
            :APOLCOBR-DIG-CONTA-DEB:VIND-NULL04
            FROM SEGUROS.APOLICE_COBRANCA
            WHERE NUM_APOLICE = :APOLCOBR-NUM-APOLICE
            AND NUM_ENDOSSO = :APOLCOBR-NUM-ENDOSSO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_AGENCIA_DEB 
							,
											OPER_CONTA_DEB 
							,
											NUM_CONTA_DEB 
							,
											DIG_CONTA_DEB
											FROM SEGUROS.APOLICE_COBRANCA
											WHERE NUM_APOLICE = '{this.APOLCOBR_NUM_APOLICE}'
											AND NUM_ENDOSSO = '{this.APOLCOBR_NUM_ENDOSSO}'
											WITH UR";

            return query;
        }
        public string APOLCOBR_COD_AGENCIA_DEB { get; set; }
        public string VIND_NULL01 { get; set; }
        public string APOLCOBR_OPER_CONTA_DEB { get; set; }
        public string VIND_NULL02 { get; set; }
        public string APOLCOBR_NUM_CONTA_DEB { get; set; }
        public string VIND_NULL03 { get; set; }
        public string APOLCOBR_DIG_CONTA_DEB { get; set; }
        public string VIND_NULL04 { get; set; }
        public string APOLCOBR_NUM_APOLICE { get; set; }
        public string APOLCOBR_NUM_ENDOSSO { get; set; }

        public static R0210_00_SELECT_APOLCOBR_DB_SELECT_1_Query1 Execute(R0210_00_SELECT_APOLCOBR_DB_SELECT_1_Query1 r0210_00_SELECT_APOLCOBR_DB_SELECT_1_Query1)
        {
            var ths = r0210_00_SELECT_APOLCOBR_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0210_00_SELECT_APOLCOBR_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0210_00_SELECT_APOLCOBR_DB_SELECT_1_Query1();
            var i = 0;
            dta.APOLCOBR_COD_AGENCIA_DEB = result[i++].Value?.ToString();
            dta.VIND_NULL01 = string.IsNullOrWhiteSpace(dta.APOLCOBR_COD_AGENCIA_DEB) ? "-1" : "0";
            dta.APOLCOBR_OPER_CONTA_DEB = result[i++].Value?.ToString();
            dta.VIND_NULL02 = string.IsNullOrWhiteSpace(dta.APOLCOBR_OPER_CONTA_DEB) ? "-1" : "0";
            dta.APOLCOBR_NUM_CONTA_DEB = result[i++].Value?.ToString();
            dta.VIND_NULL03 = string.IsNullOrWhiteSpace(dta.APOLCOBR_NUM_CONTA_DEB) ? "-1" : "0";
            dta.APOLCOBR_DIG_CONTA_DEB = result[i++].Value?.ToString();
            dta.VIND_NULL04 = string.IsNullOrWhiteSpace(dta.APOLCOBR_DIG_CONTA_DEB) ? "-1" : "0";
            return dta;
        }

    }
}