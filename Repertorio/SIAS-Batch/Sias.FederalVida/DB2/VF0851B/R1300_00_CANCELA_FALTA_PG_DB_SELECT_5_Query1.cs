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
    public class R1300_00_CANCELA_FALTA_PG_DB_SELECT_5_Query1 : QueryBasis<R1300_00_CANCELA_FALTA_PG_DB_SELECT_5_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT TIPO_INCLUSAO,
            COD_AGENCIADOR,
            NUM_ITEM,
            OCORR_HISTORICO
            INTO :V0SEGU-TPINCLUS,
            :V0SEGU-AGENCIADOR,
            :V0SEGU-ITEM,
            :V0SEGU-OCORHIST
            FROM SEGUROS.V0SEGURAVG
            WHERE NUM_CERTIFICADO = :V0PROP-NRCERTIF
            AND TIPO_SEGURADO = '1'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT TIPO_INCLUSAO
							,
											COD_AGENCIADOR
							,
											NUM_ITEM
							,
											OCORR_HISTORICO
											FROM SEGUROS.V0SEGURAVG
											WHERE NUM_CERTIFICADO = '{this.V0PROP_NRCERTIF}'
											AND TIPO_SEGURADO = '1'";

            return query;
        }
        public string V0SEGU_TPINCLUS { get; set; }
        public string V0SEGU_AGENCIADOR { get; set; }
        public string V0SEGU_ITEM { get; set; }
        public string V0SEGU_OCORHIST { get; set; }
        public string V0PROP_NRCERTIF { get; set; }

        public static R1300_00_CANCELA_FALTA_PG_DB_SELECT_5_Query1 Execute(R1300_00_CANCELA_FALTA_PG_DB_SELECT_5_Query1 r1300_00_CANCELA_FALTA_PG_DB_SELECT_5_Query1)
        {
            var ths = r1300_00_CANCELA_FALTA_PG_DB_SELECT_5_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1300_00_CANCELA_FALTA_PG_DB_SELECT_5_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1300_00_CANCELA_FALTA_PG_DB_SELECT_5_Query1();
            var i = 0;
            dta.V0SEGU_TPINCLUS = result[i++].Value?.ToString();
            dta.V0SEGU_AGENCIADOR = result[i++].Value?.ToString();
            dta.V0SEGU_ITEM = result[i++].Value?.ToString();
            dta.V0SEGU_OCORHIST = result[i++].Value?.ToString();
            return dta;
        }

    }
}