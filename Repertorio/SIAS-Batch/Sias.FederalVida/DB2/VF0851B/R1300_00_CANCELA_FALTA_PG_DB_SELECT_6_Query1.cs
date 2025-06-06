using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.FederalVida.DB2.VF0851B
{
    public class R1300_00_CANCELA_FALTA_PG_DB_SELECT_6_Query1 : QueryBasis<R1300_00_CANCELA_FALTA_PG_DB_SELECT_6_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT IMP_SEGURADA_IX,
            PRM_TARIFARIO_IX
            INTO :V0COBA-IMPMORNATU,
            :V0COBA-PRMVG
            FROM SEGUROS.V0COBERAPOL
            WHERE NUM_APOLICE = :V0PROP-NUM-APOLICE
            AND NRENDOS = 0
            AND NUM_ITEM = :V0SEGU-ITEM
            AND OCORHIST = :V0SEGU-OCORHIST
            AND RAMOFR = 93
            AND MODALIFR = 0
            AND COD_COBERTURA = 11
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT IMP_SEGURADA_IX
							,
											PRM_TARIFARIO_IX
											FROM SEGUROS.V0COBERAPOL
											WHERE NUM_APOLICE = '{this.V0PROP_NUM_APOLICE}'
											AND NRENDOS = 0
											AND NUM_ITEM = '{this.V0SEGU_ITEM}'
											AND OCORHIST = '{this.V0SEGU_OCORHIST}'
											AND RAMOFR = 93
											AND MODALIFR = 0
											AND COD_COBERTURA = 11";

            return query;
        }
        public string V0COBA_IMPMORNATU { get; set; }
        public string V0COBA_PRMVG { get; set; }
        public string V0PROP_NUM_APOLICE { get; set; }
        public string V0SEGU_OCORHIST { get; set; }
        public string V0SEGU_ITEM { get; set; }

        public static R1300_00_CANCELA_FALTA_PG_DB_SELECT_6_Query1 Execute(R1300_00_CANCELA_FALTA_PG_DB_SELECT_6_Query1 r1300_00_CANCELA_FALTA_PG_DB_SELECT_6_Query1)
        {
            var ths = r1300_00_CANCELA_FALTA_PG_DB_SELECT_6_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1300_00_CANCELA_FALTA_PG_DB_SELECT_6_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1300_00_CANCELA_FALTA_PG_DB_SELECT_6_Query1();
            var i = 0;
            dta.V0COBA_IMPMORNATU = result[i++].Value?.ToString();
            dta.V0COBA_PRMVG = result[i++].Value?.ToString();
            return dta;
        }

    }
}