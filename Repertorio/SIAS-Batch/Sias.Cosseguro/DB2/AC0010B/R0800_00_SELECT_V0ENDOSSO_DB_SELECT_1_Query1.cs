using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0010B
{
    public class R0800_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1 : QueryBasis<R0800_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT QTPARCEL ,
            DTINIVIG ,
            CORRECAO ,
            CDFRACIO
            INTO :V0ENDO-QTPARCEL ,
            :V0ENDO-DTINIVIG ,
            :V0ENDO-CORRECAO ,
            :V0ENDO-CDFRACIO
            FROM SEGUROS.V0ENDOSSO
            WHERE NUM_APOLICE = :V1HISP-NUM-APOL
            AND NRENDOS = :V1HISP-NRENDOS
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT QTPARCEL 
							,
											DTINIVIG 
							,
											CORRECAO 
							,
											CDFRACIO
											FROM SEGUROS.V0ENDOSSO
											WHERE NUM_APOLICE = '{this.V1HISP_NUM_APOL}'
											AND NRENDOS = '{this.V1HISP_NRENDOS}'";

            return query;
        }
        public string V0ENDO_QTPARCEL { get; set; }
        public string V0ENDO_DTINIVIG { get; set; }
        public string V0ENDO_CORRECAO { get; set; }
        public string V0ENDO_CDFRACIO { get; set; }
        public string V1HISP_NUM_APOL { get; set; }
        public string V1HISP_NRENDOS { get; set; }

        public static R0800_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1 Execute(R0800_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1 r0800_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1)
        {
            var ths = r0800_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0800_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0800_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0ENDO_QTPARCEL = result[i++].Value?.ToString();
            dta.V0ENDO_DTINIVIG = result[i++].Value?.ToString();
            dta.V0ENDO_CORRECAO = result[i++].Value?.ToString();
            dta.V0ENDO_CDFRACIO = result[i++].Value?.ToString();
            return dta;
        }

    }
}