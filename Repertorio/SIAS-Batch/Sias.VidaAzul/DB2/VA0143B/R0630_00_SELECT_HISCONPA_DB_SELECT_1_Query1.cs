using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0143B
{
    public class R0630_00_SELECT_HISCONPA_DB_SELECT_1_Query1 : QueryBasis<R0630_00_SELECT_HISCONPA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT B.NUM_APOLICE
            ,B.NUM_ENDOSSO
            ,B.RAMO_EMISSOR
            ,B.COD_PRODUTO
            ,B.COD_SUBGRUPO
            ,B.COD_FONTE
            ,B.DATA_INIVIGENCIA
            ,B.DATA_TERVIGENCIA
            INTO :ENDOSSOS-NUM-APOLICE
            ,:ENDOSSOS-NUM-ENDOSSO
            ,:ENDOSSOS-RAMO-EMISSOR
            ,:ENDOSSOS-COD-PRODUTO
            ,:ENDOSSOS-COD-SUBGRUPO
            ,:ENDOSSOS-COD-FONTE
            ,:ENDOSSOS-DATA-INIVIGENCIA
            ,:ENDOSSOS-DATA-TERVIGENCIA
            FROM SEGUROS.HIST_CONT_PARCELVA A
            ,SEGUROS.ENDOSSOS B
            WHERE A.NUM_CERTIFICADO = :HISCONPA-NUM-CERTIFICADO
            AND A.NUM_PARCELA = :HISCONPA-NUM-PARCELA
            AND A.NUM_ENDOSSO <> 0
            AND B.NUM_APOLICE = A.NUM_APOLICE
            AND B.NUM_ENDOSSO = A.NUM_ENDOSSO
            AND B.TIPO_ENDOSSO = '1'
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT B.NUM_APOLICE
											,B.NUM_ENDOSSO
											,B.RAMO_EMISSOR
											,B.COD_PRODUTO
											,B.COD_SUBGRUPO
											,B.COD_FONTE
											,B.DATA_INIVIGENCIA
											,B.DATA_TERVIGENCIA
											FROM SEGUROS.HIST_CONT_PARCELVA A
											,SEGUROS.ENDOSSOS B
											WHERE A.NUM_CERTIFICADO = '{this.HISCONPA_NUM_CERTIFICADO}'
											AND A.NUM_PARCELA = '{this.HISCONPA_NUM_PARCELA}'
											AND A.NUM_ENDOSSO <> 0
											AND B.NUM_APOLICE = A.NUM_APOLICE
											AND B.NUM_ENDOSSO = A.NUM_ENDOSSO
											AND B.TIPO_ENDOSSO = '1'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string ENDOSSOS_NUM_APOLICE { get; set; }
        public string ENDOSSOS_NUM_ENDOSSO { get; set; }
        public string ENDOSSOS_RAMO_EMISSOR { get; set; }
        public string ENDOSSOS_COD_PRODUTO { get; set; }
        public string ENDOSSOS_COD_SUBGRUPO { get; set; }
        public string ENDOSSOS_COD_FONTE { get; set; }
        public string ENDOSSOS_DATA_INIVIGENCIA { get; set; }
        public string ENDOSSOS_DATA_TERVIGENCIA { get; set; }
        public string HISCONPA_NUM_CERTIFICADO { get; set; }
        public string HISCONPA_NUM_PARCELA { get; set; }

        public static R0630_00_SELECT_HISCONPA_DB_SELECT_1_Query1 Execute(R0630_00_SELECT_HISCONPA_DB_SELECT_1_Query1 r0630_00_SELECT_HISCONPA_DB_SELECT_1_Query1)
        {
            var ths = r0630_00_SELECT_HISCONPA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0630_00_SELECT_HISCONPA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0630_00_SELECT_HISCONPA_DB_SELECT_1_Query1();
            var i = 0;
            dta.ENDOSSOS_NUM_APOLICE = result[i++].Value?.ToString();
            dta.ENDOSSOS_NUM_ENDOSSO = result[i++].Value?.ToString();
            dta.ENDOSSOS_RAMO_EMISSOR = result[i++].Value?.ToString();
            dta.ENDOSSOS_COD_PRODUTO = result[i++].Value?.ToString();
            dta.ENDOSSOS_COD_SUBGRUPO = result[i++].Value?.ToString();
            dta.ENDOSSOS_COD_FONTE = result[i++].Value?.ToString();
            dta.ENDOSSOS_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.ENDOSSOS_DATA_TERVIGENCIA = result[i++].Value?.ToString();
            return dta;
        }

    }
}