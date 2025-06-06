using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA2646B
{
    public class R1912_00_SELECT_CONVERS_SICOB_DB_SELECT_1_Query1 : QueryBasis<R1912_00_SELECT_CONVERS_SICOB_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            NUM_PROPOSTA_SIVPF
            INTO
            :CONVERSI-NUM-PROPOSTA-SIVPF
            FROM SEGUROS.CONVERSAO_SICOB
            WHERE NUM_SICOB =
            :PROPOVA-NUM-APOLICE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											NUM_PROPOSTA_SIVPF
											FROM SEGUROS.CONVERSAO_SICOB
											WHERE NUM_SICOB =
											'{this.PROPOVA_NUM_APOLICE}'";

            return query;
        }
        public string CONVERSI_NUM_PROPOSTA_SIVPF { get; set; }
        public string PROPOVA_NUM_APOLICE { get; set; }

        public static R1912_00_SELECT_CONVERS_SICOB_DB_SELECT_1_Query1 Execute(R1912_00_SELECT_CONVERS_SICOB_DB_SELECT_1_Query1 r1912_00_SELECT_CONVERS_SICOB_DB_SELECT_1_Query1)
        {
            var ths = r1912_00_SELECT_CONVERS_SICOB_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1912_00_SELECT_CONVERS_SICOB_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1912_00_SELECT_CONVERS_SICOB_DB_SELECT_1_Query1();
            var i = 0;
            dta.CONVERSI_NUM_PROPOSTA_SIVPF = result[i++].Value?.ToString();
            return dta;
        }

    }
}