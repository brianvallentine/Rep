using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI6016B
{
    public class R9900_00_GRAVA_OBJETO_DB_SELECT_1_Query1 : QueryBasis<R9900_00_GRAVA_OBJETO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DISTINCT STA_REGISTRO
            INTO :GEOBJECT-STA-REGISTRO
            FROM SEGUROS.GE_OBJETO_ECT
            WHERE NUM_CEP = 0
            AND NOM_PROGRAMA = 'BI6016B'
            AND COD_FORMULARIO = :GEOBJECT-COD-FORMULARIO
            AND STA_REGISTRO = 'H'
            AND DATE(DTH_TIMESTAMP) <> '9999-12-31'
            ORDER BY STA_REGISTRO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DISTINCT STA_REGISTRO
											FROM SEGUROS.GE_OBJETO_ECT
											WHERE NUM_CEP = 0
											AND NOM_PROGRAMA = 'BI6016B'
											AND COD_FORMULARIO = '{this.GEOBJECT_COD_FORMULARIO}'
											AND STA_REGISTRO = 'H'
											AND DATE(DTH_TIMESTAMP) <> '9999-12-31'
											ORDER BY STA_REGISTRO";

            return query;
        }
        public string GEOBJECT_STA_REGISTRO { get; set; }
        public string GEOBJECT_COD_FORMULARIO { get; set; }

        public static R9900_00_GRAVA_OBJETO_DB_SELECT_1_Query1 Execute(R9900_00_GRAVA_OBJETO_DB_SELECT_1_Query1 r9900_00_GRAVA_OBJETO_DB_SELECT_1_Query1)
        {
            var ths = r9900_00_GRAVA_OBJETO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R9900_00_GRAVA_OBJETO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R9900_00_GRAVA_OBJETO_DB_SELECT_1_Query1();
            var i = 0;
            dta.GEOBJECT_STA_REGISTRO = result[i++].Value?.ToString();
            return dta;
        }

    }
}