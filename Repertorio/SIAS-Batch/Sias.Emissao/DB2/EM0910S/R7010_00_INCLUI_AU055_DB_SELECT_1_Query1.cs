using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0910S
{
    public class R7010_00_INCLUI_AU055_DB_SELECT_1_Query1 : QueryBasis<R7010_00_INCLUI_AU055_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE ( MAX ( SEQ_HISTORICO ) , 0 )
            INTO :AU055-SEQ-HISTORICO
            FROM SEGUROS.AU_HIS_PROP_CONV
            WHERE NUM_PROPOSTA_VC = :AU055-NUM-PROPOSTA-VC
            AND COD_CONGENERE = :AU055-COD-CONGENERE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE ( MAX ( SEQ_HISTORICO ) 
							, 0 )
											FROM SEGUROS.AU_HIS_PROP_CONV
											WHERE NUM_PROPOSTA_VC = '{this.AU055_NUM_PROPOSTA_VC}'
											AND COD_CONGENERE = '{this.AU055_COD_CONGENERE}'";

            return query;
        }
        public string AU055_SEQ_HISTORICO { get; set; }
        public string AU055_NUM_PROPOSTA_VC { get; set; }
        public string AU055_COD_CONGENERE { get; set; }

        public static R7010_00_INCLUI_AU055_DB_SELECT_1_Query1 Execute(R7010_00_INCLUI_AU055_DB_SELECT_1_Query1 r7010_00_INCLUI_AU055_DB_SELECT_1_Query1)
        {
            var ths = r7010_00_INCLUI_AU055_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R7010_00_INCLUI_AU055_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R7010_00_INCLUI_AU055_DB_SELECT_1_Query1();
            var i = 0;
            dta.AU055_SEQ_HISTORICO = result[i++].Value?.ToString();
            return dta;
        }

    }
}