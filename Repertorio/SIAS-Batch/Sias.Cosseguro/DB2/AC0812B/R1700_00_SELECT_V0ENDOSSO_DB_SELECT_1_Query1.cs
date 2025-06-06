using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0812B
{
    public class R1700_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1 : QueryBasis<R1700_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_MOEDA_PRM ,
            TIPO_ENDOSSO ,
            CORRECAO ,
            DTINIVIG
            INTO :V0ENDO-MOEDA-PRM ,
            :V0ENDO-TIPO-ENDO ,
            :V0ENDO-CORRECAO ,
            :V0ENDO-DTINIVIG
            FROM SEGUROS.V0ENDOSSO
            WHERE NUM_APOLICE = :V1CHIS-NUM-APOL
            AND NRENDOS = :V1CHIS-NUM-ENDS
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_MOEDA_PRM 
							,
											TIPO_ENDOSSO 
							,
											CORRECAO 
							,
											DTINIVIG
											FROM SEGUROS.V0ENDOSSO
											WHERE NUM_APOLICE = '{this.V1CHIS_NUM_APOL}'
											AND NRENDOS = '{this.V1CHIS_NUM_ENDS}'";

            return query;
        }
        public string V0ENDO_MOEDA_PRM { get; set; }
        public string V0ENDO_TIPO_ENDO { get; set; }
        public string V0ENDO_CORRECAO { get; set; }
        public string V0ENDO_DTINIVIG { get; set; }
        public string V1CHIS_NUM_APOL { get; set; }
        public string V1CHIS_NUM_ENDS { get; set; }

        public static R1700_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1 Execute(R1700_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1 r1700_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1)
        {
            var ths = r1700_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1700_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1700_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0ENDO_MOEDA_PRM = result[i++].Value?.ToString();
            dta.V0ENDO_TIPO_ENDO = result[i++].Value?.ToString();
            dta.V0ENDO_CORRECAO = result[i++].Value?.ToString();
            dta.V0ENDO_DTINIVIG = result[i++].Value?.ToString();
            return dta;
        }

    }
}