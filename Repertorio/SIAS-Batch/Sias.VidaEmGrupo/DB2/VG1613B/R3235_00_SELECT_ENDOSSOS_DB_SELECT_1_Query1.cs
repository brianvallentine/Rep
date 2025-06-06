using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1613B
{
    public class R3235_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 : QueryBasis<R3235_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_INIVIGENCIA,
            DATE(:SISTEMAS-DATA-MOV-ABERTO-1) -
            DATA_INIVIGENCIA
            INTO :WS-DATA-INIVIGENCIA-APOL,
            :WS-QTD-DIAS-VIGENCIA
            FROM SEGUROS.ENDOSSOS
            WHERE NUM_APOLICE = :MOVIMVGA-NUM-APOLICE
            AND NUM_ENDOSSO = 0
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_INIVIGENCIA
							,
											DATE('{this.SISTEMAS_DATA_MOV_ABERTO_1}') -
											DATA_INIVIGENCIA
											FROM SEGUROS.ENDOSSOS
											WHERE NUM_APOLICE = '{this.MOVIMVGA_NUM_APOLICE}'
											AND NUM_ENDOSSO = 0";

            return query;
        }
        public string WS_DATA_INIVIGENCIA_APOL { get; set; }
        public string WS_QTD_DIAS_VIGENCIA { get; set; }
        public string SISTEMAS_DATA_MOV_ABERTO_1 { get; set; }
        public string MOVIMVGA_NUM_APOLICE { get; set; }

        public static R3235_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 Execute(R3235_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 r3235_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1)
        {
            var ths = r3235_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3235_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3235_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_DATA_INIVIGENCIA_APOL = result[i++].Value?.ToString();
            dta.WS_QTD_DIAS_VIGENCIA = result[i++].Value?.ToString();
            return dta;
        }

    }
}