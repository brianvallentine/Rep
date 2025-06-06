using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.RE0002S
{
    public class R2500_00_SELECT_PARCEHIS_DB_SELECT_1_Query1 : QueryBasis<R2500_00_SELECT_PARCEHIS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            VALUE(SUM(PRM_LIQUIDO),+0),
            VALUE(SUM(ADICIONAL_FRACIO),+0)
            INTO :PARCEHIS-PRM-LIQUIDO,
            :PARCEHIS-ADICIONAL-FRACIO
            FROM SEGUROS.PARCELA_HISTORICO
            WHERE NUM_APOLICE = :PARCEHIS-NUM-APOLICE
            AND NUM_ENDOSSO = :PARCEHIS-NUM-ENDOSSO
            AND OCORR_HISTORICO = 01
            AND COD_OPERACAO < 0200
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											VALUE(SUM(PRM_LIQUIDO)
							,+0)
							,
											VALUE(SUM(ADICIONAL_FRACIO)
							,+0)
											FROM SEGUROS.PARCELA_HISTORICO
											WHERE NUM_APOLICE = '{this.PARCEHIS_NUM_APOLICE}'
											AND NUM_ENDOSSO = '{this.PARCEHIS_NUM_ENDOSSO}'
											AND OCORR_HISTORICO = 01
											AND COD_OPERACAO < 0200
											WITH UR";

            return query;
        }
        public string PARCEHIS_PRM_LIQUIDO { get; set; }
        public string PARCEHIS_ADICIONAL_FRACIO { get; set; }
        public string PARCEHIS_NUM_APOLICE { get; set; }
        public string PARCEHIS_NUM_ENDOSSO { get; set; }

        public static R2500_00_SELECT_PARCEHIS_DB_SELECT_1_Query1 Execute(R2500_00_SELECT_PARCEHIS_DB_SELECT_1_Query1 r2500_00_SELECT_PARCEHIS_DB_SELECT_1_Query1)
        {
            var ths = r2500_00_SELECT_PARCEHIS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2500_00_SELECT_PARCEHIS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2500_00_SELECT_PARCEHIS_DB_SELECT_1_Query1();
            var i = 0;
            dta.PARCEHIS_PRM_LIQUIDO = result[i++].Value?.ToString();
            dta.PARCEHIS_ADICIONAL_FRACIO = result[i++].Value?.ToString();
            return dta;
        }

    }
}