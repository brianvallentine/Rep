using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0141B
{
    public class R0460_00_SELECT_HISCONPA_DB_SELECT_1_Query1 : QueryBasis<R0460_00_SELECT_HISCONPA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT B.DATA_TERVIGENCIA + 1 DAYS
            ,B.DATA_TERVIGENCIA + :WHOST-PERI MONTHS
            ,A.NUM_PARCELA
            INTO :ENDOSSOS-DATA-INIVIGENCIA
            ,:ENDOSSOS-DATA-TERVIGENCIA
            ,:WHOST-NUMPARCEL
            FROM SEGUROS.HIST_CONT_PARCELVA A
            ,SEGUROS.ENDOSSOS B
            WHERE A.NUM_CERTIFICADO = :HISCONPA-NUM-CERTIFICADO
            AND A.NUM_PARCELA < :HISCONPA-NUM-PARCELA
            AND A.NUM_ENDOSSO <> 0
            AND B.NUM_APOLICE = A.NUM_APOLICE
            AND B.NUM_ENDOSSO = A.NUM_ENDOSSO
            AND B.TIPO_ENDOSSO = '1'
            ORDER BY A.NUM_PARCELA DESC
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT B.DATA_TERVIGENCIA + 1 DAYS
											,B.DATA_TERVIGENCIA + {this.WHOST_PERI} MONTHS
											,A.NUM_PARCELA
											FROM SEGUROS.HIST_CONT_PARCELVA A
											,SEGUROS.ENDOSSOS B
											WHERE A.NUM_CERTIFICADO = '{this.HISCONPA_NUM_CERTIFICADO}'
											AND A.NUM_PARCELA < '{this.HISCONPA_NUM_PARCELA}'
											AND A.NUM_ENDOSSO <> 0
											AND B.NUM_APOLICE = A.NUM_APOLICE
											AND B.NUM_ENDOSSO = A.NUM_ENDOSSO
											AND B.TIPO_ENDOSSO = '1'
											ORDER BY A.NUM_PARCELA DESC
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string ENDOSSOS_DATA_INIVIGENCIA { get; set; }
        public string ENDOSSOS_DATA_TERVIGENCIA { get; set; }
        public string WHOST_NUMPARCEL { get; set; }
        public string HISCONPA_NUM_CERTIFICADO { get; set; }
        public string HISCONPA_NUM_PARCELA { get; set; }
        public string WHOST_PERI { get; set; }

        public static R0460_00_SELECT_HISCONPA_DB_SELECT_1_Query1 Execute(R0460_00_SELECT_HISCONPA_DB_SELECT_1_Query1 r0460_00_SELECT_HISCONPA_DB_SELECT_1_Query1)
        {
            var ths = r0460_00_SELECT_HISCONPA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0460_00_SELECT_HISCONPA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0460_00_SELECT_HISCONPA_DB_SELECT_1_Query1();
            var i = 0;
            dta.ENDOSSOS_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.ENDOSSOS_DATA_TERVIGENCIA = result[i++].Value?.ToString();
            dta.WHOST_NUMPARCEL = result[i++].Value?.ToString();
            return dta;
        }

    }
}