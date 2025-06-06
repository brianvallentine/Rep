using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SISAP03B
{
    public class R1010_LE_CHEQUES_SAP_DB_SELECT_1_Query1 : QueryBasis<R1010_LE_CHEQUES_SAP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            NUM_OCORR_MOVTO ,
            NUM_CHEQUE_INTERNO,
            NSAS ,
            IDE_SISTEMA ,
            DTH_CADASTRAMENTO
            INTO
            :GE097-NUM-OCORR-MOVTO,
            :GE097-NUM-CHEQUE-INTERNO,
            :GE097-NSAS,
            :GE097-IDE-SISTEMA,
            :GE097-DTH-CADASTRAMENTO
            FROM SEGUROS.GE_CHEQUE_SAP
            WHERE NUM_OCORR_MOVTO = :GE100-NUM-OCORR-MOVTO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											NUM_OCORR_MOVTO 
							,
											NUM_CHEQUE_INTERNO
							,
											NSAS 
							,
											IDE_SISTEMA 
							,
											DTH_CADASTRAMENTO
											FROM SEGUROS.GE_CHEQUE_SAP
											WHERE NUM_OCORR_MOVTO = '{this.GE100_NUM_OCORR_MOVTO}'";

            return query;
        }
        public string GE097_NUM_OCORR_MOVTO { get; set; }
        public string GE097_NUM_CHEQUE_INTERNO { get; set; }
        public string GE097_NSAS { get; set; }
        public string GE097_IDE_SISTEMA { get; set; }
        public string GE097_DTH_CADASTRAMENTO { get; set; }
        public string GE100_NUM_OCORR_MOVTO { get; set; }

        public static R1010_LE_CHEQUES_SAP_DB_SELECT_1_Query1 Execute(R1010_LE_CHEQUES_SAP_DB_SELECT_1_Query1 r1010_LE_CHEQUES_SAP_DB_SELECT_1_Query1)
        {
            var ths = r1010_LE_CHEQUES_SAP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1010_LE_CHEQUES_SAP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1010_LE_CHEQUES_SAP_DB_SELECT_1_Query1();
            var i = 0;
            dta.GE097_NUM_OCORR_MOVTO = result[i++].Value?.ToString();
            dta.GE097_NUM_CHEQUE_INTERNO = result[i++].Value?.ToString();
            dta.GE097_NSAS = result[i++].Value?.ToString();
            dta.GE097_IDE_SISTEMA = result[i++].Value?.ToString();
            dta.GE097_DTH_CADASTRAMENTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}