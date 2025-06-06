using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE2640B
{
    public class R0000_2600_IDENTIFICA_APOLICE_DB_SELECT_1_Query1 : QueryBasis<R0000_2600_IDENTIFICA_APOLICE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.NUM_APOLICE
            INTO :H-VGPROSIA-NUM-APOLICE-P
            FROM SEGUROS.VG_PRODUTO_SIAS A
            WHERE A.COD_PRODUTO_EMP = 16
            AND A.COD_PRODUTO = :H-COD-PRODUTO
            FETCH FIRST 1 ROW ONLY
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT A.NUM_APOLICE
											FROM SEGUROS.VG_PRODUTO_SIAS A
											WHERE A.COD_PRODUTO_EMP = 16
											AND A.COD_PRODUTO = '{this.H_COD_PRODUTO}'
											FETCH FIRST 1 ROW ONLY
											WITH UR";

            return query;
        }
        public string H_VGPROSIA_NUM_APOLICE_P { get; set; }
        public string H_COD_PRODUTO { get; set; }

        public static R0000_2600_IDENTIFICA_APOLICE_DB_SELECT_1_Query1 Execute(R0000_2600_IDENTIFICA_APOLICE_DB_SELECT_1_Query1 r0000_2600_IDENTIFICA_APOLICE_DB_SELECT_1_Query1)
        {
            var ths = r0000_2600_IDENTIFICA_APOLICE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0000_2600_IDENTIFICA_APOLICE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0000_2600_IDENTIFICA_APOLICE_DB_SELECT_1_Query1();
            var i = 0;
            dta.H_VGPROSIA_NUM_APOLICE_P = result[i++].Value?.ToString();
            return dta;
        }

    }
}