using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA1139B
{
    public class R1220_00_LE_PREMIO_DIT_DB_SELECT_1_Query1 : QueryBasis<R1220_00_LE_PREMIO_DIT_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PRMAP
            INTO :V0PLAN-PRMDIT
            FROM SEGUROS.PLANOS_VA_VGAP
            WHERE NUM_APOLICE = :HOST-NUM-APOLICE
            AND CODSUBES = :HOST-CODSUBES
            AND IDADE_INICIAL <= :V0PROP-IDADE
            AND IDADE_FINAL >= :V0PROP-IDADE
            AND OPCAO_COBER = :V0PROP-OPCAO-COBER
            AND DTINIVIG <= :V0ENDO-DTTERVIG
            AND DTTERVIG >= :V0ENDO-DTTERVIG
            AND IMPDIT = :V0CBPR-IMPDIT
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT PRMAP
											FROM SEGUROS.PLANOS_VA_VGAP
											WHERE NUM_APOLICE = '{this.HOST_NUM_APOLICE}'
											AND CODSUBES = '{this.HOST_CODSUBES}'
											AND IDADE_INICIAL <= '{this.V0PROP_IDADE}'
											AND IDADE_FINAL >= '{this.V0PROP_IDADE}'
											AND OPCAO_COBER = '{this.V0PROP_OPCAO_COBER}'
											AND DTINIVIG <= '{this.V0ENDO_DTTERVIG}'
											AND DTTERVIG >= '{this.V0ENDO_DTTERVIG}'
											AND IMPDIT = '{this.V0CBPR_IMPDIT}'";

            return query;
        }
        public string V0PLAN_PRMDIT { get; set; }
        public string V0PROP_OPCAO_COBER { get; set; }
        public string HOST_NUM_APOLICE { get; set; }
        public string V0ENDO_DTTERVIG { get; set; }
        public string HOST_CODSUBES { get; set; }
        public string V0CBPR_IMPDIT { get; set; }
        public string V0PROP_IDADE { get; set; }

        public static R1220_00_LE_PREMIO_DIT_DB_SELECT_1_Query1 Execute(R1220_00_LE_PREMIO_DIT_DB_SELECT_1_Query1 r1220_00_LE_PREMIO_DIT_DB_SELECT_1_Query1)
        {
            var ths = r1220_00_LE_PREMIO_DIT_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1220_00_LE_PREMIO_DIT_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1220_00_LE_PREMIO_DIT_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0PLAN_PRMDIT = result[i++].Value?.ToString();
            return dta;
        }

    }
}