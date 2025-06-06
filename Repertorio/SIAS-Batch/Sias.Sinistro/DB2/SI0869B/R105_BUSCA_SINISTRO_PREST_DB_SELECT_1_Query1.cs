using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0869B
{
    public class R105_BUSCA_SINISTRO_PREST_DB_SELECT_1_Query1 : QueryBasis<R105_BUSCA_SINISTRO_PREST_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_SINI_PREST
            INTO :SIMOLOT1-NUM-SINI-PREST
            FROM SEGUROS.SI_MOV_LOTERICO1
            WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_SINI_PREST
											FROM SEGUROS.SI_MOV_LOTERICO1
											WHERE NUM_APOL_SINISTRO = '{this.SINISHIS_NUM_APOL_SINISTRO}'";

            return query;
        }
        public string SIMOLOT1_NUM_SINI_PREST { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }

        public static R105_BUSCA_SINISTRO_PREST_DB_SELECT_1_Query1 Execute(R105_BUSCA_SINISTRO_PREST_DB_SELECT_1_Query1 r105_BUSCA_SINISTRO_PREST_DB_SELECT_1_Query1)
        {
            var ths = r105_BUSCA_SINISTRO_PREST_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R105_BUSCA_SINISTRO_PREST_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R105_BUSCA_SINISTRO_PREST_DB_SELECT_1_Query1();
            var i = 0;
            dta.SIMOLOT1_NUM_SINI_PREST = result[i++].Value?.ToString();
            return dta;
        }

    }
}