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
    public class R0290_00_SELECT_APOLICOB_DB_SELECT_1_Query1 : QueryBasis<R0290_00_SELECT_APOLICOB_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_INIVIGENCIA
            ,DATA_TERVIGENCIA
            INTO :APOLICOB-DATA-INIVIGENCIA
            ,:APOLICOB-DATA-TERVIGENCIA
            FROM SEGUROS.APOLICE_COBERTURAS
            WHERE NUM_APOLICE = :ENDOSSOS-NUM-APOLICE
            AND NUM_ENDOSSO = 0
            AND NUM_ITEM = :SEGVGAP-NUM-ITEM
            AND OCORR_HISTORICO = :APOLICOB-OCORR-HISTORICO
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_INIVIGENCIA
											,DATA_TERVIGENCIA
											FROM SEGUROS.APOLICE_COBERTURAS
											WHERE NUM_APOLICE = '{this.ENDOSSOS_NUM_APOLICE}'
											AND NUM_ENDOSSO = 0
											AND NUM_ITEM = '{this.SEGVGAP_NUM_ITEM}'
											AND OCORR_HISTORICO = '{this.APOLICOB_OCORR_HISTORICO}'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string APOLICOB_DATA_INIVIGENCIA { get; set; }
        public string APOLICOB_DATA_TERVIGENCIA { get; set; }
        public string APOLICOB_OCORR_HISTORICO { get; set; }
        public string ENDOSSOS_NUM_APOLICE { get; set; }
        public string SEGVGAP_NUM_ITEM { get; set; }

        public static R0290_00_SELECT_APOLICOB_DB_SELECT_1_Query1 Execute(R0290_00_SELECT_APOLICOB_DB_SELECT_1_Query1 r0290_00_SELECT_APOLICOB_DB_SELECT_1_Query1)
        {
            var ths = r0290_00_SELECT_APOLICOB_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0290_00_SELECT_APOLICOB_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0290_00_SELECT_APOLICOB_DB_SELECT_1_Query1();
            var i = 0;
            dta.APOLICOB_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.APOLICOB_DATA_TERVIGENCIA = result[i++].Value?.ToString();
            return dta;
        }

    }
}