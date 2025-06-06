using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0009B
{
    public class R6550_00_SELECT_TARIFA_BALCAO_DB_SELECT_1_Query1 : QueryBasis<R6550_00_SELECT_TARIFA_BALCAO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COUNT(*)
            INTO :V0ERRO-COUNT:VIND-COUNT
            FROM SEGUROS.TARIFA_BALCAO_CEF
            WHERE COD_EMPRESA = :V0TRBL-CODEMP
            AND NUM_MATRICULA = :V0TRBL-MATRICULA
            AND TIPO_FUNCIONARIO = :V0TRBL-TIPOFUNC
            AND NUM_CERTIFICADO = :V0TRBL-NRCERTIF
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COUNT(*)
											FROM SEGUROS.TARIFA_BALCAO_CEF
											WHERE COD_EMPRESA = '{this.V0TRBL_CODEMP}'
											AND NUM_MATRICULA = '{this.V0TRBL_MATRICULA}'
											AND TIPO_FUNCIONARIO = '{this.V0TRBL_TIPOFUNC}'
											AND NUM_CERTIFICADO = '{this.V0TRBL_NRCERTIF}'";

            return query;
        }
        public string V0ERRO_COUNT { get; set; }
        public string VIND_COUNT { get; set; }
        public string V0TRBL_MATRICULA { get; set; }
        public string V0TRBL_TIPOFUNC { get; set; }
        public string V0TRBL_NRCERTIF { get; set; }
        public string V0TRBL_CODEMP { get; set; }

        public static R6550_00_SELECT_TARIFA_BALCAO_DB_SELECT_1_Query1 Execute(R6550_00_SELECT_TARIFA_BALCAO_DB_SELECT_1_Query1 r6550_00_SELECT_TARIFA_BALCAO_DB_SELECT_1_Query1)
        {
            var ths = r6550_00_SELECT_TARIFA_BALCAO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R6550_00_SELECT_TARIFA_BALCAO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R6550_00_SELECT_TARIFA_BALCAO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0ERRO_COUNT = result[i++].Value?.ToString();
            dta.VIND_COUNT = string.IsNullOrWhiteSpace(dta.V0ERRO_COUNT) ? "-1" : "0";
            return dta;
        }

    }
}