using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Auto.DB2.AU2055B
{
    public class R5040_00_INSERT_AU055_DB_SELECT_1_Query1 : QueryBasis<R5040_00_INSERT_AU055_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(SEQ_HISTORICO),0)
            INTO :AU055-SEQ-HISTORICO
            FROM SEGUROS.AU_HIS_PROP_CONV
            WHERE NUM_PROPOSTA_VC = :WHOST-PROPOSTA-VC
            AND COD_CONGENERE = :WHOST-CONGENERE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(SEQ_HISTORICO)
							,0)
											FROM SEGUROS.AU_HIS_PROP_CONV
											WHERE NUM_PROPOSTA_VC = '{this.WHOST_PROPOSTA_VC}'
											AND COD_CONGENERE = '{this.WHOST_CONGENERE}'";

            return query;
        }
        public string AU055_SEQ_HISTORICO { get; set; }
        public string WHOST_PROPOSTA_VC { get; set; }
        public string WHOST_CONGENERE { get; set; }

        public static R5040_00_INSERT_AU055_DB_SELECT_1_Query1 Execute(R5040_00_INSERT_AU055_DB_SELECT_1_Query1 r5040_00_INSERT_AU055_DB_SELECT_1_Query1)
        {
            var ths = r5040_00_INSERT_AU055_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R5040_00_INSERT_AU055_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R5040_00_INSERT_AU055_DB_SELECT_1_Query1();
            var i = 0;
            dta.AU055_SEQ_HISTORICO = result[i++].Value?.ToString();
            return dta;
        }

    }
}