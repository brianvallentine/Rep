using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI8005B
{
    public class R0500_00_TRATA_APOLICE_DB_SELECT_1_Query1 : QueryBasis<R0500_00_TRATA_APOLICE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SEQ_APOLICE
            INTO :V1NAES-SEQ-APOL
            FROM SEGUROS.V1NUMERO_AES
            WHERE COD_ORGAO = :V0APOL-ORGAO
            AND COD_RAMO = :V0BILH-RAMO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SEQ_APOLICE
											FROM SEGUROS.V1NUMERO_AES
											WHERE COD_ORGAO = '{this.V0APOL_ORGAO}'
											AND COD_RAMO = '{this.V0BILH_RAMO}'";

            return query;
        }
        public string V1NAES_SEQ_APOL { get; set; }
        public string V0APOL_ORGAO { get; set; }
        public string V0BILH_RAMO { get; set; }

        public static R0500_00_TRATA_APOLICE_DB_SELECT_1_Query1 Execute(R0500_00_TRATA_APOLICE_DB_SELECT_1_Query1 r0500_00_TRATA_APOLICE_DB_SELECT_1_Query1)
        {
            var ths = r0500_00_TRATA_APOLICE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0500_00_TRATA_APOLICE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0500_00_TRATA_APOLICE_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1NAES_SEQ_APOL = result[i++].Value?.ToString();
            return dta;
        }

    }
}