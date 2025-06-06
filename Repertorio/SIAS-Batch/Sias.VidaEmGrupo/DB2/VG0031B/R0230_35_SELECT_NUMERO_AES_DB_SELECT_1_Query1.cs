using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0031B
{
    public class R0230_35_SELECT_NUMERO_AES_DB_SELECT_1_Query1 : QueryBasis<R0230_35_SELECT_NUMERO_AES_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            NRENDOCA
            INTO :V0NAES-NRENDOCA
            FROM SEGUROS.V0NUMERO_AES
            WHERE COD_ORGAO = :V1ENDO-ORGAO
            AND COD_RAMO = :V1ENDO-RAMO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											NRENDOCA
											FROM SEGUROS.V0NUMERO_AES
											WHERE COD_ORGAO = '{this.V1ENDO_ORGAO}'
											AND COD_RAMO = '{this.V1ENDO_RAMO}'";

            return query;
        }
        public string V0NAES_NRENDOCA { get; set; }
        public string V1ENDO_ORGAO { get; set; }
        public string V1ENDO_RAMO { get; set; }

        public static R0230_35_SELECT_NUMERO_AES_DB_SELECT_1_Query1 Execute(R0230_35_SELECT_NUMERO_AES_DB_SELECT_1_Query1 r0230_35_SELECT_NUMERO_AES_DB_SELECT_1_Query1)
        {
            var ths = r0230_35_SELECT_NUMERO_AES_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0230_35_SELECT_NUMERO_AES_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0230_35_SELECT_NUMERO_AES_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0NAES_NRENDOCA = result[i++].Value?.ToString();
            return dta;
        }

    }
}