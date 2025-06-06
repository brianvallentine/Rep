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
    public class R1020_LE_MOVDEBCC_SAP_DB_SELECT_1_Query1 : QueryBasis<R1020_LE_MOVDEBCC_SAP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            NUM_APOLICE ,
            NUM_ENDOSSO ,
            NUM_PARCELA ,
            COD_CONVENIO ,
            NSAS ,
            NUM_OCORR_MOVTO ,
            IDE_SISTEMA ,
            DTH_CADASTRAMENTO
            INTO
            :GE094-NUM-APOLICE ,
            :GE094-NUM-ENDOSSO ,
            :GE094-NUM-PARCELA ,
            :GE094-COD-CONVENIO ,
            :GE094-NSAS ,
            :GE094-NUM-OCORR-MOVTO ,
            :GE094-IDE-SISTEMA ,
            :GE094-DTH-CADASTRAMENTO
            FROM SEGUROS.GE_MOVDEBCE_SAP
            WHERE NUM_OCORR_MOVTO = :GE100-NUM-OCORR-MOVTO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											NUM_APOLICE 
							,
											NUM_ENDOSSO 
							,
											NUM_PARCELA 
							,
											COD_CONVENIO 
							,
											NSAS 
							,
											NUM_OCORR_MOVTO 
							,
											IDE_SISTEMA 
							,
											DTH_CADASTRAMENTO
											FROM SEGUROS.GE_MOVDEBCE_SAP
											WHERE NUM_OCORR_MOVTO = '{this.GE100_NUM_OCORR_MOVTO}'";

            return query;
        }
        public string GE094_NUM_APOLICE { get; set; }
        public string GE094_NUM_ENDOSSO { get; set; }
        public string GE094_NUM_PARCELA { get; set; }
        public string GE094_COD_CONVENIO { get; set; }
        public string GE094_NSAS { get; set; }
        public string GE094_NUM_OCORR_MOVTO { get; set; }
        public string GE094_IDE_SISTEMA { get; set; }
        public string GE094_DTH_CADASTRAMENTO { get; set; }
        public string GE100_NUM_OCORR_MOVTO { get; set; }

        public static R1020_LE_MOVDEBCC_SAP_DB_SELECT_1_Query1 Execute(R1020_LE_MOVDEBCC_SAP_DB_SELECT_1_Query1 r1020_LE_MOVDEBCC_SAP_DB_SELECT_1_Query1)
        {
            var ths = r1020_LE_MOVDEBCC_SAP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1020_LE_MOVDEBCC_SAP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1020_LE_MOVDEBCC_SAP_DB_SELECT_1_Query1();
            var i = 0;
            dta.GE094_NUM_APOLICE = result[i++].Value?.ToString();
            dta.GE094_NUM_ENDOSSO = result[i++].Value?.ToString();
            dta.GE094_NUM_PARCELA = result[i++].Value?.ToString();
            dta.GE094_COD_CONVENIO = result[i++].Value?.ToString();
            dta.GE094_NSAS = result[i++].Value?.ToString();
            dta.GE094_NUM_OCORR_MOVTO = result[i++].Value?.ToString();
            dta.GE094_IDE_SISTEMA = result[i++].Value?.ToString();
            dta.GE094_DTH_CADASTRAMENTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}