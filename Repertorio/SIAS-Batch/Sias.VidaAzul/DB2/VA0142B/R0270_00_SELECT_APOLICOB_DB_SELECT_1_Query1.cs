using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0142B
{
    public class R0270_00_SELECT_APOLICOB_DB_SELECT_1_Query1 : QueryBasis<R0270_00_SELECT_APOLICOB_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COUNT(*)
            ,MAX(OCORR_HISTORICO)
            INTO :WHOST-COUNT1:VIND-COUNT
            ,:APOLICOB-OCORR-HISTORICO:VIND-NULL01
            FROM SEGUROS.APOLICE_COBERTURAS
            WHERE NUM_APOLICE = :ENDOSSOS-NUM-APOLICE
            AND NUM_ENDOSSO = 0
            AND NUM_ITEM = :SEGVGAP-NUM-ITEM
            AND DATA_INIVIGENCIA <= :ENDOSSOS-DATA-INIVIGENCIA
            AND DATA_TERVIGENCIA >= :ENDOSSOS-DATA-INIVIGENCIA
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COUNT(*)
											,MAX(OCORR_HISTORICO)
											FROM SEGUROS.APOLICE_COBERTURAS
											WHERE NUM_APOLICE = '{this.ENDOSSOS_NUM_APOLICE}'
											AND NUM_ENDOSSO = 0
											AND NUM_ITEM = '{this.SEGVGAP_NUM_ITEM}'
											AND DATA_INIVIGENCIA <= '{this.ENDOSSOS_DATA_INIVIGENCIA}'
											AND DATA_TERVIGENCIA >= '{this.ENDOSSOS_DATA_INIVIGENCIA}'
											WITH UR";

            return query;
        }
        public string WHOST_COUNT1 { get; set; }
        public string VIND_COUNT { get; set; }
        public string APOLICOB_OCORR_HISTORICO { get; set; }
        public string VIND_NULL01 { get; set; }
        public string ENDOSSOS_DATA_INIVIGENCIA { get; set; }
        public string ENDOSSOS_NUM_APOLICE { get; set; }
        public string SEGVGAP_NUM_ITEM { get; set; }

        public static R0270_00_SELECT_APOLICOB_DB_SELECT_1_Query1 Execute(R0270_00_SELECT_APOLICOB_DB_SELECT_1_Query1 r0270_00_SELECT_APOLICOB_DB_SELECT_1_Query1)
        {
            var ths = r0270_00_SELECT_APOLICOB_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0270_00_SELECT_APOLICOB_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0270_00_SELECT_APOLICOB_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_COUNT1 = result[i++].Value?.ToString();
            dta.VIND_COUNT = string.IsNullOrWhiteSpace(dta.WHOST_COUNT1) ? "-1" : "0";
            dta.APOLICOB_OCORR_HISTORICO = result[i++].Value?.ToString();
            dta.VIND_NULL01 = string.IsNullOrWhiteSpace(dta.APOLICOB_OCORR_HISTORICO) ? "-1" : "0";
            return dta;
        }

    }
}