using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0006B
{
    public class R1200_00_SELECT_PARCELAS_DB_SELECT_1_Query1 : QueryBasis<R1200_00_SELECT_PARCELAS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            VALUE(SUM(PRM_TARIFARIO_IX),+0),
            VALUE(SUM(VAL_DESCONTO_IX),+0),
            VALUE(SUM(ADICIONAL_FRAC_IX),+0)
            INTO :PARCELAS-PRM-TARIFARIO-IX,
            :PARCELAS-VAL-DESCONTO-IX ,
            :PARCELAS-ADICIONAL-FRAC-IX
            FROM SEGUROS.PARCELAS
            WHERE NUM_APOLICE = :PARCEHIS-NUM-APOLICE
            AND NUM_ENDOSSO = :PARCEHIS-NUM-ENDOSSO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											VALUE(SUM(PRM_TARIFARIO_IX)
							,+0)
							,
											VALUE(SUM(VAL_DESCONTO_IX)
							,+0)
							,
											VALUE(SUM(ADICIONAL_FRAC_IX)
							,+0)
											FROM SEGUROS.PARCELAS
											WHERE NUM_APOLICE = '{this.PARCEHIS_NUM_APOLICE}'
											AND NUM_ENDOSSO = '{this.PARCEHIS_NUM_ENDOSSO}'";

            return query;
        }
        public string PARCELAS_PRM_TARIFARIO_IX { get; set; }
        public string PARCELAS_VAL_DESCONTO_IX { get; set; }
        public string PARCELAS_ADICIONAL_FRAC_IX { get; set; }
        public string PARCEHIS_NUM_APOLICE { get; set; }
        public string PARCEHIS_NUM_ENDOSSO { get; set; }

        public static R1200_00_SELECT_PARCELAS_DB_SELECT_1_Query1 Execute(R1200_00_SELECT_PARCELAS_DB_SELECT_1_Query1 r1200_00_SELECT_PARCELAS_DB_SELECT_1_Query1)
        {
            var ths = r1200_00_SELECT_PARCELAS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1200_00_SELECT_PARCELAS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1200_00_SELECT_PARCELAS_DB_SELECT_1_Query1();
            var i = 0;
            dta.PARCELAS_PRM_TARIFARIO_IX = result[i++].Value?.ToString();
            dta.PARCELAS_VAL_DESCONTO_IX = result[i++].Value?.ToString();
            dta.PARCELAS_ADICIONAL_FRAC_IX = result[i++].Value?.ToString();
            return dta;
        }

    }
}